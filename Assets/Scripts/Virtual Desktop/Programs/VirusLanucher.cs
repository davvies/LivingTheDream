using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> Class <c>VirusLauncher</c> Logic for handing when virus software is opened on the virtual PC </summary>
public class VirusLanucher : MonoBehaviour, IPointerDownHandler
{

    //click timers for mouse interaction
    float clicked = 0;
    float clickTime = 0;
    readonly float clickDelay = 0.5f;

    [SerializeField] GameObject window;

    [SerializeField] Transform parent;

    [SerializeField] GameConfig OS;

    //all window pop ups relating to the virus 
    [SerializeField] GameObject[] popupwindow = new GameObject[6];

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked++;

        //if clicked once begin click timer (for double click)
        if (clicked == 1)
            clickTime = Time.time;

        //if double clicked..
        if (clicked > 1 && Time.time - clickTime < clickDelay)
        {
            clicked = 0;
            clickTime = 0;

            //launch window
            CheckAndOpenWindow();
        }

        else if (clicked > 2 || Time.time - clickTime > 1) 
            clicked = 0;
    }

    /// <summary> Method <c>CheckAndOpenWindow</c> Begins the execution of the virus </summary>
    public void CheckAndOpenWindow()
    {
        StartCoroutine(WindowLauncher());
        OS.onTriggerUpdateCursor = true;
    }

    IEnumerator WindowLauncher()
    {
       foreach(GameObject popup in popupwindow)
        {
            popup.SetActive(true);
            popup.transform.SetAsLastSibling(); //container formatting
            yield return new WaitForSeconds(1f);
        }
    }
    
}
