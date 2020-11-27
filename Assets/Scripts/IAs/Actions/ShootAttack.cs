using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ShootAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speedShot = 4f;

    public Vector2 directionShoot = Vector2.up;


    public string shootAnimParam = "isAttacking";
    public bool isAttacking;
    Animator animator;

    [Header("Propiedades del ataque")]
    public float timerEntreAtaques = 2f;
    float timerActual = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        timerActual += Time.deltaTime;

        if (timerActual >= timerEntreAtaques)
        {
            timerActual = 0;
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        //altobobo

        animator.SetBool(shootAnimParam, isAttacking);
    }

    public void Shoot()
    {
        GameObject bull = Instantiate(bulletPrefab, GameInfo.instance.particlesContainer, true);
        bull.transform.position = transform.position;
        bull.GetComponent<Rigidbody2D>().AddForce(directionShoot * speedShot, ForceMode2D.Impulse);

    }
}
