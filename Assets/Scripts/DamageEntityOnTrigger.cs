using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEntityOnTrigger : MonoBehaviour
{
    public int dmgDone = 1;
    public bool toPlayer = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (toPlayer && collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            collision.GetComponent<HealthScript>().GetDamage(dmgDone);
            //print("dmg"); //ok
        }
        else if (!toPlayer && collision.gameObject.layer == GameInfo.ENEMY_LAYER && !collision.gameObject.name.Contains("spike"))
        {
            collision.GetComponent<HealthScript>().GetDamage(dmgDone);
            //print("dmg"); //ok
        }
    }

}
