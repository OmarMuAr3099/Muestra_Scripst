using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrControlMenu : MonoBehaviour
{
    public GameObject pausa;
    public GameObject opciones;
    public GameObject controles;
    public GameObject abandonar;
    [SerializeField] public GameObject Inventario;
    [SerializeField] public GameObject Fuego;
    [SerializeField] public GameObject Salto;
    [SerializeField] public GameObject Energia;
    [SerializeField] public GameObject Ticket;
    [SerializeField] public GameObject Llave;

    public static bool pausar;
    public static bool options;
    public static bool controls;
    public static bool quit;
    public static bool fuegoInventario;
    public static bool energiaInventario;
    public static bool ticketInventario;


    public static string nivel;


    // Start is called before the first frame update
    void Start()
    {
        pausa.SetActive(false);
        opciones.SetActive(false);
        controles.SetActive(false);
        abandonar.SetActive(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(fuegoInventario == true)
        {
            Fuego.SetActive(true);
        }else Fuego.SetActive(false);

        if (energiaInventario == true)
        {
            Energia.SetActive(true);
        }else Energia.SetActive(false);

        if (ticketInventario == true)
        {
            Ticket.SetActive(true);
        }
        else Ticket.SetActive(false);

        if (Input.GetButton("Inventory"))
        {
            Inventario.SetActive(true);
        }

        if (Input.GetButtonUp("Inventory"))
        {
            Inventario.SetActive(false);
        }

        if (Input.GetButtonDown("Pause")) pausar = true;

        if (pausar == true)
        {
            pausa.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {

            Time.timeScale = 1;
            pausa.SetActive(false);
        }



        if (options == true)
        {
            opciones.SetActive(true);
            pausa.SetActive(false);
            Time.timeScale = 0;

        }
        else
        {

            
            opciones.SetActive(false);
        }



        if (controls == true)
        {
            controles.SetActive(true);
            pausa.SetActive(false);
            Time.timeScale = 0;

        }
        else
        {


            controles.SetActive(false);
        }



        if (quit == true)
        {
            abandonar.SetActive(true);
            pausa.SetActive(false);
            Time.timeScale = 0;

        }
        else
        {


            abandonar.SetActive(false);
        }


        //Debug.Log(nivel);
    }

    
}
