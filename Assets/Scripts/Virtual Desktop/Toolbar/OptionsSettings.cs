using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Class <c>OptionsSettings</c> Audio drop down toolbar settings</summary>
public class OptionsSettings : MonoBehaviour
{
    [SerializeField] AudioSource primaryAudio;

	/// <summary> Method <c>SetOptionsSettings</c> Functionality for moving windows and icons</summary>
    public void SetOptionsSettings(int optionChosen)
    {
        switch (optionChosen)
        {
            case 0: //mute
                primaryAudio.mute = true;
                break;

            case 1: //unmute
                primaryAudio.mute = false;
                break;

            default:
                Debug.LogError("No option found for value: " + optionChosen);
                break;
        }
    }
}
