using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ShiftRepos: IRepository<Shift>
    {
        private HealthyContext db;

        public ShiftRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Shift> GetList()
        {
            return db.Shifts.ToList();
        }

        public Shift GetItem(int id)
        {
            return db.Shifts.Find(id);
        }

        public void Create(Shift item)
        {
            db.Shifts.Add(item);
        }

        public void Update(Shift item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Shift item = db.Shifts.Find(id);
            if (item != null)
                db.Shifts.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
