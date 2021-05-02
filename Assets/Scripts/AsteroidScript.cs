using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject shotEffect;

    public int hp = 10;
    public float moveSpeed = 5;
    public float rotSpeed = 5;
    
    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
            Destroy(gameObject);

        //transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotSpeed));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
