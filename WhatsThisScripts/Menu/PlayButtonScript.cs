using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour
{
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
		this.gameObject.GetComponent<AudioSource> ().Play ();
		fondo.GetComponent<FondoScript> ().retryplayButton = true;
        fondo.GetComponent<Animator>().SetBool("Fade In", true);
	}

	void OnMouseDown()
	{
        gameObject.GetComponent<SpriteRenderer>().sprite = spritePressed;
	}
}
