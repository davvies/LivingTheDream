using System.Collections;
using UnityEngine;

/// <summary> Class <c>GameConfig</c> Set up for any in-game configuration (used for mouse) </summary>
public class GameConfig : MonoBehaviour
{
    const float cursorUpdateTime = 0.5f;

    //cursor images used in dynamic clicking of objects
    [SerializeField] Texture2D cursor;
    [SerializeField] Texture2D waitHand;

    public bool onTriggerUpdateCursor = false; 

    void Update()
    {
        if (onTriggerUpdateCursor)
        {
            //update cursor event
            StartCoroutine(ChangeCursorDelay());
            onTriggerUpdateCursor = false; //stop continually updating calls 
        }
    }

    /// <summary> Method <c>ChangeCursorDelay</c> Changing of the mouse cursor </summary>
    IEnumerator ChangeCursorDelay()
    {
        Cursor.SetCursor(waitHand, Vector2.zero, CursorMode.ForceSoftware);
        yield return new WaitForSeconds(cursorUpdateTime);
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    /// <summary> Method <c>ChangeCursorBackToOriginalCursor</c> Changing of the mouse cursor back to the standard </summary>
    public void ChangeCursorBackToOrignalCursor() => Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

    /// <summary> Method <c>ChangeCursorToHandSymbol</c> Changing of the mouse cursor to a hand icon </summary>
    public void ChangeCursorToHandSymbol()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
