// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SpawnNave
using System.Collections;
using UnityEngine;

public class SpawnNave : MonoBehaviour
{
	[SerializeField]
	private GameObject[] Ships;

	private void Start()
	{
		StartCoroutine(spawnFirstEnemy(1f, Ships[0]));
	}

	private void Update()
	{
	}

	private IEnumerator spawnEnemy(float interval, GameObject enemy)
	{
		yield return new WaitForSeconds(interval);
		if (!Object.FindObjectOfType<GameLogic>().Win() && !Object.FindObjectOfType<GameLogic>().Lose())
		{
			Object.Instantiate(enemy, new Vector2(10f, Random.Range(-3f, 4f)), Quaternion.identity);
		}
		StartCoroutine(spawnEnemy(interval, enemy));
	}

	private IEnumerator spawnNextEnemy(float interval, GameObject enemy)
	{
		yield return new WaitForSeconds(interval);
		if (!Object.FindObjectOfType<GameLogic>().Win() && !Object.FindObjectOfType<GameLogic>().Lose())
		{
			Object.Instantiate(enemy, new Vector2(10f, Random.Range(-3f, 4f)), Quaternion.identity);
		}
		StartCoroutine(spawnNextEnemy(interval, Ships[Random.Range(1, 3)]));
	}

	private IEnumerator spawnFirstEnemy(float interval, GameObject enemy)
	{
		yield return new WaitForSeconds(interval);
		if (!Object.FindObjectOfType<GameLogic>().Win() && !Object.FindObjectOfType<GameLogic>().Lose())
		{
			Object.Instantiate(enemy, new Vector2(10f, Random.Range(-2f, 2f)), Quaternion.identity);
		}
		StartCoroutine(spawnNextEnemy(4f, Ships[Random.Range(1, 3)]));
		StartCoroutine(spawnEnemy(5f, Ships[0]));
	}
}
