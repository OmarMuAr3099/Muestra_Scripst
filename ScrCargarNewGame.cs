using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrCargarNewGame : MonoBehaviour
{
    public ScrProgreso datos;
    public static float X;
    public static float Y;
    private float timeLeft = 5f;
    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource selectSound;

    public void NuevaPartida()
    {
        clickSound.Play();
        StartCoroutine(DelaySceneNuevaPartida());
    }

    public void Cargar()
    {
        clickSound.Play();
        StartCoroutine(DelaySceneCargar());
    }

    public void Select()
    {
        selectSound.Play();
    }

    IEnumerator DelaySceneNuevaPartida()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("CINEMATICA1");
        ScrErin.vida = 3;
        ScrErin.tokens = 0;
        X = 0;
        Y = -3.6f;
        ScrErin.energia = 0;
    }

    IEnumerator DelaySceneCargar()
    {
        yield return new WaitForSeconds(1.5f);
        datos.Load();
        if (datos.nivel == "Tutorial") SceneManager.LoadScene("Tutorial");
        if (datos.nivel == "Circo") SceneManager.LoadScene("Circo");
        X = datos.X;
        Y = datos.Y;
        ScrErin.tokens = datos.tokens;
        ScrErin.vida = datos.Vidas;
        ScrErin.energia = datos.energia;
    }
}

