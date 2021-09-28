using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkussSafe : MonoBehaviour
{
    public MarkussTumbler FirstDig;
    public MarkussTumbler SecondDig;
    public MarkussTumbler ThirdDig;
    public MarkussTumbler FourthDig;

    public string SafeCode = "1130";

    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        string Code = FirstDig.value.ToString() + SecondDig.value.ToString() + ThirdDig.value.ToString() + FourthDig.value.ToString();
        Debug.Log(Code);
        if(Code.Equals(SafeCode))
        {
            anim.SetBool("Open", true);
        }
    }
}
