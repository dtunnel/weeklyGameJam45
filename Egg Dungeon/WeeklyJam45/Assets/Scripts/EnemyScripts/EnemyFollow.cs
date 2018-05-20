using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    public float maxDistance;
    //public float slimeThrust;

    private Transform target;
    private Rigidbody2D rb;

    //private bool attacking;
    //private float attackCooldown;
    //public float attackCooldownTime;

	// Use this for initialization
	void Start () {
        //attacking = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Vector2.Distance(transform.position, target.position) > maxDistance)
            rb.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        /*
        else if(attacking) {
            if(attackCooldown > 0) {
                attackCooldown -= Time.deltaTime;
            }
            else {
                attackCooldown = 0;
                attacking = false;
            }
        }
        else {
            attack();
        }
        */
    }

    /*
    void attack() {
        attacking = true;
        attackCooldown = attackCooldownTime;
        if (gameObject.name.Contains("slime"))
            slimeAttack();
    }

    void slimeAttack() {
        rb.AddForce((target.transform.position - transform.position) * slimeThrust * Time.deltaTime);
    }*/
}
