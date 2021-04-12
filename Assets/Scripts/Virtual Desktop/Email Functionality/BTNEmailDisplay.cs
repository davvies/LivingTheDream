using UnityEngine;
using TMPro;

/// <summary> Class <c>BTNEmailDisplay</c> Display given email on the desktop </summary>
public class BTNEmailDisplay : MonoBehaviour
{
    [SerializeField] EmailLogic EmailList = default; //email meta data 

    [SerializeField] GameObject ResponseSentText = default; //field for whether the user has responded 

    [SerializeField] GameObject SendResponse = default;

    //visual text fields
    [SerializeField] TextMeshProUGUI sender = default;
    [SerializeField] TextMeshProUGUI message = default;

    [SerializeField] GameStats gameStats = default; //used in updating stats

    public void DisplayEmailInfo()
    {
        //set email text relative to given email 
        int indexOfEmail = int.Parse(name);
        sender.text = "SENDER: "+EmailList.emails[indexOfEmail].sender;
        message.text = EmailList.emails[indexOfEmail].message;

        //if sent a response..
        if (EmailList.emails[indexOfEmail].hasSentNegativeResponse || EmailList.emails[indexOfEmail].hasSentPositiveResponse)
        {
            ResponseSentText.SetActive(true);
            SendResponse.SetActive(false);

            //display dynamic text based on response e.g. 'YOU RESPONDED WITH [POSTIVE/NEGATIVE] email
            message.text = EmailList.emails[indexOfEmail].hasSentNegativeResponse ? 
                message.text = "REPLY: " + EmailList.emails[indexOfEmail].negativeResponse : message.text = "REPLY: " + EmailList.emails[indexOfEmail].positiveResponse;
        } else
        {
            //show response
            SendResponse.SetActive(true);
            ResponseSentText.SetActive(false);
        }
    }

    /// <summary> Method <c>SendPositiveReply</c> Send positive reply and update stats </summary>
    public void SendPositiveReply()
    {
        EmailSystem.Email key = null; //active email clicked
        string keyMessage = message.text;

        foreach(var Email in EmailList.emails)
        {
            if (Email.message.Equals(keyMessage)) //O(n) search for emails is not too bad considering upper limit of emails is six
            
                key = Email;
            
        }

        EmailList.emailsLeftToAnswer -= 1;

        if (key.familyImpact > 0) //clamp family impact stat

            gameStats.emotionTracker.relationshipToFamily += key.familyImpact;
        

        if (key.workImpact > 0) //clamp work impact stat

            gameStats.emotionTracker.relationshipToWork += key.workImpact;
        
        key.hasSentPositiveResponse = true; //mark email

        //show response
        ResponseSentText.SetActive(true);
        SendResponse.SetActive(false);
    }


    /// <summary> Method <c>SendNegativeReply</c> Send negative reply and update stats </summary>
    public void SendNegativeReply()
    {
        EmailSystem.Email key = null;
        string keyMessage = message.text;

        foreach (var Email in EmailList.emails)
        {
            if (Email.message.Equals(keyMessage))
            
                key = Email;
            
        }

        if (key.familyImpact > 0) //clamp family impact stat

            gameStats.emotionTracker.relationshipToFamily -= key.familyImpact;
        

        if (key.workImpact > 0) //clamp work impact stat
        
            gameStats.emotionTracker.relationshipToWork -= key.workImpact;
        
        EmailList.emailsLeftToAnswer -= 1;

        key.hasSentNegativeResponse = true;

        ResponseSentText.SetActive(true);
        SendResponse.SetActive(false);
    }
}
