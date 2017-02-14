using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Extensions.MonoHttp;
using System;
using System.Linq;


namespace sarbacane_sdk
{
    public class ListsManager : AuthenticationManager
    {
        public static String addList(String listName)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(listName))
            {
                throw new SystemException("Error: Please define the List Name.");
            }
            else
            {
                var query = BaseManager.httpPost("/lists", listName);
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }



        public static String bulkImport(String listId, String filePath)
        {
            AuthenticationManager.ensureSmsTokens();
            if ((!isSet(listId)) || (!isSet(filePath)))
            {
                throw new SystemException("Error: Please define listId AND filePath.");
            }
            else
            {
                Console.WriteLine("file: " + filePath);
                var query = BaseManager.httpPostContent("/lists/" + listId + "/import", filePath);
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                string locationUrl = (string)query.Headers.Where(h => h.Type == ParameterType.HttpHeader && h.Name == "Location").SingleOrDefault().Value;
                return locationUrl;
            }
        }

        public static String operationStatus(String operationUrl)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(operationUrl))
            {
                throw new SystemException("Error: Please define operationId to check.");
            }
            else
            {
                var query = BaseManager.httpGet(operationUrl);
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }

        }

        public static String getLists()
        {
            AuthenticationManager.ensureSmsTokens();
            var query = BaseManager.httpGet("/lists");
            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
            String response = deserial.Deserialize<String>(query);
            return response;
        }

        public static String getList(String listId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(listId))
            {
                throw new SystemException("Error: Please define a ListId.");
            }
            else
            {
                var query = BaseManager.httpGet("/lists" + listId);
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String delList(String listId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(listId))
            {
                throw new SystemException("Error: Please define a ListId.");
            }
            else
            {
                var query = BaseManager.httpDelete("/lists/" + listId);
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String addField(PTField newField)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(newField.getType()))
            {
                throw new SystemException("Error: Please define the field type (STRING, DATE OR NUMBER)");
            }
            else if (!"STRING".Equals(newField.getType()) && !"DATE".Equals(newField.getType()) && !"NUMBER".Equals(newField.getType()))
            {
                throw new SystemException("Error: Please define the field type: STRING, DATE OR NUMBER");
            }
            else if ("DATE".Equals(newField.getType()) && !isSet(newField.getFormat()))
            {
                throw new SystemException("Error: Please define the format of the DATE field: dd/MM/yyyy, dd/MM OR MM/yyyy");
            }
            else
            {
                var query = BaseManager.httpPost("/lists/" + newField.getListId() + "/fields", newField);
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }

        }

        public static String delField(PTField newField)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(newField.getId()))
            {
                throw new SystemException("Error: Please define a FieldId.");
            }
            else
            {
                var query = BaseManager.httpDelete("/lists/" + newField.getListId() + "/fields/" + newField.getId());
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String getFields(PTField newField)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(newField.getListId()))
            {
                throw new SystemException("Error: Please define a ListId.");
            }
            else
            {
                var query = BaseManager.httpGet("/lists/" + newField.getListId() + "/fields/");
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

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
    }
}
