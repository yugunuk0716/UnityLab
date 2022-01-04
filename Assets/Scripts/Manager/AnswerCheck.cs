using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : Singleton<AnswerCheck>
{
    public bool isPremium = false;

    public List<string> answerList = new List<string>();

    public void TextAreaClear() // isPremium은 그 유료로 결제한사람? 그런거라고 하네요
    {
        HandleableObj[] objs = FindObjectsOfType<HandleableObj>();
        foreach (HandleableObj obj in objs)
        {
            obj.BackToOriginPosition();
        }
    }

    //결제시에 특혜주는 로직, 지금은 안써서 바꿔놨어요
    /*
    public void TextAreaClear(bool isPremiumm) // isPremium은 그 유료로 결제한사람? 그런거라고 하네요
    {
        if (isPremium)
        {
            //틀린것만
        }
        else
        {
            HandleableObj[] objs = FindObjectsOfType<HandleableObj>();
            foreach (HandleableObj obj in objs)
            {
                obj.BackToOriginPosition();
            }
        }
    }
    */
}
