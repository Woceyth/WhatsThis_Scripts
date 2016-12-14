using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
    [Header("Game Components")]
    public GameObject gameManager;
	public GameObject parentEnemies;
	public GameObject cross;
	public GameObject square;
	public GameObject triangle;
	public GameObject score;
	GameObject enemieClone;
    GameObject initialClone;
    GameObject initialClone2;
    GameObject initialClone3;
    int figure;
	int whereToSpawn;
	public int spawnCurrent;
    int numberToIncreaseSpeed;
    int numberRequired;
    //int spawnLimit;

	// Use this for initialization
	void Start () 
	{
		whereToSpawn = 0;
        numberToIncreaseSpeed = 0;
        numberRequired = 7;
		spawnCurrent = 3;
        
        // Square
        initialClone = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Game/Enemies/Square"), new Vector3(-0.86f, 6f, 2.5f), Quaternion.identity);
        initialClone.transform.parent = parentEnemies.transform;
        initialClone.SetActive(true);

        // Cross
        initialClone2 = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Game/Enemies/Cross"), new Vector3(0f, 6f, 2.5f), Quaternion.identity);
        initialClone2.transform.parent = parentEnemies.transform;
        initialClone2.SetActive(true);

        // Triangle
        initialClone3 = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Game/Enemies/Triangle"), new Vector3(0.8f, 6f, 2.5f), Quaternion.identity);
        initialClone3.transform.parent = parentEnemies.transform;
        initialClone3.SetActive(true);

        score.GetComponent<TextMesh>().text = spawnCurrent.ToString();
		InvokeRepeating ("InstantiateEnemie", 3, 8);
	}

	/// <summary>
	/// Instantiates the enemies.
	/// </summary>
	void InstantiateEnemie()
	{
        int randomGenerated = Random.Range(3,5);
		Random.seed = System.Environment.TickCount;

				for(int i = 0; i < randomGenerated; i++)
				{
					// 0 || 1 || 2
					figure = Random.Range (0,3);

					// 0 -> left || 1 -> right					
					switch( whereToSpawn )
					{
//						From -1.58 to -0.85 
						case 0:
							transform.position = new Vector3( Random.Range(-1.5f, -0.85f), 6f, 2.5f);
							whereToSpawn++;
							break;
//						From -0.75 to -0.45
						case 1:
							transform.position = new Vector3( Random.Range(-0.65f, -0.45f), 6f, 2.5f);
							whereToSpawn++;
							break;
//						From 0.45 to 0.85
						case 2:
							transform.position = new Vector3 (Random.Range (0.45f, 0.65f), 6f, 2.5f);
							whereToSpawn++;
							break;
//						From 0.79 to 1.58
						case 3:
							transform.position = new Vector3 (Random.Range (0.85f, 1.5f), 6f, 2.5f);
//							whereToSpawn = Random.Range(0,3);
							whereToSpawn = 0;
							break;
					}
					
					switch(figure)
					{
						// Spawn Square
					case 0:
						enemieClone = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Game/Enemies/Square"), transform.position, Quaternion.identity);
						enemieClone.transform.parent = parentEnemies.transform;
						enemieClone.SetActive (true);
						break;
						// Spawn Cross
					case 1:
						enemieClone = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Game/Enemies/Cross"), transform.position, Quaternion.identity);
                        enemieClone.transform.parent = parentEnemies.transform;
						enemieClone.SetActive (true);
						break;
						// Spawn Triangle
					case 2:
						enemieClone = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Game/Enemies/Triangle"), transform.position, Quaternion.identity);
                        enemieClone.transform.parent = parentEnemies.transform;
						enemieClone.SetActive (true);
						break;
					}

                    numberToIncreaseSpeed++;
//					if  numberToIncreaseSpeed is euqls to numberRequired, then increase the speed of the figures by 0.001
                    if( numberToIncreaseSpeed == numberRequired )
                    {
                        numberToIncreaseSpeed = 0;
                        numberRequired += 1;
                        gameManager.GetComponent<GameManager>().pushForce += 0.001f;
                    }
				}
            spawnCurrent += randomGenerated;
            score.GetComponent<TextMesh>().text = spawnCurrent.ToString();
	}
	
	/// <summary>
	/// Determines whether this instance cancel invoker.
	/// </summary>
	/// <returns><c>true</c> if this instance cancel invoker; otherwise, <c>false</c>.</returns>
	void CancelInvoker()
	{
		CancelInvoke("InstantiateEnemie");
	}
}
