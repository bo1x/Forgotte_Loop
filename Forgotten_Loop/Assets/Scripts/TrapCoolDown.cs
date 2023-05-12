using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCoolDown : MonoBehaviour
{
    public Animator myanim;

   void Inactive()
    {
        myanim.Play("Inactive");
    }

    void Active()
    {
        myanim.Play("Active");
    }
}
