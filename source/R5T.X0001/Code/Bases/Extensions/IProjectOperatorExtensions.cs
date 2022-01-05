using System;
using System.Threading.Tasks;

using R5T.D0078;
using R5T.D0079;
using R5T.T0113;
using R5T.T0114;

using Instances = R5T.X0001.Instances;


namespace System
{
    public static class IProjectOperatorExtensions
    {
        public static async Task CreateProjectForExistingSolution(this IProjectOperator _,
            string solutionFilePath,
            IProjectSpecification projectSpecification,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            var repositoryDirectoryPath = Instances.RepositoryPathOperator.GetRepositoryDirectoryPathFromSolutionFilePathInSourceDirectory(
                solutionFilePath);

            await Instances.RepositoryOperator.InRepositoryContext(
                repositoryDirectoryPath,
                async localRepositoryContext =>
                {
                    await Instances.SolutionOperator.InSolutionContext(
                        solutionFilePath,
                        async solutionFileContext =>
                        {
                            var projectFileContext = Instances.ProjectOperator.GetProjectFileSpecification(
                                projectSpecification.Name,
                                projectSpecification.Description,
                                solutionFileContext.DirectoryPath);

                            await Instances.ProjectGenerator.CreateProject(
                                projectFileContext.FilePath,
                                projectSpecification.Type,
                                solutionFileContext,
                                visualStudioProjectFileOperator,
                                visualStudioSolutionFileOperator);
                        });
                });
        }
    }
}
