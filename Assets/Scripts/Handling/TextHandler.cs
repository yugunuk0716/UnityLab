using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class TextHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    HandleableObj dragObj;
    [SerializeField] private Transform dragObjsTemporaryParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        try
        {
            if (eventData.selectedObject.CompareTag("Handleable"))
            {
                dragObj = eventData.selectedObject.GetComponent<HandleableObj>();
                dragObj.transform.SetParent(dragObjsTemporaryParent);
                dragObj.GetComponent<Image>().raycastTarget = false;
            }
        }
        catch
        {

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

        GameObject item = eventData.pointerCurrentRaycast.gameObject;
        if (item != null && (item.name.Contains("AnswerArea") || item.name.Contains("textPrefab")))
        {
            TextArea textArea = item.GetComponentInChildren<TextArea>();
            if (textArea != null)
            {
                dragObj.transform.SetParent(textArea.transform);
                dragObj.transform.position = textArea.transform.position + new Vector3(215, 0, 0);
                dragObj.GetComponent<Image>().raycastTarget = true;


                Debug.Log(textArea.Answer);
                Debug.Log(dragObj.GetComponentInChildren<TextMeshProUGUI>().text);

                if (textArea.Answer == dragObj.codeText)
                {
                    textArea.bCurAnswerisCurrect = true;
                    Debug.Log("����");
                }
                else
                {
                    Debug.Log("���� : " + textArea.Answer);
                }
                GameManager.Instance.UsedBtnCountPlus();
                dragObj = null;
                return;
            }
        }
        dragObj.GetComponent<Image>().raycastTarget = true;
        dragObj.BackToOriginPosition();
        dragObj = null;
    }
}
