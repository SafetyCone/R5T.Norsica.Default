using System;

using R5T.Caledonia;
using R5T.Heraklion;

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

        private void Execute(string arguments)
        {
            var gitExecutableFilePath = this.DotnetExecutableFilePathProvider.GetDotnetExecutableFilePath();

            var invocation = CommandLineInvocation.New(gitExecutableFilePath, arguments);

            var result = this.CommandLineInvocationOperator.Run(invocation);

            if (result.ExitCode != 0)
            {
                throw new Exception($"Execution failed. Error:\n{result.GetErrorText()}\nOutput:\n{result.GetOutputText()}\nArguments:\n{arguments}");
            }
            else
            {
                Console.WriteLine(result.GetOutputText());
                Console.WriteLine(result.GetErrorText());
            }
        }

        public void CreateNewSolutionFile(string solutionDirectoryPath, string solutionName)
        {
            var command = DotnetCommandLine.New().New()
                .Sln()
                .SetOutputDirectoryPath(solutionDirectoryPath)
                .SetName(solutionName)
                .BuildCommand();

            this.Execute(command);
        }
    }
}
