using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioReader : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform enemySpawnPoints;
    private Transform[] spawnPoints;
    private GameObject[] enemies;

    public GameObject lightSource;
    private bool lightToggle = false;
    private int lightTimer = 0;


    public float spawnThershold = 0.5f;
    public int frequency = 0;
    public float spawnThershold2 = 0.1f;
    public int frequency2 = 0;
    public float spawnThershold3 = 0.01f;
    public int frequency3 = 3;

    public float size = 10.0f;
    public float amplitude = 1.0f;
    public FFTWindow fftWindow;
    //private int samples = 64;   // must be power of 2
    private float[] samples = new float[64];

    public float timeScale = 0.1f;



    private float stepSize;

    public int cutoffSample = 32;

    void Start()
    {
        spawnPoints = enemySpawnPoints.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
        if (timeScale < 1)
        {
            timeScale = timeScale + 0.1f;

            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }



        AudioListener.GetSpectrumData(samples, 0, fftWindow);

        if (samples[frequency2] > spawnThershold2)
        {
            print("freq1");



        }


        if (samples[frequency3] > spawnThershold3)
        {
            print("freq3");



        }

        if ((samples[frequency2] > spawnThershold2) ^ (samples[frequency3] > spawnThershold3))
        {
            print("freq2 + 3");
        }



        if (samples[frequency] > spawnThershold)
        {
            print("freq");
            timeScale = 0.1f;
            lightTimer++;

            if (lightTimer > 5)
            {
                if (lightToggle)
                {
                    lightSource.gameObject.SetActive(lightToggle);
                    lightToggle = false;
                    lightTimer = 0;
                }
                else
                {
                    lightSource.gameObject.SetActive(lightToggle);
                    lightToggle = true;
                    lightTimer = 0;
                }
            }


            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length < 10)
            {

                int i = Random.Range(1, spawnPoints.Length);
                Instantiate(enemyPrefab, spawnPoints[i].transform.position, Quaternion.identity);

            };
        }

    }
}
