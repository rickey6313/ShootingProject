using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject coin;
    public GameObject explosion;
    public int hp = 10;
    public float moveSpeed = 5;
    public float rotSpeed = 5;
    public int coinSize = 2;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotSpeed));
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            Vector3 tr = transform.position;
            Vector3 randomPos = new Vector3(tr.x + Random.Range(-0.01f, 0.01f), tr.y + Random.Range(-0.01f, 0.01f), 0);
            GameObject coinObj =  Instantiate(coin, randomPos, Quaternion.identity);
            CoinScript coinScr = coinObj.GetComponent<CoinScript>();
            coinScr.coinSize = coinSize;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
