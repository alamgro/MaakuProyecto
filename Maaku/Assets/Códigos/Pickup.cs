using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject objetoInventario;
    bool triggered = false;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            triggered = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
            triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggered == true)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //Item can be added
                    inventory.isFull[i] = true;
                    Instantiate(objetoInventario, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            if (inventory.isFull[0] == true)
            {
                //Item can be added
                inventory.isFull[0] = false;
                Instantiate(objetoInventario, this.transform.position, Quaternion.identity);
            }
            
        }
    }

}
