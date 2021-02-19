using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    //Kada nam je bool pozitivan onda nam je i objekt koji skupljamo
    //Ako nam je negativan bool onda nam je to predmet koji izbjegavamo
    [Header("True = Good prefab | False = Bad prefab")]
    public bool isPositive = true;
    GameManager gm;

    private void Start()
    {
        //Dodjeliti game manager skriptu da se povezuje sa skriptom falling object tako što 
        //unity pretraži hijarahiju i nađe koji objekt na sebi ima GameManager skriptu
        //Problem je jedino ako imamo vise objekata sa skriptom GameManager što kod nas nije

        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Predmet koji player skuplja

        if (isPositive)
        {
            if (other.gameObject.tag == "Player")
            {
                gm.score++;
                Destroy(this.gameObject);
            }
            if(other.gameObject.tag == "Floor")
            {
                if(gm.score > 0)
                {
                    gm.score--;
                }
                Destroy(this.gameObject);
            }
        }
        //Predmet koji player izbjegava

        else if (isPositive == false)
        {
            if (other.gameObject.tag == "Player")
            {
                gm.life--;
                Destroy(this.gameObject);
            }
            if (other.gameObject.tag == "Floor")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
