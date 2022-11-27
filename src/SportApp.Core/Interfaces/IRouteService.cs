using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface IRouteService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        IEnumerable<Route> GetAsync(string userId, string site);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Route> GetAllAsync(string userId);
    }
}