using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartridgeScript : MonoBehaviour {

    private Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.right * 100);
        //rigidBody.AddRelativeForce(-100, 0, 0);
        Destroy(transform.parent.gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
