using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class SpecializationRepos : IRepository<Specialization>
    {
        private HealthyContext db;

        public SpecializationRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Specialization> GetList()
        {
            return db.Specializations.ToList();
        }

        public Specialization GetItem(int id)
        {
            return db.Specializations.Find(id);
        }

        public void Create(Specialization item)
        {
            db.Specializations.Add(item);
        }

        public void Update(Specialization item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Specialization item = db.Specializations.Find(id);
            if (item != null)
                db.Specializations.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
