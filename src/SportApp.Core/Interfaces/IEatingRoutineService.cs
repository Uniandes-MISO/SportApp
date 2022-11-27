using SportApp.Core.Dtos;

namespace SportApp.Core.Interfaces
{
    public interface IEatingRoutineService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<EatingRoutineUserDto> GetByUser(string userId, int type);
    }
}