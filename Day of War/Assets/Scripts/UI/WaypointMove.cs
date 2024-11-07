using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WaypointMove : MonoBehaviour
{
    [SerializeField] private WayPointSystem waypoint;
    [SerializeField] private float movespeed;
    private Transform currentwaypoint;
    private float distanceThreshold = 1f;
    private Quaternion rotationtarget;
    private Vector3 waypointdirection;
    [SerializeField] private float rotatespeed;
    void Start()
    {
        movespeed = 90f;
        currentwaypoint = waypoint.GetNextWaypoint(currentwaypoint);
        transform.position = currentwaypoint.position;
        currentwaypoint = waypoint.GetNextWaypoint(currentwaypoint);
        transform.LookAt(currentwaypoint.position);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentwaypoint.position, movespeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentwaypoint.position) < distanceThreshold)
        {
            currentwaypoint = waypoint.GetNextWaypoint(currentwaypoint);
        }
        rotatetowardspoint();
    }
    public void rotatetowardspoint()
    {
        Vector3 targetPosition = new Vector3(currentwaypoint.position.x, currentwaypoint.position.y, currentwaypoint.position.z);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotatespeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(80f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
