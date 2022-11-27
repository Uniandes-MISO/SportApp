using Microsoft.EntityFrameworkCore;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class UserTrainingService : IUserTrainingService
    {
        private readonly IAppDbContext _dbContext;

        public UserTrainingService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task CreateAsync(UserTraining userTraining, CancellationToken token)
        {
            var any = _dbContext.UserTraining.Any(x => x.UserId == userTraining.UserId && x.TrainingId == userTraining.TrainingId);
            if (!any)
            {
                await _dbContext.UserTraining.AddAsync(userTraining, token);
                await _dbContext.SaveChangesAsync(token);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<UserTraining> GetAsync(string userId)
        {
            return (_dbContext.UserTraining.Where(x => x.UserId == userId).Include(a => a.Training).ThenInclude(a => a.Activities)).AsEnumerable();
        }
    }
}