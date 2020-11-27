using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class HealthScript : MonoBehaviour
{
    [Header("Medidor de estados")]
    public int currentLife = 3;
    public int maxLife = 3;
    public float cameraShakeFactor = 5f;

    public bool isPlayer = false;

    [Header("Opcional para jugador")]
    public GameObject deadScreenGO;

    public UnityEvent OnDeathEvent;

    public AudioClip damagedSound;
    public AudioClip deathSound;

    Animator animator;
    public string deadTrigger = "isDead";
    public string damagedAnimName = "damaged";




    private void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    public void ResetLife()
    {
        this.currentLife = maxLife;

    }
    public bool GetDamage(int damage)
    {
        bool died = false;

        CamerasManager.instance.ShakeCameraNormal(cameraShakeFactor, .2f);
        this.currentLife -= damage;

        if (currentLife <= 0)
        {
            died = true;
            this.animator.SetBool(deadTrigger, true);

            if (isPlayer)
                GameManagerActions.current.defeatEvent.Invoke();
        }

        animator.Play(damagedAnimName);

        return died;

    }

    public void DamageSound()
    {
        SoundManager.instance.PlayEffect(damagedSound);
    }
    public void DeathSound()
    {
        SoundManager.instance.PlayEffect(damagedSound);
    }

}
