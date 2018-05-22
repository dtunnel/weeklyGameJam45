using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public KeyCode actionKey;

    public float health;
    public float damage;
    public List<string> eggs;

    private void Awake() {
        actionKey = KeyCode.E;
    }

    /*
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    */
}
