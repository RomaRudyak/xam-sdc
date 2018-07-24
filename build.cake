#tool nuget:?package=MSBuild.SonarQube.Runner.Tool
#addin nuget:?package=Cake.Sonar
#addin nuget:?package=Cake.Git

var target = Argument("target", "Default");
var login = Argument<String>("login", null);

Task("Default");

var settings = new SonarBeginSettings{
  Url = "https://sonarcloud.io/",
  Login = login,
  Verbose = true,
  Organization="romarudyak-github",
  Key="SDC-Coach",
  Branch=GitBranchCurrent(".").FriendlyName
};

Task("SonarBegin")
  .Does(() => {
     SonarBegin(settings);
  });

Task("SonarEnd")
  .Does(() => {
     SonarEnd(settings.GetEndSettings());
  });

  RunTarget(target);