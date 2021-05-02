using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Camera mMainCamera;
    public GameObject mShot;
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
        
        colSize = GetComponent<BoxCollider2D>().size;
        chrSize = new Vector2(colSize.x / 2, colSize.y / 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PlayerShot();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0).normalized;

        transform.position = transform.position + dir * Time.deltaTime * speed;

        float newX = transform.position.x;
        float newY = transform.position.y;

        newX = Mathf.Clamp(newX, min.x + chrSize.x, max.x - chrSize.x);
        newY = Mathf.Clamp(newY, min.y + chrSize.y, max.y - chrSize.y);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    public float shotMax = 0;
    public float shotDelay = 0;
    private void PlayerShot()
    {   
        shotDelay += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log($"shotMax : {shotMax} / shotDelay : {shotDelay}");
            if (shotDelay >= shotMax)
            {
                shotDelay = 0;
                Vector3 vec = new Vector3(transform.position.x + 1.1f, transform.position.y - 0.3f, transform.position.z);
                Instantiate(mShot, vec, Quaternion.identity);
            }
            else
            {

            }
        }
    }
}
