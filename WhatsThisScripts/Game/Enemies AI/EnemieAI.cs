using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class EnemieAI : MonoBehaviour 
{
    [Header ("Game Components")]
	public GameObject cautionText;
	public GameObject figuresDestroyedCounter;
    public GameObject gameManager;
	private Vector3 newPosition;
	public float pushForce;
	bool touched;
    public int hp;
	
	// Use this for initialization
	void Start ()
	{
		cautionText = GameObject.Find("!");
		figuresDestroyedCounter = GameObject.Find ("Figures Destroyed");
		gameManager = GameObject.Find ("Game Manager"); 
        hp = gameManager.GetComponent<GameManager>().enemiesHP;
        touched = false;
        pushForce = gameManager.GetComponent<GameManager>().pushForce;
    }

    // Update is called once per frame
    void Update () 
	{
		
		if( !this.gameObject.GetComponent<AudioSource> ().isPlaying )
		{
			this.gameObject.GetComponent<AudioSource> ().Stop ();
		}
		
        if(hp < 1)
        {
			PushUp();
            DestroyGameObject();
        }
        else
        {
            if (touched == true)
            {
                PushUp();
            }
            else
            {
                MoveDown();
            }
        }
	}

	void AddFigureDestroyed()
	{
		figuresDestroyedCounter.GetComponent<FiguresDestroyedCounterScript> ().figuresDestroyed++;
	}

    void DestroyGameObject()
    {
		this.gameObject.GetComponent<AudioSource> ().Stop ();
        gameObject.GetComponent<Animator>().SetBool("Dead", true);
        Destroy(gameObject, 0.5f);

		if( this.transform.localPosition.y <= .8f )
		{
			cautionText.GetComponent<Animator> ().SetBool ("Blink", false);
		}
    }
	
	/// <summary>
	/// Push up.
	/// </summary>
	void PushUp()
	{
		if( this.transform.localPosition != newPosition)
		{
			this.transform.localPosition = Vector3.MoveTowards( this.transform.localPosition, newPosition, 0.08f * Time.timeScale);
		}
		else
		{
			SetTouchedFalse();
		}
	}

    /// <summary>
    /// Moves down.
    /// </summary>
    void MoveDown()
    {
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(this.transform.localPosition.x, -0.25f, 2.5f), pushForce * Time.timeScale);
    }

	/// <summary>
	/// Sets the touched false.
	/// </summary>
	public void SetTouchedFalse()
	{
		touched = false;
	}
	
	/// <summary>
	/// Raises the enable event.
	/// </summary>
	private void OnEnable()
	{
		GetComponent<TapGesture>().Tapped += HandleTapped;	
	}

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	private void OnDisable()
	{
		GetComponent<TapGesture>().Tapped -= HandleTapped;	
	}

	/// <summary>
	/// Handles the tapped.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	void HandleTapped (object sender, System.EventArgs e)
	{
		touched = true;
		newPosition = new Vector3(this.transform.localPosition.x, (this.transform.localPosition.y + 0.5f), 2.5f);
		this.gameObject.GetComponent<AudioSource> ().Play ();
		hp--;
    }
}
