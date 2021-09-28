using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObj : Trigger
{
    Animator anim;

    public override void OnTrigger()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Activated", true);
        CharInteraction.locked = true;
    }
}
