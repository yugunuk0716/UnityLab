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
        testText.text = SetTextColor("김주형 병신","FFFFFF");

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
                print("김주형 병신");
            }
            else
            {
                print("김주형 장애인");
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
            //틀린것만
        }
        else
        {
            
            //모두 다
        }
        //텍스트 에리어에서 선택영역으로 단어를 옮기는 함수가 필요함
    }


    public string SetTextColor(string str, string colorCode) 
    {
        str = $"<color={colorCode}>{str}</color>";

        return str;
    }


}
