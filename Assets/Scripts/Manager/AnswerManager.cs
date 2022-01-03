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
    [SerializeField] private VerticalLayoutGroup verticalGroup;

    public GameObject answerArea;
    public Transform parentTrm;

    void Start()
    {
        //OutPutText("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa<blink>aa</blink>aaaa", 55);
    }
	public GameObject OutPutText(string _str, int lineIdx,GameObject content)
    {
        GameObject text = Instantiate(textPrefab, content.transform);
        //TextArea data = text.GetComponent<TextArea>();
        TextMeshProUGUI strText = text.transform.Find("text").GetComponent<TextMeshProUGUI>();
        Text lineIndex = text.transform.Find("LineIndex").GetComponent<Text>();
        lineIndex.text = "";
        //strText.ForceMeshUpdate();

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
            print(strText.rectTransform.rect.width);
            content.GetComponent<VerticalLayoutGroup>().padding.right = (int)strText.rectTransform.rect.width + 50;
        }
    }
    public IEnumerator wait(TextMeshProUGUI strText, GameObject content)
    {
        yield return null;
        verticalScaleUp(strText, content);
    }

    public IEnumerator ParseText(TextMeshProUGUI StrText, string[] strs, GameObject text)
    {
        int idx = 0;
        StrText.text = "";
       // TextMeshProUGUI fake = Instantiate(fakeTxt, StrText.transform.parent).GetComponent<TextMeshProUGUI>();
        
        //fake.text = "";
        for (int i = 0; i < strs.Length; i++)
        {
            if (i % 2 != 0)
            {
                //MakeAnswerArea(fake, idx, text.transform);
                testMake(StrText);
                strs[i] = "                 "; // 공백17개
                //print("A"+idx);
                //print("B"+fake.text.Length);
				//Debug.Log("텍스트 : " + fake.text);
				//Debug.Log("문자열 길이 : " + fake.text.Length);
				//Debug.Log("인덱스 : " + idx);
				//Debug.Log("인덱스 해당 텍스트 : " + fake.text[idx]);
				//Debug.Log("인덱스-1 해당 텍스트 : " + fake.text[idx - 1]);
				//Debug.Log("인덱스+1 해당 텍스트 : " + fake.text[idx + 1]);
			}

            //string test = strs[i].Replace(' ', 'a');
            //fake.text += test;
            //yield return null;
            //fake.text = fake.GetParsedText();
            StrText.text += strs[i];

            yield return null;
            idx = StrText.GetParsedText().Length;
        }
    }


    public void testMake(TextMeshProUGUI tmp_text)
    {
        GameObject area = Instantiate(answerArea, tmp_text.transform.parent);
        print(tmp_text.bounds.size.x);
        area.GetComponent<RectTransform>().anchoredPosition = new Vector3(100+tmp_text.bounds.size.x,0);
    }
    //public void MakeAnswerArea(TextMeshProUGUI tmp_text, int index, Transform parent)
    //{
    //    Debug.Log("index : " + index);
    //    tmp_text.ForceMeshUpdate();
    //    Vector3[] vertices = tmp_text.mesh.vertices;
    //    TMP_CharacterInfo charInfo = tmp_text.textInfo.characterInfo[index - 1];
    //    int vertexIndex = charInfo.vertexIndex;
    //    Debug.Log("vertices : " + vertices.Length);
    //    Debug.Log("vertexIndex : " + vertexIndex);

    //    Vector2 charMidTopLine = new Vector2((vertices[vertexIndex / 2 - 1].x + vertices[vertexIndex / 2 - 2].x) / 2, (charInfo.bottomLeft.y + charInfo.topLeft.y) / 2);
    //    Vector3 worldPos = tmp_text.transform.TransformPoint(charMidTopLine);
    //    GameObject charPositionGameObj = Instantiate(answerArea, parent);
    //    charPositionGameObj.transform.position = worldPos;
    //}
}
