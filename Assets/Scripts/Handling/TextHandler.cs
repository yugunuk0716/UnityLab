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
        if (eventData.selectedObject != null && eventData.selectedObject.CompareTag("DragableObj"))
        {
            dragObj = eventData.selectedObject;
            GameManager.Instance.UsedBtnCountMinus();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragObj != null)
        {
            dragObj.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        foreach (GameObject item in eventData.hovered)
        {
            TextArea textArea = item.GetComponent<TextArea>();
            if (textArea != null)
            {
                dragObj.transform.position = item.transform.position;
                textArea.Answer = dragObj.GetComponent<HandleableObj>().codeText.text;
                GameManager.Instance.UsedBtnCountPlus();
                break;
            }
        }
    }
}
