using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;
using TMPro;

/// <summary> Class <c>SystemSettings</c> Saving and logging out of the computer </summary>
public class SystemSettings : MonoBehaviour
{
    [SerializeField] Binary shaderEffect = default; //shader
	
    [SerializeField] GameObject primaryCanvas = default; //primary game window
	
    [SerializeField] GameConfig OS = default;
	
    [SerializeField] DitherControl ditherEffect = default; //shader script settings
	
    [SerializeField] GameObject postDayCanvas = default;
	
    [SerializeField] EmailLogic levelEmails = default; //list of emails
	
    [SerializeField] GameObject prefabOfWindows = default;
	
    [SerializeField] GameStats gameStats = default;

    //stats to be added/removed at the end of each day
    const int dailyMotivation = 20; 
    const int mentalStress = 20;

    /// <summary> Method <c>SystemDataSettings</c> Handles menu options from dropdown system menu</summary>
    public void SystemDataSettings(int optionChosen)
    {
        switch (optionChosen)
        {
            case 0: //log-out

                if (levelEmails.emailsLeftToAnswer == 0) //if all emails have been answered
                {
                    gameStats.emotionTracker.motivation -= dailyMotivation;
                    gameStats.emotionTracker.mentalstress += mentalStress;

                    StartCoroutine(FadeToBlack());

                } else
                {                   
                    //create window
                    GameObject prefabWindow = Instantiate(prefabOfWindows, primaryCanvas.transform.GetChild(0));
                    prefabOfWindows.transform.SetAsLastSibling();

                    //add temp item to menu (Unity UI drop down bug)
                    GetComponent<TMP_Dropdown>().AddOptions(new List<string> { "empty" });

                    //remove such issue 
                    GetComponent<TMP_Dropdown>().SetValueWithoutNotify(3);
                    GetComponent<TMP_Dropdown>().options.RemoveAt(2);

                }
                break;

            case 1: //shut down
                Application.Quit();
                break;

                  
             default:
                Debug.LogError("No option found for value: " + optionChosen);
             break;
        }
    }

    /// <summary> IEnumerator <c>FadeToBlack</c> Fade out the screen </summary>
    IEnumerator FadeToBlack()
    {
        CanvasGroup cp = primaryCanvas.GetComponent<CanvasGroup>(); //get local UI window

        while (cp.alpha > 0) //while there's still screen to fade out..
        {
            cp.alpha -= Time.deltaTime / 2; //log removal 

            //stop cursor interaction
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            yield return null;

        }

        //display post day screen
        postDayCanvas.SetActive(true);

        cp.interactable = false;

        //allow cursor movement
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        OS.ChangeCursorBackToOrignalCursor();

        for(float t = 0.01f; t < 2f; t += 0.1f) //dither effect
        {
            shaderEffect.color0 = Color.Lerp(ditherEffect.gray, ditherEffect.black, t / 2f);
            yield return null;
        }

        primaryCanvas.SetActive(false);

        yield return null;
    }

}
