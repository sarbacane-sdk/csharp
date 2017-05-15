using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Extensions.MonoHttp;
using System;
using System.Linq;


namespace sarbacane_sdk
{
    public class ListsManager : BaseManager
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
                PTList list = new PTList();
                list.setName(listName);
                var query = BaseManager.httpPost("/lists", list);
                JsonDeserializer deserial = new JsonDeserializer();
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
        
    }
}
