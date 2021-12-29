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
        if(usedBtnCount == textAreas.Length)
        {
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
