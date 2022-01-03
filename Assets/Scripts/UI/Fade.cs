using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
	float a = 1;

	public CanvasGroup cv;
	public Text stageIndexText;
	public Text stageTitleText;

	private void Start()
	{
		stageIndexText.text = $"{StageManager.Instance.stageIdx}";
		stageTitleText.text = "백그라운드 이동 만들기 시..시발련아";
		StartCoroutine(FadeOut());
	}
	public IEnumerator FadeIn()
	{

		while (true)
		{
			a += 0.008f;
			cv.alpha = a;
			yield return new WaitForSeconds(0.01f);
			if (a >= 1)
				break;
		}
		

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		StartCoroutine(FadeOut());
	}
	public IEnumerator FadeOut()
	{
		while (true)
		{
			a -= 0.008f;
			cv.alpha = a;
			yield return new WaitForSeconds(0.01f);
			if (a <= 0)
            {

				break;

            }
		}

	}
}
