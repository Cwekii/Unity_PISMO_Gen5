using UnityEngine;

public class Zadatak_10 : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.right);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector3.left);
            //rb.AddForce(-Vector3.right);
            //rb.AddForce(new Vector3(-1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector3.back);
        }
    }
}
