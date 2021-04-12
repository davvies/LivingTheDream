using UnityEngine;
using UnityEngine.UI;

/// <summary> Class <c>PreDayDisplay</c> UI Logic for the pre-day screen </summary>
public class PreDayDisplay : MonoBehaviour
{
    [SerializeField] Animator snoozeAnimatior; //used for the animation in the 'snooze' button

    [SerializeField] AudioManager am; 

    [SerializeField] Canvas dayOne;
    [SerializeField] Canvas dayTwo;
    [SerializeField] Canvas dayThree;
    [SerializeField] Canvas dayFour;
    [SerializeField] Canvas dayFive;

    //used for getting the day and data
    [SerializeField] GameConfig gm;
    [SerializeField] GameStats gameStats;

    //on-screen text objects 
    [SerializeField] Text day;
    [SerializeField] Text date;
    [SerializeField] Text thought;

   void Start()
    {
        gm.ChangeCursorBackToOrignalCursor();
        UpdateFields();
    }

    /// <summary> Method <c>UpdateFields</c> Used for on-screen preset data </summary>
    void UpdateFields()
    {
        day.text = "DAY " + gameStats.dayTracker.GetDay();
        date.text = gameStats.dayTracker.GetDateOfDayInStandard();
        thought.text = "(Thought: "+gameStats.dayTracker.GetThoughtOfTheDay()+")";
    }

    void OnEnable()
    {
        gm.ChangeCursorBackToOrignalCursor();
        UpdateFields();
    }
    public void OnClickSnooze()
    {
        //mute alarm
        snoozeAnimatior.SetBool("AlarmStopped", true);
        am.MuteCurrentTrack();
    }

    /// <summary> Method <c>OnClickLaunchDay</c> Start the day relative to the progression </summary>
    public void OnClickLaunchDay()
    {
        am.UnmuteCurrentTrack();
        gm.ChangeCursorToMouseCursor();

        switch (gameStats.dayTracker.GetDay())
        {
           
            case 1:
                dayOne.gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;

            case 2:
                dayTwo.gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;

            case 3:
                dayThree.gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;

            case 4:
                dayFour.gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;

            case 5:
                dayFive.gameObject.SetActive(true);
                gameObject.SetActive(false);
                break; 

            default:
                Debug.LogWarning("DAY NOT FOUND: " + gameStats.dayTracker.GetDay());
                break;

        }
    }
}