using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaManager : MonoBehaviour
{
    private GameObject[] diorama1;
    private GameObject[] diorama2;
    private float transition1 = 10;
    private float transition2 = 10;

    private bool diorama1Active = false;
    private bool diorama2Active = false;

    // Start is called before the first frame update
    void Start()
    {
        diorama1 = GameObject.FindGameObjectsWithTag("Diorama1");
        foreach(GameObject go in diorama1)
        {
            go.GetComponent<Renderer>().material.SetFloat("_Transition", 10);
            var emission = go.transform.Find("Particle").GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
        diorama2 = GameObject.FindGameObjectsWithTag("Diorama2");
        foreach (GameObject go in diorama2)
        {
            go.GetComponent<Renderer>().material.SetFloat("_Transition", 10);
            var emission = go.transform.Find("Particle").GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            diorama1Active = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            diorama2Active = true;
        }
        
        if (diorama1Active == true && transition1 != 0)
        {
            diorama1 = GameObject.FindGameObjectsWithTag("Diorama1");
            foreach (GameObject go in diorama1)
            {
                transition1 = Mathf.Lerp(transition1, 0, 0.01f);
                go.GetComponent<Renderer>().material.SetFloat("_Transition", transition1);
                var emission = go.transform.Find("Particle").GetComponent<ParticleSystem>().emission;
                emission.enabled = true;
                if (transition1 < .1)
                {
                    emission.enabled = false;
                }
            }
        }
        if (diorama2Active == true && transition2 != 0)
        {
            diorama2 = GameObject.FindGameObjectsWithTag("Diorama2");
            foreach (GameObject go in diorama2)
            {
                transition2 = Mathf.Lerp(transition2, 0, 0.01f);
                go.GetComponent<Renderer>().material.SetFloat("_Transition", transition2);
                var emission = go.transform.Find("Particle").GetComponent<ParticleSystem>().emission;
                emission.enabled = true;
                if (transition2 < .1)
                {
                    emission.enabled = false;
                }
            }
        }
    }
}
