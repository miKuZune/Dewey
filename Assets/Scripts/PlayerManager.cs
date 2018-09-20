using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour {

    public float attackDist;
    public float attackDelay;

    public int playerBaseDamage;
    int damageBonus;
    NavMeshAgent playerNav;

    GameObject targetedEnemy;
    GameObject targetChest;
    bool isAttacking;

    float attackTimer;

    public Text damageText;

	// Use this for initialization
	void Start ()
    {
        playerNav = GetComponent<NavMeshAgent>();
        UpdateDamage();
	}

    void OnClick(Vector3 InputPos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(InputPos);

        isAttacking = false;

        if (Physics.Raycast(ray, out hit))
        {
            //If enemy clicked on
            if(hit.transform.tag == "Enemy")
            {
                NewDestination(hit);
                targetedEnemy = hit.transform.gameObject;
            }
            else if(hit.transform.tag == "Chest")
            {
                NewDestination(hit);
                
                targetChest = hit.transform.gameObject;
                Debug.Log(targetChest.name);
            }
            //If anything clicked on with no tag.
            else
            {
                NewDestination(hit);
                targetedEnemy = null;
                if (playerNav.isStopped) { ToggleStop(); }
            }
        }
    }

    void UpdateDamage()
    {
        damageText.text = playerBaseDamage + damageBonus + "";
    }

    public void AddDamage(int bonus)
    {
        damageBonus += bonus;
        UpdateDamage();
    }

    void DealDamage()
    {
        Health enemyHealth = targetedEnemy.GetComponent<Health>();

        enemyHealth.TakeDamage(playerBaseDamage + damageBonus);
    }

    void ToggleStop()
    {
        playerNav.isStopped = !playerNav.isStopped;
    }

    void NewDestination(RaycastHit hitInfo)
    {
        playerNav.destination = hitInfo.point;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnClick(Input.mousePosition);
        }

        if(Input.touchCount > 0)
        {
            Vector3 pos = new Vector3(Input.touches[0].position.x, 0, Input.touches[0].position.y);
            OnClick(pos);
        }

        if(targetedEnemy != null && !isAttacking)
        {
            float dist = Vector3.Distance(transform.position, targetedEnemy.transform.position);
            if (dist < attackDist) { isAttacking = true; ToggleStop(); }
        }

        if(isAttacking)
        {
            if(attackTimer < 0)
            {
                GetComponent<Animator>().SetTrigger("Attack");
                attackTimer = attackDelay;
            }
            attackTimer -= Time.deltaTime;

            if(targetedEnemy == null)
            {
                isAttacking = false;
                attackTimer = 0;
            }
        }

        if (targetChest != null)
        {
            float dist = Vector3.Distance(transform.position, targetChest.transform.position);

            if(dist < attackDist)
            {
                targetChest.GetComponent<Chest>().OnOpen();
            }
        }

        //Test key
        if(Input.GetKeyDown(KeyCode.E))
        {
            ToggleStop();
        }
	}
}
