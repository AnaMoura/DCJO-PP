using UnityEngine;
using System.Collections;

public class BounceScript : MonoBehaviour {

    public float forceX;
    public float forceY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        var rb = other.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(forceX, forceY));
    }
}
