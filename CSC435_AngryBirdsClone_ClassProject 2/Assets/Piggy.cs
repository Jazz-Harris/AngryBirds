using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piggy : MonoBehaviour
{
    private float _damageForce = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Compute the relaive velocity of the colliding object
        float collisionForce = collision.relativeVelocity.sqrMagnitude;
        Debug.Log(collisionForce);

        if (collisionForce > _damageForce)
        {
            //Destroy the pig
            UIManager.instance.totalPigsInScene -= 1;
            Destroy(gameObject);
        }
    }
}
