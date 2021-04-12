using UnityEngine;
using TMPro;

/// <summary> Class <c>ToolbarUpdate</c> Internal logic for computer screen </summary>
public class ToolbarUpdate : MonoBehaviour
{
    [SerializeField] GameStats stats;
    [SerializeField] TextMeshProUGUI date;

    void Start() => date.text = stats.dayTracker.GetDateOfDayInComputer();
    
}
