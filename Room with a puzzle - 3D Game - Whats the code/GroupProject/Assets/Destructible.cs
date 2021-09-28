using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject DestroyedObject;
    
    private void OnMouseDown()
    {
        Instantiate(DestroyedObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
