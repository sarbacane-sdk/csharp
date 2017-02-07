using System;
using System.Web.Script.Serialization;

namespace sarbacane_sdk
{
    
    public class PTBlacklist : BaseManager
    {
        [ScriptIgnore]
        public String type;
        [ScriptIgnore]
        public String id;
        [ScriptIgnore]
        public String url;
        public String identifier;


        public PTBlacklist(String type, String identifier, String id)
        {
            this.type = type;
            this.identifier = identifier;
            this.id = id;
        }

        public PTBlacklist()
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

        public String getIdentifier()
        {
            return identifier;
        }

        public void setIdentifier(String identifier)
        {
            this.identifier = identifier;
        }

        public String getId()
        {
            return id;
        }

        public void setId(String id)
        {
            this.id = id;
        }
    }
}
