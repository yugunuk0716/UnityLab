using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : Singleton<AnswerCheck>
{
    public void TextAreaClear() // isPremium�� �� ����� �����ѻ��? �׷��Ŷ�� �ϳ׿�
    {
        HandleableObj[] objs = FindObjectsOfType<HandleableObj>();
        foreach (HandleableObj obj in objs)
        {
            obj.BackToOriginPosition();
        }
    }

    //�����ÿ� Ư���ִ� ����, ������ �ȽἭ �ٲ�����
    /*
    public bool isPremium = false;
    public void TextAreaClear(bool isPremiumm) // isPremium�� �� ����� �����ѻ��? �׷��Ŷ�� �ϳ׿�
    {
        if (isPremium)
        {
            //Ʋ���͸�
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
