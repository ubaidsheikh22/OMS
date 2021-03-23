using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class emailSender
    {
        private string smtpClient, emailFrom, email_CC;
        private int serverPort;

        public string email(string Email, string subject, string link)
        {
            smtpClient = ConfigurationManager.AppSettings["SmtpClient"];
            emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            email_CC = ConfigurationManager.AppSettings["EmailCC"];
            string Password = ConfigurationManager.AppSettings["EmailPassword"];

            serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtpClient);

                mail.From = new MailAddress(emailFrom);
                mail.To.Add(Email);

                if (email_CC != null)
                    mail.CC.Add(email_CC);

                mail.Subject = subject;

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = "<h2> " + subject + " </h2>" +
                             "\n Click the link below to access your account " +
                             "<a href = " + link + "> login </a>";


                mail.Body = htmlBody;

                SmtpServer.Port = serverPort;
                //SmtpServer.Credentials = new System.Net.NetworkCredential(emailFrom, Password);
                //SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "1";
        }

        public string emailPOD(DataTable dt)
        {
            smtpClient = ConfigurationManager.AppSettings["SmtpClient"];
            emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            email_CC = ConfigurationManager.AppSettings["EmailCCPOD"];
            string EmailTOPOD = ConfigurationManager.AppSettings["EmailTOPOD"];
            string Subject = ConfigurationManager.AppSettings["SubjectPOD"];
            serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtpClient);


                mail.From = new MailAddress(emailFrom);
                mail.To.Add(EmailTOPOD);
                mail.CC.Add(email_CC);
                mail.Subject = Subject;

                mail.IsBodyHtml = true;
                string htmlBody;

                //htmlBody = "<h2> Kindly find the attached POD File </h2>";
                //htmlBody = RenderDataTableToHtml(dt);

                mail.Body = "Please find the attached POD file.";
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(ToCSV(dt));
                MemoryStream stream = new MemoryStream(bytes);

                StreamReader reader = new StreamReader(stream);
                mail.Attachments.Add(new Attachment(stream, "EPOD.csv"));
                //Console.WriteLine(reader.ReadToEnd());
                SmtpServer.Port = serverPort;
                SmtpServer.UseDefaultCredentials = true;
                //SmtpServer.Credentials = new System.Net.NetworkCredential(emailFrom, "Password-90");
                //SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "1";
        }

        public static string ToCSV(DataTable table)
        {
            var result = new StringBuilder();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(table.Columns[i].ColumnName);
                result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
            }

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
                }
            }

            return result.ToString();
        }

        public string SpecialOrderApproval(string To_Email, string body)
        {
            smtpClient = ConfigurationManager.AppSettings["SmtpClient"];
            emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
            string Password = ConfigurationManager.AppSettings["EmailPassword"];

            try
            {
                //setting up mail server
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtpClient);
                SmtpServer.UseDefaultCredentials = false;
                NetworkCredential basicAuthInfo = new NetworkCredential(emailFrom, Password);
                SmtpServer.Credentials = basicAuthInfo;
                SmtpServer.Port = serverPort;
                //SmtpServer.EnableSsl = true;

                mail.From = new MailAddress(emailFrom);
                mail.To.Add(To_Email);
                //mail.CC.Add(email_CC);
                mail.Subject = "Special Order Alert - OMS";
                mail.IsBodyHtml = true;
                mail.Body = body;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "1";
        }



        public string ClaimApproval(string To_Email, string body)
        {
            smtpClient = ConfigurationManager.AppSettings["SmtpClient"];
            emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtpClient);

                mail.From = new MailAddress(emailFrom);
                mail.To.Add(To_Email);
                //mail.CC.Add(email_CC);
                mail.Subject = "Claim Alert - OMS";

                mail.IsBodyHtml = true;

                mail.Body = body;

                SmtpServer.Port = serverPort;
                SmtpServer.UseDefaultCredentials = true;
                //SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "1";
        }

        private string RenderDataTableToHtml(DataTable dtInfo)
        {
            StringBuilder tableStr = new StringBuilder();

            if (dtInfo.Rows != null && dtInfo.Rows.Count > 0)
            {
                int columnsQty = dtInfo.Columns.Count;
                int rowsQty = dtInfo.Rows.Count;

                tableStr.Append("<TABLE BORDER=\"1\">");
                tableStr.Append("<TR>");
                for (int j = 0; j < columnsQty; j++)
                {
                    tableStr.Append("<TH>" + dtInfo.Columns[j].ColumnName + "</TH>");
                }
                tableStr.Append("</TR>");

                for (int i = 0; i < rowsQty; i++)
                {
                    tableStr.Append("<TR>");
                    for (int k = 0; k < columnsQty; k++)
                    {
                        tableStr.Append("<TD>");
                        tableStr.Append(dtInfo.Rows[i][k].ToString());
                        tableStr.Append("</TD>");
                    }
                    tableStr.Append("</TR>");
                }

                tableStr.Append("</TABLE>");
            }

            return tableStr.ToString();
        }
    }
}



