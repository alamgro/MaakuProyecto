using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionSoloDialogo : MonoBehaviour
{
    public Text UIDialogo;
    [TextArea(2, 4)] //Para ver en el inspector los cuádros de diálogo más grandes
    public string[] textoDialogo;
    public GameObject boton; //Boton de PressE
    private bool isTriggered = false;
    private int count = 0;
    private PlayerControl playerControl;

    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		boton.SetActive(true);
        boton.transform.position = new Vector3(this.transform.position.x, 3.5f, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered && count < textoDialogo.Length) 
        {
            GameManager.ResetTimer();
            playerControl.enabled = false; //Desactiva el script de movimiento del jugador
            UIDialogo.text = textoDialogo[count];
            count++;
        }
        else if (count == textoDialogo.Length) //Cuenta para saber si ya ha leído todos los diálogos
        {
            playerControl.enabled = true; //Activa el script de movimiento del jugador
            count++;
            GameManager.secuenciaActual++;
            boton.SetActive(false);
        }
    }
}
