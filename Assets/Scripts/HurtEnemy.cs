using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int dmgToDeal = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy") {
            //creo el la isntancia para controler el hp y le paso el enemigo del que quiero controlarla
            EnemyHealthManager eHPManager;
            eHPManager = other.gameObject.GetComponent<EnemyHealthManager>();
            eHPManager.HurtEnemy(dmgToDeal);
        }
    }
}
