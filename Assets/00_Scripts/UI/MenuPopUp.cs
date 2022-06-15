using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopUp : PopUp
{
    public Button continueBtn;
    public Button retryBtn;
    public Button homeBtn;
    public Button closeBtn;

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        closeBtn.onClick.AddListener(() => { Close(); });

        continueBtn.onClick.AddListener(() =>
        {
            Close();
        });
        homeBtn.onClick.AddListener(() => { StartCoroutine(UIManager.Instance.fade.FadeIn()); OnClickHomeBtn("Title");  });
        retryBtn.onClick.AddListener(() => { StartCoroutine(UIManager.Instance.fade.FadeIn()); OnClickRetryBtn();   });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
