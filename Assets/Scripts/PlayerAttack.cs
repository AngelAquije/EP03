using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator ani;
    public int combo;
    public bool atacando;
    public AudioSource audio_S;
    public AudioClip[] sonido;
    
    void Start()
    {
        ani = GetComponent<Animator>();
        audio_S= GetComponent<AudioSource>();
    }

    public void Start_Combo() 
    {
        atacando = false;
        if (combo < 3) 
        {
            combo++;
        }
    }

    public void Finish_Ani() 
    {
        atacando = false;
        combo = 0;
    }

    public void Combos_()
    {
        if (Input.GetKeyDown(KeyCode.C) && !atacando) 
        {
            atacando = true;
            ani.SetTrigger("" + combo);
            /*audio_S.clip = sonido[combo];
            audio_S.Play();*/
        }
    }

    void Update() 
    {
        Combos_();
    }
}
