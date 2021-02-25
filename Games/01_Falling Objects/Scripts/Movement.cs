using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed; //vrijednost za brzinu kretanja
    Rigidbody rb;

    //U startu dodjeljujemo rb u skriptu
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Kretanje desno
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * speed);
        }

        //Kretanje lijevo
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * speed);
        }
    }
}
