using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBackPausa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Heal"))
        {
            ScrControlGame.options = false;
            ScrControlGame.pausar = true;
            ScrControlGame.controls = false;
            ScrControlGame.quit = false;
        }
    }
}
