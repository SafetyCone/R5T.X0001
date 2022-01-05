using System;

using R5T.T0029.Dotnet.T001;
using R5T.T0103;
using R5T.T0113;
using R5T.T0123;


namespace R5T.X0001
{
    public static class Instances
    {
        public static IProjectGenerator ProjectGenerator { get; } = T0113.ProjectGenerator.Instance;
        public static IProjectOperator ProjectOperator { get; } = T0113.ProjectOperator.Instance;
        public static IProjectType ProjectType { get; } = T0029.Dotnet.T001.ProjectType.Instance;
        public static IRepositoryOperator RepositoryOperator { get; } = T0103.RepositoryOperator.Instance;
        public static IRepositoryPathOperator RepositoryPathOperator { get; } = T0123.RepositoryPathOperator.Instance;
        public static ISolutionGenerator SolutionGenerator { get; } = T0113.SolutionGenerator.Instance;
        public static ISolutionOperator SolutionOperator { get; } = T0113.SolutionOperator.Instance;
    }
}
