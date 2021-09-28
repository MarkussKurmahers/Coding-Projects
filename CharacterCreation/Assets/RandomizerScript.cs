using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    public List<ChangeOutfit> ChangeOutfits = new List<ChangeOutfit>();
    string RandomizerTest;
    string ForTheMoment;
    public void CharacterRandomizer()
    {
        ForTheMoment = null;
            foreach (ChangeOutfit changer in ChangeOutfits) // need to go through each object
            {
                RandomizerTest = changer.Randomizer();
                // Debug.Log(RandomizerTest);
                ForTheMoment = ForTheMoment + " " + RandomizerTest; // Input in line all choices
            }
         Debug.Log(ForTheMoment); // Shows the random character at that moment on the screen and the debug.log, when it gets randomized
    }
}
