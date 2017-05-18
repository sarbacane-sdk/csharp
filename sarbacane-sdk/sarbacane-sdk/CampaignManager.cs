using RestSharp.Deserializers;
using System;


namespace sarbacane_sdk
{
    public class CampaignManager : BaseManager
    {
        public static String campaignCreate(PTCampaign campaign)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(campaign.getSubtype()) || (!"notification".Equals(campaign.getSubtype())) && (!"marketing".Equals(campaign.getSubtype())))
            {
                throw new SystemException("Error: Campaign not created - You need to specify a type: notification OR marketing.\n");
            }
            else if (!isSet(campaign.getName()) || (!isSet(campaign.getMessage())) || (!isSet(campaign.getSendList())))
            {
                throw new SystemException("Error: Campaign MUST have at least name, message and sendList properties.\n");
            }
            else
            {
                if (!isSet(campaign.getType()))
                {
                    campaign.setType("STANDARD");
                }
                var query = BaseManager.httpPost("/" + campaign.getSubtype() + "/campaigns", campaign);
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String campaignTest(PTCampaignTest campaignTest)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(campaignTest.getId()) || (!isSet(campaignTest.getIdentifier())))
            {
                throw new SystemException("Error: You need to specify campaignId and identifier to test the campaign.\n");
            }
            else
            {
                var query = BaseManager.httpPost("/campaigns/" + campaignTest.getId() + "/test", campaignTest);
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String campaignSend(String campaignId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(campaignId))
            {
                throw new SystemException("Error: You need to specify the campaignId.\n");
            }
            else
            {
                var query = BaseManager.httpPost("/campaigns/" + campaignId + "/send", "SEND");
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String campaignInfo(String campaignId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(campaignId))
            {
                throw new SystemException("Error: You need to specify the campaignId.\n");
            }
            else
            {
                var query = BaseManager.httpGet("/campaigns/" + campaignId );
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String campaignsInfo()
        {
            AuthenticationManager.ensureSmsTokens();
            var query = BaseManager.httpGet("/campaigns");
            JsonDeserializer deserial = new JsonDeserializer();
            String response = deserial.Deserialize<String>(query);
            return response;
        }

        public static String campaignStats(String campaignId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(campaignId))
            {
                throw new SystemException("Error: You need to specify the campaignId.\n");
            }
            else
            {
                var query = BaseManager.httpGet("/campaigns/" + campaignId + "/status");
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String campaignReplies(String campaignId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(campaignId))
            {
                throw new SystemException("Error: You need to specify the campaignId.\n");
            }
            else
            {
                var query = BaseManager.httpGet("/campaigns/" + campaignId + "/replies");
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }

        public static String campaignBlacklists(String campaignId)
        {
            AuthenticationManager.ensureSmsTokens();
            if (!isSet(campaignId))
            {
                throw new SystemException("Error: You need to specify the campaignId.\n");
            }
            else
            {
                var query = BaseManager.httpGet("/campaigns/" + campaignId + "/blacklists");
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                String response = deserial.Deserialize<String>(query);
                return response;
            }
        }
    }
}
