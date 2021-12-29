using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : Singleton<AnswerCheck>
{
    public bool isPremium = false;

    public List<string> answerList = new List<string>();

    public Text testText;

    public bool isignore = false;

    private void Start()
    {
        if (isignore)
            return;
 
    }


    private void Update()
    {
        if (isignore)
            return;

    }

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


    public void TextAreaClear(bool isPremiumm) 
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
        //�ؽ�Ʈ ������� ���ÿ������� �ܾ �ű�� �Լ��� �ʿ���
    }


    public string SetTextColor(string str, string colorCode) 
    {
        str = $"<color={colorCode}>{str}</color>";

        return str;
    }


}
