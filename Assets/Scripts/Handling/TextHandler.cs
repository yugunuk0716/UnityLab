using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    GameObject dragObj;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        try
        {
            if (eventData.selectedObject.CompareTag("DragableObj"))
            {
                dragObj = eventData.selectedObject;
            }
        }
        catch
        {
            // eventData.selectedObject 애가 오류라서..ㅠ
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        if (dragObj != null)
        {
            dragObj.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        foreach (GameObject item in eventData.hovered)
        {
            Debug.Log(item);
            TextArea textArea = item.GetComponent<TextArea>();
            if (textArea != null)
            {
                dragObj.transform.position = item.transform.position; 
                textArea.Answer = dragObj.GetComponent<HandleableObj>().codeText.text;
                
                break;
            }
        }
        dragObj = null;
    }
}
