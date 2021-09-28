using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    [SerializeField] private Key key;

    public enum Key
    {
        Gold,
        Gold1,
        Gold2
    }

    public Key GetKey()
    {
        return key;
    }
}
