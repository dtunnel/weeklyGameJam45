using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Collider2D enemyDetector;

    public float invicibilityCooldownTime;
    public float knockBackDurrationTime;

    private PlayerStats playerStats;

    private float knockBackDurration;
    private float invicibilityCooldown;
    private bool invincible;

    private float attackDamage;

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start() {
        playerStats = gameObject.GetComponent<PlayerStats>();
        attackDamage = playerStats.damage;
        rb = gameObject.GetComponent<Rigidbody2D>();
        invincible = false;
    }

	// Update is called once per frame
	void Update ()
    {
        if(playerStats.health <= 0) {
            print("You Died");
            Application.LoadLevel(Application.loadedLevel);
        }
	}

    private void FixedUpdate() {
        Move();

        // Allows temporary invincibility when hit
        if (invincible) {
            if(invicibilityCooldown > 0) {
                invicibilityCooldown -= Time.deltaTime;
            }
            else {
                invicibilityCooldown = 0;
                enemyDetector.enabled = true;
                invincible = false;
            }
        }
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 moveVect = new Vector3(moveHorizontal, moveVertical, 0f);
        moveVect = moveVect.normalized * speed * Time.deltaTime;

        // Movement if key is pressed
        if (moveHorizontal != 0 || moveVertical != 0) {
            rb.MovePosition(transform.position + moveVect);
        }
    }

    // Player loses health from enemy and becomes temporarially invincible
    void takeDamage(float damage) {
        playerStats.health -= damage;
        enemyDetector.enabled = false;
        invincible = true;
        invicibilityCooldown = invicibilityCooldownTime;
    }

    // Adds force to enemy to knockback after attacking
   /*void knockBackEnemy(Rigidbody2D enemyRb) {
        
        float pushForce = 100;
        Vector3 pushDirection = (enemyRb.transform.position - transform.position);
        enemyRb.AddForce(pushDirection * pushForce);
    }
    */

    IEnumerator knockBackEnemy(Rigidbody2D enemyRb) {
        float pushFroce = 7;
        knockBackDurration = knockBackDurrationTime;

        while (knockBackDurration > 0) {
            if (enemyRb) {
                Vector3 pushDirection = (enemyRb.transform.position - transform.position);
                enemyRb.velocity = new Vector2(pushDirection.x, pushDirection.y) * pushFroce;
            }
            knockBackDurration -= Time.deltaTime;
            yield return null;
        }
        if(enemyRb)
            enemyRb.velocity = Vector2.zero;
        knockBackDurration = 0;
        yield return null;

        /*
        float pushForce = 1;
        knockBackDurration = knockBackDurrationTime;

        while (knockBackDurration > 0) {
            knockBackDurration -= Time.deltaTime;
            Vector3 pushDirection = (enemyRb.transform.position - transform.position);
            enemyRb.AddForce(pushDirection * pushForce);
        }

        if (knockBackDurration < 0)
            knockBackDurration = 0;
        */
    }

}
