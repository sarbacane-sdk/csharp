using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace sarbacane_sdk
{
    public class PTList : ListsManager
    {
        [ScriptIgnore]
        private String id;
        private String name;
        private List<PTField> fields = new List<PTField>();


        public List<PTField> getFields()
        {
            return fields;
        }

        public void setFields(List<PTField> fields)
        {
            this.fields = fields;
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

    }
}
