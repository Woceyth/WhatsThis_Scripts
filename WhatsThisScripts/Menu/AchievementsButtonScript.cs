using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using GooglePlayGames;

public class AchievementsButtonScript : MonoBehaviour {

	public Sprite spritePressed;
	public Sprite spriteNormal;

	// Update is called once per frame
	void Update ()
	{
		if (!this.gameObject.GetComponent<AudioSource> ().isPlaying)
		{
			this.gameObject.GetComponent<AudioSource> ().Stop ();
		}
	}

	void OnMouseUp()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = spriteNormal;
		this.gameObject.GetComponent<AudioSource> ().Play ();
		Social.ShowAchievementsUI ();
	}

	void OnMouseDown()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = spritePressed;
	}
}
