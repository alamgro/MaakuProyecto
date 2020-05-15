using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionObjeto : Inventory
{
	public bool esParaAbrir; //Determina si el objeto tiene un sprite donde está cerrado (que tiene una interacción que no dropea item)
	public int numDeSecuenciaObj;
    public GameObject boton; //Boton de PressE
	public GameObject itemQueRecoge; //Prefab que cambia el item que recoge
	public Sprite[] objetoSprites; //Array de sprites para los muebles y objetos de escenario
	public Sprite[] itemSprites; //Array de sprites de los items que puede recoger en este objeto
	public string[] dialogosTexto;
	public AudioClip audioSFX;
	int countSprite = 0, countItem = 0, cuentaDialogos = 0;
	private bool isTriggered = false;

	private Inventory inventory;

	Text dialogo;

	void Start()
	{
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		dialogo = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
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
		if (isTriggered && numDeSecuenciaObj <= GameManager.secuenciaActual)
		{
			if (esParaAbrir)
				objetoQueSeAbre();
			else
				objetoQueNoSeAbre();
		}
	}

	void PickItem()
	{
		inventory.isFull = true;
		itemQueRecoge.GetComponent<Image>().sprite = itemSprites[countItem];
		Inventory.itemActual = Instantiate(itemQueRecoge, inventory.slots.transform, false);
		itemQueSuelta.GetComponent<SpriteRenderer>().sprite = itemQueRecoge.GetComponent<Image>().sprite; //Le decimos cuál item debería soltar en caso de que presione 1
		//dialogo.text = dialogosTexto[countItem];
		countItem++;
	}

	void objetoQueSeAbre() //Cuando el objeto del escenario SÍ tiene una interacción solo para abrirlo (Que no dropea item la primer interacción)
	{
		if (Input.GetKeyDown(KeyCode.E) && countItem < itemSprites.Length) //Si presiona E y aún quedan items disponibles, entonces cambia de sprite
		{
			if (countSprite == 0) //Para la primera vez que interactúa con el objeto (interacción #0)
			{
				SoundScript.playSound(audioSFX); //Audio que se va a reproducir al interactuar la primera vez con el objeto
				this.gameObject.GetComponent<SpriteRenderer>().sprite = objetoSprites[countSprite];
				countSprite++;
			}
			else if (!inventory.isFull) //Para cuando ya pasó de la interacción #0 y verifica si tiene espacio en el inventario
			{
				if (objetoSprites.Length > 1)
				{ //Solo en caso de que el objeto contenga más de un sprite en el array
					this.gameObject.GetComponent<SpriteRenderer>().sprite = objetoSprites[countSprite];
					countSprite++;
				}
				PickItem();
			}
		}
		else if (countItem == itemSprites.Length) //Cuando ya se acabaron las interacciones, se desbloquean las siguientes secuencias de interacción
		{
			GameManager.secuenciaActual++;
			countItem++;
		}

	}
	void objetoQueNoSeAbre() //Cuando el objeto del escenario NO tiene una interacción para abrirlo (Dropea item la primer interacción)
	{
		if (Input.GetKeyDown(KeyCode.E) && !inventory.isFull) 
		{
			if (cuentaDialogos < dialogosTexto.Length)
			{
				playerControl.enabled = false; //Desactivar el script de movimiento de jugador.
				boton.SetActive(true);
				boton.transform.position = new Vector3(this.transform.position.x, 3.5f, 0);

				GameManager.ResetTimer(); //Reinicia la cuenta de tiempo para borrar el tiempo 5 segundos después.

				dialogo.text = dialogosTexto[cuentaDialogos];
				cuentaDialogos++;
			}
			else
			{
				PickItem();
				playerControl.enabled = true;
				boton.SetActive(false); //Quitar el botón de la pantalla
				GameManager.secuenciaActual++;
				Destroy(this.gameObject);
			}
		}
	}

}
