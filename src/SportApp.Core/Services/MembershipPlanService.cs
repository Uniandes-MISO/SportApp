using Microsoft.EntityFrameworkCore;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class MembershipPlanService : IMembershipPlanService
    {
        private readonly IAppDbContext _dbContext;

        public MembershipPlanService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task InsertOrUpdateAsync(MembershipPlan plan, CancellationToken token)
        {
            plan.Active = true;
            IEnumerable<MembershipPlan> plans = _dbContext.MembershipPlans.Where(x => x.UserId == plan.UserId).AsEnumerable();

            if (plans.Any())
            {
                foreach (var item in plans)
                {
                    if (item.Type == plan.Type)
                        item.Active = plan.Active;
                    else
                        item.Active = false;
                }
                _dbContext.MembershipPlans.UpdateRange(plans);
            }

            if (!plans.Any(el => el.Type == plan.Type))
            {
                await _dbContext.MembershipPlans.AddAsync(plan, token);
            }
            await _dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MembershipPlan> GetAsync(string userId)
        {
            return await _dbContext.MembershipPlans.FirstOrDefaultAsync(x => x.UserId == userId && x.Active == true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MembershipPlan> GetAllAsync()
        {
            return (_dbContext.MembershipPlans.Select(x => x)).AsEnumerable();
        }
    }
}