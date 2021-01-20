using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrQuitPausa : MonoBehaviour
{
    public void Si()
    {
        SceneManager.LoadScene("MainMenu");
        ScrControlGame.pausar = false;

        ScrControlGame.quit = false;
    }


    public void No()
    {
        ScrControlGame.pausar = true;
       
        ScrControlGame.quit = false;
    }
}
