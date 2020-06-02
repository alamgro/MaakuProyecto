using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerificarCodigoDial : MonoBehaviour
{
    public Button[] boton;
    public GameObject dialCaja;
    private string claveCorrecta = "9021";
    private string claveIngresada;
    private Inventory inventory;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        claveIngresada = "";
        for(int i = 0; i < 4; i++)
        {
            claveIngresada += boton[i].GetComponentInChildren<Text>().text;
        }
        if (claveCorrecta == claveIngresada)
        {
            print("Clave correcta");
            LaClaveEsCorrecta();
        }
    }

    void LaClaveEsCorrecta()
    {
        dialCaja.SetActive(false);
        inventory.enabled = true; //activar el inventario de nuevo
        inventory.isFull = false;
        GameManager.secuenciaActual++;
        GameManager.aMenuIsOpen = false;
        PlayerControl.vel = 20f; //Activar el script de movimiento de jugador.
        dialCaja.SetActive(false); //Desactivar el dial dentro del UI
        Destroy(Inventory.itemActual);
    }
}
