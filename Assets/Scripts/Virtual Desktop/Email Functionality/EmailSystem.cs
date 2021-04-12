using UnityEngine;

/// <summary> Class <c>EmailSystem</c> Data for email objects </summary>
public class EmailSystem : MonoBehaviour
{
    public class Email
    {
        //visible output elements
        public string sender, subject, message, sendOff, positiveResponse, negativeResponse;

        //used as an indicator of display
        public bool hasSentPositiveResponse, hasSentNegativeResponse;

        //stats for external impact
        public int workImpact, familyImpact;

        public Email(string sender, string subject, string message, string positiveResponse, string negativeResponse,bool hasSentPositiveResponse, bool hasSentNegativeResponse, int workImpact, int familyImpact)
        {
            this.sender = sender;
            this.subject = subject;
            this.message = message;
            this.positiveResponse = positiveResponse;
            this.negativeResponse = negativeResponse;
            this.hasSentPositiveResponse = hasSentPositiveResponse;
            this.hasSentNegativeResponse = hasSentNegativeResponse;
            this.workImpact = workImpact;
            this.familyImpact = familyImpact;
        }

    }

}
