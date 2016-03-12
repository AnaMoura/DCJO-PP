using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //rb.velocity = new Vector2(rb.velocity.x * 1.1f, rb.velocity.y * 1.1f);
        }
	}
}
