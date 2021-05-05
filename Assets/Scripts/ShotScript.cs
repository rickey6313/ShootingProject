using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public GameObject shotEffect;    
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);    
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Astroid"))
        {
            AsteroidScript astroidScript = collision.gameObject.GetComponent<AsteroidScript>();
            astroidScript.TakeDamage(3);            
            Instantiate(shotEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScript EnemyScript = collision.gameObject.GetComponent<EnemyScript>();
            EnemyScript.TakeDamage(3);
            Instantiate(shotEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
