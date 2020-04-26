using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public bool isFull;
    public GameObject slots;
    public GameObject itemQueSuelta;

    void Start()
    {
        isFull = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isFull)
        {
            //Item can be added
            Instantiate(itemQueSuelta, this.transform.position, Quaternion.identity);
            Destroy(InteraccionObjeto.itemToDelete);
            isFull = false;
        }

    }

    

}
