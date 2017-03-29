using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimScript : MonoBehaviour
{

    private float transRot;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("HoldAim", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("HoldAim", false);
        }

        if (Input.GetMouseButtonDown(3))
        {
            animator.SetBool("HoldSlide", false);
        }
        if (Input.GetMouseButtonUp(3))
        {
            
        }



        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("HoldReload", true);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            animator.SetBool("HoldReload", false);
        }






        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            animator.SetBool("HoldSlide", false);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            animator.SetBool("HoldSlide", true);
        }



    }





}





