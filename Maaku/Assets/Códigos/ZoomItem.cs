using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomItem : MonoBehaviour
{
    public static Sprite itemParaHacerZoom;
    public static bool itemEstaEnZoom = false;
    private PlayerControl playerControl;
    private Inventory inventory;
    public GameObject UIitemZoom;

    // Start is called before the first frame update
    void Start()
    {
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        UIitemZoom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inventory.isFull) //Hacer zoom al objeto del inventario
        {
            if (!itemEstaEnZoom) //Activará el zoom
            {
                GameManager.aMenuIsOpen = true;
                playerControl.enabled = false;
                UIitemZoom.GetComponent<Image>().sprite = itemParaHacerZoom;
                UIitemZoom.SetActive(true);
                //UIitemZoom.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            else //Desactivará el zoom
            {
                GameManager.aMenuIsOpen = false;
                playerControl.enabled = true;
                UIitemZoom.SetActive(false);
                //UIitemZoom.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            }
            itemEstaEnZoom = !itemEstaEnZoom;
        }
    }
}
