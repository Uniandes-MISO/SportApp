using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface IUserTrainingService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task CreateAsync(UserTraining userTraining, CancellationToken token);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<UserTraining> GetAsync(string userId);
    }
}