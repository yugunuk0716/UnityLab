using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class AnswerManager : Singleton<AnswerManager>
{
    [SerializeField] private GameObject textPrefab;
    //[SerializeField] private GameObject buttonPrefab;
    //[SerializeField] private Transform buttonParent;
    [SerializeField] private GameObject answerArea;
    public Transform parentTrm;

    float answerAreaWidth;

    void Start()
    {
        answerAreaWidth = answerArea.GetComponent<RectTransform>().rect.width;
    }

    public void AnswerLoad(string path)
    {
        string[] strs = path.Split(',');

        foreach (string answer in strs)
        {
            //HandleableObj obj = Instantiate(buttonPrefab, buttonParent).GetComponent<HandleableObj>();
            //obj.codeText = answer;
        }
    }

    public GameObject OutPutText(string _str, int lineIdx,GameObject content)
    {
        GameObject text = Instantiate(textPrefab, content.transform);
        TextMeshProUGUI strText = text.transform.Find("text").GetComponent<TextMeshProUGUI>();
        Text lineIndex = text.transform.Find("LineIndex").GetComponent<Text>();
        lineIndex.text = "";

        if (_str.IndexOf("<blink>") != -1)
        {
            string[] strs = _str.Split(new string[] { "<blink>", "</blink>" }, StringSplitOptions.None);
            StartCoroutine(ParseText(strText, strs, text));

            if(lineIdx!=0)
            lineIndex.text = lineIdx.ToString();
            StartCoroutine(wait(strText, content));
            return text;
        }

        strText.text = _str;
        if (lineIdx != 0)
            lineIndex.text = lineIdx.ToString();

        StartCoroutine(wait(strText, content));
        return text;
    }

    public void verticalScaleUp(TextMeshProUGUI strText, GameObject content)
    {
        if (content.GetComponent<VerticalLayoutGroup>().padding.right < strText.bounds.size.x)
        {
            content.GetComponent<VerticalLayoutGroup>().padding.right = (int)(strText.bounds.size.x + answerAreaWidth * 2.5f); // 3개이상 안드감
        }
    }
    public IEnumerator wait(TextMeshProUGUI strText, GameObject content)
    {
        yield return null;
        verticalScaleUp(strText, content);
    }

    public IEnumerator ParseText(TextMeshProUGUI StrText, string[] strs, GameObject text)
    {
        StrText.text = "";
        for (int i = 0; i < strs.Length; i++)
        {
            if (i % 2 != 0)
            {
                testMake(StrText);
                strs[i] = "                 "; 
			}
            StrText.text += strs[i];
            yield return null;
        }
    }


    public void testMake(TextMeshProUGUI tmp_text)
    {
        GameObject area = Instantiate(answerArea, tmp_text.transform.parent);
        area.GetComponent<RectTransform>().anchoredPosition = new Vector3(100+tmp_text.bounds.size.x,0);
    }

}
