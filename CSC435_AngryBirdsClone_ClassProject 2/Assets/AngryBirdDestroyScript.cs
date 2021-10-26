using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdDestroyScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            // Destroy it after 5 seconds
            StartCoroutine(DestroyAngryBird());
        }
    }

    IEnumerator DestroyAngryBird()
    {
        yield return new WaitForSeconds(5);

        MyGameManager.instance.availableChances -= 1;

        Destroy(gameObject);

    }
}
