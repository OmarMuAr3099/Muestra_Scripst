using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine.Events;

public class ScrErin : MonoBehaviour
{
    public static bool llave = false;
    public static bool dobleSaltoPickUp = false;

    public ScrProgreso datos;


    public float JumpForce=18f;
    public static bool enSuelo = true;
    [SerializeField]
    Transform comprobadorSuelo;
    public float comprobadorRadio = 0.5f;
    public LayerMask mascaraSuelo;
    private bool dobleSalto = false;
    bool attacking;

    public static bool interactuar;
    public static bool checkpoint;


    bool dash;
    float dashTime;
    int direccion;
    public float enfriamiento=2f;


    public float speed = 10f;
    public float maxSpeed = 10f;

    bool dashfreez;

    bool run;

    
    

    [SerializeField]
    BoxCollider2D ataque;
    // Start is called before the first frame update

    Rigidbody2D rb;
    public Animator anim;
    // en aquest punt, està buit
    float ejeX;  // Per llegir entrada usuari

    //Arma de fuego
    [SerializeField] public RuntimeAnimatorController fireAttack;
    // Per accedir al component Audio source
    [SerializeField] AudioSource coinSound;
    [SerializeField] AudioSource stepsSound;
    [SerializeField] AudioSource attackSound;
    [SerializeField] AudioSource deathSound;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource keySound;
    [SerializeField] AudioSource dobleSaltoSound;
    [SerializeField] AudioSource espejoSound;
    [SerializeField] AudioSource healSound;
    [SerializeField] AudioSource bossDeathSound;
    [SerializeField] AudioSource arlequinDeathSound;
    [SerializeField] GameObject llaveInventario, dobleSaltoInventario;

    public static bool espejo;
    public static bool canMove;

    public static int Maxvida = 3;
    public static int vida = 3;
    static public int damage = 1;
    public static int tokens=100;
    public static bool muerto = false;

    public static bool ticket = false;

    public static int energia;
    public static int maxEnergia = 8;

    public static bool hit = false;

    bool pasosLimit = false;

    public static bool armaFuego = false;

    bool bossDeath = false;
    bool bossDeathTime = false;
    bool keyTime = false;
    bool saltoTime = false;

    public static bool arlequinMuerte = false;

    void Start()
    {
        dashTime = 0.5f;
        dashfreez = false;
        rb = GetComponent<Rigidbody2D>();  // ara apunta al ribidBody del game object
        //so = GetComponent<AudioSource>();  // ara apunta al audioSource del game object
        anim = GetComponent<Animator>();
        ataque.enabled = false;
        Time.timeScale = 1;
        canMove = true;
        muerto = false;
        transform.position = new Vector3(ScrCargarNewGame.X, ScrCargarNewGame.Y,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScrErin.dobleSaltoPickUp == true && saltoTime == false)
        {
            dobleSaltoSound.Play();
            saltoTime = true;
        }

        if (ScrBossMagia.vitality <= 0) bossDeath = true;
        if (bossDeath == true && bossDeathTime == false)
        {
            bossDeathTime = true;
            bossDeathSound.Play();
        }

        if (arlequinMuerte == true)
        {
            arlequinMuerte = false;
            arlequinDeathSound.Play();
        }

        if (dobleSaltoPickUp == false) dobleSalto = true;
        if (dobleSaltoPickUp == true) dobleSaltoInventario.SetActive(true);

        if (espejo == true)
        {
            espejo = false;
            espejoSound.Play();
        }

        if (llave == true && keyTime == false)
        {
            keyTime = true;
            keySound.Play();
            llaveInventario.SetActive(true); //  LLAVE INVENTARIO
        } 

        if (armaFuego == true)
        {
            anim.runtimeAnimatorController = fireAttack;
        }

        if (ScrPasos.pasos == true)
        {
            if (pasosLimit == false)
            {
                stepsSound.Play();
                pasosLimit = true;
            }
        }

        if (ScrPasos.pasos == false)
        {
            stepsSound.Stop();
            pasosLimit = false;
        }

        if (canMove == true)
        {
            // Salto
            
            if ((enSuelo || !dobleSalto) && Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                jumpSound.Play();
                if ((!dobleSalto && dobleSaltoPickUp == true) && !enSuelo)
                {
                    dobleSalto = true;
                    GetComponent<Animator>().SetTrigger("DoubleJump");
                }
            }

            //Ataque
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            attacking = stateInfo.IsName("Erin_Attack");
            if (Input.GetButtonDown("Attack") && !attacking)
            {
                GetComponent<Animator>().SetTrigger("Atacar");
                attackSound.Play();

            }
            if (attacking)
            {
                float playbackTime = stateInfo.normalizedTime;
                
                if (playbackTime > 0.5 && playbackTime < 0.8)
                {
                    ataque.enabled = true;
                    
                }
                else ataque.enabled = false;
            }




            //Dash
           
            if (Input.GetAxis("HorizontalDash") < 0 && dashfreez == false)
            {
                dash = true;
                direccion = 1;
                transform.localScale = new Vector3(0.3467676f, 0.3862883f, 0.3862883f);
            }

           
            if (Input.GetAxis("HorizontalDash") > 0 && dashfreez == false)
            {
                transform.localScale = new Vector3(-0.3467676f, 0.3862883f, 0.3862883f);
                dash = true;
                direccion = -1;
            }
            if (dash == true)
            {
                rb.velocity = new Vector2(30*direccion, 0);
                
                dashTime -= Time.deltaTime;
                GetComponent<Animator>().SetBool("Dash", true);



            }
            if (dashTime <= 0)
            {
                rb.velocity = new Vector2(0, 0);
                dash = false;
                dashfreez = true;
                dashTime = 0.5f;
                GetComponent<Animator>().SetBool("Dash", false);
            }
            if (dashfreez == true)
            {
                enfriamiento -= Time.deltaTime;


            }
            if (enfriamiento <= 0)
            {
                dashfreez = false;
                enfriamiento = 0.6f;

            }




           

            if (Input.GetAxis("HorizontalMove") > 0 || (Input.GetAxis("HorizontalMove") < 0))
            {

                anim.SetBool("Run", true);
                ataque.enabled = false;
                attackSound.Stop();


            }
            else
            {
                anim.SetBool("Run", false);
            }




                if (dash == true)
            {
                rb.gravityScale = 0;

            }
            else
            {
                rb.gravityScale = 5;
            }


        }

        if (vida<=0&&muerto==false)
        {
            
            canMove = false;
            ataque.enabled = false;
            GetComponent<Animator>().SetTrigger("Muerte");
            datos.Load();
            muerto = true;
            deathSound.Play();
        }
       
        
        if (hit == true)
        {
            
            GetComponent<Animator>().SetTrigger("Hurt");
            vida--;
            ataque.enabled = false;
            hit = false;
        }



        if (Input.GetButtonDown("Interact") && checkpoint == true) GetComponent<Animator>().SetTrigger("checkpoint");

        //***************************************************  CURA ***************************************************
        if (energia >= maxEnergia&&Input.GetButtonDown("Heal"))
        {
            healSound.Play();
            anim.SetBool("cura", true);
            canMove = false;
        }
        else anim.SetBool("cura", false);
        //*******************************************************************************************************************
    }

    private void FixedUpdate()
    {
        

        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
        anim.SetBool("Grounded", enSuelo);
        if (enSuelo)
        {
            dobleSalto = false;
        }


        if (canMove == true)
        {
            

            }*/
            if (Input.GetAxis("HorizontalMove") > 0)
            {
                transform.localScale = new Vector3(0.3467676f, 0.3862883f, 0.3862883f);

                transform.Translate(0.2f, 0, 0);
            }


           

            if (Input.GetAxis("HorizontalMove") < 0)
            {
                transform.localScale = new Vector3(-0.3467676f, 0.3862883f, 0.3862883f);

                transform.Translate(-0.2f, 0, 0);
            }

            
        }




    }

    public void ConstrainOnlyOnXY(RotationConstraint component)
    {
        component.rotationAxis = Axis.X | Axis.Y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Token"&&!attacking)
        {
            coinSound.Play();
            tokens = tokens + 1;
            ScrToken scrT = collision.GetComponent<ScrToken>();
            scrT.token = true;
        }

        if (collision.tag == "Pickup" && !attacking)
        {
            energia++;
            Destroy(collision.gameObject);
        }
    }
    void ParaTiempo()
    {
        Time.timeScale = 0;
    }
    void Respawn()
    {
        datos.Load();
        if (datos.nivel == "Tutorial") SceneManager.LoadScene("Tutorial");
        if (datos.nivel == "Circo") SceneManager.LoadScene("Circo");
        
        
        vida = Maxvida;
        energia = 0;
    }

    

    

    





}
