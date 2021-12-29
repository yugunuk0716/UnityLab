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

            // ������
            // ���� �������� �� Ǯ���ֱ�
            Debug.Log("�����Դϴ�");
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
