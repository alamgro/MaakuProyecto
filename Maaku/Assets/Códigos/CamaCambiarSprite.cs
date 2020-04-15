using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaCambiarSprite : MonoBehaviour
{
    public GameObject personaje;
    // Start is called before the first frame update
    Vector3 posReal;
    //float timer = 0.0f;

    void Start()
    {
        //personaje.SetActive(false);
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/Cama/CamaMaaku1");
        posReal = this.transform.position;
    }

    // Update is called once per frame
    /*void Update()
    {
        timer += Time.deltaTime;
        if(timer > 4.5f)
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/Cama/Cama");
            this.transform.position = posReal;
            personaje.SetActive(true);
        }
        else if (timer > 3.0f)
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/Cama/CamaMaaku3");
            this.transform.position = new Vector3(this.transform.position.x, -0.447f, 0);
        }
        else if (timer > 1.5f)
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/Cama/CamaMaaku2");
        }

    }*/
}
