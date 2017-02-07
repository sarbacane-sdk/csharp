using RestSharp.Deserializers;
using RestSharp.Extensions.MonoHttp;
using System;


namespace sarbacane_sdk
{
    public class AccountManager : AuthenticationManager
    {
        public static String accountStats() {
            AuthenticationManager.ensureSmsTokens();
                var query = BaseManager.httpGet("/account/stats");
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
        }


        public static String accountBlacklists(String type)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(type) || !"bounces".Equals(type) && !"unsubscribers".Equals(type))
            {
                throw new SystemException("Error: Please define Type: unsubscribers OR bounces");
            }
            var query = BaseManager.httpGet("/" + type + "/default/contacts");
            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
            String response = deserial.Deserialize<String>(query);
            return response;
        }

        public static String accountBlacklistsAdd(PTBlacklist blacklist)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(blacklist.getType()) || !"bounces".Equals(blacklist.getType()) && !"unsubscribers".Equals(blacklist.getType()))
            {
                throw new SystemException("Error: Please define Type: unsubscribers OR bounces");
            }
            if (!isSet(blacklist.getIdentifier()))
            {
                throw new SystemException("Error: Please define a contact identifier");
            }
            var query = BaseManager.httpPost("/" + blacklist.getType() + "/default/contacts", blacklist);
            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
            String response = deserial.Deserialize<String>(query);
            return response;
        }

        public static String accountBlacklistsDel(PTBlacklist blacklist)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(blacklist.getType()) || !"bounces".Equals(blacklist.getType()) && !"unsubscribers".Equals(blacklist.getType()))
            {
                throw new SystemException("Error: Please define Type: unsubscribers OR bounces");
            }
            if (isSet(blacklist.getIdentifier()) && isSet(blacklist.getId()))
            {
                throw new SystemException("Error: Please choose between identifier OR id METHOD");
            }
            if (isSet(blacklist.getIdentifier()))
            {
                String identifier = HttpUtility.UrlEncode(blacklist.getIdentifier());
                blacklist.url = "/" + blacklist.getType() + "/default/contacts?identifier=" + identifier;
            }
            else if (isSet(blacklist.getId()))
            {
                blacklist.url = "/" + blacklist.getType() + "/default/contacts/" + blacklist.getId();
            }
            else
            {
                throw new SystemException("Error: Please define identifier OR id blacklist");
            }
            var query = BaseManager.httpDelete("blacklist.url");
            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
            String response = deserial.Deserialize<String>(query);
            return response;
        }

    }
}
