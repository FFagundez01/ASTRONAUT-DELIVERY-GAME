// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Limites
using UnityEngine;

public class Limites : MonoBehaviour
{
	public Camera MainCamera;

	private Vector2 screenBounds;

	private float objectWidth;

	private float objectHeight;

	private void Start()
	{
		screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
		objectWidth = base.transform.GetComponent<SpriteRenderer>().bounds.extents.x;
		objectHeight = base.transform.GetComponent<SpriteRenderer>().bounds.extents.y;
	}

	private void LateUpdate()
	{
		Vector3 position = base.transform.position;
		position.x = Mathf.Clamp(position.x, screenBounds.x * -1f + objectWidth, screenBounds.x - objectWidth);
		position.y = Mathf.Clamp(position.y, screenBounds.y * -1f + objectHeight, screenBounds.y - objectHeight);
		base.transform.position = position;
	}
}
