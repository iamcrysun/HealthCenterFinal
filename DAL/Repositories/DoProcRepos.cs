using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class DoProcRepos : IRepository<DoProc>
    {
        private HealthyContext db;

        public DoProcRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<DoProc> GetList()
        {
            return db.DoProcs.ToList();
        }

        public DoProc GetItem(int id)
        {
            return db.DoProcs.Find(id);
        }

        public void Create(DoProc item)
        {
            db.DoProcs.Add(item);
        }

        public void Update(DoProc item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DoProc item = db.DoProcs.Find(id);
            if (item != null)
                db.DoProcs.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
