using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : Singleton<AnswerManager>
{
    [SerializeField] private GameObject answerArea;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonsParent;

    public int nowMaxTextLength = 0;

    public List<TextSO> texts = new List<TextSO>();
    public Dictionary<string, TextSO> textInfoDictionary = new Dictionary<string, TextSO>();

    private void Awake()
    {
        foreach (TextSO text in texts)
        {
            textInfoDictionary.Add(text.textName, text);
        }
    }

    public IEnumerator AnswerLoad(string str)
    {
        string[] answers = str.Split(',');
        foreach(var item in answers)
        {
            HandleableObj obj = Instantiate(buttonPrefab, buttonsParent).GetComponent<HandleableObj>();
            TextMeshProUGUI t = obj.GetComponentInChildren<TextMeshProUGUI>();
            t.text = item;
            yield return null;
            obj.codeText = t.GetParsedText();
            yield return null;
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

            if(lineIdx!=0)  lineIndex.text = lineIdx.ToString();
            StartCoroutine(wait(strText, content));
            Debug.Log("실행한다 했다!");
            return text;
        }
        strText.text = _str;

        if (lineIdx != 0) lineIndex.text = lineIdx.ToString();
        StartCoroutine(wait(strText, content));
        return text;
    }

    public void verticalScaleUp(TextMeshProUGUI strText, GameObject content)
    {
        VerticalLayoutGroup vlg = content.GetComponent<VerticalLayoutGroup>();
        if (strText.text.Length > vlg.padding.right/12)
        {
            vlg.padding.right = strText.text.Length * 12;
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
                Debug.Log("답안 문자열 : " + strs[i]);
                testMake(StrText);
                TextArea [] areas = StrText.transform.parent.GetComponentsInChildren<TextArea>();
                TextArea makeArea = null;
                foreach(TextArea item in areas)
                {
                    if(item.isUsed == false)
                    {
                        makeArea = item;
                        makeArea.isUsed = true;
                        break;
                    }
                }

                if (makeArea != null)
                {
                    makeArea.GetComponentInChildren<TextMeshProUGUI>().text = strs[i];
                    yield return null;
                    makeArea.Answer = makeArea.GetComponentInChildren<TextMeshProUGUI>().GetParsedText();
                    yield return null;
                }
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
