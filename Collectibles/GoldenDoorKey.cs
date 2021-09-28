using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenDoorKey : MonoBehaviour
{
    [SerializeField] private KeyScript.Key key;

    public KeyScript.Key GetKey()
    {
        return key;
    }
    public void UnlockDoor()
    {
        gameObject.SetActive(false);
    }
}
