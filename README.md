error MSB4057: The target "pipelinePreDeployCopyAllFilesToOneFolder" does not exist in the project.



In every class library .csproj file add the following import:
--solo tube que agregar esto en cada .csproj--
<Import Project="$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\v17.0\WebApplications\Microsoft.WebApplication.targets" Condition="Exists('$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\v17.0\WebApplications\Microsoft.WebApplication.targets')" />
