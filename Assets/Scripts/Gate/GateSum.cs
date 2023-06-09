using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSum : MonoBehaviour
{
    public int arrows;
    private float randomPos = 0.5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<Player>())
        {
            for (int i = 0; i < arrows; i++)
            {
                GameObject newArrows = Instantiate(collision.gameObject.GetComponentInParent<Player>().arrowPrefabs, collision.gameObject.GetComponentInParent<Player>().transform);

                newArrows.transform.localPosition = new Vector3(Random.Range(-randomPos, randomPos), 
                                                                Random.Range(-randomPos, randomPos), 0);

                Destroy(gameObject);

            }
        }
    }
}