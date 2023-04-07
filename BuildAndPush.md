# Build T4Toolbox (for Mono T4) and push

```shell
dotnet build T4Toolbox.sln --configuration Release
```

Push T4Toolbox (for Mono T4) packages to NuGet.org:

```shell
dotnet nuget push ./src/T4Toolbox/bin/Release/T4Toolbox.Mono.0.0.5.nupkg ./src/T4Toolbox.DirectiveProcessors/bin/Release/T4Toolbox.DirectiveProcessors.Mono.0.0.5.nupkg ./src/T4Toolbox.VSTextTemplating/bin/Release/T4Toolbox.Lites.VSTextTemplating.Mono.0.0.5.nupkg ./src/T4Toolbox.EnvDteLites/bin/Release/T4Toolbox.EnvDteLites.0.0.5.nupkg ./src/T4Toolbox.VisualStudio/bin/Release/T4Toolbox.Lites.VisualStudio.Mono.0.0.5.nupkg ./src/T4Toolbox.ForPreprocessedTemplates/bin/Release/T4Toolbox.ForPreprocessedTemplates.Mono.0.0.5.nupkg --source https://www.nuget.org/api/v2/package -k __API_KEY__ --skip-duplicate
```


