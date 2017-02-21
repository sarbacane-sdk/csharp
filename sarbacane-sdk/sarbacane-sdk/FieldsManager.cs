using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sarbacane_sdk
{
    public class FieldsManager : BaseManager
    {
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
    }
}
