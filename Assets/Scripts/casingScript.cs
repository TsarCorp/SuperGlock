using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casingScript : MonoBehaviour {

    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.right * 1000);
        //rigidBody.AddRelativeForce(-100, 0, 0);
        Destroy(transform.parent.gameObject, 3f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
