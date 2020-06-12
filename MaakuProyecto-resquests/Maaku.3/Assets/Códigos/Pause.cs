using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool pausa= false;

    public GameObject pausaUI;
    private PlayerControl playerControl;
    private Inventory inventory;
     void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P)){

            if (pausa)
            {
                Resume();
            }
            else {
                Pause1();
            
            }

        
        }

    }


    void Resume()
    {
        pausaUI.SetActive(false);
        inventory.enabled = true;
        pausa = false;
        playerControl.enabled = true;
        GameManager.menuAbierto = false;

    }

    void Pause1()
    {
       
            pausaUI.SetActive(true);
            inventory.enabled = false;
            pausa = true;
            playerControl.enabled = false;
            GameManager.menuAbierto = true;
        

    }

    public void QuitarJuegop()
    {
        print("hoLITAS DE MAR");
        Application.Quit();
    }

}


