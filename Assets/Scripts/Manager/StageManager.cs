using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : Singleton<StageManager>
{
    public int stageIdx = 1;
    public int[] stageInScriptsCount;
    private int buttonCount;

    public Transform btnParent; //��ư �θ�
    public Button[] stageBtns { get; private set; } //�ΰ��� �̵� ��ư


    private void Start()
    {
        stageInScriptsCount = new int[]
        {
            -1,1,2,3,2,1,2,2,1
        };
        #region ��ư ����
        stageBtns = btnParent.GetComponentsInChildren<Button>();
        buttonCount = stageBtns.Length;

        for (int i = 0; i < buttonCount; i++)
        {
            int idx = i;
            stageBtns[idx].onClick.AddListener(() =>
            {
                stageIdx = idx + 1;
                SceneManager.LoadScene("InGame");
            });
        }   
        #endregion
    }

}
