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

	private void Start()
	{

	}
	public GameObject OutPutText(string _str,int lineIdx)
	{
		GameObject text = Instantiate(textPrefab,content);
		//TextArea data = text.GetComponent<TextArea>();
		TextMeshProUGUI strText = text.transform.Find("text").GetComponent<TextMeshProUGUI>();
		Text lineIndex = text.transform.Find("LineIndex").GetComponent<Text>();
		//strText.ForceMeshUpdate();

		if (_str.IndexOf("<blink>")!=-1)
		{
			string[] strs = _str.Split(new string[] { "<blink>", "</blink>" }, StringSplitOptions.None);
			StartCoroutine(ParseText(strText, strs,text));
			
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
				CreateAnswerArea(text, idx);
				strs[i] = "                                ";
				//strs[i] = "      ";
			}
			StrText.text += strs[i];
			yield return null;
			idx = StrText.GetParsedText().Length;
		}
	}
	public void CreateAnswerArea(GameObject text, int index)
	{
	 	GameObject answer= Instantiate(answerArea, text.transform);
		RectTransform anwserTrm = answer.GetComponent<RectTransform>();


	}
	public void MakeAnswerArea(TextMeshProUGUI tmp_text,int index)
	{
		Debug.Log(index);
		Vector3[] vertices = tmp_text.mesh.vertices;
		TMP_CharacterInfo charInfo = tmp_text.textInfo.characterInfo[index];
		int vertexIndex = charInfo.vertexIndex;
		Vector2 charMidTopLine = new Vector2((vertices[vertexIndex + 0].x + vertices[vertexIndex + 2].x) / 2, (charInfo.bottomLeft.y + charInfo.topLeft.y) / 2);
		Vector3 worldPos = tmp_text.transform.TransformPoint(charMidTopLine);
		Instantiate(answerArea, worldPos, Quaternion.identity, parentTrm);
	}
}
