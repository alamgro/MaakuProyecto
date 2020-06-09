using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambio_ropa : MonoBehaviour
{
    public GameObject player;
    public AnimatorOverrideController Player_outfit1_sombrero;
    public AnimatorOverrideController Player_outfit1;
    public int Contador = 0;


    public void Ropa1_sombrero()
    {
        Contador++;
        if (Contador > 1)
        {
            Contador = 0;
        }
        if (Contador == 0)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit1 as RuntimeAnimatorController;
        }
        if (Contador == 1)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit1_sombrero as RuntimeAnimatorController;
        }
    }
}
