using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Neka se sfera pomiče za 0.1 po sve tri osi svaki frame

public class TransformPosition : MonoBehaviour
{
    private void Update()
    {
        transform.localPosition += new Vector3(0.1f, 0.1f, 0.1f);
    }
}
