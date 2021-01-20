using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrUI : MonoBehaviour
{
    public Text tokens;


    Animator anim;


    public Image[] Vidas;
    public Sprite FullVida;
    public Sprite EmptyVida;
    
    public static bool newVida = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        tokens.text = (ScrErin.tokens).ToString();


        GetComponentInChildren<Animator>().SetInteger("Energy", ScrErin.energia);


        for (int i = 0; i < Vidas.Length; i++)
        {
            if (i < ScrErin.vida)
            {
                Vidas[i].sprite = FullVida;
            }
            else
            {
                Vidas[i].sprite = EmptyVida;
            }
            if (i < ScrErin.Maxvida)
            {
                Vidas[i].enabled = true;
            }
            else
            {
                Vidas[i].enabled = false;
            }
        }

    }
}
