using System;


namespace sarbacane_sdk
{
    public class PTCampaign : BaseManager
    {
        private String id = null;
        private String name = null;
        private String type = null;
        private String subtype = null;
        private String sendList = null;
        private String sourceAddress = null;
        private String message = null;
        private String date = null;
        private String externalUrl = null;
        private String landingPageType = null;
        private String landingPage = null;
        private String landingPageTitle = null;


        public String getMessage()
        {
            return message;
        }

        public void setMessage(String message)
        {
            this.message = message;
        }

        public String getSubtype()
        {
            return subtype;
        }

        public void setSubtype(String subtype)
        {
            this.subtype = subtype;
        }

        public String getId()
        {
            return id;
        }

        public void setId(String id)
        {
            this.id = id;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getType()
        {
            return type;
        }

        public void setType(String type)
        {
            this.type = type;
        }

        public String getSendList()
        {
            return sendList;
        }

        public void setSendList(String sendList)
        {
            this.sendList = sendList;
        }

        public String getSourceAddress()
        {
            return sourceAddress;
        }

        public void setSourceAddress(String sourceAddress)
        {
            this.sourceAddress = sourceAddress;
        }

        public String getDate()
        {
            return date;
        }

        public void setDate(String date)
        {
            this.date = date;
        }

        public String getExternalUrl()
        {
            return externalUrl;
        }

        public void setExternalUrl(String externalUrl)
        {
            this.externalUrl = externalUrl;
        }

        public String getLandingPageType()
        {
            return landingPageType;
        }

        public void setLandingPageType(String landingPageType)
        {
            this.landingPageType = landingPageType;
        }

        public String getLandingPage()
        {
            return landingPage;
        }

        public void setLandingPage(String landingPage)
        {
            this.landingPage = landingPage;
        }

        public String getLandingPageTitle()
        {
            return landingPageTitle;
        }

        public void setLandingPageTitle(String landingPageTitle)
        {
            this.landingPageTitle = landingPageTitle;
        }

    }
}
