using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerManager : MonoBehaviour {

    public float attackDist;
    
    NavMeshAgent playerNav;

    GameObject targetedEnemy;
    bool isAttacking;

	// Use this for initialization
	void Start ()
    {
        playerNav = GetComponent<NavMeshAgent>();
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
                Debug.Log(targetedEnemy.name);
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
            if (dist < attackDist) { isAttacking = true; Debug.Log(isAttacking); ToggleStop(); }
        }


        //Test key
        if(Input.GetKeyDown(KeyCode.E))
        {
            ToggleStop();
        }
	}
}
