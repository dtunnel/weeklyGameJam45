using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ParticleSystem ps = this.GetComponent<ParticleSystem>();
        float totalDurration = ps.duration + ps.startLifetime;
        Destroy(this.gameObject, totalDurration);
    }
}
