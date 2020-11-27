using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    Rigidbody2D rbComp;

    public Transform followTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (followTarget == null)
            followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        rbComp = GetComponent<Rigidbody2D>();
    }
    public void Move()
    {
        if (followTarget)
        {
            Vector2 nextMov = Vector2.MoveTowards(transform.position, followTarget.position, moveSpeed * Time.deltaTime);
            rbComp.MovePosition(nextMov);
        }
    }
}
