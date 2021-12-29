using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
	[SerializeField] private Transform content;
	[SerializeField] private GameObject textPrefab;

	private void Start()
	{

	}

	public GameObject OutPutText(string _str,string _answer)
	{
		GameObject text = Instantiate(textPrefab,content);
		TextArea data = text.GetComponent<TextArea>();
		Text strText = text.transform.Find("text").GetComponent<Text>();
		Text lineIndex = text.transform.Find("LineIndex").GetComponent<Text>();
		strText.text = _str;

		//if (data != null)
		//{
		//	data.Answer = _answer;
		//	lineIndex.text = data.index.ToString();
		//}
		return text;
	}
}
