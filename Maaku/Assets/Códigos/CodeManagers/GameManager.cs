using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float timer = 0.0f;
    public Text dialogo;

    public static int secuenciaActual = 0; //Marca el progreso del juego

    void Update()
    {
        if(dialogo.text != "") // Si el diálogo es diferente a vacío, entonces empieza contar 5 segundos para borrar el texto
        {
            timer += Time.deltaTime;
            if (timer >= 5.0f)
            {
                dialogo.text = "";
                timer = 0.0f;
            }
        }
        
    }
}