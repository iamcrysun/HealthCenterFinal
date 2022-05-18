using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DAL.Repositories
{
    public class PatientRepos : IRepository<Patient>
    {
        private HealthyContext db;

        public PatientRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Patient> GetList()
        {
            return db.Patients.ToList();
        }

        public Patient GetItem(int id)
        {
            return db.Patients.Find(id);
        }

        public void Create(Patient item)
        {
            db.Patients.Add(item);
        }

        public void Update(Patient item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Patient item = db.Patients.Find(id);
            if (item != null)
                db.Patients.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
