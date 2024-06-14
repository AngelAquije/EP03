using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private RaycastHit2D hit;
    public float distance;
    public float speed;
    public LayerMask layer;
    public float Gravedad;
    public float Altura_salto;
    public Animator ani;

    public bool Dash;
    public float Dash_T;
    public float Speed_Dash;

    [SerializeField] private float tiempoPerdidaControl;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    bool CheckCollision 
    {
        get 
        {
            hit = Physics2D.Raycast(transform.position, transform.up * -1, distance, layer);
            return hit.collider != null;
        }
    }

    public void Detector_Plataforma()
    {
        if (CheckCollision)
        {
            Altura_salto = 0;
            Gravedad = 0;
            ani.SetBool("jump", false);
        }
        else 
        {
            ani.SetBool("jump", true);
            if (Dash)
            {
                Gravedad = 0;
            }
            else 
            {
                Gravedad = -5;
            }
        }
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.D) && !Dash)
        {
            ani.SetBool("run", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
        else 
        {
            ani.SetBool("run", false);

        }

        if (Input.GetKey(KeyCode.A) && !Dash)
        {
            ani.SetBool("run", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (Altura_salto < 0.25f)
            {
                Altura_salto += 1 * Time.deltaTime;
                Gravedad = 15;
            }
        }
        else 
        {
            Altura_salto = 5f;
        }
    }

    void Dash_Skill() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Dash_T += 1 * Time.deltaTime;

            if (Dash_T < 0.35f)
            {
                Dash = true;
                ani.SetBool("dash", true);
                transform.Translate(Vector3.right * Speed_Dash * Time.fixedDeltaTime);                
                StartCoroutine(DesactivarColision());

            }
            else
            {
                Dash = false;
                ani.SetBool("dash", false);                
               
            }
        }
        else 
        {
            Dash = false;
            ani.SetBool("dash", false);
            Dash_T = 0;
        }
    }

    private IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(3, 12, true);       
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(3, 12, false);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("boss")) 
        {
            print("falta");
        }
    }

    void FixedUpdate()
    {
        Detector_Plataforma();
        Move();
        Dash_Skill();
        transform.Translate(transform.up * Gravedad * Time.fixedDeltaTime);
    }
}
