using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkussTumbler : ObjectInteract
{
    public int value = 2;

    public override void OnStartInteracting()
    {
        value++;
        if (value > 9)
        {
            value = 0;
        }
    }
    private void Update()
    {
        int angle = value - 2;
        float rotateAngle = angle * 36f;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, rotateAngle, 0f), Time.deltaTime*2f);
    }
}
