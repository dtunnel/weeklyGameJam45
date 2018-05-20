using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject deathEffect;

    private EnemyStats enemyStats;
    private float attackDamage;


	// Use this for initialization
	void Start () {
        enemyStats = GetComponent<EnemyStats>();
        attackDamage = enemyStats.damage;
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyStats.health <= 0) {
            DestroyObject(gameObject);
            if(deathEffect)
                Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Contains("Attack")) {
            enemyStats.health -= collision.GetComponentInParent<PlayerStats>().damage;
            collision.SendMessageUpwards("knockBackEnemy", gameObject.GetComponent<Rigidbody2D>());
        }

    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.name.Contains("Enemy")) {
            collision.SendMessageUpwards("takeDamage", attackDamage);
        }
    }
}
