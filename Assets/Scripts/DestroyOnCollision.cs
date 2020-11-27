using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public bool isEnemyBullet;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (gameObject.layer == GameInfo.BULLET_LAYER && collision.gameObject.layer == GameInfo.ENEMY_LAYER)
            Destroy(this.gameObject);
        //else if (isEnemyBullet && collision.gameObject.layer == GameInfo.PLAYER_LAYER)
            //Destroy(this.gameObject);
    }
}
