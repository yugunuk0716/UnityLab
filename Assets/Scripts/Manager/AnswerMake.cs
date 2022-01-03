using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerMake : MonoBehaviour
{
    public GameObject answerArea;
    public RectTransform answerTrm;



    public void AnswerLoad(string path) 
    {
        string[] strs = path.Split(',');

        foreach(string answer in strs)
        {
            HandleableObj obj = Instantiate(answerArea, answerTrm).GetComponent<HandleableObj>();
            obj.codeText = answer;
        }
    }
}
