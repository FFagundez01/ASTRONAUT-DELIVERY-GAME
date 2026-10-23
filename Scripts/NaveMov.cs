// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// NaveMov
using UnityEngine;

public class NaveMov : MonoBehaviour
{
	public float speedNave;

	public GameObject[] carteles;

	private int cartelActual;

	public Transform spawnCartelPosition;

	private Vector3 newPositionNave;

	private bool naveSatisfecha;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Burger")
		{
			SiguienteCartel();
		}
		if (collider.tag == "ActivationZone")
		{
			NaveEnojada();
			Object.FindObjectOfType<GameLogic>().LostALife();
		}
	}

	private void Awake()
	{
		carteles[0].SetActive(value: false);
		carteles[1].SetActive(value: false);
		carteles[2].SetActive(value: false);
	}

	private void Start()
	{
		cartelActual = Random.Range(0, 3);
		carteles[cartelActual].SetActive(value: true);
		newPositionNave = new Vector3(base.transform.position.x - 30f, base.transform.position.y, base.transform.position.z);
	}

	private void FixedUpdate()
	{
		if (naveSatisfecha)
		{
			NaveSatisfecha();
		}
		else if (!Object.FindObjectOfType<GameLogic>().Win() && !Object.FindObjectOfType<GameLogic>().Lose())
		{
			base.transform.position = Vector2.MoveTowards(base.transform.position, newPositionNave, 0.01f * speedNave);
		}
		else
		{
			NaveSatisfecha();
		}
	}

	public void SiguienteCartel()
	{
		if (cartelActual == 0)
		{
			carteles[cartelActual].SetActive(value: false);
			naveSatisfecha = true;
			Object.FindObjectOfType<GameLogic>().Completed1Objective();
			Object.FindObjectOfType<SoundManagerInGame>().PlayAudio(2);
		}
		else
		{
			carteles[cartelActual].SetActive(value: false);
			cartelActual--;
			carteles[cartelActual].SetActive(value: true);
		}
	}

	public void NaveSatisfecha()
	{
		base.transform.position = Vector2.MoveTowards(base.transform.position, new Vector2(base.transform.position.x - 0.085f, base.transform.position.y + 0.03f), 0.08f * speedNave);
		if (base.transform.localScale.x > 0f)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x + -0.01f, base.transform.localScale.y + -0.01f, base.transform.localScale.z);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void NaveEnojada()
	{
		base.gameObject.SetActive(value: false);
	}
}
