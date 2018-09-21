using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    GameObject player;

    bool isAttacking;

    public float attackDist;
    public float attackDelay;
    public int attackPower;

    float attackTimer;
    Animator AIanim;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AIanim = GetComponent<Animator>();

        isAttacking = false;
	}
	
    void CheckForAttack()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if(dist < attackDist)
        {
            AttackAnim();
        }
    }

    void AttackAnim()
    {
        attackTimer -= Time.deltaTime;
        if(attackTimer < 0 )
        {
            AIanim.SetTrigger("Attack");
            attackTimer = attackDelay;
        }
    }

    public void DamagePlayer()
    {
        Health playerHealth = player.GetComponent<Health>();

        playerHealth.TakeDamage(attackPower);
    }

	// Update is called once per frame
	void Update ()
    {
        Vector3 lookAt = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(lookAt);

        CheckForAttack();
        
	}
}
