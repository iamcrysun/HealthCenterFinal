using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Data
{
    public class DbInitializer
    {
        public static void Initialize(HealthyContext context) // использовалось в лабораторных
        {
            context.Database.EnsureCreated();
            if (context.Doctors.Count() == 0)
            {
                context.Categories.Add(new Category
                { Category1 = "Высшая" }
                    );
                context.Doctors.Add(new Doctor
                {
                    FullName = "Петров Аркадий Валерьевич",
                    CategoryId = 1

                });
                context.SaveChanges();
            }
        }
    }
}