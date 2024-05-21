using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Rigidbody PlayerRb;
	private int score = 0;
	public int health = 5;
	public Text scoreText;
	public Text healthText;
	public Text winLoseText;
	public Image winLoseBG;
	private bool dead = false;
	private bool win = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("menu");
		}

		if (health == 0)
		{
			//Debug.Log("Game Over!");
			dead = true;
			winLoseBG.color = Color.red;
			winLoseText.color = Color.white;
			winLoseText.text = "Game Over!";
			winLoseBG.gameObject.SetActive(true);
			StartCoroutine(LoadScene(3));
		}
	}

	void FixedUpdate()
	{
		if (dead == false && win == false)
		{
			if (Input.GetKey("up")) {
				PlayerRb.AddForce(0 ,0 ,speed * Time.deltaTime);
			}
			if (Input.GetKey("down")) {
				PlayerRb.AddForce(0 ,0 ,-speed * Time.deltaTime);
			}
			if (Input.GetKey("left")) {
				PlayerRb.AddForce(-speed * Time.deltaTime ,0 ,0);
			}
			if (Input.GetKey("right")) {
				PlayerRb.AddForce(speed * Time.deltaTime ,0 ,0);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Pickup"))
        {
			score ++;
            //Debug.Log("Score: " + score);
			Destroy(other.gameObject);
			SetScoreText();
        }
		if (other.CompareTag("Trap")) {
			health --;
			//Debug.Log("Health: " + health);
			SetHealthText();
		}
		if (other.CompareTag("Goal")) {
			//Debug.Log("You win!") ;
			win = true;
			winLoseText.text = "You win!" ;
			winLoseText.color = Color.black;
			winLoseBG.color = Color.green;
			winLoseBG.gameObject.SetActive(true);
			StartCoroutine(LoadScene(3));
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	void SetHealthText()
	{
		healthText.text = "Health: " + health;
	}

	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("maze");
	}
}
