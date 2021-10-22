using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{

    public float speed = 0.3f;
    public float fadePerSecond = 2f;

    public UnityEvent missed;

    private Material mat;


    void Start()
    {
        mat = GetComponent<Renderer>().material;

        GetComponent<Renderer>().material.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0);
    }

    void Update()
    {
        if (mat.color.a < 1)
        {
            var alpha = Mathf.Clamp(mat.color.a + (fadePerSecond * Time.deltaTime), 0, 1f);
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, alpha);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);

        if (transform.position.z < -5)
        {
            missed?.Invoke();
            Destroy(gameObject);
        }
        else if (transform.position.z < -15)
            Destroy(gameObject);
    }
}
