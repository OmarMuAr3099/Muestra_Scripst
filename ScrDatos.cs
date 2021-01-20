using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrDatos : MonoBehaviour
{
    

    public ScrProgreso datos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        datos.Vidas = ScrErin.vida;
        datos.tokens = ScrErin.tokens;
        datos.nivel = ScrControlGame.nivel;
        datos.energia = ScrErin.energia;
    }
}
