using System.Collections;
using System.Collections.Generic;
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
		if (_str.Contains("<blink>"))
		{
			_str = _str.Replace("<newLine>", "     ");
		}
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
