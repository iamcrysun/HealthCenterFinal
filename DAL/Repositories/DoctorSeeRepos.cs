using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class DoctorSeeRepos : IRepository<DoctorSee>
    {
        private HealthyContext db;

        public DoctorSeeRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<DoctorSee> GetList()
        {
            return db.DoctorSees.Include(i => i.Patient).ToList();
        }

        public DoctorSee GetItem(int id)
        {
            return db.DoctorSees.Include(i => i.Patient).Where(i => i.Id == id).First();
        }

        public void Create(DoctorSee item)
        {
            db.DoctorSees.Add(item);
        }

        public void Update(DoctorSee item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DoctorSee item = db.DoctorSees.Find(id);
            if (item != null)
                db.DoctorSees.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
