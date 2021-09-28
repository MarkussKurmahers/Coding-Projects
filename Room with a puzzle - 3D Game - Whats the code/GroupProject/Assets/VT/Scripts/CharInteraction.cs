using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInteraction : MonoBehaviour
{
    public LayerMask mask;
    static public bool locked = false;
  
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1.5f, mask))
            {
                if(hit.collider.GetComponent<Trigger>() != null)
                {
                    hit.collider.GetComponent<Trigger>().OnTrigger();
                }
            }
        }
    }
}
