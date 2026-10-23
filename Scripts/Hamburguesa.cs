// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Hamburguesa
using UnityEngine;

public class Hamburguesa : MonoBehaviour
{
	public float speed;

	private Vector3 newPosition;

	private Vector3 to = new Vector3(0f, 0f, -90f);

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Desactivation Zone")
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		base.gameObject.SetActive(value: false);
		Object.FindObjectOfType<SoundManagerInGame>().PlayAudio(0);
	}

	private void Awake()
	{
	}

	private void Start()
	{
		newPosition = new Vector3(base.transform.position.x + 30f, base.transform.position.y, base.transform.position.z);
	}

	private void FixedUpdate()
	{
		base.transform.eulerAngles = Vector3.Lerp(base.transform.rotation.eulerAngles, to, Time.deltaTime * 2f);
		base.gameObject.transform.position = Vector2.MoveTowards(base.transform.position, newPosition, 0.5f);
		base.transform.localScale = new Vector3(base.transform.localScale.x + -0.001f, base.transform.localScale.y + -0.001f, base.transform.localScale.z);
		if (Object.FindObjectOfType<GameLogic>().Win() || Object.FindObjectOfType<GameLogic>().Lose())
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
