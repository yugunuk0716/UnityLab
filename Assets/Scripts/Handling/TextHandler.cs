using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    HandleableObj dragObj;
    [SerializeField] private Transform dragObjsTemporaryParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.selectedObject.CompareTag("Handleable"))
        {
            dragObj = eventData.selectedObject.GetComponent<HandleableObj>();
            dragObj.transform.SetParent(dragObjsTemporaryParent);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragObj == null) return;
        dragObj.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragObj == null) return;

        foreach (GameObject item in eventData.hovered)
        {
            Debug.Log(item.name);
            TextArea textArea = item.GetComponentInChildren<TextArea>();
            if (textArea == null) continue;
            dragObj.transform.SetParent(textArea.transform);
            dragObj.transform.position = textArea.transform.position + new Vector3(215, 0, 0);

            if (textArea.Answer == dragObj.codeText) textArea.bCurAnswerisCurrect = true;
            GameManager.Instance.UsedBtnCountPlus();
            return;
        }

        dragObj.BackToOriginPosition();
        dragObj = null;
    }


}
