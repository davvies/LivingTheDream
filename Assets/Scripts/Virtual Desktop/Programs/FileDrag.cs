using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> Class <c>FileDrag</c> Functionality for moving windows and icons</summary>
public class FileDrag : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField] RectTransform dragRectTransform; //UI context

    [SerializeField] Canvas screen;
	
	const string ic = "icon";
	
	//move icon/window relative to framerate
    public void OnDrag(PointerEventData eventData) => dragRectTransform.anchoredPosition += eventData.delta; 


    public void CloseDrag() => gameObject.SetActive(false);

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!name.Contains(ic)) 
   
            gameObject.transform.SetAsLastSibling(); //layered formatting for dragged icons
        
    }
}

