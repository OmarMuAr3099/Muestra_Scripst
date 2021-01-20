using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class ScrAtaque : MonoBehaviour
{
    private ScrErin player;
    [SerializeField] GameObject particulasPared, particulasEnemigo;
    [SerializeField] AudioSource barrilRoto;
    public static bool damageArlequin;
    private float timeLeft = 0.5f;
    public Animator particulas;
    public Animator particulasF;
    public static bool finParticulas = false;


    void Start()
    {
        player = GetComponentInParent<ScrErin>();
    }

    void Update()
    {
        print(finParticulas);
        if (finParticulas == true)
        {
            particulas.SetBool("Attack?", false);
            particulasF.SetBool("AttackF?", false);
            finParticulas = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "woodbox")
        {
            Destroy(collision.gameObject);
            particulas.SetBool("Attack?", true);
        }

        if (collision.tag == "Enemy")
        {
            damageArlequin = true;
            particulas.SetBool("Attack?", true);
        }

        if (collision.tag == "Boss")
        {
            ScrBossMagia.vitality--;
            ScrBossMagia.anim.SetBool("daño", true);
            print("hitboss");
            particulas.SetBool("Attack?", true);
           
        }

        if (collision.tag == "MagaA")
        {
            ScrMaga.vida--;
            ScrMaga.anim.SetBool("damaged", true);
            
        }
        if (collision.tag == "MagaB")
        {
            ScrMagaQuieta.vida--;
            ScrMagaQuieta.anim.SetBool("damaged", true);
           
        }

        if (collision.tag == "Barril")
        {
            ScrBarril scrB = collision.GetComponent<ScrBarril>();
            
            scrB.hit = true;
            
            barrilRoto.Play();
            particulas.SetBool("Attack?", true);
        }

        if (collision.tag == "intverde")
        {
            particulas.SetBool("Attack?", true);
        }

        if (collision.tag == "intazul")
        {
            particulas.SetBool("Attack?", true);
        }

        if (collision.tag == "ground")
        {
            particulasF.SetBool("AttackF?", true);
        }
    }

    

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            damageArlequin = false;
        }
        
    }
}
