using UnityEngine;
using System.Collections;

public class HeightSpawnScript : MonoBehaviour {

    public GameObject[] objMin;
    public GameObject[] objMax;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    public GameObject mainCamera;
    public Transform player;

    // Use this for initialization
    void Start () {
        Invoke("Spawn", Random.Range(0f, 4f));
    }

    // Update is called once per frame
    void Spawn()
    {
        GameObject instance;
        if (player.position.y < 10)
            instance = Instantiate(objMin[Random.Range(0, objMin.Length)], transform.position, Quaternion.identity) as GameObject;
        else
            instance = Instantiate(objMax[Random.Range(0, objMax.Length)], transform.position, Quaternion.identity) as GameObject;
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
