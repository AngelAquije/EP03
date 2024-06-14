using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int cantidadDeVida;

    public void TomarDa�o(int da�o) 
    {
        cantidadDeVida -= da�o;
        if (cantidadDeVida <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
