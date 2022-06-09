using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgMove : MonoBehaviour
{
	private Image meshRenderer;
	private Vector2 offset = Vector2.zero;

	public float speed = 0.1f;
	private void Awake()
	{
		meshRenderer = GetComponent<Image>();
	}

	private void Update()
	{
		offset.y += speed * Time.deltaTime;
		meshRenderer.material.SetTextureOffset("_MainTex", offset);
	}
}
