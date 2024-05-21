using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayMaze() 
	{
		SceneManager.LoadScene("maze");
	}

	public void QuitMaze()
	{
		Debug.Log("Quitting! It's like trying but easier!");
		Application.Quit();
	}
}
