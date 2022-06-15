using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameOpen : MonoBehaviour
{
	public PlayableDirector director;
	public GameObject inGameObj;
	public Button titleButton;

	private void Awake()
	{
		titleButton.onClick.AddListener(() => { SceneManager.LoadScene("Title"); });
	}

	public void Clear()
	{
		Instantiate(Resources.Load("Stage/Stage " + StageManager.instance.stageIdx), inGameObj.transform);

		director.Play();

	}
}
