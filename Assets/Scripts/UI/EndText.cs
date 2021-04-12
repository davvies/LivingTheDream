using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary> Class <c>EndText</c> UI Game ending text (relative to outcome) </summary>
public class EndText : MonoBehaviour
{
    [SerializeField] Text endTitleText = default;

    [SerializeField] GameStats stats = default;

    string weakestOutcome = string.Empty;

    [SerializeField] AudioSource audio = default;

    const float textTransitionTime = 12f; 

    void Start()
    {
        //decide the fate of the story base on the stats of the game
        weakestOutcome = stats.emotionTracker.relationshipToWork > stats.emotionTracker.relationshipToFamily ? "family" : "work";
        StartCoroutine(FadeTitleText());
    }


    IEnumerator FadeTitleText()
    {
        audio.loop = false;
        endTitleText.text = "...another week finished...";
        yield return new WaitForSeconds(textTransitionTime);
        endTitleText.text = "...what's this?...";
        yield return new WaitForSeconds(textTransitionTime);
        endTitleText.text = "...a voice message from "+weakestOutcome+"...";
        yield return new WaitForSeconds(textTransitionTime);
        //play call pickup sound

        if (weakestOutcome.Equals("family")) //if the player has the 'family' ending..
        {
            endTitleText.text = "'I don't know what's gotten into you'";
            yield return new WaitForSeconds(textTransitionTime);
            endTitleText.text = "'We seem to be your last priority constantly'";
            yield return new WaitForSeconds(textTransitionTime);
            endTitleText.text = "'Seeing as you don't have time for us, we're leaving'";
            yield return new WaitForSeconds(textTransitionTime);
            endTitleText.text = "'I'm heading to my parents house'";
            yield return new WaitForSeconds(textTransitionTime);
            endTitleText.text = "'Some role model you are'";
        }
        else //if the player has the 'work' ending..
        {
            endTitleText.text = "'Your performance and attitude at work has dropped significantly'";
            yield return new WaitForSeconds(textTransitionTime);
            endTitleText.text = "'We're going to have to move you to a different department'";
            yield return new WaitForSeconds(textTransitionTime);
            endTitleText.text = "'This will involve pay deductions'";
            yield return new WaitForSeconds(textTransitionTime);
            endTitleText.text = "'You'll have fifteen minutes to grab your stuff monday'";
            yield return new WaitForSeconds(textTransitionTime);
            endTitleText.text = "'Hopefully next time you may show some more passion for the team'";
        }


        //play end of call sound
        yield return new WaitForSeconds(textTransitionTime);
        endTitleText.text = "welp.. guess I better get ready for next week eitherway";
        yield return new WaitForSeconds(textTransitionTime);
        endTitleText.text = "I am well and truly....";
        yield return new WaitForSeconds(textTransitionTime);
        endTitleText.text = "Living the dream";
        transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("TextFinished", false);
        SceneManager.LoadScene(0);
    }
}
