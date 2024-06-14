using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo : MonoBehaviour
{
    public Animator ani;
    public Enemigo enemigo;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("player")) 
        {
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            enemigo.atacando = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
