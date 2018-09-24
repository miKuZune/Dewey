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

    public int GetCurrHealth()
    {
        return UnitHealth;
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

        if(gameObject.tag == "Player")
        {
            UpdatePersistantHealth();
        }
    }

    public void UpdatePersistantHealth()
    {
        PersistantData.Health = UnitHealth;
    }

    public void AddHealth(int add)
    {
        UnitHealth += add;
        CheckForHealthCap();
        UpdateHealth();
        UpdatePersistantHealth();
    }

    public void SetHealth(int newHealth)
    {
        UnitHealth = newHealth;
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

    public void UpdateHealth()
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
            GetComponent<PlayerManager>().HasDied();
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
