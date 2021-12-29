using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : Singleton<StageManager>
{
    public int stageIdx = 1;

    private Dictionary<int, int> stage_AnswerFiledCount = new Dictionary<int, int>();
    //private int[] stage~~ = new
    //stage[1]
    public Transform btnParent; //��ư �θ�
    private Button[] stageBtns; //�ΰ��� �̵� ��ư��

    private void Start()
    {
        #region ��ư ����
        stageBtns = btnParent.GetComponentsInChildren<Button>();

        for (int i = 0; i < stageBtns.Length; i++)
        {
            int idx = i;
            stageBtns[idx].onClick.AddListener(() =>
            {
                stageIdx = i + 1;
                //stageIdx�� ��� ī��Ʈ ��������
                SceneManager.LoadScene("InGame");

            });
        }   
        #endregion
    }

    public int GetCurStageBtnCount()
    {
        return stage_AnswerFiledCount[stageIdx];
    }
}
