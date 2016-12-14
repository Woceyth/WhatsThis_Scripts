using UnityEngine;
using System.Collections;

public class PauseButtonScript : MonoBehaviour {

    public GameObject score;
    public GameObject resumeButton;
    public GameObject pauseFondo;
    public GameObject pauseText;
	public GameObject parentEnemies;
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

	/// <summary>
	/// Raises the mouse up event.
	/// </summary>
    void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteNormal;
        pauseText.SetActive(true);
        pauseFondo.SetActive(true);
        resumeButton.SetActive(true);
        score.SetActive(false);
        Time.timeScale = 0;
		DisableEnemiesCollider ();
        this.gameObject.SetActive(false);
    }

	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
    void OnMouseDown()
    {
		this.gameObject.GetComponent<AudioSource> ().Play ();
        gameObject.GetComponent<SpriteRenderer>().sprite = spritePressed;
    }

	/// <summary>
	/// Disables the enemies collider.
	/// </summary>
	void DisableEnemiesCollider()
	{
		for( int i = 0; i < parentEnemies.transform.childCount; i++)
		{
			parentEnemies.transform.GetChild (i).GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
