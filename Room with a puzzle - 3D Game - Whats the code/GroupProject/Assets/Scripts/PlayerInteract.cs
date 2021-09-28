using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask mask;
    public GameObject PickUpPosition;
    public static GameObject PickedObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (PickedObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f, mask))
                {
                    if (hit.collider.GetComponent<ObjectInteract>() != null)
                    {
                        hit.collider.GetComponent<ObjectInteract>().OnStartInteracting();
                    }
                }
            }
            else
            {
                PickedObject.transform.parent = null;
                PickedObject.GetComponent<ObjectInteract>().OnEndInteracting();
                PickedObject = null;
            }
        }
        if(PickedObject != null)
        {
            PickedObject.transform.parent = PickUpPosition.transform;
            PickedObject.transform.position = Vector3.Lerp(PickedObject.transform.position, PickUpPosition.transform.position, Time.deltaTime*10f);
            PickedObject.transform.rotation = Quaternion.Slerp(PickedObject.transform.rotation, PickUpPosition.transform.rotation, Time.deltaTime * 10f);
        }
    }
}
