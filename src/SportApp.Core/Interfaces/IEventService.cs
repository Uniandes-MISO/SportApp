using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface IEventService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        IEnumerable<Event> GetAsync(string userId, string date, string site);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Event> GetAllAsync(string userId);
    }
}