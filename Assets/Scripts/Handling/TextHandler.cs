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
        TextArea textArea;
        foreach (GameObject item in eventData.hovered)
        {
            textArea = item.GetComponent<TextArea>();
            if (textArea != null)
            {
                dragObj.transform.position = item.transform.position;
                string dragCodeText = dragObj.GetComponent<HandleableObj>().codeText.text;

                if (textArea.Answer == dragCodeText)
                {
                    textArea.bCurAnswerisCurrect = true;
                    textArea.Answer = dragCodeText;
                }

                GameManager.Instance.UsedBtnCountPlus();
                Debug.Log("답안 버튼 하나 사용");
                return;
            }
        }

        // 드래그 끝낸 곳이 적절한 위치가 아니면 원위치
        dragObj.GetComponent<HandleableObj>().BackToOriginPosition();
    }
}
