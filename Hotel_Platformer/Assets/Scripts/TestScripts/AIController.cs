using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {

    private GameObject player;//object to follow
    private NavMeshAgent agent;//easy accesible navagent int the script

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//find the component
        player = GameObject.FindGameObjectWithTag("Player");//find da player
    }

    private void Update()
    {
        agent.destination = player.transform.position;//update destination
    }
}
