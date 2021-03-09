using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumerator_Ex2 : MonoBehaviour
{
    public string ourText;
    public int counter = 0;
    private void Start()
    {
        StartCoroutine(SpawnPrimitiveObject());
    }

    IEnumerator SpawnPrimitiveObject()
    {
        while(true)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(counter, counter, 0);
            counter++;
            Debug.Log(ourText + " " + counter);
            yield return new WaitForSeconds(3f);
        }
    }
}
