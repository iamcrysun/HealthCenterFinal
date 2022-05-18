using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operations
{
    public static class Email // класс для отправки сообщений
    {
        public static async Task Close(DoctorSeeDTO see) // сообщение об отмене приема
        {
            DBOperations db = new DBOperations();
            var patient = db.GetPatient(see.PatientId);
            if (patient != null)
            {
                MailMessage emailMessage = new MailMessage();
                emailMessage.IsBodyHtml = true;
                emailMessage.From = new MailAddress("adamova.01@mail.ru",
                    "HealthyCenter"); //отправитель сообщения и его подпись, срабатывает корректно при указании
                                      // реальной почты
                emailMessage.To.Add(patient.Email); //адресат сообщения
                emailMessage.Subject = "Отмена приема приема"; //тема сообщения
                emailMessage.Body = "<div></h3><label>Прием " + see.Id
                + " на " + see.DateTime + " отменен</label></div>"; // сообщение

                using (SmtpClient client = new SmtpClient("smtp.mail.ru", 25)) // отправка письма
                {
                    client.EnableSsl = true; // требуется mail.ru
                    client.Credentials = new NetworkCredential("adamova.01",
                    "KVnzYx8VxvNx7GQ9vpys"); // данные для отправки
                    client.Send(emailMessage); // отправка
                }
            }
        }

        public static async Task Priem(RecordInPatientFileDTO record, 
            string email) // отправка результатов приема на почту
        {
            DBOperations db = new DBOperations();
            var doctor = db.GetDoctor(record.DoctorId);
            if (doctor != null)
            {
                MailMessage emailMessage = new MailMessage();
                emailMessage.IsBodyHtml = true;
                emailMessage.From = new MailAddress("adamova.01@mail.ru",
                    "HealthyCenter"); //отправитель сообщения и его подпись, срабатывает корректно при указании
                                      // реальной почты
                emailMessage.To.Add(email); //адресат сообщения
                emailMessage.Subject = "Результат приема"; //тема сообщения
                emailMessage.Body = "<div></h3><label>Доктор - " + doctor.FullName
                + "</label><br><label>Диагноз - " + record.Diagnosis
                + "</label><br><label>Результат - " + record.Result
                    + "</label></div>"; // сообщение

                using (SmtpClient client = new SmtpClient("smtp.mail.ru", 25)) // отправка письма
                {
                    client.EnableSsl = true; // требуется mail.ru
                    client.Credentials = new NetworkCredential("adamova.01",
                    "KVnzYx8VxvNx7GQ9vpys"); // данные для отправки
                    client.Send(emailMessage); // отправка
                }
            }
        }
        public static async Task Reg(DoctorSeeDTO see, string email) 
            // отправка талона на прием на почту
        {
            DBOperations db = new DBOperations();
            var doctor = db.GetDoctor(see.DoctorId);
            if (doctor != null)
            {
                MailMessage emailMessage = new MailMessage();
                emailMessage.IsBodyHtml = true;
                emailMessage.From = new MailAddress("adamova.01@mail.ru",
                    "HealthyCenter"); //отправитель сообщения и его подпись, срабатывает корректно при указании
                                      // реальной почты
                emailMessage.To.Add(email); //адресат сообщения
                emailMessage.Subject = "Запись на прием"; //тема сообщения
                emailMessage.Body = "<div><h3>Талон номер " + see.Id // сообщение
                    + "</h3><label>Доктор - " + doctor.FullName
                + "</label><br><label>Время приема - " + see.DateTime
                    + "</label></div>";

                using (SmtpClient client = new SmtpClient("smtp.mail.ru", 25)) // отправка письма
                {
                    client.EnableSsl = true; // требуется mail.ru
                    client.Credentials = new NetworkCredential("adamova.01",
                    "KVnzYx8VxvNx7GQ9vpys");
                    client.Send(emailMessage); // отправка
                }
            }
        }
    }
}
