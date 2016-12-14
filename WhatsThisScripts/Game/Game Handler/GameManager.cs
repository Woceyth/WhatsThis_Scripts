using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [Header ("Game Components")]
	public bool gameOver;
	public GameObject spawner;
    public float pushForce;
    public int enemiesHP;

    // Use this for initialization
    void Start ()
    {
        pushForce = 0.005f;
        enemiesHP = 8;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(gameOver == true)
		{
			spawner.SendMessage("CancelInvoker");
		}
	}
}
