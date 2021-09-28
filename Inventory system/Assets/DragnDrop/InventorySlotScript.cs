using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotScript : MonoBehaviour, IDropHandler
{
    public bool Full = false;
    public int Count = 0;
    public int SlotNumber;
    public GameObject ItemInSlot;
    public DragnDrop ItemObject;
    public bool Check = false;
    public void OnDrop(PointerEventData eventData) // Activates, when item is dropped
    {
        //Debug.Log("On Drop");
        if (eventData.pointerDrag != null) // Checks if there is an item inside the slot
        {
            bool FullSlots = true;
            if (Full == false) // If it doesn't have an item, it goes to putting an item into an empty slot
            {
                Check = false;
            }
            if (Full == true && Check == true) // If the slot has the item, then we're gonna move the item in the slot to the next empty slot and the Assistant changes the variables we need for the next slot
            {
                if(ItemInSlot != null) // If there is no item in the slot, it skips the following steps
                {
                    DragnDrop Assistant = ItemInSlot.GetComponent<DragnDrop>();
                    if (Assistant.ItemName == ItemObject.ItemName) // If the item names are the same
                    {
                        if (Assistant.Amount + ItemObject.Amount <= ItemObject.MaxStack) // The Item we are dragging Amount and the Amount in the slot
                        {
                            Assistant.Amount = ItemObject.Amount + Assistant.Amount; // Not bigger than max stack, so it just is being added
                            Destroy(ItemObject.gameObject);
                            ItemObject = null;
                            FullSlots = false; // Even the inventory might be full, I am setting this var to be false, to avoid extra checks
                        }
                        else // In case the amount is bigger than the MaxStack
                        {
                            Assistant.Amount = ItemObject.Amount + Assistant.Amount - Assistant.MaxStack; // Assistant.Amount I tem in the slot, changes the amount to the difference
                            ItemObject.Amount = ItemObject.MaxStack;
                        }

                    }
                    if (ItemObject != null) // Checks if the item is still there
                    {
                        int n = 0;
                        while (n < Assistant.Slots.Length) // Checks every slot, moves the item to the next empty slot
                        {
                            if (Assistant.Slots[n].Full == false) // Checks if a slot is empty
                            {
                                Assistant.SlotNumber = n;
                                ItemInSlot.transform.position = Assistant.Slots[n].transform.position;
                                Assistant.Slots[n].Full = true;
                                Assistant.Item = true;
                                Assistant.Slots[n].ItemInSlot = Assistant.gameObject;
                                Assistant.Slots[n].Check = true;
                                Assistant.Slots[n].Count = 1;
                                n = Assistant.Slots.Length;
                                FullSlots = false; // found empty slot
                            }
                            n++;
                        }
                        if (FullSlots == true) // In case I did not find an empty slot, Item is being put in the environment
                        {
                            int x, y;
                            x = Random.Range(50, 400);
                            y = Random.Range(50, 400);
                            ItemInSlot.transform.position = new Vector2(x, y);
                        }
                    }
                    
                   
                }
                
            }
            if (ItemObject != null) // When all is done, I put the item 
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Count = 1;
                ItemObject.SlotNumber = SlotNumber;
                Full = true;
                Check = true;
                ItemInSlot = ItemObject.gameObject;
            }
            
        }
    }
    public void OnTriggerEnter2D(Collider2D other) // Once the item enters the slot, it gets all the item components, once the item is set into the slot, that value is going to be saved in the current slot variable, so its hella useful
    {
        ItemObject = other.GetComponent<DragnDrop>();
    }
    public void OnTriggerExit2D(Collider2D other) // Once the item exits the slot, it cleans all the info from the slot
    {
        DragnDrop Assistant = other.GetComponent<DragnDrop>();
        if (other.gameObject == ItemInSlot) // If the item was in the slot, It clears all the info from that slot about that item
        {
            // Debug.Log("He lied");
            Count = 0;
            Assistant.SlotNumber = -1;
            Full = false;
            Check = false;
            Assistant.Item = false;
        }
    }
    void Update()
    {
        if (Count == 0) // Updates the slot to make it empty
        {
            Full = false;
        }
    }
    public void PrintContent()
    {
        // n = 0;
        //while (n < Slots.Length - 1)
        //{
        
        if (Full == true) // Checks if the slot is full, if it is, it prints on Debug.Log The Item and the amount
        {
            DragnDrop Assistant = ItemInSlot.GetComponent<DragnDrop>();
            Debug.Log(Assistant.ItemName + Assistant.Amount);
        }
       
        //}
    }
}
