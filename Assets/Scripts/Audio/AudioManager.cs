using System.Collections;
using UnityEngine;

/// <summary> Class <c>AudioManager</c> Audio logic within the project </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicPlayer = default; 

    //all game sounds
    [SerializeField] AudioClip computerSong = default;
    [SerializeField] AudioClip menuSong = default;
    [SerializeField] AudioClip alarmClock = default;
    [SerializeField] AudioClip finalSong = default;

    //all game screens
    [SerializeField] Canvas menu = default;
    [SerializeField] Canvas preWorkDay = default;
    [SerializeField] Canvas postWorkDay = default;
    [SerializeField] Canvas endScreen = default;

    void Start() => StartCoroutine(WaitTillEndOfFrame());

    /// <summary> Method <c>WaitTillEndOfFrame</c> Allow music to play until end of frame </summary>
    IEnumerator WaitTillEndOfFrame()
    {
        /*
         * Typically when dealing with same frame audio,
         * certain issues can arrive. 
         */
        yield return new WaitForEndOfFrame();

        musicPlayer.enabled = true;

        UnmuteCurrentTrack();
    }

    enum AUDIOSTATE { sMenu, sPreDay, sEndScreen, sPostDay, sEndMenu} //all active music states

    AUDIOSTATE audioState = AUDIOSTATE.sMenu; //dynamic active satte 

    void Update()
    {
        ManageState();

        PlayAudio();
    }

    /// <summary> Method <c>ManageState</c> Manages the state of game-wide audio state </summary>
    public void ManageState()
    {
        /**
         * Due to the odd nature of Unity's audio source not playing at instanced times the state is managed here,
         * Audio state manager is able to fix
         */
        if (menu.isActiveAndEnabled)

            audioState = AUDIOSTATE.sMenu;

        else if (preWorkDay.isActiveAndEnabled && musicPlayer.clip == menuSong || preWorkDay.isActiveAndEnabled && musicPlayer.clip == computerSong)
        {

            audioState = AUDIOSTATE.sPreDay;

        }
        else if (endScreen.isActiveAndEnabled && musicPlayer.enabled == false)
        {

            audioState = AUDIOSTATE.sEndScreen;

        }
        else if (postWorkDay.isActiveAndEnabled && musicPlayer.clip == computerSong)
        {

            audioState = AUDIOSTATE.sPostDay;

        }
        else if (!menu.isActiveAndEnabled && !preWorkDay.isActiveAndEnabled && !postWorkDay.isActiveAndEnabled && musicPlayer.clip != computerSong && !endScreen.isActiveAndEnabled)
        {

            audioState = AUDIOSTATE.sEndMenu;

        }
    }

    /// <summary> Method <c>PlayAudio</c> Play audio based on audio state </summary>
    public void PlayAudio()
    {
        switch (audioState)
        {

            case AUDIOSTATE.sMenu:

                musicPlayer.clip = menuSong;

                break;

            case AUDIOSTATE.sPreDay:

                musicPlayer.clip = alarmClock;
                musicPlayer.enabled = false;
                StartCoroutine(WaitTillEndOfFrame());

                break;

            case AUDIOSTATE.sEndScreen:

                musicPlayer.enabled = false;
                musicPlayer.clip = finalSong;
                StartCoroutine(WaitTillEndOfFrame());
                break;

            case AUDIOSTATE.sPostDay:
                musicPlayer.enabled = false;
                break;

            case AUDIOSTATE.sEndMenu:
                musicPlayer.clip = computerSong;
                musicPlayer.enabled = false;
                StartCoroutine(WaitTillEndOfFrame());
                break; 
        }
    }

    public void MuteCurrentTrack() => musicPlayer.mute = true;

    public void UnmuteCurrentTrack() => musicPlayer.mute = false; 
}
