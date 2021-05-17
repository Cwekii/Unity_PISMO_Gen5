using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy_AI : MonoBehaviour
{
    public Transform player; //Objekt do kojeg enemy AI treba ići (pratiti)
    Vector3 finalDestionation; //Konačna pozicija na koju enemy treba doći
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<CharacterController>().gameObject.transform;
        finalDestionation = agent.destination;
    }

    private void LateUpdate()
    {
        if(Vector3.Distance(finalDestionation, player.position) > 2.0f)
        {
            finalDestionation = player.position;
            agent.destination = finalDestionation;
        }
    }
}
