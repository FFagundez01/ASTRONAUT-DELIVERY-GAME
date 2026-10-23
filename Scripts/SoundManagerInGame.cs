// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SoundManagerInGame
using UnityEngine;

public class SoundManagerInGame : MonoBehaviour
{
	public AudioSource[] Audios;

	private void Start()
	{
		Object.FindObjectOfType<MainTrack>().PlayMusic();
	}

	private void Update()
	{
	}

	public void PlayAudio(int i)
	{
		Audios[i].Play();
	}
}
