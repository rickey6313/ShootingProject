using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    SpriteRenderer backgroundSprite;
    public float scrollSpeed = 2.0f;

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
        if(pos.x + backgroundSprite.bounds.size.x / 2 < -8)
        {
            float size = backgroundSprite.bounds.size.x * 2;
            pos.x += size;
            transform.position = pos;
        }
    }
}
