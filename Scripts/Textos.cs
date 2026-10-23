// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Textos
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Textos : MonoBehaviour
{
	public Text live;

	public Text objectives;

	public Text Perdiste;

	public Text Ganaste;

	private void Awake()
	{
		Ganaste.enabled = false;
		Perdiste.enabled = false;
	}

	private void Update()
	{
		live.text = Object.FindObjectOfType<GameLogic>().Lives().ToString();
		objectives.text = Object.FindObjectOfType<GameLogic>().ObjectivesDone() + "/30";
		if (Object.FindObjectOfType<GameLogic>().Win())
		{
			Object.FindObjectOfType<SoundManagerInGame>().PlayAudio(1);
			Ganaste.enabled = true;
			Ganaste.text = "Ganaste";
			StartCoroutine(Wait3secondsBeforeReload());
		}
		else if (Object.FindObjectOfType<GameLogic>().Lose())
		{
			Perdiste.enabled = true;
			Perdiste.text = "Perdiste";
			StartCoroutine(Wait3secondsBeforeReload());
		}
	}

	public IEnumerator Wait3secondsBeforeReload()
	{
		yield return new WaitForSeconds(3f);
		CargarMismaEscena();
	}

	public void CargarMismaEscena()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
