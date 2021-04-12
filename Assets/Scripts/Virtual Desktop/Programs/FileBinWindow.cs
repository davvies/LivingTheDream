using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Class <c>FileBinWindow</c> Functionality for desktop recycling bin </summary>
public class FileBinWindow : MonoBehaviour
{
    [SerializeField] GameObject fileWindowDialogBox; //sprite reference to window
	
    [SerializeField] GameConfig OS; 
	
	/// <summary> Method <c>OnClickDelete</c> Empty recycling bin </summary>
    public void OnClickDelete()
    {
        if (!fileWindowDialogBox.gameObject.activeSelf) //assuming the window is closed..
			
			fileWindowDialogBox.gameObject.SetActive(true); //display
		
        fileWindowDialogBox.transform.SetAsLastSibling(); //ensure container is visible
        OS.onTriggerUpdateCursor = true; //update the cursor after the click event (minor detail)
    }
}
