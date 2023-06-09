using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {   
        //jeżeli dotykamy jednego z końców
        if(Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < .1f){
            currentWaypoint++;
            currentWaypoint %= waypoints.Length;
        }    
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}
