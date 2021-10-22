using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{

    public float speed = 5f;

    void Start()
    {

    }

    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);

        if (transform.position.z < -6)
            Destroy(gameObject);
    }
}
