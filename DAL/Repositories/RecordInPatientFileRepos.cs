using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class RecordInPatientFileRepos : IRepository<RecordInPatientFile>
    {
        private HealthyContext db;

        public RecordInPatientFileRepos(HealthyContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<RecordInPatientFile> GetList()
        {
            return db.RecordInPatientFiles.ToList();
        }

        public RecordInPatientFile GetItem(int id)
        {
            return db.RecordInPatientFiles.Find(id);
        }

        public void Create(RecordInPatientFile item)
        {
            db.RecordInPatientFiles.Add(item);
        }

        public void Update(RecordInPatientFile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            RecordInPatientFile item = db.RecordInPatientFiles.Find(id);
            if (item != null)
                db.RecordInPatientFiles.Remove(item);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
