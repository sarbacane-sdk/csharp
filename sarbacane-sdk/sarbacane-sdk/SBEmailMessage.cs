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
        private String htmlBody;
        private String textBody;


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

        public String getHtmlBody()
        {
            return htmlBody;
        }

        public void setHtmlBody(String message)
        {
            this.htmlBody = message;
        }

        public String getTextBody()
        {
            return textBody;
        }

        public void setTextBody(String message)
        {
            this.textBody = message;
        }
    }
}
