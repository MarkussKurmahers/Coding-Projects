using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHolder : MonoBehaviour
{
    public GameObject Star;
    public GameObject StarUI;

    public void Start()
    {
        StarUI.SetActive(false); //Hides the StarUI 
    }

  private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager manager = collision.GetComponent<PlayerManager>(); //If the Star collides with the player
        if(manager)
        {
            manager.PickupStar();
            Star.SetActive(false); //Hides the Star from the level
            StarUI.SetActive(true); //Shows the Star on the UI when it has been collected
        }
    }
}
