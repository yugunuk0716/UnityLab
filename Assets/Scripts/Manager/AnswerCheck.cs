using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : Singleton<AnswerCheck>
{
    public bool isPremium = false;

    public List<string> answerList = new List<string>();

    public Text testText;

    private void Start()
    {
        testText.text = SetTextColor("������ ����","FFFFFF");

        answerList.Add("a");
        answerList.Add("b");
        answerList.Add("c");
        answerList.Add("d");
        answerList.Add("e");
        answerList.Add("f");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

            if (CheckAnswer(GameManager.Instance.GetTextAreas(), answerList)) 
            {
                print("������ ����");
            }
            else
            {
                print("������ �����");
            }
        }
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
            
            //��� ��
        }
        //�ؽ�Ʈ ������� ���ÿ������� �ܾ �ű�� �Լ��� �ʿ���
    }


    public string SetTextColor(string str, string colorCode) 
    {
        str = $"<color={colorCode}>{str}</color>";

        return str;
    }


}
