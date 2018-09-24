using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour {

    public float attackDist;
    public float attackDelay;

    public int playerBaseDamage;
    int damageBonus = 0;
    NavMeshAgent playerNav;

    GameObject targetedEnemy;
    GameObject targetChest;
    GameObject targetStair;
    bool isAttacking;

    float attackTimer;

    public Text damageText;
    public GameObject DeathUI;

    bool isDead;
    
	// Use this for initialization
	void Start ()
    {
        playerNav = GetComponent<NavMeshAgent>();
        

        if(PersistantData.Health == 0)
        {
            PersistantData.Health = GetComponent<Health>().GetCurrHealth();
        }
        else
        {
            GetComponent<Health>().SetHealth(PersistantData.Health);
        }

        if(PersistantData.DamageBonus == 0)
        {
            PersistantData.DamageBonus = damageBonus;
        }
        else
        {
            damageBonus = PersistantData.DamageBonus;
        }

        PersistantData.CurrentFloor = PersistantData.CurrentFloor + 1;

        UpdateDamage();
        GetComponent<Health>().UpdateHealth();

        DeathUI.SetActive(false);

    }

    void OnClick(Vector3 InputPos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(InputPos);

        isAttacking = false;
        targetedEnemy = null;
        targetChest = null;
        targetStair = null;


        if (Physics.Raycast(ray, out hit))
        {
            //If enemy clicked on
            if(hit.transform.tag == "Enemy")
            {
                NewDestination(hit);
                targetedEnemy = hit.transform.gameObject;
                GetComponent<Animator>().SetTrigger("isMoving");
            }
            else if(hit.transform.tag == "Chest")
            {
                NewDestination(hit);
                
                targetChest = hit.transform.gameObject;
                GetComponent<Animator>().SetTrigger("isMoving");
            }
            else if(hit.transform.tag == "Stair")
            {
                targetStair = hit.transform.gameObject;
                GetComponent<Animator>().SetTrigger("isMoving");
                NewDestination(hit);
            }
            //If anything clicked on with no tag.
            else
            {
                NewDestination(hit);
                
                if (playerNav.isStopped) { ToggleStop(); }
                GetComponent<Animator>().SetTrigger("isMoving");
            }
        }
    }

    void UpdateDamage()
    {
        damageText.text = playerBaseDamage + damageBonus + "";
    }

    public void HasDied()
    {
        isDead = true;
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
        Debug.Log("Damage dealt");
        GetComponent<Animator>().SetBool("isMoving", false);
    }

    void ToggleStop()
    {
        playerNav.isStopped = !playerNav.isStopped;
    }

    void NewDestination(RaycastHit hitInfo)
    {
        playerNav.destination = hitInfo.point;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isDead)
        {
            DeathUI.SetActive(true);
            return;
        }
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
                GetComponent<Animator>().SetTrigger("isLooting");
            }
        }

        if(targetStair != null)
        {
            float distToStair = Vector3.Distance(transform.position, targetStair.transform.position);

            if(distToStair < attackDist)
            {
                PersistantData.DamageBonus = damageBonus;
                SceneManager.LoadScene(1);
            }
        }

        float distToDestination = Vector3.Distance(playerNav.destination, transform.position);
        if(distToDestination < 0.5f)
        {
            GetComponent<Animator>().SetBool("isMoving", false);
        }

        //Test key
        if(Input.GetKeyDown(KeyCode.E))
        {
            ToggleStop();
        }
	}
}
