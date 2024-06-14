using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    /*public GameObject player;
     public float distance;*/
    public float velocidad;
    public int daño;
    
    
    private void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * Vector2.right);

        /*distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, velocidad * Time.deltaTime);*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerLife playerlife)) 
        {
            playerlife.TomarDaño(daño);
            Destroy(gameObject);
        }
    }

}
