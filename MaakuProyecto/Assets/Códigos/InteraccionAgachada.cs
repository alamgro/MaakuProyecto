﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionAgachada : MonoBehaviour
{
	private Inventory inventory;
	private Text dialogo;
	int countItem = 0, cuentaDialogos = 0;
	public string[] dialogosTexto;
	public GameObject boton; //Boton de PressE
	public GameObject itemQueRecoge; //Prefab que cambia el item que recoge
	public Sprite[] itemSprites; //Array de sprites de los items que puede recoger en este objeto
	public AudioClip audioSFX;
	private bool isTriggered = false;
	private void Start()
	{
		
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		dialogo = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
	}
	private void Update()
	{
		ObjetoAgachada();
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		isTriggered = true;
	}
	void OnTriggerExit2D(Collider2D collision)
	{
		isTriggered = false;
	}
	void ObjetoAgachada()
    {
		if (Input.GetKeyDown(KeyCode.E) && !GameManager.estaMoviendose && !inventory.isFull && PlayerControl.agachada && isTriggered)
		{
			if (cuentaDialogos < dialogosTexto.Length)
			{
				MostrarDialogos();
			}
			else
			{
				PlayerControl.agachada = false;
				PickItem();
				boton.SetActive(false); //Quitar el botón de la pantalla
				GameManager.SetInteraccionDesactivada();
				GameManager.secuenciaActual++;
				Destroy(this.gameObject);
			}
		}
	}
	void PickItem() //Recoge el item
	{
		inventory.isFull = true;
		itemQueRecoge.GetComponent<Image>().sprite = itemSprites[countItem];
		Inventory.itemActual = Instantiate(itemQueRecoge, inventory.slots.transform, false);
		inventory.itemQueSuelta.GetComponent<SpriteRenderer>().sprite = itemQueRecoge.GetComponent<Image>().sprite; //Le decimos cuál item debería soltar en caso de que presione 1
		countItem++;
	}
	void MostrarDialogos()
	{
		GameManager.SetInteraccionActivada();
		boton.SetActive(true);
		boton.transform.position = new Vector3(this.transform.position.x, 3.5f, 0);

		GameManager.ResetTimer(); //Reinicia la cuenta de tiempo para borrar el tiempo 7 segundos después.

		dialogo.text = dialogosTexto[cuentaDialogos];
		cuentaDialogos++;
	}
}
//-I drew my first day of school.
// -I love my backpack, is so pretty and Pink.
