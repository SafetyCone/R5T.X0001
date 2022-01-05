using System;
using System.Threading.Tasks;

using R5T.D0078;
using R5T.D0079;
using R5T.T0113;
using R5T.T0114;

using Instances = R5T.X0001.Instances;


namespace System
{
    public static class ISolutionOperatorExtensions
    {
        public static async Task CreateProjectForExistingSolution(this ISolutionOperator _,
            string solutionFilePath,
            IProjectSpecification projectSpecification,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            await Instances.ProjectOperator.CreateProjectForExistingSolution(
                solutionFilePath,
                projectSpecification,
                visualStudioProjectFileOperator,
                visualStudioSolutionFileOperator);
        }

        public static async Task CreateSolutionInExistingRepository(this ISolutionOperator _,
            string repositoryDirectoryPath,
            string solutionName,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            await Instances.RepositoryOperator.InRepositoryContext(
                repositoryDirectoryPath,
                async localRepositoryContext =>
                {
                    var solutionFileSpecification = Instances.SolutionOperator.GetSolutionFileSpecificationInRepositorySourceDirectory(
                        solutionName,
                        localRepositoryContext.DirectoryPath);

                    // Just create the solution with no modification.
                    await Instances.SolutionGenerator.CreateSolution(
                        solutionFileSpecification.FilePath,
                        visualStudioSolutionFileOperator);
                });
        }
    }
}
