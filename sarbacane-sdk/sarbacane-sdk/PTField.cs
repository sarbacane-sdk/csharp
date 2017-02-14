using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace sarbacane_sdk
{
    public class PTField : ListsManager
    {
    [ScriptIgnore]
    private String format;
    
    private String id;
    
    private String listId;
    
    private String name;
    
    private String type;
   
    private Dictionary<String, Object> additionalProperties = new Dictionary<String, Object>();

    
    public String getFormat() {
        return format;
    }


    
    public void setFormat(String format) {
        this.format = format;
    }

      
    public String getId() {
        return id;
    }

      
    public void setId(String id) {
        this.id = id;
    }

   
   
    public String getListId() {
        return listId;
    }

   
    public void setListId(String listId) {
        this.listId = listId;
    }

   
    public String getName() {
        return name;
    }

   
    public void setName(String name) {
        this.name = name;
    }

   
    public String getType() {
        return type;
    }

   
    public void setType(String type) {
        this.type = type;
    }

   
    public Dictionary<String, Object> getAdditionalProperties() {
        return this.additionalProperties;
     
    }

   
    public void setAdditionalProperty(String name, Object value) {
        this.additionalProperties.Add(name, value);
    }

    }
}
