using System;

using R5T.Caledonia;
using R5T.Heraklion;
using R5T.Heraklion.Default;

using R5T.Norsica.Commands;
using R5T.Norsica.Configuration;


namespace R5T.Norsica.Default
{
    public class DotnetOperator : IDotnetOperator
    {
        private ICommandLineInvocationOperator CommandLineInvocationOperator { get; }
        private IDotnetExecutableFilePathProvider DotnetExecutableFilePathProvider { get; }


        public DotnetOperator(ICommandLineInvocationOperator commandLineInvocationOperator, IDotnetExecutableFilePathProvider dotnetExecutableFilePathProvider)
        {
            this.CommandLineInvocationOperator = commandLineInvocationOperator;
            this.DotnetExecutableFilePathProvider = dotnetExecutableFilePathProvider;
        }

        private void Execute(ICommandBuilderContext command)
        {
            var dotnetExecutableFilePath = this.DotnetExecutableFilePathProvider.GetDotnetExecutableFilePath();

            this.CommandLineInvocationOperator.Execute(dotnetExecutableFilePath, command);
        }

        public void CreateNewSolutionFile(string solutionDirectoryPath, string solutionName)
        {
            var command = DotnetCommandLine.Start()
                .New()
                .Solution2019() // Use the 2019 solution.
                .SetOutputDirectoryPath(solutionDirectoryPath)
                .SetName(solutionName)
                ;

            this.Execute(command);
        }

        public void CreateNewProjectFile(string projectTemplateShortName, string projectDirectoryPath, string projectName)
        {
            var command = DotnetCommandLine.Start()
                .New()
                .CSharpProject(projectTemplateShortName)
                .SetProjectName(projectName)
                .SetOutputDirectory(projectDirectoryPath)
                ;

            this.Execute(command);
        }

        public void AddProjectFileToSolutionFile(string solutionFilePath, string projectFilePath)
        {
            var command = DotnetCommandLine.Start()
                .Sln(solutionFilePath)
                .Add(projectFilePath)
                ;

            this.Execute(command);
        }

        public void Publish(string projectFilePath, string outputDirectoryPath, string buildConfigurationName, string frameworkName)
        {
            var command = DotnetCommandLine.Start()
                .Publish(projectFilePath)
                .SetBuildConfigurationName(buildConfigurationName)
                .SetFramework(frameworkName)
                .SetOutputDirectoryPath(outputDirectoryPath)
                ;

            this.Execute(command);
        }
    }
}
