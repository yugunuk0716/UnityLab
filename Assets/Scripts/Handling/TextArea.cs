using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextArea : MonoBehaviour
{
    public string Answer;
    public int index;

    public void AddMyDatasToAnswerDict()
    {
        AnswerManager.Instance.realAnswerList.Add(Answer);
    }
}
