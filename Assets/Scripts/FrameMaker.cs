using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameMaker : MonoBehaviour
{

    public GameObject framePref;

    void Start()
    {

        StartCoroutine(MakeFrame());
    }



    IEnumerator MakeFrame()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            var frame = Instantiate(framePref, transform.position + new Vector3(0, 0, 40f), Quaternion.Euler(0, 0, 45));
            frame.transform.SetParent(this.transform);
        }

    }





}
