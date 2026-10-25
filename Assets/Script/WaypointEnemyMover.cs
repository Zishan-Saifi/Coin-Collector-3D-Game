using UnityEngine;

public class WaypointEnemyMover : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;
    private int currentWaypointIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame

    void Update()
    {
        if (waypoints == null || waypoints.Length ==0) return;
        if (waypoints[currentWaypointIndex] == null) return;
        Transform target = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            transform.position = target.position;
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        }


        
    }
}
