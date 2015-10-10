using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;
	float paddleScale = 3;
	int MAX_PADDLE_SCALE = 10;

	private GameObject clonePaddle;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(instance);
		}
		Setup ();
	}

	public void Setup(){
		clonePaddle = Instantiate (paddle, new Vector3(transform.position.x, transform.position.y-9.46f, 0), Quaternion.identity) as GameObject;
		Instantiate (bricksPrefab, new Vector3(transform.position.x - 5.7f, transform.position.y + 3.05f, 0), Quaternion.identity);

		IncreasePaddle (paddleScale);
		Debug.Log (transform.position.x);

	}

	void CheckGameOver(){
		if (bricks < 1) {
			//youWon.SetActive(true);
			Time.timeScale = 0.25f;
			Invoke("Reset", resetDelay);
		}
		if (lives < 1) {
			//gameOver.SetActive(true);
			Time.timeScale = 0.25f;
			Invoke("Reset", resetDelay);
		}
	}

	void Reset(){
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void LoseLife(){
		lives --;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke ("ResetPaddle", resetDelay);
		CheckGameOver ();
	}

	void ResetPaddle(){
		clonePaddle = Instantiate (paddle, new Vector3(transform.position.x, transform.position.y-9.46f, 0), Quaternion.identity) as GameObject;
		IncreasePaddle (paddleScale);
	}

	public void IncreasePaddle(){
		if (bricks <= 10) {
			IncreasePaddle(MAX_PADDLE_SCALE);
		}
	}

	public void IncreasePaddle(float scale){
		if (clonePaddle != null) {
			foreach(Transform transf in clonePaddle.transform){
				if(transf.name.Equals("Paddle") && transf.localScale.x >= 3 && transf.localScale.x <= scale){
					transf.localScale += new Vector3 (scale/10, 0.0f, 0.0f);
					paddleScale += (scale/10);
					Debug.Log("Fuck");
				}
			}
		}
	}

	public void FixedUpdate(){
		IncreasePaddle ();
	}

	public void DestroyBricks(){

		bricks --;
		if (bricks == 10) {
			Debug.Log ("DestroyBricks");
			//IncreasePaddle ();
		}
		CheckGameOver ();
	}



}
