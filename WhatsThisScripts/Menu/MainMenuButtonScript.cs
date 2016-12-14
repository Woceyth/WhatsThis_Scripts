using UnityEngine;
using System.Collections;

public class MainMenuButtonScript : MonoBehaviour {

	public GameObject fondo;
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
		fondo.GetComponent<Animator>().SetBool("Fade In", true);
	}

	void OnMouseDown()
	{
		this.gameObject.GetComponent<AudioSource> ().Play ();
		gameObject.GetComponent<SpriteRenderer>().sprite = spritePressed;
	}
}
