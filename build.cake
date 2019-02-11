#tool nuget:?package=Cake.Wyam
#addin nuget:?package=Cake.Wyam
#addin nuget:?package=Wyam
#tool nuget:?package=ReportGenerator
#tool nuget:?package=OpenCover
///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////
Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});
Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});
///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////
Task("Default")
.Does(() => {
   Information("Hello Cake!");
});
Task("clean")
   .Does(() =>
{
   CleanDirectories("./*/*/"+configuration);
}); 
Task("restore")
.IsDependentOn("clean")
   .Does(() =>
{
   NuGetRestore("./Calculator.sln");
});
Task("build")
.IsDependentOn("restore")
   .Does(() =>
{
   MSBuild("./Calculator.sln", new MSBuildSettings{Configuration=configuration});
});
Task("tests")
.IsDependentOn("build")
   .Does(() =>
{
   MSTest("./src/CalculatorTests/bin/"+configuration+"/*.UnitTests.dll");
});
Task("opencover")
.IsDependentOn("build")
   .Does(() =>
{
    var openCoverDir = $"./output/OpenCover";
    EnsureDirectoryExists(openCoverDir);
 
    var resultsFilePath = new FilePath($"{openCoverDir}/_results.xml");
    OpenCover(tool => {
                tool.MSTest("./src/CalculatorTests/bin/"+configuration+"/*.UnitTests.dll");
            },
            resultsFilePath,
            new OpenCoverSettings()
        );
    ReportGenerator(resultsFilePath, openCoverDir);
});
Task("doc")
.IsDependentOn("build")
   .Does(() =>
{
   Wyam(new WyamSettings{
Recipe="docs",
Preview=true
   });
});
RunTarget(target);
