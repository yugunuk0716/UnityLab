using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : Singleton<AnswerManager>
{
	[SerializeField] private Transform content;
	[SerializeField] private GameObject textPrefab;

	private void Start()
	{

	}
	public GameObject OutPutText(string _str,int lineIdx)
	{
		GameObject text = Instantiate(textPrefab,content);
		//TextArea data = text.GetComponent<TextArea>();
		TextMeshProUGUI strText = text.transform.Find("text").GetComponent<TextMeshProUGUI>();
		Text lineIndex = text.transform.Find("LineIndex").GetComponent<Text>();

		if (_str.IndexOf("<blink>")!=-1)
		{
			string[] strs = _str.Split(new string[] { "<blink>", "</blink>" }, StringSplitOptions.None);
			strs[1] = "       ";
			strText.text = "";
			foreach (var item in strs)
			{
				strText.text += item;
			}
			lineIndex.text = lineIdx.ToString();
			return text;
		}

		//if (_str.Contains("<blink>"))
		//{

		//}	

		strText.text = _str;
		lineIndex.text = lineIdx.ToString();
		//if (data != null)
		//{
		//	data.Answer = _answer;
		//	
		//}
		return text;
	}
}
