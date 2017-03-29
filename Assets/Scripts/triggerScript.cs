using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{

    private Light muzzleLight;

    public AudioClip slideBack;
    public AudioClip slideFore;
    public AudioClip triggerClick;
    public AudioClip triggerFire;
    public AudioClip reload1;
    public AudioClip reload2;
    private AudioSource audioSource;
    private AudioSource audioSourceFire;
    private Vector3 ejectOffset = new Vector3(0.03f, 0f, 0.15f);
    private Vector3 bulletOffset = new Vector3(0.00f, -0.035f, 0.4f);

    public GameObject cartridge;
    public GameObject bullet;
    public GameObject casing;

    public GameObject ejectPoint;
    public GameObject muzzlePoint;

    private Animator anim;
    public Animator[] childAnim;
    public int bullets = 0;
    public bool chambering = false;

    private float recoilRotation;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        childAnim = GetComponentsInChildren<Animator>();

        AudioSource[] audios = GetComponents<AudioSource>();
        audioSource = audios[0];
        audioSourceFire = audios[1];

        muzzleLight = GetComponentInChildren<Light>();
        muzzleLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (recoilRotation < 0) { recoilRotation = recoilRotation + 1f;  }
        transform.localEulerAngles = new Vector3(recoilRotation, 0f, 0f);

        ejectOffset = ejectPoint.transform.position;
        bulletOffset = muzzlePoint.transform.position;

        if (Input.GetKeyDown(KeyCode.R))
        {
            childAnim[1].SetInteger("RoundsInMag", bullets);
            anim.SetInteger("bullets", bullets);
            audioSource.clip = reload1;
            audioSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            bullets = childAnim[1].GetInteger("RoundsInMag");
            anim.SetInteger("bullets", bullets);
            audioSource.clip = reload2;
            audioSource.Play();
        }

        if (Input.GetMouseButtonDown(3))
        {
            slideReleased();
        }

        if (Input.GetMouseButtonDown(0))
        {
            pullTheTrigger();
        }

        // if (anim.GetBool("slideBack") && !anim.GetBool("chambered")) { anim.SetInteger("bullets", bullets--); }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            slideItFore();
            anim.SetTrigger("slideRelease");
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {

            slideItBack();

        }
        
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        
        // Code to execute after the delay
        slideItFore();

    }


    IEnumerator ExecuteAfterFiring(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        muzzleLight.gameObject.SetActive(false);

    }



    void slideReleased()
    {

        if (anim.GetBool("slideBack"))
        {

            anim.SetTrigger("slideRelease");

            if (bullets > 0)
            {
                audioSource.clip = slideFore;
                audioSource.Play();
                slideItFore();
                anim.SetBool("chambered", true);

                bullets--;
                //childAnim.SetInteger("RoundsInMag", (childAnim.GetInteger("RoundsInMag") - 1));

                anim.SetInteger("bullets", bullets);
            }
            else
            {
                audioSource.clip = slideFore;
                audioSource.Play();
                slideItFore();

            }

        }
    }

    void pullTheTrigger()
    {

        anim.SetTrigger("pullTrigger");

        if (anim.GetBool("chambered"))
        {

            Instantiate(bullet, bulletOffset, muzzlePoint.transform.rotation);

            muzzleLight.gameObject.SetActive(true);
            StartCoroutine(ExecuteAfterFiring(0.05f));


            slideItBack();
            anim.SetBool("Fired", true);

            //add recoil angle
            recoilRotation = recoilRotation - 10;
          
            


            
            



            if (chambering)
            {
                anim.SetTrigger("slideRelease");
                StartCoroutine(ExecuteAfterTime(0.05f));
            }

            anim.SetBool("chambered", false);

            //audioSource.clip = triggerFire;
            audioSourceFire.PlayOneShot(triggerFire, 1F);
            //audioSource.Play();


        }
        else
        {
            audioSource.clip = triggerClick;
            audioSource.Play();
            // slideItBack();
            anim.ResetTrigger("pullTrigger");

        }
    }

    void slideItFore()
    {
        if (anim.GetBool("slideBack"))
        {
            
            audioSource.clip = slideFore;
            audioSource.Play();
            anim.SetBool("slideBack", false);

            if (chambering)
            {
                anim.SetBool("chambered", true);
                //bullets--;
                //anim.SetInteger("bullets", bullets);
            }
            else
            {
                // anim.SetBool("chambered", false);
            }
        }

    }
    void slideItBack()
    {

        
        if (!anim.GetBool("slideBack"))
        {
            
            anim.SetBool("slideBack", true);

            audioSource.clip = slideBack;
            audioSource.Play();

            if (anim.GetBool("chambered"))
            {

                if (anim.GetBool("Fired"))
                {
                    Instantiate(casing, ejectOffset, ejectPoint.transform.rotation);
                    anim.SetBool("chambered", false);

                }
                else
                {
                    Instantiate(cartridge, ejectOffset, ejectPoint.transform.rotation);
                    anim.SetBool("chambered", false);
                }
                anim.SetBool("Fired", false);
            }

            if (anim.GetInteger("bullets") > 0)
            {
                chambering = true;
                //anim.SetBool("chambered", false);

                bullets--;
                //childAnim.SetInteger("RoundsInMag", (childAnim.GetInteger("RoundsInMag") - 1));


                anim.SetInteger("bullets", bullets);
            }
            else
            {
                chambering = false;

            }
        }
    }

    



}
