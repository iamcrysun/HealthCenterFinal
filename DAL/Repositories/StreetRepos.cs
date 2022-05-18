using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class StreetRepos : IRepository<Street>
    {
        private HealthyContext db;

        public StreetRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Street> GetList()
        {
            return db.Streets.ToList();
        }

        public Street GetItem(int id)
        {
            return db.Streets.Find(id);
        }

        public void Create(Street item)
        {
            db.Streets.Add(item);
        }

        public void Update(Street item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Street item = db.Streets.Find(id);
            if (item != null)
                db.Streets.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
