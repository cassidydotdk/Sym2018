var gulp = require("gulp");
var msbuild = require("gulp-msbuild");
var debug = require("gulp-debug");
var foreach = require("gulp-foreach");
var runSequence = require("run-sequence");
var config = require("./gulp-config.js")();
var nugetRestore = require('gulp-nuget-restore');
var fs = require('fs');
var unicorn = require("./scripts/unicorn.js");

module.exports.config = config;

gulp.task("default", function (callback) {
  config.runCleanBuilds = true;
  return runSequence(
    "B01-Nuget-Restore",
    "B02-Publish-All-Projects",
    "B03-Sync-Unicorn",
	callback);
});

/*****************************
  Initial setup
*****************************/
gulp.task("I-Copy-Sitecore-Lib", function () {
  console.log("Copying Sitecore Libraries");

  fs.statSync(config.sitecoreLibraries);

  var files = config.sitecoreLibraries + "/**/*";

  return gulp.src(files).pipe(gulp.dest("./lib/Sitecore"));
});

gulp.task("B01-Nuget-Restore", function (callback) {
  var solution = "./" + config.solutionName + ".sln";
  return gulp.src(solution).pipe(nugetRestore());
});


gulp.task("B02-Publish-All-Projects", function (callback) {
  return runSequence(
    "Publish-Foundation-Projects",
    "Publish-Feature-Projects",
    "Publish-Project-Projects", callback);
});

gulp.task("B03-Sync-Unicorn", function (callback) {
  var options = {};
  options.siteHostName = config.hostName;
  options.authenticationConfigFile = config.websiteRoot + "/App_config/Include/Unicorn/z.UnicornDataStore.config";

  unicorn(function() { return callback() }, options);
});


/*****************************
  Publish
*****************************/
var publishProjects = function (location, dest) {
  dest = dest || config.websiteRoot;
  var targets = ["Build"];
  if (config.runCleanBuilds) {
    targets = ["Clean", "Build"]
  }
  console.log("publish to " + dest + " folder");
  return gulp.src([location])
    .pipe(foreach(function (stream, file) {
      return stream
        .pipe(debug({ title: "Building project:" }))
        .pipe(msbuild({
          targets: targets,
          configuration: config.buildConfiguration,
          logCommand: false,
          verbosity: "minimal",
          maxcpucount: 0,
          toolsVersion: 15.0,
          properties: {
            DeployOnBuild: "true",
            DeployDefaultTarget: "WebPublish",
            WebPublishMethod: "FileSystem",
            DeleteExistingFiles: "false",
            publishUrl: dest,
            _FindDependencies: "false"
          }
        }));
    }));
};

gulp.task("Publish-Foundation-Projects", function () {
  return publishProjects("./src/**/Foundation.*.csproj");
});

gulp.task("Publish-Feature-Projects", function () {
	return publishProjects("./src/**/Feature.*.csproj");
});

gulp.task("Publish-Project-Projects", function () {
	return publishProjects("./src/**/Project.*.csproj");
});
