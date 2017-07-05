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

    //loads inputted level
    public void LoadLevel(string level)
    {
        Debug.Log("Load Scene");
        SceneManager.LoadScene("Game");
    }
}
