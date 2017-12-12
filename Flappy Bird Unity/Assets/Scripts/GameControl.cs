using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	// We will have a singleton that control all the game
	public static GameControl instance;

	public GameObject gameOverText;
	public Text scoreText;
	public bool gameOver = false;

	public float scollSpeed = -1.5f;

	private int score = 0;

	// Use this for initialization
	void Awake () {

		if (instance == null)
			instance = this;
		
		 else if (instance != this) 
			Destroy (gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (gameOver == true && Input.GetMouseButtonDown (0) == true)
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		
	}

	public void BirdScored() {

		if (gameOver == true)
			return;

		score++;
		scoreText.text = "Score: " + score.ToString();

	}

	public void BirdDied() {
	
		gameOverText.SetActive(true);
		gameOver = true;

	}
}
