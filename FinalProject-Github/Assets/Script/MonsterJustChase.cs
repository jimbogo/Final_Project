using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterJustChase : MonoBehaviour
{
    private NavMeshAgent Mob;

    public GameObject player;




    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float Player_distance = Vector3.Distance(transform.position, player.transform.position);

        Vector3 dirToplayer = transform.position - player.transform.position;

        Vector3 newPos = transform.position - dirToplayer;

        Mob.SetDestination(newPos); 



    }
}
