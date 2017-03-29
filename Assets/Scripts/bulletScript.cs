using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    
    private Rigidbody rigidBody;
    public GameObject ragdoll;
    private int variableForce;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        if (Time.timeScale < 1) {
            variableForce = 200000;
            
        } else
        {
            variableForce = 2500;

        }


        rigidBody.AddForce(transform.forward * variableForce);
        //rigidBody.AddRelativeForce(-100, 0, 0);
        Destroy(gameObject, 6f);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
            
        }

        if (other.gameObject.tag == "Enemy")
        {
            
            other.GetComponent<RagdollActivator>().SetRagdollState(true);

            Instantiate(ragdoll, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            Destroy(gameObject);
        } 


    }
}
