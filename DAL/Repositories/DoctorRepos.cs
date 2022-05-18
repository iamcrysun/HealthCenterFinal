using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class DoctorRepos : IRepository<Doctor>
    {
        private HealthyContext db;

        public DoctorRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Doctor> GetList()
        {
            return db.Doctors.Include(i => i.Schedules).Include(i => i.DoctorSees).Include(i => i.Specialization).ToList();
        }

        public Doctor GetItem(int id)
        {
            return db.Doctors.Include(i => i.Schedules).Include(i => i.DoctorSees).Include(i => i.Specialization).Where(i => i.Id == id).SingleOrDefault();
        }

        public void Create(Doctor item)
        {
            db.Doctors.Add(item);
        }

        public void Update(Doctor item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Doctor item = db.Doctors.Find(id);
            if (item != null)
                db.Doctors.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
