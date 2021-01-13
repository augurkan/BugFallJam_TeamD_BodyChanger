using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    Animator anim;
    int isDeadHash;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();

        anim = GetComponent<Animator>();
        isDeadHash = Animator.StringToHash("isDead");
    }

    
    void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if (health <= 0)
        {
            this.gameObject.tag = "Dead";
            this.anim.SetBool(isDeadHash, true);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }

    float CalculateHealth()
    {
        
        return health / maxHealth;
    }

    public void TakeDamage()
    {
        health -= 50;
    }



}
