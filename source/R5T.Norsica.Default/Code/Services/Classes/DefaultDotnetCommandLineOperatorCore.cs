//using System;

//using R5T.Caledonia;


//namespace R5T.Norsica.Default
//{
//    public class DefaultDotnetCommandLineOperatorCore : IDotnetCommandLineOperatorCore
//    {
//        private ICommandLineInvocationOperator CommandLineInvocationOperator { get; }


//        public DefaultDotnetCommandLineOperatorCore(ICommandLineInvocationOperator commandLineInvocationOperator)
//        {
//            this.CommandLineInvocationOperator = commandLineInvocationOperator;
//        }

//        public void Publish(string projectFilePath, string outputDirectoryPath, string buildConfigurationName, string frameworkName)
//        {
//            var command = "dotnet";

//            var arguments = $"publish \"{projectFilePath}\" --configuration {buildConfigurationName} --framework {frameworkName} --output \"{outputDirectoryPath}\"";

//            var result = this.CommandLineInvocationOperator.Run(CommandLineInvocation.New(command, arguments));

//            Console.Write(result.GetOutputText());
//        }
//    }
//}
