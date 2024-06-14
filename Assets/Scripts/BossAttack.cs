using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform ControladorDisparo;
    public float distanciaLinea;
    public LayerMask CapaJugador;
    public bool JugadorEnRango;

    public GameObject balaEnemigo;
    public float tiempoEntreDisparos;
    public float tiempoUltimoDisparo;
    public float tiempoEsperaDisparo;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        JugadorEnRango = Physics2D.Raycast(ControladorDisparo.position, transform.right, distanciaLinea, CapaJugador);
        if (JugadorEnRango) 
        {
            if (Time.time > tiempoEntreDisparos + tiempoUltimoDisparo) 
            {
                tiempoUltimoDisparo = Time.time;
                Invoke(nameof(Disparar), tiempoEsperaDisparo);
            }
        };
    }

    private void Disparar()
    {
        Instantiate(balaEnemigo, ControladorDisparo.position, ControladorDisparo.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ControladorDisparo.position, ControladorDisparo.position + transform.right * distanciaLinea);
    }
}
