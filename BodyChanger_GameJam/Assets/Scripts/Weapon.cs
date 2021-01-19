using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //EnemyHealth enemyhealth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Elif"))
        {

            other.gameObject.GetComponent<EnemyHealth>().TakeDamage();

        }
    }

}
