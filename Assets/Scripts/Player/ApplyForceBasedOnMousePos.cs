using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ApplyForceBasedOnMousePos : MonoBehaviour
{
    private Rigidbody2D rbObject;
    public float forceToApply = 10f;
    public float minDistanceToInteractMouse = 10;
    //public float maxForce 

    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rbObject = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 force =  mousePosition - (Vector2)transform.position;
        force = force.normalized * forceToApply;

        //print(force);

        Debug.DrawRay(transform.position, mousePosition, Color.red);
        //print("Force " + force +"  ||   Mag : "+force.magnitude);



        if (Vector2.Distance(transform.position, mousePosition) <= minDistanceToInteractMouse)
        {
            rbObject.AddForce( - force * Time.deltaTime, ForceMode2D.Impulse);
            GetComponent<InstantiateShootWithForce>().Shoot(mousePosition);
        }

        //rbObject.velocity.magnitude > 

    }
}
