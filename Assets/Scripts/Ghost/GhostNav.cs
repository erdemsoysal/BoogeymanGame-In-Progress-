using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GhostNav : MonoBehaviour
{
    NavMeshAgent ghostNav;
    GameObject player;
    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        ghostNav = GetComponentInChildren<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        ghost.transform.localRotation = Quaternion.Euler(0,0,0);
    }
    // Update is called once per frame
    void Update()
    {
        GhostSearch();
    }

    private void GhostSearch() 
    {
        float distanceToGhost = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToGhost < 3)
        {
            moveToPlayer();
        }
    }

    private void moveToPlayer()
    {
        ghostNav.SetDestination(player.transform.position);
    }

}
