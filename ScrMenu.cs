using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrMenu : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource selectSound;

    private void Start()
    {
    }

    public void NuevaPartida()
    {
        clickSound.Play();
        StartCoroutine(DelaySceneNuevaPartida());
    }

    public void CargarPartida()
    {
        clickSound.Play();
        StartCoroutine(DelaySceneCargarPartida());
    }

    public void Opciones()
    {
        clickSound.Play();
        StartCoroutine(DelaySceneOpciones());
    }

    public void Creditos()
    {
        clickSound.Play();
        StartCoroutine(DelaySceneCreditos());
    }
    public void Controles()
    {
        clickSound.Play();
        StartCoroutine(DelaySceneControles());
    }
    public void Salir()
    {
        clickSound.Play();
        StartCoroutine(DelaySceneSalir());
    }

    public void Select()
    {
        selectSound.Play();
    }

    IEnumerator DelaySceneNuevaPartida()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("CINEMATICA1");
    }

    IEnumerator DelaySceneCargarPartida()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("cargarPartida");
    }

    IEnumerator DelaySceneOpciones()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("OPCIONES");
    }

    IEnumerator DelaySceneCreditos()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Creditos");
    }

    IEnumerator DelaySceneControles()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("controles");
    }

    IEnumerator DelaySceneSalir()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("salir");
    }
}
