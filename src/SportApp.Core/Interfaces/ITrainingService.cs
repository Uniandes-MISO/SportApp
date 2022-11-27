using SportApp.Core.Entities;

namespace SportApp.Core.Interfaces
{
    public interface ITrainingService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Training> GetAsync(string userId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Training> GetAllAsync();
    }
}