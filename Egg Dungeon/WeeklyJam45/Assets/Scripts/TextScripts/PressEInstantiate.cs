using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEInstantiate : MonoBehaviour {

    private PlayerStats playerStats;
    private GameObject buttonPressIndicator;

	// Use this for initialization
	void Start () {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        buttonPressIndicator = this.gameObject.transform.GetChild(0).gameObject;
        buttonPressIndicator.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(playerStats.eggs.Count > 0) {
            buttonPressIndicator.SetActive(true);
        }
        else {
            buttonPressIndicator.SetActive(false);
        }
    }
}
