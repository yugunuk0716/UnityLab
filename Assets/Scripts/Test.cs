using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
	public TextMeshProUGUI test;

	private void Start()
	{
		print(test.text.Length);
		print(test.GetParsedText().Length);
		print(test.GetParsedText());
	}
}
