using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class RouteService : IRouteService
    {
        private readonly IAppDbContext _dbContext;

        public RouteService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Route> GetAllAsync(string userId)
        {
            return (_dbContext.Routes).AsEnumerable();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public IEnumerable<Route> GetAsync(string userId, string site)
        {
            var result = _dbContext.Routes.Where(x => x.Site.Contains(site));
            return result.AsEnumerable();
        }
    }
}