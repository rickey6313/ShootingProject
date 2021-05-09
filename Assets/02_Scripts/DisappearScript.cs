using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    public float disappearTime = 1.0f;

    private void Start()
    {
        Destroy(gameObject, disappearTime);
    }

}
