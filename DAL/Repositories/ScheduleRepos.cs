using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
   public class ScheduleRepos : IRepository<Schedule>
   {
        private HealthyContext db;

        public ScheduleRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Schedule> GetList()
        {
            return db.Schedules.Include(i=>i.DayofWeekNavigation).Include(i => i.Shift).ToList();
        }

        public Schedule GetItem(int id)
        {
            return db.Schedules.Include(i => i.DayofWeekNavigation).Include(i => i.Shift).Where(i=>i.Id==id).First();
        }

        public void Create(Schedule item)
        {
            db.Schedules.Add(item);
        }

        public void Update(Schedule item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Schedule item = db.Schedules.Find(id);
            if (item != null)
                db.Schedules.Remove(item);
            
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
