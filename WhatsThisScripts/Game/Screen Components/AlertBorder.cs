using UnityEngine;
using System.Collections;

public class AlertBorder : MonoBehaviour {

	public GameObject alertSign;
	bool appear;

	void OnCollisionStay2D(Collision2D coll) 
	{
		if (coll.gameObject.name.Contains ("Square") || coll.gameObject.name.Contains ("Cross") || coll.gameObject.name.Contains ("Triangle")) 
		{
			alertSign.GetComponent<Animator> ().SetBool ("Blink", true);
		}
		else 
		{
			alertSign.GetComponent<Animator> ().SetBool ("Blink", false);
		}
	}

	void OnCollisionExit2D(Collision2D coll) 
	{
		if (!coll.gameObject.name.Contains ("Square") || !coll.gameObject.name.Contains ("Cross") || !coll.gameObject.name.Contains ("Triangle")) 
		{
			alertSign.GetComponent<Animator> ().SetBool ("Blink", false);
		}
	}
}
