using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private NavMeshAgent Mob;

    public GameObject player;

    public float Attack_distance = 30f;

    // prepare for WayPoint 
    public List<Transform> waypoints = new  List<Transform>();
    private Transform TargetWaypoint;
    private int TargetWaypointIndex = 0;
    private int LastWaypointIndex;
    private float MiniDistance = 1f;

    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();

        LastWaypointIndex = waypoints.Count-1;
        TargetWaypoint = waypoints[TargetWaypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        float Player_distance = Vector3.Distance(transform.position, player.transform.position);

        // chase player if the player is in the attack range.
        if(Player_distance < Attack_distance){

            Vector3 dirToplayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToplayer;

            Mob.SetDestination(newPos); 

        // if the player is not in the attack range then patrol around the map.
        }
        else{
            
            float Waypoint_distance = Vector3.Distance(transform.position, TargetWaypoint.position);
            Checkdistancetowaypoint(Waypoint_distance);

            Mob.SetDestination(TargetWaypoint.position);
        }
    }

    void Checkdistancetowaypoint(float currentdistance){

        if(currentdistance <= MiniDistance){

            TargetWaypointIndex += 1;
            UpdateTargetPoint();
        }
    }

    void UpdateTargetPoint(){

        if(TargetWaypointIndex > LastWaypointIndex){

            TargetWaypointIndex = 0;
        }

        TargetWaypoint = waypoints[TargetWaypointIndex];
    }
}
