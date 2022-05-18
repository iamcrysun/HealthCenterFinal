using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class TypeofProcRepos : IRepository<TypeofProc>
    {
        private HealthyContext db;

        public TypeofProcRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<TypeofProc> GetList()
        {
            return db.TypeofProcs.ToList();
        }

        public TypeofProc GetItem(int id)
        {
            return db.TypeofProcs.Find(id);
        }

        public void Create(TypeofProc item)
        {
            db.TypeofProcs.Add(item);
        }

        public void Update(TypeofProc item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TypeofProc item = db.TypeofProcs.Find(id);
            if (item != null)
                db.TypeofProcs.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
