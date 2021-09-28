using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneFromVT : Trigger //VTroomDoorScript
{
    public string newScene;

    public override void OnTrigger()
    {
        if(CharInteraction.locked == true)
        {
            SceneManager.LoadScene(newScene);
        }
    }
}
