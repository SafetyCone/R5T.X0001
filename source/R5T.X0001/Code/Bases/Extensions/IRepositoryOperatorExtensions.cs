using System;
using System.Threading.Tasks;

using R5T.D0078;
using R5T.T0103;

using Instances = R5T.X0001.Instances;


namespace System
{
    public static class IRepositoryOperatorExtensions
    {
        public static async Task CreateSolutionInExistingRepository(this IRepositoryOperator _,
            string repositoryDirectoryPath,
            string solutionName,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            await Instances.SolutionOperator.CreateSolutionInExistingRepository(
                repositoryDirectoryPath,
                solutionName,
                visualStudioSolutionFileOperator);
        }
    }
}
