using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : Singleton<AnswerCheck>
{
    public bool isPremium = false;

    public List<string> answerList = new List<string>();

    //이제는 안쓰는 답 체크 함수
    /*
    public bool CheckAnswer(List<TextArea> userAnswerList, List<string> realAnswerList) 
    {
        bool result = false;

        userAnswerList.Sort((a, b) => b.transform.position.y.CompareTo(a.transform.position.y));

        if (isPremium) 
        {
            for (int i = 0; i < realAnswerList.Count; i++)
            {
                if (userAnswerList[i].Answer != realAnswerList[i])
                {
                    result = false;
                    userAnswerList.RemoveAt(i);
                }
                else
                {
                    result = true;
                }
            }
        }
        else
        {
            if (userAnswerList.Count == realAnswerList.Count)
            {
                for (int i = 0; i < realAnswerList.Count; i++)
                {
                    if (userAnswerList[i].Answer != realAnswerList[i])
                    {
                        userAnswerList.Clear();
                        return false;
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
        }

        return result;
    }
    */ 

    public void TextAreaClear(bool isPremiumm) // isPremium은 그 유료로 결제한사람? 그런거라고 하네요
    {
        if (isPremium) 
        {
            //틀린것만
        }
        else
        {
            HandleableObj[] objs = FindObjectsOfType<HandleableObj>();
            foreach(HandleableObj obj in objs)
            {
                obj.BackToOriginPosition();
            }
        }
    }


    public string SetTextColor(string str, string colorCode) 
    {
        str = $"<color={colorCode}>{str}</color>";

        return str;
    }


}
