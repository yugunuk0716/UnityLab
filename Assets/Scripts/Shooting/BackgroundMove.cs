using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private MeshRenderer meshRenderer = null;
    private Vector2 offset = Vector2.zero;

    public float speed = 0.1f;

    private void Awake()
    {
        meshRenderer = GetComponent < MeshRenderer > ();
    }

    private void Update()
    {
        offset.y += speed * Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}