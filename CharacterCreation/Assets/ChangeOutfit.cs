using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOutfit : MonoBehaviour
{
    public SpriteRenderer bodyPart; // needed reference
    public List<Sprite> options = new List<Sprite>(); // always new
    private int OptionAtTheMoment = 0; // which exact option is active
    public void ChooseNext()
    {
        OptionAtTheMoment++; // adds one for next
        if (OptionAtTheMoment >= options.Count)
        {
            OptionAtTheMoment = 0;
        }
        bodyPart.sprite = options[OptionAtTheMoment];
        string test = OptionAtTheMoment.ToString();
        string test3 = gameObject.name;
        Debug.Log("Current option is " + test3 + " Clothing option " + test);
    }
    public void ChoosePrevious()
    {
        OptionAtTheMoment--; // substracts one for previous
        if (OptionAtTheMoment <= 0)
        {
            OptionAtTheMoment = options.Count - 1;
        }
        bodyPart.sprite = options[OptionAtTheMoment];
        string test = OptionAtTheMoment.ToString(); // so it writes the result? yes
        string test3 = gameObject.name; // chosen object name written in debug.log
        Debug.Log("Current option is " + test3 + " Clothing option " + test);
    }
    public string Randomizer()
    {
        OptionAtTheMoment = Random.Range(0, options.Count - 1); // Random sprite from options
        bodyPart.sprite = options[OptionAtTheMoment];
        string test = OptionAtTheMoment.ToString(); // To be able to type the name
        string test3 = gameObject.name;
        // Debug.Log("Current option is " + test3 + " Clothing option " + test);
        string AllTest = test + " " + test3;
        return AllTest;
    }
}
