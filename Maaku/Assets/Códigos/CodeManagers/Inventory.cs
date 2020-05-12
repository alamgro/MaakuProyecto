using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool isFull;
    public GameObject slots;
    public GameObject itemQueSuelta;
    public static GameObject itemActual;
    public GameObject itemZoom;
    private bool itemEstaEnZoom = false;
    private PlayerControl playerControl;

    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        isFull = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isFull)
        {
            //Item can be added
            Instantiate(itemQueSuelta, new Vector3(this.transform.position.x, -2.572763f, 0.0f), Quaternion.identity);
            Destroy(itemActual);
            isFull = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && isFull)
        {
            print("Pressed 2");
            if (!itemEstaEnZoom) {
                playerControl.enabled = false;
                itemZoom.GetComponent<Image>().sprite = itemActual.GetComponent<Image>().sprite;
                itemZoom.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            else
            {
                playerControl.enabled = true;
                itemZoom.GetComponent<Image>().sprite = null;
                itemZoom.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            }
            itemEstaEnZoom = !itemEstaEnZoom;
        }

    }
}