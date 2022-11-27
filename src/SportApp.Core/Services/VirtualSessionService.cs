using Microsoft.EntityFrameworkCore;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Core.Services
{
    public class VirtualSessionService : IVirtualSessionService
    {
        private readonly IAppDbContext _dbContext;

        public VirtualSessionService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="virtualSession"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<VirtualSession> InsertOrUpdateAsync(VirtualSessionDto virtualSession, CancellationToken token)
        {
            var hourKey = Enum.Parse<Hour>(virtualSession.HourKey);
            var sportType = Enum.Parse<SportType>(virtualSession.SportType);

            var schedule = new UserSchedule();
            schedule.UserId = virtualSession.TrainerId;
            schedule.Date = new DateOnly(virtualSession.Date.Year, virtualSession.Date.Month, virtualSession.Date.Day);
            schedule.Type = hourKey;

            var rsSchedule = (await _dbContext.UserSchedule.AddAsync(schedule, token)).Entity;
            await _dbContext.SaveChangesAsync(token);

            var session = new VirtualSession();
            session.Date = virtualSession.Date;
            session.AthleteId = virtualSession.AthleteId;
            session.Type = sportType;
            session.CoachId = virtualSession.TrainerId;
            session.ScheduleId = rsSchedule.Id;

            var rsSession = (await _dbContext.VirtualSessions.AddAsync(session, token)).Entity;
            await _dbContext.SaveChangesAsync(token);

            return rsSession;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sportType"></param>
        /// <returns></returns>
        public IEnumerable<VirtualSession> GetAsync(string userId, SportType sportType)
        {
            var result = _dbContext.VirtualSessions.Where(x => x.AthleteId == userId && x.Type == sportType);
            return result.AsEnumerable();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<VirtualSession> GetAllAsync(string userId)
        {
            return (_dbContext.VirtualSessions.Where(x => x.AthleteId == userId).Include(a => a.Athlete)).AsEnumerable();
        }

        public IEnumerable<TrainerDto> GetCoachAsync(string type, DateOnly date)
        {
            var typeService = Enum.Parse<SportType>(type);
            var userIds = _dbContext.Services.Where(x => x.SportType == typeService).Select(x => x.UserId).ToList();
            var users = _dbContext.User.Where(x => userIds.Contains(x.Id)).ToList();
            var schudule = _dbContext.UserSchedule.Where(x => userIds.Contains(x.UserId) && x.Date == date).ToList();

            List<TrainerDto> result = new List<TrainerDto>();

            users.ForEach(x =>
            {
                var dto = new TrainerDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FullName = $"{x.FirstName} {x.LastName}"
                };
                dto.available

                = GetAvailable(schudule.Where(s => s.UserId == x.Id).ToList());
                result.Add(dto);
            });

            return result;
        }

        public List<object> GetAvailable(List<UserSchedule> schedules)
        {
            var result = new List<object>();

            if (!schedules.Any(x => x.Type == Hour.Seis))
            {
                result.Add(new { key = Hour.Seis.ToString(), value = "06:00 am - 07:00 am" });
            }

            if (!schedules.Any(x => x.Type == Hour.Siete))
            {
                result.Add(new { key = Hour.Siete.ToString(), value = "07.00 am - 08:00 am" });
            }

            if (!schedules.Any(x => x.Type == Hour.Ocho))
            {
                result.Add(new { key = Hour.Ocho.ToString(), value = "08:00 am - 09:00 am" });
            }

            if (!schedules.Any(x => x.Type == Hour.Nueve))
            {
                result.Add(new { key = Hour.Nueve.ToString(), value = "09:00 am - 10:00 am" });
            }

            if (!schedules.Any(x => x.Type == Hour.Dies))
            {
                result.Add(new { key = Hour.Dies.ToString(), value = "10:00 am - 11:00 am" });
            }

            if (!schedules.Any(x => x.Type == Hour.Once))
            {
                result.Add(new { key = Hour.Once.ToString(), value = "11:00 am - 12:00 am" });
            }

            if (!schedules.Any(x => x.Type == Hour.Doce))
            {
                result.Add(new { key = Hour.Doce.ToString(), value = "12:00 am - 01:00 pm" });
            }

            if (!schedules.Any(x => x.Type == Hour.Trece))
            {
                result.Add(new { key = Hour.Trece.ToString(), value = "01:00 pm - 02:00 pm" });
            }

            if (!schedules.Any(x => x.Type == Hour.Catorce))
            {
                result.Add(new { key = Hour.Catorce.ToString(), value = "02:00 pm - 03:00 pm" });
            }

            if (!schedules.Any(x => x.Type == Hour.Quince))
            {
                result.Add(new { key = Hour.Quince.ToString(), value = "03:00 pm - 04:00 pm" });
            }

            if (!schedules.Any(x => x.Type == Hour.Dieciseis))
            {
                result.Add(new { key = Hour.Dieciseis.ToString(), value = "04:00 pm - 05:00 pm" });
            }

            if (!schedules.Any(x => x.Type == Hour.Diecisiete))
            {
                result.Add(new { key = Hour.Diecisiete.ToString(), value = "05:00 pm - 06:00 pm" });
            }

            return result;
        }
    }
}