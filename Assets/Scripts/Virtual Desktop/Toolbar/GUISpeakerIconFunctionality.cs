using UnityEngine;
using UnityEngine.UI;

/// <summary> Class <c>GUISpeakerIconFunctionalirt</c> In-game incon representation of audio state </summary>
public class GUISpeakerIconFunctionality : MonoBehaviour
{
    public AudioSource levelAudio; //audio level

    //state images for audio
    public Texture audioPlaying;
    public Texture audioStopped;

    //image component
    RawImage thisIcon;
    
    void Start()
    {
        thisIcon = GetComponent<RawImage>();
     
        //default state is muted
        thisIcon.texture = audioStopped;
    }

    void Update() => thisIcon.texture = !levelAudio.mute ? audioPlaying : audioStopped; //update state of audio icon
        
    
}
