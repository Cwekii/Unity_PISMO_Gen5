using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IEnumerator_Zd1 : MonoBehaviour
{
    public Text timerText;
    int timer = 0;
    


    private void Start()
    {
        
        StartCoroutine(Sat());
    }

    IEnumerator Sat()
    {
        while(timer >= 0 && timer < 3600)
        {
            if (timer % 60 < 10 && timer / 60 < 10)
            {
                timerText.text = "0" + timer / 60 + ":" + "0" + timer % 60;
            }
            
            if(timer % 60 > 10 && timer / 60 <10)
            {
                timerText.text = "0" + timer / 60 + ":" + timer % 60;
            }
            if(timer % 60 < 10 && timer / 60 > 10)
            {
                timerText.text = timer / 60 + ":" + "0" + timer % 60;
            }
            if(timer % 60 > 10 && timer / 60 > 10)
            {
                timerText.text = timer / 60 + ":" + timer % 60;
            }
            timer++;
            yield return new WaitForSeconds(1);
               
                
                
               
        }
       

    }
}
