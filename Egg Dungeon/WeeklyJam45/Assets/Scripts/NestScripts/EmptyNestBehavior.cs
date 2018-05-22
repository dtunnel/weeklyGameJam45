using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyNestBehavior : MonoBehaviour {

    public List<GameObject> nests;
    private PlayerStats playerStats;
    private bool nestFull;

    private void Start() {
        nestFull = false;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void fillNest(string nestType) {
        for(int i=0; i < nests.Count; i++) {
            if (nests[i].name.Contains(nestType) && !nestFull) {
                Instantiate(nests[i], transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                playerStats.eggs.RemoveAt(playerStats.eggs.Count - 1);
                nestFull = true;
                break;
            }
        }
    }
}
