using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int usedBtnCount; // ������� �ܾ ���� ��ư


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
        //    // ���⼭ ���� ����Ʈ �� �޾� �ͼ� üũ
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
