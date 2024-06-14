using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    private Renderer rnd;
    private float value;

    void Start()
    {
        rnd = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        value += speed * Time.deltaTime;
        rnd.material.mainTextureOffset = new Vector2(value, 0);
    }
}
