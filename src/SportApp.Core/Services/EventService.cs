using SportApp.Core.Entities;
using SportApp.Core.Interfaces;
using System.Globalization;

namespace SportApp.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IAppDbContext _dbContext;

        public EventService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Event> GetAllAsync(string userId)
        {
            return (_dbContext.Events).AsEnumerable();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public IEnumerable<Event> GetAsync(string userId, string date, string site)
        {
            DateTime? dateF = null;
            if (!string.IsNullOrEmpty(date?.Trim()))
            {
                dateF = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }

            var result = _dbContext.Events.Where(x => /*x.UserId == userId &&*/ (x.Site.Contains(site) || x.Date.Date.Equals(dateF == null ? x.Date : dateF.Value.Date)));
            return result.AsEnumerable();
        }
    }
}