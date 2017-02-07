using System;


namespace sarbacane_sdk
{
    public class AuthenticationManager : BaseManager
    {
        private static String smsApikey;

        public static String getSmsApikey()
        {
            return smsApikey;
        }

        public static void setSmsApikey(String smsApikey)
        {
            if (isSet(smsApikey) && (smsApikey.Length == 32))
            {
                AuthenticationManager.smsApikey = smsApikey;
            }
            else
            {
                throw new SystemException("Incorrect (or null?) API Key !");
            }
        }

        private static Boolean smsCredentialsAreSet()
        {
            return isSet(smsApikey);
        }

        private static Boolean userIsLoggedIn()
        {
            return (isSet(getSmsApikey()));
        }

        public static void ensureSmsTokens()
        {
            if (!AuthenticationManager.smsCredentialsAreSet())
            {
                throw new SystemException("API Key is not defined !");
            }
        }

        private static String emailUser;
        private static String emailApikey;

        public static String getEmailUser()
        {
            return emailUser;
        }
        public static String getEmailApikey()
        {
            return emailApikey;
        }

        public static void setEmailTokens(String emailUser, String emailApikey)
        {
            if (isSet(emailUser) && isSet(emailApikey) && (emailApikey.Length == 32))
            {
                AuthenticationManager.emailApikey = emailApikey;
                AuthenticationManager.emailUser = emailUser;
            }
            else
            {
                throw new SystemException("Incorrect Email tokens !");
            }
        }

        private static bool emailCredentialsAreSet()
        {
            return isSet(emailUser) && isSet(emailApikey);
        }

        //private static boolean userIsLoggedIn() {
        //    return (isSet(getSmsApikey()));
        //}

        public static void ensureEmailTokens()
        {
            if (!AuthenticationManager.emailCredentialsAreSet())
            {
                throw new SystemException("Invalid Email credentials !");
            }
        }

    }
}