using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class SportActivityService : ISportActivityService
    {
        private readonly IAppDbContext _dbContext;

        public SportActivityService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task CreateAsync(SportActivity activity, CancellationToken token)
        {
            await _dbContext.Activities.AddAsync(activity, token);
            await _dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<SportActivity> GetAsync(string userId, long activityId)
        {
            return _dbContext.Activities.Where(x => x.UserId == userId && x.Id == activityId).AsEnumerable();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SportActivity> GetAllAsync(string userId)
        {
            return (_dbContext.Activities.Where(el => el.UserId == userId)).AsEnumerable();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public int ExistActivitiesDay(string userId, DateTime date)
        {
            var result = (_dbContext.Activities.Where(el => el.UserId == userId && el.End.HasValue)).AsEnumerable();

            if (result == null || !result.Any())
            {
                return 0;
            }

            var filter = result.Where(el => el.End.Value.Year == date.Year && el.End.Value.Month == date.Month && el.End.Value.Day == date.Day);

            var Cycling = filter.Any(el => el.Type == SportType.Cycling);
            var Athletics = filter.Any(el => el.Type == SportType.Athletics);

            if (Cycling && Athletics)
            {
                return 3;
            }

            if (Cycling)
            {
                return 1;
            }
            if (Athletics)
            {
                return 3;
            }

            return 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task DeleteAsync(long id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task UpdateAsync(SportActivity activity, CancellationToken token)
        {
            activity.LastUpdate = DateTime.Now;
            _dbContext.Activities.Update(activity);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}