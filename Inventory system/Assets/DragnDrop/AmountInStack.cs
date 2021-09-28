using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountInStack : MonoBehaviour
{
    Text ItemAmount;
    DragnDrop a;
    // Start is called before the first frame update
    void Start()
    {
        ItemAmount = GetComponent<Text>(); // Script is for updating the number 
        a = GetComponentInParent<DragnDrop>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ItemAmount.text = a.Amount.ToString();
    }
}
