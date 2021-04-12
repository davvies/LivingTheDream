using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary> Class <c>FileDrag</c> Drop down file settings menus</summary>
public class FileSettings : MonoBehaviour
{
    [SerializeField] GameObject mainPanel = default;

	const string windowTag = "Window";
	
	/// <summary> Method <c>SetFileSettings</c> Functionality for any drop down click</summary>
    public void SetFileSettings(int optionChosen)
    {
		//optionChosen param correlates to the drop down member chosen
		
		//switch used for ease of expansion, should one decide to add more menu options
        switch (optionChosen)
        {
            case 0: 
			
				//O(n) searching needed due to Unity not allowing ease of closing UI objects
                foreach(Transform screenObj in mainPanel.transform)
                {
                    if (screenObj.name.Contains(windowTag))
                    
                        screenObj.gameObject.SetActive(false); //hide drop down
                    
                }
                break;

            default:
			
                Debug.LogError("No option found for value: " + optionChosen); //fail safe
				
                break;
        }

		/*
		there's a bug within the unity drop down UI compontent that a lit of only one member,
		the following functionality aims to create an empty list member, and delete it.
							**THIS IS THE ONLY WAY AROUND SUCH ISSUE**
		*/
        GetComponent<TMP_Dropdown>().AddOptions(new List<string> { "empty" }); //add temp menu option 	

		//remove value
        GetComponent<TMP_Dropdown>().SetValueWithoutNotify(2); 
        GetComponent<TMP_Dropdown>().options.RemoveAt(1);
    }
}
