
using RestSharp;
using System;

using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace sarbacane_sdk
{
    public class BaseManager
    {
        public static String baseURL = "https://api.primotexto.com/v2";

        protected static String smtpHost = "smtp.tipimail.com";
        protected static int smtpPort = 587;

        protected static void sendTransport(SBEmailMessage email)
        {
            SmtpClient client = new SmtpClient();
            client.Port = smtpPort;
            client.Host = smtpHost;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(AuthenticationManager.getEmailUser(), AuthenticationManager.getEmailApikey());

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(email.getMailFrom(), email.getMailFromName());
            mm.Headers.Add("X-Sarbacane-SDK-C#", "1.0.5");
            mm.Subject = (email.getSubject());
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            foreach (string recipient in email.getRecipients())
            {
                mm.To.Add(new MailAddress(recipient));
            }

            mm.Body = email.getTextBody();
            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            AlternateView alternate = AlternateView.CreateAlternateViewFromString(email.getHtmlBody(), mimeType);
            mm.AlternateViews.Add(alternate);

            try
            {
                client.Send(mm);
            } catch (Exception ex)
            {
                new Exception("Failed: " + ex.ToString());
            }
            
        }

        protected static IRestResponse httpGet(String Uri)
        {
            var client = new RestClient(baseURL);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            var request = new RestRequest(Uri, Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            return response;
            
        }

        protected static IRestResponse httpPost(String Uri, Object Data)
        {
            var client = new RestClient(baseURL);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            var request = new RestRequest(Uri, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(Data);
            request.AddBody(request.JsonSerializer.Serialize(Data));
            var response = client.Execute(request);
            return response;

        }

        protected static IRestResponse httpPostContent(String Uri, String File)
        {
            var client = new RestClient(baseURL);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            client.AddDefaultHeader("Accept", "application/json");
            var request = new RestRequest(Uri, Method.POST);
            String fileContent = readText(File);
            Console.WriteLine("FileContent: " + fileContent);
            
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", fileContent, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            
            var response = client.Execute(request);
            return response;

        }

        protected static IRestResponse httpPut(String Uri, Object Data)
        {
            var client = new RestClient(baseURL);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            var request = new RestRequest(Uri, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(Data);
            request.AddBody(request.JsonSerializer.Serialize(Data));
            var response = client.Execute(request);
            return response;

        }

        protected static IRestResponse httpDelete(String Uri)
        {
            var client = new RestClient(baseURL);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            var request = new RestRequest(Uri, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            return response;
        }

        
        public static Boolean isSet(String args)
        {
            return args != null && args.Length > 0;
        }

        public static String readText(String fileName)
        {
            return File.ReadAllText(fileName);
        }

    }
}