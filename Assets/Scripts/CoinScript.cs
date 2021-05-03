using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float speed = 1.5f;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
