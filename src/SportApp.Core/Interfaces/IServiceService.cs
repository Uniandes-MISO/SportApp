using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface IServiceService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="service"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task CreateAsync(Service service, CancellationToken token);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Service? GetAsync(string userId, long serviceId);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerable<Service> GetAllAsync(string userId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task DeleteAsync(long id, CancellationToken token);

        /// <summary>
        ///
        /// </summary>
        /// <param name="service"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task UpdateAsync(Service service, CancellationToken token);
    }
}