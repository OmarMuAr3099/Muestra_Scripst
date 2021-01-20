using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class ScrTienda : MonoBehaviour
{
    [SerializeField] AudioSource compraSound;
    [SerializeField] AudioSource selectSound;

    [SerializeField] GameObject rayoTicket;
    [SerializeField] GameObject botonTicket;
    [SerializeField] GameObject descripcionTicket;
    [SerializeField] GameObject precioTicket;

    [SerializeField] GameObject rayoEnergia;
    [SerializeField] GameObject botonEnergia;
    [SerializeField] GameObject descripcionEnergia;
    [SerializeField] GameObject precioEnergia;

    [SerializeField] GameObject rayoFuego;
    [SerializeField] GameObject botonFuego;
    [SerializeField] GameObject descripcionFuego;
    [SerializeField] GameObject precioFuego;

    private void Start()
    {
        if (ScrErin.ticket == true)
        {
            botonTicket.SetActive(false);
            Destroy(rayoTicket);
            Destroy(botonTicket);
            Destroy(descripcionTicket);
            Destroy(precioTicket);
            compraSound.Play();
            if (ScrErin.Maxvida == 3)
            {
                UnityEngine.EventSystems.EventSystem.current.firstSelectedGameObject = botonEnergia;
            }

            if (ScrErin.Maxvida == 4 && ScrErin.armaFuego == false)
            {
                UnityEngine.EventSystems.EventSystem.current.firstSelectedGameObject = botonFuego;
            }
        }

        if (ScrErin.Maxvida == 4)
        {
            botonEnergia.SetActive(false);
            Destroy(rayoEnergia);
            Destroy(botonEnergia);
            Destroy(descripcionEnergia);
            Destroy(precioEnergia);
        }

        if (ScrErin.armaFuego == true)
        {
            botonFuego.SetActive(false);
            Destroy(rayoFuego);
            Destroy(botonFuego);
            Destroy(descripcionFuego);
            Destroy(precioFuego);
        }
    }

    public void Update()
    {
        
    }

    public void Ticket()
    {
        if(ScrErin.tokens >= 100)
        {
            ScrErin.tokens -= 100;
            ScrErin.ticket = true;
            ScrControlGame.ticketInventario = true;
            botonTicket.SetActive(false);
            Destroy(rayoTicket);
            Destroy(botonTicket);
            Destroy(descripcionTicket);
            Destroy(precioTicket);
            compraSound.Play();
            if (ScrErin.Maxvida == 3)
            {
                UnityEngine.EventSystems.EventSystem.current.firstSelectedGameObject = botonEnergia;
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(botonEnergia);
            }

            if (ScrErin.Maxvida == 4 && ScrErin.armaFuego == false)
            {
                UnityEngine.EventSystems.EventSystem.current.firstSelectedGameObject = botonFuego;
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(botonFuego);
            }
           
        }
    }

    public void TicketSelected()
    {
        selectSound.Play();
        rayoTicket.SetActive(true);
        descripcionTicket.SetActive(true);
        precioTicket.SetActive(true);
    }

    public void TicketDeselected()
    {
        selectSound.Stop();
        rayoTicket.SetActive(false);
        descripcionTicket.SetActive(false);
        precioTicket.SetActive(false);
    }

    public void Energia()
    {
        if (ScrErin.tokens >= 100)
        {
            ScrErin.tokens -= 100;
            ScrErin.Maxvida = 4;
            ScrErin.vida = 4;
            ScrUI.newVida = true;
            ScrControlGame.energiaInventario = true;
            botonEnergia.SetActive(false);
            Destroy(rayoEnergia);
            Destroy(botonEnergia);
            Destroy(descripcionEnergia);
            Destroy(precioEnergia);
            compraSound.Play();
            if (ScrErin.ticket == false)
            {
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(botonTicket);
            }
            if (ScrErin.ticket == true && ScrErin.armaFuego == false)
            {
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(botonFuego);
            }
            
        }
    }

    public void EnergiaSelected()
    {
        selectSound.Play();
        rayoEnergia.SetActive(true);
        descripcionEnergia.SetActive(true);
        precioEnergia.SetActive(true);
    }

    public void EnergiaDeselected()
    {
        selectSound.Stop();
        rayoEnergia.SetActive(false);
        descripcionEnergia.SetActive(false);
        precioEnergia.SetActive(false);

    }

    public void Fuego()
    {
        if (ScrErin.tokens >= 100)
        {
            ScrErin.tokens -= 100;
            ScrErin.damage = 2;
            ScrErin.armaFuego = true;
            ScrControlGame.fuegoInventario = true;
            botonFuego.SetActive(false);
            Destroy(rayoFuego);
            Destroy(botonFuego);
            Destroy(descripcionFuego);
            Destroy(precioFuego);
            if (ScrErin.ticket == false)
            {
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(botonTicket);
            }
            if (ScrErin.ticket == true && ScrErin.Maxvida == 3)
            {
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(botonEnergia);
            }
            
        }
    }

    public void FuegoSelected()
    {
        selectSound.Play();
        rayoFuego.SetActive(true);
        descripcionFuego.SetActive(true);
        precioFuego.SetActive(true);
    }

    public void FuegoDeselected()
    {
        selectSound.Stop();
        rayoFuego.SetActive(false);
        descripcionFuego.SetActive(false);
        precioFuego.SetActive(false);
    }

}
