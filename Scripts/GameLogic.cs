// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GameLogic
using UnityEngine;

public class GameLogic : MonoBehaviour
{
	public bool lose;

	public bool win;

	public int lives;

	public int objectives;

	public int objectivesDone;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		if (objectivesDone == objectives)
		{
			Win(b: true);
		}
		if (lives == 0)
		{
			Lose(b: true);
		}
	}

	public void Lose(bool b)
	{
		lose = b;
	}

	public void Win(bool b)
	{
		win = b;
	}

	public bool Lose()
	{
		return lose;
	}

	public bool Win()
	{
		return win;
	}

	public int Lives()
	{
		return lives;
	}

	public int ObjectivesDone()
	{
		return objectivesDone;
	}

	public void LostALife()
	{
		if (lives != 0)
		{
			Object.FindObjectOfType<SoundManagerInGame>().PlayAudio(5);
			lives--;
		}
		else if (!Win())
		{
			Lose(b: true);
		}
	}

	public void Completed1Objective()
	{
		if (objectivesDone < objectives)
		{
			objectivesDone++;
		}
	}
}
