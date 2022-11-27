using SportApp.Core.Dtos;
using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface IVirtualSessionService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="virtualSession"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<VirtualSession> InsertOrUpdateAsync(VirtualSessionDto virtualSession, CancellationToken token);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sportId"></param>
        /// <returns></returns>
        IEnumerable<VirtualSession> GetAsync(string userId, SportType sportId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<VirtualSession> GetAllAsync(string userId);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerable<TrainerDto> GetCoachAsync(string type, DateOnly date);
    }
}