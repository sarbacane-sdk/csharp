using RestSharp.Deserializers;
using RestSharp.Extensions.MonoHttp;
using System;



namespace sarbacane_sdk
{
    public class MessagesManager : AuthenticationManager
    {

        public static void sendEmailMessage(SBEmailMessage email)
        {
            AuthenticationManager.ensureEmailTokens();
            if ((!isSet(email.getMailFrom())) || (!isSet(email.getMailFromName())) || (!isSet(email.getRecipients().ToString())) || !(isSet(email.getSubject())) || (!isSet(email.getTextBody())) || (!isSet(email.getHtmlBody())))
            {
                throw new SystemException("Error: mailFrom, mailFromname, recipients, subject, htmlBody and textBody are required.");
            }
            else
            {
                BaseManager.sendTransport(email);
            }
        }

        public static String sendSmsMessage(SBSmsMessage msg)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(msg.getType()))
            {
                throw new SystemException("Error: SMS NOT SENT - You need to specify a Type: notification OR marketing");
            }
            if ("notification".Equals(msg.getType()) || "marketing".Equals(msg.getType()))
            {
                var response = BaseManager.httpPost("/" + msg.getType() + "/messages/send", msg);
                JsonDeserializer deserial = new JsonDeserializer();
                String msgResponse = deserial.Deserialize<String>(response);
                return msgResponse;
            }
            else
            {
                throw new SystemException("Error: SMS NOT SENT - You need to specify a Type: notification OR marketing");
            }
        }


        public static String messagesStatusBySnapshotId(String snapshotId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (snapshotId != null)
            {
                var response = BaseManager.httpGet("/messages/status?snapshotId=" + snapshotId);
                JsonDeserializer deserial = new JsonDeserializer();
                String msgStatus = deserial.Deserialize<String>(response);
                return msgStatus;
            }
            else
            {
                throw new SystemException("Error: Please define snapshotId \n");
            }
        }


        public static String messagesStatusByIdentifier(String identifier)
        {
            AuthenticationManager.ensureSmsTokens();
            if (identifier != null)
            {
                var response = BaseManager.httpGet("/messages/status?identifier=" + HttpUtility.UrlEncode(identifier));
                JsonDeserializer deserial = new JsonDeserializer();
                String msgStatus = deserial.Deserialize<String>(response);
                return msgStatus;
            }
            else
            {
                throw new SystemException("Error: Please define snapshotId \n");
            }
        }

        public static String messagesCallbacks(String category)
        {
            AuthenticationManager.ensureSmsTokens();
            if (category != null)
            {
                    var response = BaseManager.httpGet("/messages/replies?category=" + category);
                    JsonDeserializer deserial = new JsonDeserializer();
                    String msgCallbacks = deserial.Deserialize<String>(response);
                    return msgCallbacks;
                
                
            }
            else
            {
                throw new SystemException("Error: Please define snapshotId \n");
            }
        }

        public static String messagesBlacklists(String category)
        {
            AuthenticationManager.ensureSmsTokens();
            if (category != null)
            {
                var response = BaseManager.httpGet("/messages/blacklists?category=" + HttpUtility.UrlEncode(category));
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String msgBlacklists = deserial.Deserialize<String>(response);
                return msgBlacklists;
            }
            else
            {
                throw new SystemException("Error: Please define snapshotId \n");
            }
        }
    }
}
