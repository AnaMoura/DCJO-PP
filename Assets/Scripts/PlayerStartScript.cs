using UnityEngine;
using System.Collections;

public class PlayerStartScript : MonoBehaviour {

    Rigidbody2D rb;
    public float startSpeedX = 0;
    public float startSpeedY = 0;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(startSpeedX, startSpeedY);
            GetComponent<PlayerStartScript>().enabled = false;
        }
    }
}
