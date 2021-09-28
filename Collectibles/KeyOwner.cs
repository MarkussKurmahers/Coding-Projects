using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOwner : MonoBehaviour
{
    private List<KeyScript.Key> GoldKey;
    private void Awake()
    {
        GoldKey = new List<KeyScript.Key>();
    }
    public void PickUpKey(KeyScript.Key key) // Picks up the key, adds it to the player
    {
        Debug.Log("Pickup up a " + key);
        GoldKey.Add(key);
    }
    public void UseKey(KeyScript.Key key) // Uses the key on the door and removes it from the player
    {
        GoldKey.Remove(key);
    }
    public bool HoldingTheKey(KeyScript.Key key) // Checks if the player still contains the key
    {
        return GoldKey.Contains(key);
    }
    private void OnTriggerEnter2D(Collider2D collision) // On entering the trigger, picks it up and destroys it in the environment
    {
        KeyScript Key = collision.GetComponent<KeyScript>();
        if (Key != null)
        {
            PickUpKey(Key.GetKey());
            Destroy(Key.gameObject);
        }
        GoldenDoorKey GoldenKey = collision.GetComponent<GoldenDoorKey>();
        if (GoldenKey != null)
        {
            if (HoldingTheKey(GoldenKey.GetKey())) // Opens the door if the player has the key
            {
                UseKey(GoldenKey.GetKey());
                GoldenKey.UnlockDoor();
            }
            // Holding the key
        }
    }
}
