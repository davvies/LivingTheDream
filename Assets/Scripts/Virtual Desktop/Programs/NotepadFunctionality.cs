using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>Class <c>NotepadFunctionality</c> Handle functionality for in-game notepad</summary>
public class NotepadFunctionality : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pageNumber; //visible page number on notepad 
    [SerializeField] TMP_InputField inputField; //notepad text
	
    int pageCounter = 1; //page counter initially starts with one 

    void Start()
    {
        pageCounter = 1;
        inputField.text = string.Empty;
    }

    void OnEnable() => pageCounter = 1; //reset page after window re-opens

    public void UpdatePage()
    {
		//Handle event after the user clicks the corner of a page
        pageCounter++;
        pageNumber.text = pageCounter.ToString(); //visual display and update of page number
        inputField.text = string.Empty;
    }

    public void OnDisable()
    {
		//Handle event for window closing
        inputField.text = string.Empty;
        pageCounter = 1;
        pageNumber.text = pageCounter.ToString();
    }

}
