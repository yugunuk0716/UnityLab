using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : Singleton<StageManager>
{

    /// <summary>
    /// �� ������ �ΰ��ӿ��� ������ ���ָ� ���� ������ 1���� ������
    /// </summary>
    public int stageIdx = 1;

    public Transform btnParent; //��ư �θ�
    private Button[] stageBtns; //�ΰ��� �̵� ��ư��

    private void Awake()
    {
        


    }

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
                SceneManager.LoadScene("InGame");
            });
        }
        #endregion


    }
}
