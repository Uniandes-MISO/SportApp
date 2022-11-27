using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface ISportActivityService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task CreateAsync(SportActivity activity, CancellationToken token);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<SportActivity> GetAsync(string userId, long activityId);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerable<SportActivity> GetAllAsync(string userId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int ExistActivitiesDay(string userId, DateTime date);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task DeleteAsync(long id, CancellationToken token);

        /// <summary>
        ///
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task UpdateAsync(SportActivity activity, CancellationToken token);
    }
}