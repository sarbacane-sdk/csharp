
using RestSharp;
using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace sarbacane_sdk
{
    public class BaseManager
    {
        protected static String version = "1.0.6";
        protected static String smsUrl = "https://api.primotexto.com/v2";
        protected static String smtpHost = "smtp.tipimail.com";
        protected static int smtpPort = 587;
        protected static int smtpConnectionTimeout = 60000;
        protected static bool smtpStartTlsEnable = true;
        protected static String sdkHeader = "X-Sarbacane-SDK";
        protected static String sdkVersion = "sarbacane-sdk-net " + version;
        protected static String smtpDefaultHtmlEncoding = "text/html; charset=utf-8";
        protected static String smtpDefaultTextEncoding = "text/plain; charset=utf-8";

        //protected static String sdkVersion = ConfigurationManager.AppSettings["version"];
        //protected static String smsUrl = ConfigurationManager.AppSettings["smsUrl"];
        //protected static String smtpHost = ConfigurationManager.AppSettings["smtpHost"];
        //protected static int smtpPort = int.Parse(ConfigurationManager.AppSettings["smtpPort"]);
        //protected static int smtpConnectionTimeout = int.Parse(ConfigurationManager.AppSettings["smtpConnectionTimeout"]);
        //protected static String smtpStartTlsEnable = ConfigurationManager.AppSettings["smtpStartTlsEnable"];
        //protected static String smtpAuthEnable = ConfigurationManager.AppSettings["smtpAuthEnable"];
        //protected static String smtpDefaultHtmlEncoding = ConfigurationManager.AppSettings["smtpDefaultHtmlEncoding"];
        //protected static String smtpDefaultTextEncoding = ConfigurationManager.AppSettings["smtpDefaultTextEncoding"];



        protected static void sendTransport(SBEmailMessage email)
        {
            SmtpClient client = new SmtpClient();
            client.Port = smtpPort;
            client.Host = smtpHost;
            client.EnableSsl = smtpStartTlsEnable;
            client.Timeout = smtpConnectionTimeout;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(AuthenticationManager.getEmailUser(), AuthenticationManager.getEmailApikey());

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(email.getMailFrom(), email.getMailFromName());
            mm.Headers.Add(sdkHeader, sdkVersion);
            mm.Subject = (email.getSubject());
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            foreach (string recipient in email.getRecipients())
            {
                mm.To.Add(new MailAddress(recipient));
            }

            mm.Body = email.getTextBody();
            ContentType mimeType = new ContentType(smtpDefaultHtmlEncoding);
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
            var client = new RestClient(smsUrl);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            client.AddDefaultHeader(sdkHeader, sdkVersion);
            var request = new RestRequest(Uri, Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            return response;
            
        }

        protected static IRestResponse httpPost(String Uri, Object Data)
        {
            var client = new RestClient(smsUrl);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            client.AddDefaultHeader(sdkHeader, sdkVersion);
            var request = new RestRequest(Uri, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(Data);
            request.AddBody(request.JsonSerializer.Serialize(Data));
            var response = client.Execute(request);
            return response;

        }

        protected static IRestResponse httpPostContent(String Uri, String File)
        {
            var client = new RestClient(smsUrl);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            client.AddDefaultHeader("Accept", "application/json");
            client.AddDefaultHeader(sdkHeader, sdkVersion);
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
            var client = new RestClient(smsUrl);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            client.AddDefaultHeader(sdkHeader, sdkVersion);
            var request = new RestRequest(Uri, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(Data);
            request.AddBody(request.JsonSerializer.Serialize(Data));
            var response = client.Execute(request);
            return response;

        }

        protected static IRestResponse httpDelete(String Uri)
        {
            var client = new RestClient(smsUrl);
            client.AddDefaultHeader("X-Primotexto-ApiKey", AuthenticationManager.getSmsApikey());
            client.AddDefaultHeader("Content-type", "application/json");
            client.AddDefaultHeader(sdkHeader, sdkVersion);
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