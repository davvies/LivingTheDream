using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>Class <c>OpenProgram</c> Functionality for opening programs</summary>
public class OpenProgram : MonoBehaviour, IPointerDownHandler
{
    float clicked = 0; //timer delay 
	
    float clickTime = 0;
    const float clickDelay = 0.5f;

    [SerializeField] GameObject window;
    [SerializeField] GameConfig OS;

    public void OnPointerDown(PointerEventData eventData) //check for double clicks
    {
		
        clicked++;

        if (clicked == 1)
            clickTime = Time.time; //get active time to check for double click

        if (clicked > 1 && Time.time - clickTime < clickDelay) //if double click..
        {
			//stop continuous calls
            clicked = 0; 
            clickTime = 0;
			
            CheckAndOpenWindow(); //open given window
        }

        else if (clicked > 2 || Time.time - clickTime > 1)
			clicked = 0; //reset click
    }

	/// <summary>Method <c>CheckAndOpenWindow</c> Handle window opening and window layering </summary>
    public void CheckAndOpenWindow()
    {
        if (!window.gameObject.activeSelf)
			window.gameObject.SetActive(true);
		
        window.transform.SetAsLastSibling(); //layering
        OS.onTriggerUpdateCursor = true; //update cursor to clicked
    }

}
