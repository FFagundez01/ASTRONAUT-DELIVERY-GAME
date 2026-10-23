// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Fondo
using UnityEngine;
using UnityEngine.UI;

public class Fondo : MonoBehaviour
{
	[SerializeField]
	private RawImage _img;

	[SerializeField]
	private float x;

	[SerializeField]
	private float y;

	private void Update()
	{
		_img.uvRect = new Rect(_img.uvRect.position + new Vector2(x, y) * Time.deltaTime, _img.uvRect.size);
	}
}
