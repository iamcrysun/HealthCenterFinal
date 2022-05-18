using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ProcedureRepos : IRepository<Procedure>
    {
        private HealthyContext db;

        public ProcedureRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Procedure> GetList()
        {
            return db.Procedures.ToList();
        }

        public Procedure GetItem(int id)
        {
            return db.Procedures.Find(id);
        }

        public void Create(Procedure item)
        {
            db.Procedures.Add(item);
        }

        public void Update(Procedure item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Procedure item = db.Procedures.Find(id);
            if (item != null)
                db.Procedures.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
