//using System;

//using R5T.Angleterria;


//namespace R5T.Norsica.Default
//{
//    public class DotnetCommandLineOperator : IDotnetCommandLineOperator
//    {
//        private IDotnetCommandLineOperatorCore Core { get; }


//        public DotnetCommandLineOperator(IDotnetCommandLineOperatorCore core)
//        {
//            this.Core = core;
//        }

//        public void Publish(string projectFilePath, string outputDirectoryPath, string buildConfigurationName, string frameworkName)
//        {
//            this.Core.Publish(projectFilePath, outputDirectoryPath, buildConfigurationName, frameworkName);
//        }

//        public void PublishApp(string projectFilePath, string outputDirectoryPath, string buildConfigurationName)
//        {
//            var frameworkName = NetCoreAppV2_2.FrameworkName;

//            this.Core.Publish(projectFilePath, outputDirectoryPath, buildConfigurationName, frameworkName);
//        }

//        public void PublishApp(string projectFilePath, string outputDirectoryPath)
//        {
//            string buildConfigurationName = ReleaseBuildConfiguration.BuildConfigurationName;

//            this.PublishApp(projectFilePath, outputDirectoryPath, buildConfigurationName);
//        }
//    }
//}
