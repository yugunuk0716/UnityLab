using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    Pool<TextArea> textAreaPool;
	public GameObject prefab;


    private void Start()
    {
		textAreaPool = new Pool<TextArea>(new PrefabFactory<TextArea>(prefab), 5);

	}

    public void CreateText()
	{
		TextArea ta = textAreaPool.Allocate();

		EventHandler handler = null;
		handler = (sender, e) => {
			textAreaPool.Release(ta);
			ta.Death -= handler;
		};

		ta.Death += handler;
		ta.gameObject.SetActive(true);
	}
}
