using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("player")) 
        {
            print("Da�o");
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
