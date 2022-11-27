using Microsoft.EntityFrameworkCore;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class EatingRoutineService : IEatingRoutineService
    {
        private readonly IAppDbContext _dbContext;

        public EatingRoutineService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<EatingRoutineUserDto> GetByUser(string userId, int type)
        {
            //var eating = _dbContext.EatingRoutine.ToList();
            //var ids = eating.Select(x => x.Id).ToList();

            var business = _dbContext.EatingRoutineBusiness.Include(a => a.Service).Include(el => el.EatingRoutine).ToList();
            var result = new List<EatingRoutineUserDto>();

            foreach (var item in business)
            {
                var eating = result.FirstOrDefault(x => x.Id == item.EatingRoutineId);

                if (eating == null)
                {
                    eating = new EatingRoutineUserDto()
                    {
                        Id = item.EatingRoutine.Id,
                        Name = item.EatingRoutine.Name,
                        Description = item.EatingRoutine.Description,
                        Image = item.EatingRoutine.Image
                    };

                    result.Add(eating);
                }

                if ((type == 1 && item.Service.SportType == SportType.Cycling) || (type == 2 && item.Service.SportType == SportType.Athletics) || type == 3)
                {
                    ServiceDto service = new()
                    {
                        Id = item.Service.Id,
                        Name = item.Service.Name,
                        Type = item.Service.Type.ToString(),
                        Phone = item.Service.Phone,
                        Email = item.Service.Email,
                        Website = item.Service.Website,
                        Description = item.Service.Description,
                        SportType = item.Service.SportType.ToString(),
                        UserId = item.Service.UserId
                    };

                    eating.Services ??= new();
                    eating.Services.Add(service);
                }
            }

            return result;
        }
    }
}