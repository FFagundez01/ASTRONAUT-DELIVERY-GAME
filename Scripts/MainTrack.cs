// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MainTrack
using UnityEngine;

public class MainTrack : MonoBehaviour
{
	private AudioSource _audioSource;

	private void Awake()
	{
		Object.DontDestroyOnLoad(base.transform.gameObject);
		_audioSource = GetComponent<AudioSource>();
	}

	public void PlayMusic()
	{
		if (!_audioSource.isPlaying)
		{
			_audioSource.Play();
		}
	}

	public void StopMusic()
	{
		_audioSource.Stop();
	}
}
