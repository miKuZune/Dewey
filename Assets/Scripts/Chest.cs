using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    PlayerManager player;
    Health playerHealth;

    [Header ("Damage")]
    public int chanceForDamage;
    public int minDMGincrease;
    public int maxDMGincrease;
    [Header("Health")]
    public int chanceForHealth;
    public int minHealthIncrease;
    public int maxHealthIncrease;
    [Header("Base Health")]
    public int chanceForBaseHealth;
    public int minBaseHealthIncrease;
    public int maxBaseHealthIncrease;

    void Start()
    {
        
    }

    public void OnOpen()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        System.Random random = new System.Random(System.DateTime.Now.Millisecond);
        int num = random.Next(0, 100);

        if(num > chanceForDamage)
        {
            num = random.Next(minDMGincrease, maxDMGincrease);
            player.AddDamage(num);
        }

        num = random.Next(0, 100);

        if (num > chanceForBaseHealth)
        {
            num = random.Next(minHealthIncrease, maxHealthIncrease);
            playerHealth.AddBaseHealth(num);
        }

        num = random.Next(0, 100);

        if(num > chanceForHealth)
        {
            num = random.Next(minBaseHealthIncrease, maxBaseHealthIncrease);
            playerHealth.AddHealth(num);
        }

        
        

        Destroy(this.gameObject);
    }
}
