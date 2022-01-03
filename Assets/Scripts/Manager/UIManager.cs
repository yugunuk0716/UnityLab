using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Transform panelParent;
    public MenuPopUp menuPopUp;


    public Button menuBtn;
    public Fade fade;

    private CanvasGroup cv;
    Dictionary<string, PopUp> panelDic = new Dictionary<string, PopUp>();
    Stack<PopUp> panelStack = new Stack<PopUp>();


    void Start()
    {
        fade = GetComponent<Fade>();
        cv = panelParent.GetComponent<CanvasGroup>();
        if (cv == null)
        {
            cv = panelParent.gameObject.AddComponent<CanvasGroup>();
        }
        cv.alpha = 0;
        cv.interactable = false;
        cv.blocksRaycasts = false;

        panelDic.Add("inGameMenu", Instantiate(menuPopUp, panelParent));

        menuBtn.onClick.AddListener(() => 
        {
            OpenPanel("inGameMenu");
        }); 
    }

    void Update()
    {
       
    }

    public void OpenPanel(string name, object data = null, int closeCount = 1) // UI 활성화 함수
    {
        if (panelStack.Count == 0)
        {
            cv.alpha = 1f;
            cv.interactable = true;
            cv.blocksRaycasts = true;
        }
        panelStack.Push(panelDic[name]);
        panelDic[name].Open(data, closeCount);
    }

    public void ClosePanel() // UI 비활성화 함수
    {
        //cv = panelStack.Peek().GetComponent<CanvasGroup>();
        panelStack.Pop().Close();
        if (panelStack.Count == 0)
        {
            cv.alpha = 0f;
            cv.interactable = false;
            cv.blocksRaycasts = false;
        }
    }

}
