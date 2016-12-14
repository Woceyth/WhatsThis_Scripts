using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class BottomBorder : MonoBehaviour {

    [Header ("Game Components")]
	public GameObject figuresDestroyed;
    public GameObject tryAgain;
    public GameObject pauseButton;
    public GameObject replayButton;
	public GameObject mainMenuButton;
    public GameObject score;
    public GameObject spawner;
	public GameObject alertSign;
	public GameObject enemieParent;
	public GameObject gameManager;
	public string leaderboardString;

	// Update is called once per frame
	void Update ()
	{
		if (!this.gameObject.GetComponent<AudioSource> ().isPlaying)
		{
			this.gameObject.GetComponent<AudioSource> ().Stop ();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name.Contains("Square") || coll.gameObject.name.Contains("Cross") || coll.gameObject.name.Contains("Triangle") )
		{
			this.gameObject.GetComponent<AudioSource> ().Play ();
			gameManager.GetComponent<GameManager>().gameOver = true;
            spawner.SendMessage("CancelInvoker");

            for (int i = 0; i < enemieParent.transform.childCount; i++)
            {
                enemieParent.transform.GetChild(i).gameObject.GetComponent<EnemieAI>().hp = 0;
            }

            score.SetActive(false);
            pauseButton.SetActive(false);
            replayButton.SetActive(true);
			mainMenuButton.SetActive (true);
            tryAgain.SetActive(true);
            tryAgain.transform.GetChild(1).GetComponent<TextMesh>().text = spawner.GetComponent<Spawner>().spawnCurrent.ToString();

			if( Social.localUser.authenticated)
			{
				Social.ReportScore (spawner.GetComponent<Spawner>().spawnCurrent , leaderboardString, (bool success) =>{
					if(success)
					{
						Debug.Log("yeah");
					}
					else
					{
						Debug.Log("No");
					}


					if( figuresDestroyed.GetComponent<FiguresDestroyedCounterScript>().figuresDestroyed >= 5 )
					{
						Social.ReportProgress("CgkI3OuUiu8PEAIQAg", 100.0f, (bool achievement1) => {
							if(achievement1)
							{
								Debug.Log("achievement1");
							}
							else
							{
								Debug.Log("No1");
							}
						});
					}

					if( figuresDestroyed.GetComponent<FiguresDestroyedCounterScript>().figuresDestroyed >= 10 )
					{
						Social.ReportProgress("CgkI3OuUiu8PEAIQAw", 100.0f, (bool achievement2) => {
							if(achievement2)
							{
								Debug.Log("achievement2");
							}
							else
							{
								Debug.Log("No2");
							}
						});
					}

					if( figuresDestroyed.GetComponent<FiguresDestroyedCounterScript>().figuresDestroyed >= 15 )
					{
						Social.ReportProgress("CgkI3OuUiu8PEAIQBA", 100.0f, (bool achievement3) => {
							if(achievement3)
							{
								Debug.Log("achievement3");
							}
							else
							{
								Debug.Log("No3");
							}
						});
					}

					if( figuresDestroyed.GetComponent<FiguresDestroyedCounterScript>().figuresDestroyed >= 20 )
					{
						Social.ReportProgress("CgkI3OuUiu8PEAIQBQ", 100.0f, (bool achievement4) => {
							if(achievement4)
							{
								Debug.Log("achievement4");
							}
							else
							{
								Debug.Log("No4");
							}
						});
					}

					if( figuresDestroyed.GetComponent<FiguresDestroyedCounterScript>().figuresDestroyed >= 25 )
					{
						Social.ReportProgress("CgkI3OuUiu8PEAIQBg", 100.0f, (bool achievement5) => {
							if(achievement5)
							{
								Debug.Log("achievement5");
							}
							else
							{
								Debug.Log("No5");
							}
						});
					}

				});
			}
			
		}
	}
}
