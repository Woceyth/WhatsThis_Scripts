using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class SignIn : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		if( Social.localUser.authenticated == false )
		{
			PlayGamesPlatform.Activate ();
		}

		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			if (success) {
				Debug.Log ("Login Sucess");
			} else {
				Debug.Log ("Login failed");
			}
		});
	}
}
