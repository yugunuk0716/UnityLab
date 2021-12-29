using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int usedBtnCount; // 사용중인 단어나 문장 버튼


    public GameObject answerParent;
    private TextArea[] textAreas;

    private void Start()
    {
        usedBtnCount = 0;
        textAreas = answerParent.GetComponentsInChildren<TextArea>();
    }

    public void UsedBtnCountPlus()
    {
        usedBtnCount++;
        //if(usedBtnCount == StageManager.Instance.GetCurStageBtnCount())
        //{
        //    // 여기서 이제 리스트 다 받아 와서 체크
        //}
    }

    public void UsedBtnCountMinus()
    {
        usedBtnCount--;
    }

    public List<TextArea> GetTextAreas() 
    {
        List<TextArea> answer = new List<TextArea>();

        for (int i = 0; i < textAreas.Length; i++)
        {
            answer.Add(textAreas[i]);
        }

        return answer;
    }
}
