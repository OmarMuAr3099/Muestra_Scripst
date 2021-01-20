using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTransiciones : MonoBehaviour
{
    bool start = false;
    bool isFadeIn = false;
    float alpha = 0;
    float fadeTime = 2f;
    public Transform target;
    [SerializeField] bool outBoss = true;

    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera cam5;
    public Camera cam6;
    public Camera cam7;
    public Camera cam8;
    public Camera cam9;
    public Camera cam10;
    public Camera cam11;
    public Camera cam12;

    public GameObject musicaActivada;
    public GameObject musicaMuted1;
    public GameObject musicaMuted2;
    public GameObject musicaMuted3;

    public Transform Erin;

    void Star()
    {
        
    }
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if(outBoss == true)
            {
                outBoss = false;
            }

            FadeIn();

            yield return new WaitForSeconds(0.8f);

           
            CambioCamara();
            CambioMusica();
            Erin.position = new Vector2(target.position.x, target.position.y);

            FadeOut();
        }

    }
    void OnGUI()
    {
        if (!start) return;

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        if (isFadeIn)
        {
            alpha = Mathf.Lerp(alpha, 1.1f, fadeTime * Time.deltaTime);
            
        }
        else
        {
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime);
            
        }

    }

    private void Update()
    {
        if (ScrBossMagia.vitality <= 18 && ScrBossMagia.vitality > 0)
        {
            musicaActivada.SetActive(false);
            musicaMuted1.SetActive(false);
            musicaMuted2.SetActive(false);
            musicaMuted3.SetActive(true);
        }

        if (ScrBossMagia.vitality <= 0 && outBoss == true)
        {
            musicaActivada.SetActive(false);
            musicaMuted1.SetActive(false);
            musicaMuted2.SetActive(false);
            musicaMuted3.SetActive(false);
        }
    }

    void FadeIn()
    {
        start = true;
        isFadeIn = true;
    }

    void FadeOut()
    {
        isFadeIn = false;
    }

    void CambioCamara()
    {
        cam1.enabled = false;
        cam2.enabled = true;
        cam3.enabled = false;
        cam4.enabled = false;
        cam5.enabled = false;
        cam6.enabled = false;
        cam7.enabled = false;
        cam8.enabled = false;
        cam9.enabled = false;
        cam10.enabled = false;
        cam11.enabled = false;
        cam12.enabled = false;
    }

    void CambioMusica()
    {
        musicaActivada.SetActive(true);
        musicaMuted1.SetActive(false);
        musicaMuted2.SetActive(false);
        musicaMuted3.SetActive(false);
    }
}
