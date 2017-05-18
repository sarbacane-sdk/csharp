using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace sarbacane_sdk
{
    public class PTList : ListsManager
    {
        private String name;

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public PTList(String name)
        {
            this.name = name;
        }

        public PTList() { }

        /**
        //[ScriptIgnore]
        //private String id;

        
        //[ScriptIgnore]
        //private List<PTField> fields = new List<PTField>();


        public List<PTField> getFields()
        {
            return fields;
        }

        public void setFields(List<PTField> fields)
        {
            this.fields = fields;
        }

        public PTList(String name)
        {
            this.name = name;
        }

        public PTList() { }


        public String getId()
        {
            return id;
        }

        public void setId(String id)
        {
            this.id = id;
        }


    **/
    }
}
