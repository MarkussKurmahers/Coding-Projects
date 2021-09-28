using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePickableObject : ObjectInteract
{
    public override void OnStartInteracting()
    {
        if(PlayerInteract.PickedObject == null)
        {
            PlayerInteract.PickedObject = gameObject;
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    public override void OnEndInteracting()
    {
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    
}
