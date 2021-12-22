using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : Singleton<AnswerManager>
{
    public Dictionary<int, string> realAnswerList = new Dictionary<int, string>();

    public void CheckAnswer(List<string> userAnswerList) 
    {
        if (userAnswerList.Count == realAnswerList.Count) 
        {
            for (int i = 0; i < realAnswerList.Count; i++)
            {

            }
        }
    }
}
