using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBGScript : MonoBehaviour
{
    SpriteRenderer backgroundSprite;
    public float scrollSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        backgroundSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * scrollSpeed;
        Vector3 pos = transform.position;
        if (pos.x + backgroundSprite.bounds.size.x / 2 < -8)
        {
            pos.x += backgroundSprite.bounds.size.x * 3;             
            transform.position = pos;
        }
    }
}
