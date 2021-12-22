using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : Singleton<AnswerManager>
{
    public bool isPremium = false;

    public List<string> realAnswerList = new List<string>();

    public bool CheckAnswer(List<string> userAnswerList, List<string> realAnswerList) 
    {
        bool result = false;
        if (isPremium) 
        {

            for (int i = 0; i < realAnswerList.Count; i++)
            {
                if (userAnswerList[i] != realAnswerList[i])
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
                    if (userAnswerList[i] != realAnswerList[i])
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


}
