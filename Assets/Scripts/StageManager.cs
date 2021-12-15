using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    /// <summary>
    /// 이 변수로 인게임에서 조절을 해주면 되지 않을까
    /// </summary>
    public int stageIdx = 1;

    public Transform btnParent;
    private Button[] stageBtns;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
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
    }
}
