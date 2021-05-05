using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject coin;
    public GameObject explosion;
    public GameObject enemyShot;

    public int type = 0;
    private int hp = 3;
    private float speed = 4;
    public int coinSize = 0;
    
    public float maxShotTime;
    public float shotSpeed;
    public float time = 0;

    void Start()
    {
        switch(type)
        {
            case 0:
                hp = 10;
                speed = 1.5f;
                coinSize = 3;
                maxShotTime = 3;
                shotSpeed = 3;
                break;
            case 1:
                hp = 20;
                speed = 1.4f;
                coinSize = 4;
                maxShotTime = 2;
                shotSpeed = 4;
                break;
            case 2:
                hp = 30;
                speed = 1.3f;
                coinSize = 5;
                maxShotTime = 1;
                shotSpeed = 5;
                break;
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Vector3 tr = transform.position;
            Vector3 randomPos = new Vector3(tr.x + Random.Range(-0.01f, 0.01f), tr.y + Random.Range(-0.01f, 0.01f), 0);            
            GameObject coinObj = Instantiate(coin, randomPos, Quaternion.identity);
            CoinScript coinScr = coinObj.GetComponent<CoinScript>();
            coinScr.coinSize = coinSize;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= maxShotTime)
        {
            GameObject shotObj = Instantiate(enemyShot, transform.position, Quaternion.identity);
            EnemyShot shotScript = shotObj.GetComponent<EnemyShot>();
            shotScript.speed = shotSpeed;
            time = 0;
        }

        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
