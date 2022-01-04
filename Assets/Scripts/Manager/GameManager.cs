using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int usedBtnCount = 0; // 사용중인 단어나 문장 버튼
    private int textAreaCount;

    public GameObject answerParent;
    public TextArea[] textAreas;

    private void Start()
    {
        textAreas = FindObjectsOfType<TextArea>();
        textAreaCount = textAreas.Length;
    }

    public void UsedBtnCountPlus()
    {
        usedBtnCount++;
        CheckClear();
    }

    public void CheckClear()
    {
        if (usedBtnCount == textAreaCount)
        {
            usedBtnCount = 0; // 정답이든 아니든 사용한 갯수 0으로 초기화 해주기!

            foreach (TextArea item in GetTextAreas())
            {
                if (!item.bCurAnswerisCurrect)
                {
                    AnswerCheck.Instance.TextAreaClear();
                    return;
                }
            }

            UIManager.Instance.OpenPanel("clear");
            StageManager.instance.SaveData();
            Debug.Log("정답입니다");
        }
    }

    public TextArea[] GetTextAreas() 
    {
        return textAreas;
    }
}
