using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchNest : MonoBehaviour {

    public float timeToHatch;
    public GameObject emptyNest;

    // Update is called once per frame
    void Update () {
        if(timeToHatch <= 0) {
            Instantiate(emptyNest, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        timeToHatch -= Time.deltaTime;	
	}


}
