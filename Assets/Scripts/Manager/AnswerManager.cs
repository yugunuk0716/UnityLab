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


	public GameObject OutPutText(string _str,int lineIdx)
	{
		GameObject text = Instantiate(textPrefab,content);
		//TextArea data = text.GetComponent<TextArea>();
		TextMeshProUGUI strText = text.transform.Find("text").GetComponent<TextMeshProUGUI>();
		Text lineIndex = text.transform.Find("LineIndex").GetComponent<Text>();

		if (_str.IndexOf("<blink>")!=-1)
		{
			string[] strs = _str.Split(new string[] { "<blink>", "</blink>" }, StringSplitOptions.None);
			int idx = 0;
			for (int i = 0; i < strs.Length; i++)
			{
				
				if (i % 2 != 0)
				{
					//박스 생성 만들면됨(strs[i]);
					//strs[i] = "                                ";
					strs[i] = " ";
				}

				StartCoroutine(ParseText(strText, strs, i));
			}
			lineIndex.text = lineIdx.ToString();
			return text;
		}

		strText.text = _str;
		lineIndex.text = lineIdx.ToString();

		return text;
	}


	public IEnumerator ParseText(TextMeshProUGUI StrText, string[] strs, int i)
	{
		int idx = 0;
		yield return null;
		StrText.text += strs[i];
		idx = StrText.GetParsedText().Length;
		string a = StrText.GetParsedText();


		Debug.Log(StrText.GetParsedText().Length);
	}
}
