using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class AnswerManager : Singleton<AnswerManager>
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject fakeTxt;

    public GameObject answerArea;
    public Transform parentTrm;

	private void Start()
	{

    }

	public GameObject OutPutText(string _str, int lineIdx)
    {
        GameObject text = Instantiate(textPrefab, content);
        //TextArea data = text.GetComponent<TextArea>();
        TextMeshProUGUI strText = text.transform.Find("text").GetComponent<TextMeshProUGUI>();
        Text lineIndex = text.transform.Find("LineIndex").GetComponent<Text>();
        //strText.ForceMeshUpdate();

        if (_str.IndexOf("<blink>") != -1)
        {
            string[] strs = _str.Split(new string[] { "<blink>", "</blink>" }, StringSplitOptions.None);
            StartCoroutine(ParseText(strText, strs, text));

            lineIndex.text = lineIdx.ToString();
            return text;
        }

        strText.text = _str;
        lineIndex.text = lineIdx.ToString();

        return text;
    }


    public IEnumerator ParseText(TextMeshProUGUI StrText, string[] strs, GameObject text)
    {
        yield return null;
        int idx = 0;
        StrText.text = "";
        TextMeshProUGUI fake = Instantiate(fakeTxt, StrText.transform.parent).GetComponent<TextMeshProUGUI>();
        
        fake.text = "";
        for (int i = 0; i < strs.Length; i++)
        {
            if (i % 2 != 0)
            {
                yield return null;
                fake.text = fake.GetParsedText();
                StartCoroutine(MakeAnswerArea(fake, idx, text.transform));
				strs[i] = "                                "; // 공백32개
				Debug.Log("텍스트 : " + fake.text);
				Debug.Log("문자열 길이 : " + fake.text.Length);
				Debug.Log("인덱스 : " + idx);
			}

            string test = strs[i].Replace(' ', 'a');
            fake.text += test; // 공백은 a로 바꿔서
            StrText.text += strs[i]; // 공백채워주기
            yield return null;
            idx = fake.GetParsedText().Length;
        }
    }


    IEnumerator MakeAnswerArea(TextMeshProUGUI tmp_text, int index, Transform parent)
    {
        yield return null;
        tmp_text.ForceMeshUpdate();
        tmp_text.UpdateVertexData();    
        yield return null;

        Vector3[] vertices = tmp_text.mesh.vertices;
        TMP_CharacterInfo charInfo = tmp_text.textInfo.characterInfo[tmp_text.textInfo.characterCount - 1];
        int vertexIndex = charInfo.vertexIndex;

        foreach(var item in vertices)
        {
            Debug.Log(item);
        }

        Debug.Log(vertices.Length);
        Debug.Log(vertexIndex);

        Vector2 charMidTopLine = new Vector2( vertices[vertexIndex ].x, (charInfo.bottomLeft.y + charInfo.topLeft.y) / 2);
        Vector3 worldPos = tmp_text.transform.TransformPoint(charMidTopLine);
        Instantiate(answerArea, worldPos, Quaternion.identity, parent);
    }
}
