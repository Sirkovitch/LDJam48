using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCoverage : MonoBehaviour
{
    public bool winter;
    private GameObject[] snowGO;
    private float state = 0;

    // Start is called before the first frame update
    void Start()
    {
        snowGO = GameObject.FindGameObjectsWithTag("Snow");
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (winter == true & state < .95)
        {
            foreach (GameObject go in snowGO)
            {
                state = Mathf.Lerp(state, 1, 0.002f);
                go.GetComponent<Renderer>().material.SetFloat("_WinterTransi", state);
            }
        }
        if (winter == false & state > .05)
        {
            foreach (GameObject go in snowGO)
            {
                state = Mathf.Lerp(state, 0, 0.002f);
                go.GetComponent<Renderer>().material.SetFloat("_WinterTransi", state);
            }
        }

    }
}
