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

    public GameObject answerArea;
    public Transform parentTrm;


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
        int idx = 0;
        StrText.text = "";
        for (int i = 0; i < strs.Length; i++)
        {
            if (i % 2 != 0)
            {
                MakeAnswerArea(StrText, idx, text.transform);
                strs[i] = "                                "; // ����32��
                Debug.Log("�ؽ�Ʈ : " + StrText.text);
                Debug.Log("���ڿ� ���� : " + StrText.text.Length);
                Debug.Log("�ε��� : " + idx);
                Debug.Log("�ε��� �ش� �ؽ�Ʈ : " + StrText.text[idx]);
                Debug.Log("�ε���-1 �ش� �ؽ�Ʈ : " + StrText.text[idx - 1]);
                Debug.Log("�ε���+1 �ش� �ؽ�Ʈ : " + StrText.text[idx + 1]);
            }
            StrText.text += strs[i];
            yield return null;
            idx = StrText.GetParsedText().Length;
        }
    }



    public void MakeAnswerArea(TextMeshProUGUI tmp_text, int index, Transform parent)
    {
        Debug.Log(index);
        tmp_text.ForceMeshUpdate();
        Vector3[] vertices = tmp_text.mesh.vertices;
        TMP_CharacterInfo charInfo = tmp_text.textInfo.characterInfo[index - 1];
        Debug.Log(tmp_text.textInfo.characterInfo[index - 1].character.ToString());
        int vertexIndex = charInfo.vertexIndex;
        Debug.Log(vertices.Length);

        Vector2 charMidTopLine = new Vector2((vertices[index - 1].x) / 2, (charInfo.bottomLeft.y + charInfo.topLeft.y) / 2);
        Vector3 worldPos = tmp_text.transform.TransformPoint(charMidTopLine);
        GameObject charPositionGameObj = Instantiate(answerArea, parent);
        charPositionGameObj.transform.position = worldPos;
    }
}
