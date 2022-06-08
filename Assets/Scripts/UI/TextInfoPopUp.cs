using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInfoPopUp : PopUp
{
    public Text textName;
    public Text textInfo;


    protected override void Awake()
    {
        base.Awake();
    }

    public void SetText(TextSO tSO) 
    {
        textName.text = tSO.textName;
        textInfo.text = tSO.textInfo;
    }

    public override void Open(int closeCount = 1)
    {
        base.Open(closeCount);
    }

    public override void OnClickHomeBtn(string str)
    {
        base.OnClickHomeBtn(str);
    }
}
