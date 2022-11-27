using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface IMembershipPlanService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task InsertOrUpdateAsync(MembershipPlan activity, CancellationToken token);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<MembershipPlan> GetAsync(string userId);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerable<MembershipPlan> GetAllAsync();
    }
}