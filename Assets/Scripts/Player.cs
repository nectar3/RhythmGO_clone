using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public float moveMulitplier = 1.5f;
    public TextMeshProUGUI comboText;

    public Transform CubeForMeasure;
    Vector2 poslimit;


    private Vector3 startObjectPos;
    private ParticleSystem particle;

    int combo = 0;

    void Start()
    {
        particle = transform.GetChild(0).GetComponent<ParticleSystem>();


        poslimit = new Vector2(CubeForMeasure.position.x, CubeForMeasure.position.y);

        startObjectPos = transform.position;
    }

    Vector3 stMousePos;
    Vector3 curMousePos;
    Vector3 stPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouse = Input.mousePosition;
            mouse.z = Camera.main.transform.position.z;
            stMousePos = Camera.main.ScreenToWorldPoint(mouse) * -1;
            stPos = transform.position;

        }
        else if (Input.GetMouseButtonUp(0))
        {

        }
        else if (Input.GetMouseButton(0))
        {

            var mouse = Input.mousePosition;
            mouse.z = Camera.main.transform.position.z;

            curMousePos = Camera.main.ScreenToWorldPoint(mouse) * -1;
            var diff = curMousePos - stMousePos;
            var pos = stPos + diff * moveMulitplier;

            transform.position = new Vector3(Mathf.Clamp(pos.x, -poslimit.x, poslimit.x), Mathf.Clamp(pos.y, -poslimit.y, poslimit.y), pos.z);
        }

    }


    public void Miss()
    {
        combo = 0;
        comboText.SetText(combo.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            combo++;
            comboText.SetText(combo.ToString());
            particle.Play();
            Destroy(other.gameObject);
        }
    }


}
