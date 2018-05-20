using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {

    
    // Destroys dropItem and picks up dropItem on player trigger enter
    private void OnTriggerEnter2D(Collider2D collision) {   
        if (collision.tag.Contains("Player")) {
            pickupItem();
            Destroy(this.gameObject);
        }
    }

    // Instructions for picking up dopped item
    void pickupItem() {

    }
}
