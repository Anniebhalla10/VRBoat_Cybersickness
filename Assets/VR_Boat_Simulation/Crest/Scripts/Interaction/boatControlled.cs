using UnityEngine;

public class BoatWaypointNavigator : MonoBehaviour
{
    public Transform[] waypoints;
    public float waypointThreshold = 20f; 
    public float enginePower = 7f;
    public float turnPower = 0.5f;
    public float turningHeel = 0.35f;
    public float forceHeightOffset = 0f;

    private Rigidbody _rb;
    private int currentWaypointIndex = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogWarning("Waypoints are not set for BoatWaypointNavigator.");
        }
    }

    void FixedUpdate()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        NavigateToWaypoints();
    }

    void NavigateToWaypoints()
    {
        var forcePosition = _rb.position;
        Vector3 directionToWaypoint = (waypoints[currentWaypointIndex].position - transform.position).normalized;

        float forward = Vector3.Dot(transform.forward, directionToWaypoint);
        float sideways = Vector3.Dot(transform.right, directionToWaypoint);

        _rb.AddForceAtPosition(enginePower * forward * transform.forward, forcePosition, ForceMode.Acceleration);
        var rotVec = transform.up + turningHeel * transform.forward;
        _rb.AddTorque(turnPower * sideways * rotVec, ForceMode.Acceleration);

        float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        if (distanceToWaypoint < waypointThreshold)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
