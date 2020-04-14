using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaCambiarSprite : MonoBehaviour
{
    public GameObject personaje;
    int count = 0;
    // Start is called before the first frame update
    Vector3 posReal;
    void Start()
    {
        personaje.SetActive(false);
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/Cama/CamaMaaku1");
        posReal = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if(count == 0)
            {
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/Cama/CamaMaaku2");
                count++;
            }
            else if (count == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/Cama/CamaMaaku3");
                this.transform.position = new Vector3(this.transform.position.x, -0.447f, 0);
                count++;
            }
            else if (count == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/Cama/Cama");
                this.transform.position = posReal;
                personaje.SetActive(true);
                count++;
            }

        }
        
        

    }
}
