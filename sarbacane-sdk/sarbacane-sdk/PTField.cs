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

    /**
     *
     * @return
     * The format
     */
    
    public String getFormat() {
        return format;
    }

    /**
     *
     * @param format
     * The format
     */
    
    public void setFormat(String format) {
        this.format = format;
    }

    /**
     *
     * @return
     * The id
     */
   
    public String getId() {
        return id;
    }

    /**
     *
     * @param id
     * The id
     */
   
    public void setId(String id) {
        this.id = id;
    }

   

    /**
     *
     * @return
     * The listId
     */
   
    public String getListId() {
        return listId;
    }

    /**
     *
     * @param listId
     * The listId
     */
   
    public void setListId(String listId) {
        this.listId = listId;
    }

    /**
     *
     * @return
     * The name
     */
   
    public String getName() {
        return name;
    }

    /**
     *
     * @param name
     * The name
     */
   
    public void setName(String name) {
        this.name = name;
    }

    /**
     *
     * @return
     * The type
     */
   
    public String getType() {
        return type;
    }

    /**
     *
     * @param type
     * The type
     */
   
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
