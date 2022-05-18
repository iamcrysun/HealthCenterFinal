using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ScheduleProcedureRepos : IRepository<ScheduleProcedure>
    {
        private HealthyContext db;

        public ScheduleProcedureRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<ScheduleProcedure> GetList()
        {
            return db.ScheduleProcedures.ToList();
        }

        public ScheduleProcedure GetItem(int id)
        {
            return db.ScheduleProcedures.Find(id);
        }

        public void Create(ScheduleProcedure item)
        {
            db.ScheduleProcedures.Add(item);
        }

        public void Update(ScheduleProcedure item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ScheduleProcedure item = db.ScheduleProcedures.Find(id);
            if (item != null)
                db.ScheduleProcedures.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
