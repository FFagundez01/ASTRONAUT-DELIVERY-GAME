// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SpawnHamb
using System.Collections;
using UnityEngine;

public class SpawnHamb : MonoBehaviour
{
	public Transform firePoint;

	public GameObject shotPrefab;

	public float spawnTime;

	public float firstInterval;

	private void Start()
	{
		StartCoroutine(FirstObject(shotPrefab));
	}

	private void Update()
	{
	}

	private void Shoot()
	{
		Object.Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
		Object.FindObjectOfType<SoundManagerInGame>().PlayAudio(4);
	}

	private IEnumerator spawnObject(float interval, GameObject objeto)
	{
		if (!Object.FindObjectOfType<GameLogic>().Win() && !Object.FindObjectOfType<GameLogic>().Lose())
		{
			yield return new WaitForSeconds(interval);
			Shoot();
			StartCoroutine(spawnObject(interval, objeto));
		}
	}

	private IEnumerator FirstObject(GameObject objeto)
	{
		yield return new WaitForSeconds(firstInterval);
		StartCoroutine(spawnObject(spawnTime, shotPrefab));
	}
}
