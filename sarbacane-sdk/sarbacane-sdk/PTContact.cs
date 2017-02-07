
using System;
using System.Collections.Generic;



namespace sarbacane_sdk
{
    public class PTContact : ListsManager
    {

        public String id = null;


        public String identifier = null;

        public Dictionary<String, String> attributes = new Dictionary<String, String>();

        public String getId()
        {
            return id;
        }

        public void setId(String id)
        {
            this.id = id;
        }

        public String getIdentifier()
        {
            return identifier;
        }

        public void setIdentifier(String identifier)
        {
            this.identifier = identifier;
        }

        public Dictionary<String, String> getAttributes()
        {
            return attributes;
        }

        public void setAttributes(Dictionary<String, String> attributes)
        {
            this.attributes = attributes;
        }
        public void setFieldValue(String fieldId, String fieldValue)
        {
            this.attributes.Add(fieldId, fieldValue);
        }
    }
}