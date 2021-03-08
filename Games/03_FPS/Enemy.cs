using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float damage;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
    }

    private void OnTriggerEnter(Collider kurac)
    {
        if(kurac.gameObject.tag == "Player")
        {
            Health hp = kurac.gameObject.GetComponent<Health>();
            hp.currentHealth -= damage;
            Destroy(this.gameObject);
        }
    }
}
