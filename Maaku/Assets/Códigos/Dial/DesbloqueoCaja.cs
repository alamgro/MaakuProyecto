using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloqueoCaja : MonoBehaviour
{
	public GameObject tv;
    public int numDeSecuenciaObj;
    public GameObject boton; //Boton de PressE
    public GameObject itemQueRecoge; //Prefab que cambia el item que recoge
    public Sprite itemQueLoDesbloquea; //Es el item que Maaku necesita tener en el inventario para poder interactuar con este objeto (No siempre aplica)
	public Sprite[] objetoSprites; //Array de sprites para los muebles y objetos de escenario
	public Sprite[] itemSprites; //Array de sprites de los items que puede recoger en este objeto
    public string[] dialogosTexto;
    public AudioClip audioSFX;
    int countItem = 0, cuentaDialogos = 2;
	private bool isTriggered = false;
    private Inventory inventory;
    private PlayerControl playerControl;
    private Text dialogo;
	public GameObject dialCaja;

    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        dialogo = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
		dialCaja.SetActive(false);
	}
    void Update()
    {
		if(isTriggered)
			InteraccionDial();
    }

	void OnTriggerStay2D(Collider2D collision)
    {
		//UsarItemEnObjeto();
		isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		isTriggered = false;
	}

	void PickItem() //Recoge el item
    {
        inventory.isFull = true;
        itemQueRecoge.GetComponent<Image>().sprite = itemSprites[countItem];
        Inventory.itemActual = Instantiate(itemQueRecoge, inventory.slots.transform, false);
        inventory.itemQueSuelta.GetComponent<SpriteRenderer>().sprite = itemQueRecoge.GetComponent<Image>().sprite; //Le decimos cuál item debería soltar en caso de que presione 1
        countItem++;
    }

	void InteraccionDial()
    {
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (itemQueRecoge.GetComponent<Image>().sprite != itemQueLoDesbloquea) //Cuando el jugador no tiene el item correcto en el inventario
			{
				dialogo.text = dialogosTexto[0];
			}
			else if (itemQueRecoge.GetComponent<Image>().sprite == itemQueLoDesbloquea && inventory.isFull && !GameManager.aMenuIsOpen)
			{
				GameManager.aMenuIsOpen = true;
				PlayerControl.vel = 0f; //Desactivar el script de movimiento de jugador.
				inventory.enabled = false; //Desactiva inventario para que no pueda hacer zoom al objeto del inventario mientras ve los diálogos
				dialCaja.SetActive(true); //Activar el dial dentro del UI
			}
		}
		else if (Input.GetKeyDown(KeyCode.Escape))
        {
			GameManager.aMenuIsOpen = false;
			PlayerControl.vel = 20f; //Activar el script de movimiento de jugador.
			dialCaja.SetActive(false); //Desactivar el dial dentro del UI
			inventory.enabled = true; //activar el inventario de nuevo
		}
	}

	void UsarItemEnObjeto() //METER CÓDIGO PARA QUE HABRA EL CANVAS DEL DIAL
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (itemQueRecoge.GetComponent<Image>().sprite != itemQueLoDesbloquea && cuentaDialogos < dialogosTexto.Length) //Cuando no tiene el item correcto en inventario.
			{
				dialogo.text = dialogosTexto[0]; //El diálogo en ínidice 0 siempre es el que muestra cuando no tienes el item correcto en inventario.
			}
			//REVISAR AQUÍ SI FALLA ALGO DE LOS DIÁLOGOS (dialogosTexto.Length -1)
			else if (cuentaDialogos < dialogosTexto.Length) //Cuando tiene el item correcto pero tiene que presionar E para que se acaben los diálogos.
			{
				inventory.enabled = false; //Desactiva inventario para que no pueda hacer zoom al objeto del inventario mientras ve los diálogos
				MostrarDialogos();
			}
			else if (cuentaDialogos == dialogosTexto.Length) //Cuando ya han acabado los diálogos y usa el item del inventario
			{
				inventory.enabled = true;
				inventory.isFull = false;
				tv.GetComponent<SpriteRenderer>().sprite = objetoSprites[0];
				dialogo.text = "You used: " + Inventory.itemActual.GetComponent<Image>().sprite.name + ".";
				cuentaDialogos++;
				boton.SetActive(false);
				playerControl.enabled = true;
				GameManager.secuenciaActual++;
				Destroy(Inventory.itemActual);
				PickItem();
			}
			else
			{
				dialogo.text = dialogosTexto[1]; //Diálogo para cuando ya no queden más interacciones con este item
			}
			GameManager.ResetTimer();
		}
	}

	void MostrarDialogos()
	{
		playerControl.enabled = false; //Desactivar el script de movimiento de jugador.
		boton.SetActive(true);
		boton.transform.position = new Vector3(this.transform.position.x, 3.5f, 0);

		GameManager.ResetTimer(); //Reinicia la cuenta de tiempo para borrar el tiempo 5 segundos después.

		dialogo.text = dialogosTexto[cuentaDialogos];
		cuentaDialogos++;
	}

    // Update is called once per frame
}
