using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public InventorySlotScript[] Button;
    public void ButtonContent() // Checks the slots and prints them
    {
        int n = 0;
        while (n < Button.Length)
        {
            Button[n].PrintContent();
            n++;
        }
    }
}
