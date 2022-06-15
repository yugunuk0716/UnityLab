using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ClearPopUp : PopUp
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void Open(int closeCount = 1)
    {
        base.Open(closeCount);
        StartCoroutine(Clear());
    }

    public override void OnClickHomeBtn(string str)
    {
        base.OnClickHomeBtn(str);
    }

    IEnumerator Clear() 
    {
        yield return new WaitForSeconds(2f);

        OnClickHomeBtn("Title");

    }
}
