using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int usedBtnCount; // 사용중인 단어나 문장 버튼
    private int textAreaCount;

    public GameObject answerParent;
    private TextArea[] textAreas;

    private void Start()
    {
        textAreas = answerParent.GetComponentsInChildren<TextArea>();
        usedBtnCount = 0;
        textAreaCount = textAreas.Length;
    }

    public void UsedBtnCountPlus()
    {
        usedBtnCount++;
        if(usedBtnCount == textAreaCount)
        {
            usedBtnCount = 0;
            foreach(TextArea item in GetTextAreas())
            {
                if (!item.bCurAnswerisCurrect)
                {
                    AnswerCheck.Instance.TextAreaClear(false);
                    return;
                }
            }

            // 정답임
            // 다음 스테이지 락 풀어주기
            Debug.Log("정답입니다");
        }
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
