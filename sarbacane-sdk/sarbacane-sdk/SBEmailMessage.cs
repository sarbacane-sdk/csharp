using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace sarbacane_sdk
{
    public class SBEmailMessage :BaseManager
    {
        private String mailFrom;
        private String mailFromName;
        private String subject;
        private String message;


        private ArrayList recipients = new ArrayList();

        public SBEmailMessage()
        {

        }

        public ArrayList getRecipients()
        {
            return recipients;
        }

        public void setRecipients(ArrayList recipients)
        {
            this.recipients = recipients;
        }

        public String getMailFrom()
        {
            return mailFrom;
        }

        public void setMailFrom(String mailFrom)
        {
            this.mailFrom = mailFrom;
        }

        public String getMailFromName()
        {
            return mailFromName;
        }

        public void setMailFromName(String mailFromName)
        {
            this.mailFromName = mailFromName;
        }


        public String getSubject()
        {
            return subject;
        }

        public void setSubject(String subject)
        {
            this.subject = subject;
        }

        public String getMessage()
        {
            return message;
        }

        public void setMessage(String message)
        {
            this.message = message;
        }
    }
}
