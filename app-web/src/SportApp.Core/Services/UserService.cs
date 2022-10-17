using Microsoft.EntityFrameworkCore;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext _dbContext;

        public UserService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task CreateAsync(User user, CancellationToken token)
        {
            await _dbContext.Users.AddAsync(user, token);
            await _dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllAsync()
        {
            return (_dbContext.Users.Select(x => x)).AsEnumerable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var user = _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id, token);
            _dbContext.Users.Remove(user.Result);
            await _dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task UpdateAsync(User user, CancellationToken token)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
