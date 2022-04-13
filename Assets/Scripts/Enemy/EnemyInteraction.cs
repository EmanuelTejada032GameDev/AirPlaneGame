using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{

    public GameObject explosionPrefab;

    private void OnEnable()
    {
        GameManager.OnUpdateScore += Deactivate;
    }

    private void OnDisable()
    {
        GameManager.OnUpdateScore.Invoke();
        GameManager.OnUpdateScore -= Deactivate;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Deactivate();
            Destroy(explosion, .5f);
        }

        if (collision.CompareTag("Bullet"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Deactivate();
            Destroy(explosion, .5f);

            //setActive false , use pooling
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
