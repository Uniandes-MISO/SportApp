using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task CreateAsync(User user, CancellationToken token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAllAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task DeleteAsync(int id, CancellationToken token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task UpdateAsync(User user, CancellationToken token);
    }
}
