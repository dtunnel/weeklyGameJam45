using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    public float maxDistance;

    private Transform target;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Vector2.Distance(transform.position, target.position) > maxDistance)
            rb.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
