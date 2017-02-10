### Sarbacane SDK C# - Send e-mail and text messages (sms)


* Install from Nuget console manager
* Download sources
* Authentication
* Buy credits
* Send E-mail
* Send SMS
* Webhooks

#### Nuget

[Install from Nuget console manager](https://www.nuget.org/packages/Sarbacane-Sdk)

```
Install-Package Sarbacane-Sdk
```


#### Sources

```
git clone https://github.com/sarbacane-sdk/csharp.git .
```


#### Authentication

###### E-mail

```
AuthenticationManager.setEmailTokens("31649838f306ebc8sca6b67be8cd7e20", "3413e65fbef014493537e77f811ca5ca");
```


###### SMS

```
AuthenticationManager.setSmsApikey("da3f2a93592ad9f43fb38977e8f64d76");
```


#### Credits

[Buy E-mail credits](https://fr.tipimail.com/tarifs) 

[Buy SMS credits](https://www.primotexto.com/tarif-sms-web.asp)


#### Send E-mail

```
    SBEmailMessage email = new SBEmailMessage();
    email.setMailFrom("sender@domain.com");
    email.setMailFromName("Sender Name");
    email.setSubject("Message sent by Sarbacane SDK");
    email.setMessage("Here is the content of the message");
    ArrayList recipientsList = new ArrayList();
    recipientsList.Add("clement.beauvois@primotexto.com");
    recipientsList.Add("clement.beauvois@sarbacane.com");
    email.setRecipients(recipientsList);
    MessagesManager.sendEmailMessage(email);
```

#### Send SMS

```
    SBSmsMessage msg = new SBSmsMessage();
    msg.setType("notification");
    msg.setNumber("+33600000000");
    msg.setMessage("Confirmation code is: 283951");
    msg.setSender("SBSMS");
    msg.setCategory("confirmationCode");
    msg.setCampaignName("Authentication confirmation code");
    MessagesManager.sendSmsMessage(msg);
```

