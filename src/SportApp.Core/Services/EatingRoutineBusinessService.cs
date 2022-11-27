using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class EatingRoutineBusinessService : IEatingRoutineBusinessService
    {
        private readonly IAppDbContext _dbContext;
        //     private readonly IEatingRoutineBusinessService _eatingRoutineBusiness;

        public EatingRoutineBusinessService(IAppDbContext dbContext/*, IEatingRoutineBusinessService eatingRoutineBusiness*/)
        {
            _dbContext = dbContext;
            // _eatingRoutineBusiness = eatingRoutineBusiness;
        }
    }
}