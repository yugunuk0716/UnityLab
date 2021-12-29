using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : Singleton<AnswerCheck>
{
    public bool isPremium = false;

    public List<string> answerList = new List<string>();

    //������ �Ⱦ��� �� üũ �Լ�
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

    public void TextAreaClear(bool isPremiumm) // isPremium�� �� ����� �����ѻ��? �׷��Ŷ�� �ϳ׿�
    {
        if (isPremium) 
        {
            //Ʋ���͸�
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
