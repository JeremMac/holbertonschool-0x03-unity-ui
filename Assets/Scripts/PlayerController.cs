﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Rigidbody PlayerRb;
	private int score = 0;
	public int health = 5;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene("maze");
		}
	}

	void FixedUpdate()
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

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Pickup"))
        {
			score ++;
            Debug.Log("Score: " + score);
			Destroy(other.gameObject);
        }
		if (other.CompareTag("Trap")) {
			health --;
			Debug.Log("Health: " + health) ;
		}
		if (other.CompareTag("Goal")) {
			Debug.Log("You win!") ;
		}
	}
}
