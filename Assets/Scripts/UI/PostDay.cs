using UnityEngine;
using UnityEngine.UI;

/// <summary> Class <c>PostDay</c> UI Logic for the end of each week day </summary>
public class PostDay : MonoBehaviour
{
    [SerializeField] GameStats currentStats = default;

    [SerializeField] Text date = default;

    //visual output for each stats (represented as a normalised slider)
    [SerializeField] Slider relationshipToWork = default;
    [SerializeField] Slider relationshipToFamily = default;
    [SerializeField] Slider motovation = default;
    [SerializeField] Slider mentalStress = default;

    [SerializeField] GameObject preDayCanvas = default;
    [SerializeField] GameObject endScreenCanvas = default;

    const int endOfTheWeek = 5;

    // Start is called before the first frame update
    void Start()
    {
        //starting game relationships

        relationshipToWork.maxValue = 100;
        relationshipToWork.minValue = 0;
        relationshipToFamily.maxValue = 100;
        relationshipToWork.minValue = 0;

        motovation.maxValue = 100;
        motovation.minValue = 0;

        mentalStress.maxValue = 100;
        mentalStress.minValue = 0;

        ShowStats();
    }

    void OnEnable() => ShowStats();

    /// <summary> Method <c>ShowStats</c> Relaying stats on-screen to the user </summary>
    void ShowStats()
    {
        date.text = "As of " + currentStats.dayTracker.GetDateOfDayInStandard();

        relationshipToWork.value = currentStats.emotionTracker.relationshipToWork;
        relationshipToFamily.value = currentStats.emotionTracker.relationshipToFamily;

        motovation.value = currentStats.emotionTracker.motivation;
        mentalStress.value = currentStats.emotionTracker.mentalstress;
    }

    public void OnClickStartNextDay()
    {
        if (currentStats.dayTracker.GetDay() != endOfTheWeek)
        {
            currentStats.dayTracker.SetDay(currentStats.dayTracker.GetDay() + 1); //increase internal week stats
            preDayCanvas.SetActive(true);

        } else
        {
            endScreenCanvas.gameObject.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
