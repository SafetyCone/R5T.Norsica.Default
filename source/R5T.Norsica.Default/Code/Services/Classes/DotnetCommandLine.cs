using System;

using R5T.Heraklion;
using R5T.Volos;

using R5T.Norsica.Commands;


namespace R5T.Norsica.Default
{
    public static class DotnetCommandLine
    {
        public static ICommandBuilderContext<DotnetContext> New()
        {
            var dotnetContext = CommandLine.New<DotnetContext>();
            return dotnetContext;
        }
    }
}
