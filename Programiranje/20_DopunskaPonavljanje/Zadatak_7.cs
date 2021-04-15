using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napišite skriptu koja na tipku W udara silom na objekt u smjeru X osi,
//na tipku S u negativnom smjeru X osi, na tipku A u pozitivnom smjeru Z osi,
//a na tipku D u negativnom smjeru Z osi
public class Zadatak_7 : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.forward * Time.deltaTime * speed;
            rb.AddForce(Vector3.forward * speed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }
    }
}
