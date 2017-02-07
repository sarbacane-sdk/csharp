using System;


namespace sarbacane_sdk
{
    public class PTQuery
    {
        private String type;
        private String identifier;
        private String snapshotId;
        private String category;
        private String request;

        public PTQuery(String type, String identifier, String snapshotId, String category, String request)
        {
            this.type = type;
            this.identifier = identifier;
            this.snapshotId = snapshotId;
            this.category = category;
            this.request = request;
        }

        public PTQuery()
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

        public String getSnapshotId()
        {
            return snapshotId;
        }

        public void setSnapshotId(String snapshotId)
        {
            this.snapshotId = snapshotId;
        }

        public String getCategory()
        {
            return category;
        }

        public void setCategory(String category)
        {
            this.category = category;
        }

        public String getRequest()
        {
            return request;
        }

        public void setRequest(String request)
        {
            this.request = request;
        }
    }
}
