using System;


namespace sarbacane_sdk
{
    public class PTListResponseId : ListsManager
    {
        public String getId() { return id; }

        public void setId(String id) { this.id = id; }

        private String id;

        public String toString() {
        return "PTResponseId{" +
                "id='" + id + '\'' +
                '}';
    }

    }
}
