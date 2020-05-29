﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SofaColicion : MonoBehaviour
{
    private GameObject makku;
    void Start()
    {
        makku = GameObject.FindGameObjectWithTag("Player");
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(makku.transform.position.y > -1.5)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
