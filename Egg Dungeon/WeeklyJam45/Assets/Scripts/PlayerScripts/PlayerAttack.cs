using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Collider2D attackTrigger;
    public float attackCooldownTime;

    public Vector3 hitBoxLeftPos;
    public Vector3 hitBoxRightPos;
    public Vector3 hitBoxUpPos;
    public Vector3 hitBoxDownPos;

    private bool isAttacking;
    private float attackCooldown;
    private float mouseAngle;

    // Use this for initialization
    void Start () {
        isAttacking = false;
        mouseAngle = 0;

        resetAttackDirection();

        if (attackTrigger)
            attackTrigger.enabled = false;
        else
            Debug.Log("Attack Trigger not found for player. Add an attack trigger gameObject to the player gameObject with a 2D Collider component");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !isAttacking) {
            isAttacking = true;
            attackCooldown = attackCooldownTime;

            attackTrigger.enabled = true;

            getMouseAngle();
            setAttackDirection();
        }

        if (isAttacking) {
            if (attackCooldown > 0)
                attackCooldown -= Time.deltaTime;
            else {
                attackCooldown = 0;
                isAttacking = false;
                attackTrigger.enabled = false;
                resetAttackDirection();
            }
        }
	}


    // Grabs mouse angle relative to player position
    void getMouseAngle() {
        Vector3 v3Pos = Input.mousePosition;
        v3Pos.z = (transform.position.z - Camera.main.transform.position.z);
        v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
        v3Pos = v3Pos - transform.position;

        mouseAngle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        if (mouseAngle < 0.0f)
            mouseAngle += 360.0f;
    }

    // Sets the position of the attack target box based on mouse angle
    void setAttackDirection() {
        if (mouseAngle <= 135f && mouseAngle > 45f) {
            attackTrigger.transform.localPosition = hitBoxUpPos;
            attackTrigger.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        }
        if ((mouseAngle <= 45f && mouseAngle >= 0f) || (mouseAngle > 315f) ) {
            attackTrigger.transform.localPosition = hitBoxRightPos;
            attackTrigger.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (mouseAngle <= 315f && mouseAngle > 225f) {
            attackTrigger.transform.localPosition = hitBoxDownPos;
            attackTrigger.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        }
        if (mouseAngle <= 225f && mouseAngle > 135f) {
            attackTrigger.transform.localPosition = hitBoxLeftPos;
            attackTrigger.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    // sets attack collider to origin of player in order to allow the onTriggerEnter2D function to work with enemies
    void resetAttackDirection() {
        attackTrigger.transform.localPosition = new Vector3(0f, 0f, 0f);
        attackTrigger.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

}
