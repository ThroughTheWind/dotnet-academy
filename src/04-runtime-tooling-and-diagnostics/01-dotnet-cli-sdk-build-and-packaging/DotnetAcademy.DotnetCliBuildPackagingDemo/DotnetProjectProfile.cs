namespace DotnetAcademy.DotnetCliBuildPackagingDemo;

public sealed record DotnetProjectProfile(
    string SdkName,
    string AssemblyName,
    string TargetFramework,
    string OutputType,
    string PackageId,
    string Version,
    bool IsPackable);