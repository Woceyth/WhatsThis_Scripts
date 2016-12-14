using UnityEngine;
using System.Collections;

public class FinalScoreAnimationEvents : MonoBehaviour {

	public GameObject signAlert;

	void RemoveSign () 
	{
		signAlert.SetActive(false);
	}
}
