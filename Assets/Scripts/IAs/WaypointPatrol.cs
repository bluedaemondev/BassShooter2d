using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPatrol : MonoBehaviour
{
    [Header("Para definir el recorrido que hace")]
    public bool resetsOnFinalWaypoint;
    public List<Transform> waypoints;
    public float speedMov;
    public float speedMultip = 1;


    public Transform currentWaypoint;
    public int currentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {

        currentWaypoint = waypoints[currentWaypointIndex];
        // tp al primer punto
        transform.position = waypoints[currentWaypointIndex].position;

        // establezco el proximo si se mueve
        if (waypoints.Count > 1)
        {
            currentWaypoint = waypoints[1];
            currentWaypointIndex = 1;
        }
        

    }

    private void Update()
    {
        MoveCharacter();
    }

    // Update is called once per frame
    public void MoveCharacter()
    {
        //se fija si alcanzo el objetivo y avanza de punto
        MoveNextWaypoint();

        // translation
        var movVector = Vector2.MoveTowards(transform.position, currentWaypoint.position, speedMov * speedMultip * Time.deltaTime);
        //transform.position = movVector;


        var lScale = transform.localScale;
        // pos siguiente a la derecha, flip sprite
        if (movVector.x > transform.position.x && lScale.x > 0)
        {
           
            lScale.x = -lScale.x;
        }
        else if(movVector.x < transform.position.x && lScale.x < 0  )
        {
            lScale.x = Mathf.Abs(lScale.x);
        }

        transform.localScale = lScale;

        GetComponent<Rigidbody2D>().MovePosition(movVector);
        //resetea si llego al final de la lista
        CheckForReset();

    }

    void CheckForReset()
    {
        // reseteo de puntos al primer waypoint (si es circular)
        if (resetsOnFinalWaypoint && currentWaypointIndex == waypoints.Count)
        {
            currentWaypointIndex = 0;
            currentWaypoint = waypoints[0];
        }
    }

    public void SetSpeedMultiplier(float speedMultip)
    {
        this.speedMultip = speedMultip;
    }

    void MoveNextWaypoint()
    {
        // avance al siguiente waypoint
        if (transform.position == currentWaypoint.position)
        {
            var next = ++currentWaypointIndex;
            if (next != waypoints.Count)
                currentWaypoint = waypoints[next];
        }
    }
}
