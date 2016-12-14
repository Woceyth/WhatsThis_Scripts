using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class LeaderboardButtonScript : MonoBehaviour {

	public string leaderboardString;
	public Sprite spritePressed;
	public Sprite spriteNormal;

	void OnMouseUp()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = spriteNormal;
		this.gameObject.GetComponent<AudioSource> ().Play ();
		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboardString);
	}

	void OnMouseDown()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = spritePressed;
	}
}
