using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPickup : MonoBehaviour {

    private GameManager gameManager;

    public float timeToAdd = 30;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    void addTime() {
        gameManager.timeLeftMinutes += timeToAdd;
    }
}
