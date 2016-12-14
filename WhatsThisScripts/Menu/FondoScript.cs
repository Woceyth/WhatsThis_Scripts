using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FondoScript : MonoBehaviour {

	public bool retryplayButton;

	void Start()
	{
		retryplayButton = false;
	}

    /// <summary>
    ///  Opens The other Scene
    /// </summary>
    void OpenScene()
    {
		if ( retryplayButton == false ) 
		{
			SceneManager.LoadScene ("Menu");
		}
		else 
		{
			SceneManager.LoadScene("Game");
		}
    }

}
