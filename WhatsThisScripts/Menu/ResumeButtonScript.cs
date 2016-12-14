using UnityEngine;
using System.Collections;

public class ResumeButtonScript : MonoBehaviour
{
    public GameObject counter;
    public GameObject pauseFondo;
    public GameObject pauseText;
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
		pauseText.SetActive(false);
        pauseFondo.SetActive(false);
        gameObject.SetActive(false);
        counter.SetActive(true);
    }

    void OnMouseDown()
    {
		Time.timeScale = 1;
		this.gameObject.GetComponent<AudioSource> ().Play ();
		Time.timeScale = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = spritePressed;
    }

}
