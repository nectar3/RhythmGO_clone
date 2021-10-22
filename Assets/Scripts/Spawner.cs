using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CubePref;
    public GameObject CubeParent;
    public Transform CubeForMeasure;

    public GameObject player;
    private Player player_script;

    public float zSpawnPos = 10f;

    Vector2 poslimit;

    public float spawnGap = 1f;

    void Start()
    {
        player_script = player.GetComponent<Player>();

        poslimit = new Vector2(CubeForMeasure.position.x, CubeForMeasure.position.y);
        CubeForMeasure.gameObject.SetActive(false);

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnGap * 0.3f, spawnGap));

            var cube = Instantiate(CubePref,
                new Vector3(
                    Random.Range(-poslimit.x, poslimit.x),
                    Random.Range(-poslimit.y, poslimit.y),
                    zSpawnPos),
                Quaternion.identity);

            cube.GetComponent<Cube>().missed.AddListener(player_script.Miss);
        }

    }


}



