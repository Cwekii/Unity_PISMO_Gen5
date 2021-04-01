using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNewTarget : MonoBehaviour
{
    public Text countText;
    public int countObjects = 0;
    public bool auto = false;
    public bool marko = false;

    public void FoundCar()
    {
        if(auto == false)
        {
            auto = true;
            countObjects++;
            countText.text = countObjects + "/10";
        }
    }

    public void FoundMarko()
    {
        if (marko == false)
        {
            marko = true;
            countObjects++;
            countText.text = countObjects + "/10";
        }
    }
}
