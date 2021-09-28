using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler // Making these systems to make drag and drop work
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTr;
    private CanvasGroup canvasGr;
    public InventorySlotScript[] Slots;
    public bool Item = false;
    public int n = 0;
    public int SlotNumber = -1;
    private int h = 0;
    public string ItemName;
    public int MaxStack = 4;
    public int Amount = 0;
    private bool found;
    //private bool ready = true;
    private void Awake() // When the program activates, it gets the components
    {
        rectTr = GetComponent<RectTransform>();
        canvasGr = GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData) // Triggered when clicked on item
    {
        //Debug.Log("Click on Item");
        if (Input.GetMouseButtonDown(1)) // Right Click to pick the item up in inventory
        {
            n = 0;
            Debug.Log("Right click");
            found = false;
            
            /*while (n < Slots.Length - 1) // Goes through every slot,, THIS DOES NOT WORK :((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
            {
                if(ready == true && Item == false) // 
                {
                    if (Slots[n].ItemInSlot != null)
                    {
                        DragnDrop Assistant = Slots[n].ItemInSlot.GetComponent<DragnDrop>();
                        if (ItemName == Assistant.ItemName)
                        {
                            if (Amount + Assistant.Amount <= MaxStack) // 
                            {
                                Assistant.Amount += Amount;
                                Destroy(gameObject);
                                found = true;
                                n = Slots.Length;
                            }
                            else
                            {
                                Assistant.Amount = Amount + Assistant.Amount - MaxStack;
                                Amount = MaxStack;
                            }
                        }
                        
                    }
                }
                else
                {
                    n++;
                }
                n++;
            }*/
            n = 0;
            while (n < Slots.Length && Item == false && found == false) // Checks if an Item is in the slot(Slot is empty or not)
            {

                if (Slots[n].Full == false) // Checks if the slot is empty(literally)
                {
                    SlotNumber = n;
                    transform.position = Slots[n].transform.position;
                    Slots[n].Full = true;
                    Item = true;
                    Slots[n].Count = 1;
                    Slots[n].Check = true;
                    Slots[n].ItemInSlot = gameObject;
                }
                n++;
            }
            if (Item == true && n == 0) // Checks if the slot is full, if yes, then it takes out the item with a right click
            {
                int x, y;
                x = Random.Range(50, 400);
                y = Random.Range(50, 400);
                transform.position = new Vector2(x, y); // Puts in a random place within the environment coordinates
                Item = false;
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData) // Activates, when Item has been started to be dragged around
    {
        //Debug.Log("Drag starting");
        canvasGr.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)// Is triggered when dragging the item
    {
        //Debug.Log("Dragging");
        rectTr.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData) // Activates, when Item is not being dragged anymore
    {
        //Debug.Log("Drag ending");
        canvasGr.blocksRaycasts = true;
    }
    void Update()
    {
        if (Slots[0].Count == 1 ) // Updates the slots so they are full
        {
            Slots[0].Full = true;
        }
        if (Slots[1].Count == 1)
        {
            Slots[1].Full = true;
        }
        if (Slots[2].Count == 1)
        {
            Slots[2].Full = true;
        }
        if (Slots[3].Count == 1)
        {
            Slots[3].Full = true;
        }
        h++;
        if (h > Slots.Length - 1)
        {
            h = 0;
        }
        if (Slots[h].transform.position == transform.position)
        {
            Item = true;
        }
        //Debug.Log("Is " + this.gameObject.name + " item in inventory slot? : " + Item); // Item is the real problem, find a way how to update this
    }
    
}
