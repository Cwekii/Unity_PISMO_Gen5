using UnityEngine;

public class Zadatak_9 : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            if(rb.isKinematic)
            {
                rb.isKinematic = false;
            }  
            else
            {
                rb.isKinematic = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            if(rb.useGravity)
            {
                rb.useGravity = false;
            }
            else
            {
                rb.useGravity = true;
            }
        }
    }
}
