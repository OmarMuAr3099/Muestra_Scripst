using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrPausa : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource selectSound;

    public void Reanudar()
    {
        clickSound.Play();     
        ScrControlGame.pausar = false;
    }


    public void Opciones()
    {
        clickSound.Play();
        ScrControlGame.options = true;
        ScrControlGame.pausar = false;
    }


    public void Controles()
    {
        clickSound.Play();
        ScrControlGame.controls = true;
        ScrControlGame.pausar = false;
    }
    public void Salir()
    {
        clickSound.Play();
        ScrControlGame.quit = true;
        ScrControlGame.pausar = false;
    }

    public void Select()
    {
        selectSound.Play();
    }

    
}
