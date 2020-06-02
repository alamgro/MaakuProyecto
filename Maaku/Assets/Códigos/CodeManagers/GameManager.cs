using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text dialogo;
    public static float timer = 0.0f;
    public static float tiempoSinMoverse = 0.0f;
    public static bool triggerBorrarTexto = false;
    public static int secuenciaActual = 0; //Marca el progreso del juego
    public static bool aMenuIsOpen = false;
    public static void VocesEnLaCabeza(AudioClip audioSFX) //Si Maaku deja de moverse por 20 segundos, escuchará voces
    {
        tiempoSinMoverse += Time.deltaTime;
        if(tiempoSinMoverse >= 2990.0f) //Cambiar a 20 seg
        {
            tiempoSinMoverse = 0.0f;
            SoundScript.playSound(audioSFX);
        }
    }

    public static void ResetTimer()
    {
        timer = 0.0f;
        triggerBorrarTexto = true;
    }

    void Update()
    {
        if(triggerBorrarTexto) // Si el diálogo es diferente a vacío, entonces empieza contar 5 segundos para borrar el texto
        {
            timer += Time.deltaTime;
            if (timer >= 7.0f)
            {
                dialogo.text = "";
                timer = 0.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            //Pause
        }

    }
}