using RestSharp.Deserializers;
using RestSharp.Extensions.MonoHttp;
using System;


namespace sarbacane_sdk
{
    public class ContactsManager : BaseManager
    {
        public static String addContact(String listId, PTContact newContact)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(listId))
            {
                throw new SystemException("Error: Please define a listId to POST the contact on.");
            }
            else
            {
                var query = BaseManager.httpPost("/lists/" + listId + "/contacts", newContact);
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String delContacts(String listId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(listId))
            {
                throw new SystemException("Error: Please define a listId to DELETE the contacts on.");
            }
            else
            {
                var query = BaseManager.httpPost("/lists/" + listId + "/empty", "");
                if (query.StatusCode.ToString() == "NoContent")
                {
                    return "OK - Contacts deleted for list " + listId;
                }
                else
                {
                    throw new SystemException("Error: " + query.StatusCode.ToString());
                }
            }
        }

        public static String delContact(String listId, PTContact newContact)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(listId))
            {
                throw new SystemException("Error: Please define a listId to DELETE the contact on.");
            }
            String request = null;
            if (isSet(newContact.getId()))
            {
                request = "/lists/" + listId + "/contacts/" + newContact.getId();
            }
            else if (isSet(listId))
            {
                request = "/lists/" + listId + "/contacts?identifier=" + HttpUtility.UrlEncode(newContact.getIdentifier());
            }
            if (!isSet(request))
            {
                throw new SystemException("Error: Please choose between id OR identifier to delete contact.");
            }
            var query = BaseManager.httpDelete(request);
            if (query.StatusCode.ToString() == "NoContent")
            {
                return "OK";
            }
            else
            {
                throw new SystemException("HTTP Code: " + query.StatusCode.ToString());
            }
        }

        public static String getContacts(String listId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(listId))
            {
                throw new SystemException("Error: Please define a listId to GET contacts on.");
            }
            var query = BaseManager.httpGet("/lists/" + listId + "/contacts");
            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
            String response = deserial.Deserialize<String>(query);
            return response;
        }

        public static String checkIdentifier(String identifier)
        {
            AuthenticationManager.ensureSmsTokens();
        if (!isSet(identifier)) {
                throw new SystemException("Error: identifier is required.\n");
            } else {
                var query = BaseManager.httpGet("/check?identifier=" + HttpUtility.UrlEncode(identifier));
                JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
        }
}
    }
}
