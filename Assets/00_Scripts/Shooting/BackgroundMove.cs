using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMove : MonoBehaviour
{
	public Material backgroundMat;
	private Vector2 offset = Vector2.zero;

	public float speed = 0.1f;
	
	private void Awake()
	{
		Debug.Log("ASD");
	}

	private void Update()
	{
		offset.y += speed * Time.deltaTime;
		backgroundMat.SetTextureOffset("_MainTex", offset);
	}
}
