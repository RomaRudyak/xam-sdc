#tool nuget:?package=MSBuild.SonarQube.Runner.Tool
#addin nuget:?package=Cake.Sonar

var target = Argument("target", "Default");
var login = Argument<String>("login", null);

Task("Default");

Task("SonarBegin")
  .Does(() => {
     SonarBegin(new SonarBeginSettings{
        Url = "https://sonarcloud.io/",
        Login = login,
        Verbose = true,
        Organization="romarudyak-github",
        Key="SDC-Coach"
     });
  });

Task("SonarEnd")
  .Does(() => {
     SonarEnd(new SonarEndSettings{
        Login = login
     });
  });

  RunTarget(target);