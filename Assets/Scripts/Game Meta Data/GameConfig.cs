using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    [SerializeField] Texture2D cursor;
    [SerializeField] Texture2D waitHand;

    public bool onTriggerUpdateCursor = false;

    void Update()
    {
        if (onTriggerUpdateCursor)
        {
            StartCoroutine(ChangeCursorDelay());
            onTriggerUpdateCursor = false; 
        }
    }

    IEnumerator ChangeCursorDelay()
    {
        Cursor.SetCursor(waitHand, Vector2.zero, CursorMode.ForceSoftware);
        yield return new WaitForSeconds(0.5f);
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ChangeCursorBackToOrignalCursor() => Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
 

    public void ChangeCursorToMouseCursor()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
