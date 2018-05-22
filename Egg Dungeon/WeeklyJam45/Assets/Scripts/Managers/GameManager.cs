using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float timeLeftMinutes = 2f;

	// Use this for initialization
	void Awake () {
        timeLeftMinutes *= 60; // converts from seconds to minutes
	}
	
	// Update is called once per frame
	void Update () {
        if (timeLeftMinutes <= 0)
            endGame();
        timeLeftMinutes -= Time.deltaTime;
    }

    void endGame() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
