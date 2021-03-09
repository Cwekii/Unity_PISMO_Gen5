using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drugiZad : MonoBehaviour
{
    public GameObject [] pbjekti;
    
   

    private void Start()
    {
        StartCoroutine(lol());
    }

    IEnumerator lol ()
      
    {
        while (true)
        {
            Instantiate(pbjekti[Random.Range(0,pbjekti.Length)], new Vector3(Random.Range(0, -10), Random.Range(0, -20), Random.Range(-15, -15)), Quaternion.identity);
            yield return new WaitForSeconds(5);

        }
    }
}
