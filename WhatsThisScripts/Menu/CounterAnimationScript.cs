using UnityEngine;
using System.Collections;

public class CounterAnimationScript : MonoBehaviour
{
    public GameObject score;
    public GameObject pauseButton;
	public GameObject parentEnemies;

	/// <summary>
	/// Resumes the game.
	/// </summary>
	void ResumeGame()
    {
        score.SetActive(true);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
		EnableEnemiesCollider ();
        this.gameObject.SetActive(false);
	}

	/// <summary>
	/// Enables the enemies collider.
	/// </summary>
	void EnableEnemiesCollider()
	{
		for( int i = 0; i < parentEnemies.transform.childCount; i++)
		{
			parentEnemies.transform.GetChild (i).GetComponent<BoxCollider2D> ().enabled = true;
		}
	}
}
