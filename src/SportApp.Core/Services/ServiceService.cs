using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IAppDbContext _dbContext;

        public ServiceService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="service"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task CreateAsync(Service service, CancellationToken token)
        {
            await _dbContext.Services.AddAsync(service, token);
            await _dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Service? GetAsync(string userId, long serviceId)
        {
            return _dbContext.Services.Where(el => el.UserId == userId && el.Id == serviceId).FirstOrDefault();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Service> GetAllAsync(string userId)
        {
            return (_dbContext.Services.Where(el => el.UserId == userId)).AsEnumerable();
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
        /// <param name="service"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Service service, CancellationToken token)
        {
            _dbContext.Services.Update(service);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}