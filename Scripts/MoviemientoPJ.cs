// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MoviemientoPJ
using System.Collections;
using UnityEngine;

public class MoviemientoPJ : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed;

	public Camera cam;

	private Vector2 screenbounds;

	public Animator a;

	public float speed = 10f;

	public float speedSpaceOnPj;

	private void Awake()
	{
		a.enabled = false;
	}

	private void Start()
	{
		StartCoroutine(StartAnimation());
	}

	private void Update()
	{
		if (!Object.FindObjectOfType<GameLogic>().Win() && !Object.FindObjectOfType<GameLogic>().Lose())
		{
			moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
			return;
		}
		a.SetBool("Termino", value: true);
		a.enabled = false;
	}

	private void FixedUpdate()
	{
		base.transform.Translate(new Vector2(base.transform.position.x + 0.1f, base.transform.position.y - 4f) * speedSpaceOnPj * Time.deltaTime * -1f);
	}

	public void moveCharacter(Vector2 direction)
	{
		base.transform.Translate(direction * speed * Time.deltaTime);
	}

	private IEnumerator StartAnimation()
	{
		yield return new WaitForSeconds(1f);
		a.enabled = true;
	}
}
