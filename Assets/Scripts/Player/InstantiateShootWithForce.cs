using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ApplyForceBasedOnMousePos), typeof(Rigidbody2D))]
public class InstantiateShootWithForce : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject gunpoint;
    public Animator animator;

    public float speedShot = 2f;
    public void Shoot(Vector2 screenPosDirection)
    {
        animator.Play("shoot-move");
        GameObject bull = Instantiate(bulletPrefab, GameInfo.instance.particlesContainer, true);
        bull.transform.position = gunpoint.transform.position;

        bull.GetComponent<Rigidbody2D>().AddForce((screenPosDirection - (Vector2)transform.position) * speedShot,
            ForceMode2D.Impulse);
    }
    private Vector3 TurnGunpoint()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angleRot = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunpoint.transform.eulerAngles = new Vector3(0, 0, angleRot);

        return gunpoint.transform.eulerAngles;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        TurnGunpoint();
        if (!Input.GetMouseButtonDown(0))
            return;
        //Shoot();
    }
}
