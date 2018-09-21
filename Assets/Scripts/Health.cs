using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int UnitHealth { get; set; }

    public int baseHealth;

    public Text healthText;

    string objectTag;

    bool hasDied;

    void Start()
    {
        UnitHealth = baseHealth;
        UpdateHealth();
    }

    public void TakeDamage(int damage)
    {
        UnitHealth -= damage;
        CheckForDeath();

        UpdateHealth();

        Animator anim = GetComponent<Animator>();
        if(anim != null && !hasDied)
        {
            anim.SetTrigger("TakeDamage");
        }
    }

    public void AddHealth(int add)
    {
        UnitHealth += add;
        CheckForHealthCap();
        UpdateHealth();
    }

    public void AddBaseHealth(int add)
    {
        baseHealth += add;
        UpdateHealth();
    }

    void CheckForHealthCap()
    {
        if (UnitHealth > baseHealth) { UnitHealth = baseHealth; }
    }

    void UpdateHealth()
    {
        if (healthText != null) { healthText.text = "" + UnitHealth + " / " + baseHealth; }
    }

    void CheckForDeath()
    {
        if(UnitHealth <= 0)
        {
            UnitHealth = 0;
            Death();
        }
    }

    void Death()
    {
        Animator anim = GetComponent<Animator>();
        if(gameObject.tag == "Player")
        {
            anim.SetTrigger("isDead");
            anim.SetLayerWeight(1, 0);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
