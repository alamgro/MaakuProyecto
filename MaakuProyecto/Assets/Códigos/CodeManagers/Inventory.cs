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
    
    //protected PlayerControl playerControl;

    void Start()
    {
        //playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        //isFull = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isFull && !ZoomItem.itemEstaEnZoom) //Soltar el item del inventaro
        {
            //Item can be added
            Instantiate(itemQueSuelta, new Vector3(this.transform.position.x, -2.6f, 0.0f), Quaternion.identity);
            Destroy(Inventory.itemActual);
            isFull = false;
        }

    }
}