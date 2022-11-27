using Microsoft.EntityFrameworkCore;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IAppDbContext _dbContext;

        public TrainingService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Training> GetAllAsync()
        {
            return _dbContext.Training.AsEnumerable();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Training> GetAsync(string userId)
        {
            var usrTraining = _dbContext.UserTraining.Where(x => x.UserId == userId).Select(el => el.TrainingId).Distinct();
            return (_dbContext.Training.Where(x => !usrTraining.Contains(x.Id)).Include(a => a.Activities)).AsEnumerable();
        }
    }
}