using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandleableObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string codeText;
    Vector3 originPos;
    private Transform originParent;

    private void Start()
    {
        originPos = this.transform.position;
        originParent = this.transform.parent;
    }

    public void BackToOriginPosition()
    {
        this.transform.position = originPos;
        this.transform.parent = originParent;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.OpenPanel("tInfo");
        TextInfoPopUp tInfo = (TextInfoPopUp)UIManager.Instance.panelDic["tInfo"];
        tInfo.SetText(AnswerManager.Instance.textInfoDictionary[codeText]);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.ClosePanel();
    }
}
