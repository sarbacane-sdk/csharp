using System;
using System.Web.Script.Serialization;

namespace sarbacane_sdk
{
    public class SBSmsMessage
    {
        [ScriptIgnore]
        public String type;
        public String number;
        public String message;
        public String sender;
        public String campaignName;
        public String category;


        public SBSmsMessage(String type, String number, String message, String sender, String campaignName, String category)
        {
            this.type = type;
            this.number = number;
            this.message = message;
            this.sender = sender;
            this.campaignName = campaignName;
            this.category = category;
        }

        public SBSmsMessage()
        {

        }

        public String getType()
        {
            return type;
        }

        public void setType(String type)
        {
            this.type = type;
        }

        public String getNumber()
        {
            return number;
        }

        public void setNumber(String number)
        {
            this.number = number;
        }

        public String getMessage()
        {
            return message;
        }

        public void setMessage(String message)
        {
            this.message = message;
        }

        public String getSender()
        {
            return sender;
        }

        public void setSender(String sender)
        {
            this.sender = sender;
        }

        public String getCampaignName()
        {
            return campaignName;
        }

        public void setCampaignName(String campaignName)
        {
            this.campaignName = campaignName;
        }

        public String getCategory()
        {
            return category;
        }

        public void setCategory(String category)
        {
            this.category = category;
        }
    }
}
