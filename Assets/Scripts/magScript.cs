using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magScript : MonoBehaviour
{


    public int roundsInMag;
    private Animator[] parentAnimator;
    private Animator thisAnimator;
    private bool magEjected;

    public GameObject round1;
    public GameObject round2;
    public GameObject round3;
    public GameObject round4;
    public GameObject round5;
    public GameObject round6;
    public GameObject round7;
    public GameObject round8;
    public GameObject round9;
    public GameObject round10;
    public GameObject round11;
    public GameObject round12;
    public GameObject round13;
    public GameObject round14;
    public GameObject round15;
    public GameObject round16;
    public GameObject round17;

    // Use this for initialization
    void Start()
    {



        parentAnimator = GetComponentsInParent<Animator>();
        thisAnimator = GetComponent<Animator>();

        thisAnimator.SetInteger("RoundsInMag", roundsInMag);

        round1 = transform.Find("round_1").gameObject;
        round2 = transform.Find("round_2").gameObject;
        round3 = transform.Find("round_3").gameObject;
        round4 = transform.Find("round_4").gameObject;
        round5 = transform.Find("round_5").gameObject;
        round6 = transform.Find("round_6").gameObject;
        round7 = transform.Find("round_7").gameObject;
        round8 = transform.Find("round_8").gameObject;
        round9 = transform.Find("round_9").gameObject;
        round10 = transform.Find("round_10").gameObject;
        round11 = transform.Find("round_11").gameObject;
        round12 = transform.Find("round_12").gameObject;
        round13 = transform.Find("round_13").gameObject;
        round14 = transform.Find("round_14").gameObject;
        round15 = transform.Find("round_15").gameObject;
        round16 = transform.Find("round_16").gameObject;
        round17 = transform.Find("round_17").gameObject;

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.R))
        {
            magEjected = true;
            thisAnimator.SetInteger("RoundsInMag", 0);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            magEjected = false;
            thisAnimator.SetInteger("RoundsInMag", roundsInMag);
        }

        thisAnimator.SetBool("Ejected", magEjected);
        if (!magEjected)
        {
            //  var bullets = parentAnimator[1].GetInteger("bullets");
            //  thisAnimator.SetInteger("RoundsInMag", bullets);


        }
        else
        {
            var bullets = 0;
            parentAnimator[1].SetInteger("bullets", bullets);

            if (thisAnimator.GetInteger("RoundsInMag") < 17) { round17.SetActive(false); } else { round17.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 16) { round16.SetActive(false); } else { round16.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 15) { round15.SetActive(false); } else { round15.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 14) { round14.SetActive(false); } else { round14.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 13) { round13.SetActive(false); } else { round13.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 12) { round12.SetActive(false); } else { round12.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 11) { round11.SetActive(false); } else { round11.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 10) { round10.SetActive(false); } else { round10.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 9) { round9.SetActive(false); } else { round9.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 8) { round8.SetActive(false); } else { round8.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 7) { round7.SetActive(false); } else { round7.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 6) { round6.SetActive(false); } else { round6.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 5) { round5.SetActive(false); } else { round5.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 4) { round4.SetActive(false); } else { round4.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 3) { round3.SetActive(false); } else { round3.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 2) { round2.SetActive(false); } else { round2.SetActive(true); }
            if (thisAnimator.GetInteger("RoundsInMag") < 1) { round1.SetActive(false); } else { round1.SetActive(true); }

        };








    }
}
