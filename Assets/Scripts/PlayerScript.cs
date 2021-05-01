using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Camera mMainCamera;
    public float speed = 0;
    Vector3 min;
    Vector3 max;
    Vector2 colSize;
    Vector2 chrSize;

    // Start is called before the first frame update
    void Start()
    {
        float speed = 3.0f;
        min = mMainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        max = mMainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        print(min);
        print(max);

        colSize = GetComponent<BoxCollider2D>().size;
        chrSize = new Vector2(colSize.x / 2, colSize.y / 2);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0).normalized;

        transform.position = transform.position + dir * Time.deltaTime * speed;

        float newX = transform.position.x;
        float newY = transform.position.y;
        if(newX < min.x + chrSize.x)
        {
            newX = min.x + chrSize.x;
        }
        if (newX > max.x - chrSize.x)
        {
            newX = max.x - chrSize.x;
        }

        if (newY < min.y + chrSize.y)
        {
            newY = min.y + chrSize.y;
        }
        if (newY > max.y - chrSize.y)
        {
            newY = max.y - chrSize.y;
        }

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
