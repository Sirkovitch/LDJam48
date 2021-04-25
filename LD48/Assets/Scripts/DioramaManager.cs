using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaManager : MonoBehaviour
{
    public float transitionStep = 0.01f;

    private Transform diorama1;
    private Transform diorama2;
    private float transition1 = 0;
    private float transition2 = 0;
    private Vector3 diorama1Pos;
    private Vector3 diorama2Pos;

    private bool diorama1Active = false;
    private bool diorama2Active = false;


    // Start is called before the first frame update
    void Start()
    {
        diorama1Pos = this.transform.Find("Diorama1Pos").transform.position;
        this.transform.Find("ParticleDiorama1").transform.position = new Vector3(diorama1Pos.x, 0, diorama1Pos.z);

        diorama2Pos = this.transform.Find("Diorama2Pos").transform.position;
        this.transform.Find("ParticleDiorama2").transform.position = new Vector3(diorama2Pos.x, 0, diorama2Pos.z);

        diorama1 = GameObject.FindGameObjectWithTag("Diorama1").GetComponent<Transform>();
        foreach(Transform go in diorama1)
        {
            go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", 0);
            go.gameObject.GetComponent<Renderer>().material.SetVector("_DioramaPos", diorama1Pos);

        }
        diorama2 = GameObject.FindGameObjectWithTag("Diorama2").GetComponent<Transform>();
        foreach (Transform go in diorama2)
        {
            go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", 0);
            go.gameObject.GetComponent<Renderer>().material.SetVector("_DioramaPos", diorama2Pos);

        }

        var emission = this.transform.Find("ParticleDiorama1").GetComponent<ParticleSystem>().emission;
        emission.enabled = false;

        emission = this.transform.Find("ParticleDiorama2").GetComponent<ParticleSystem>().emission;
        emission.enabled = false;


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
        
        if (diorama1Active == true && transition1 != 5)
        {
            var emission = this.transform.Find("ParticleDiorama1").GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
            var shape = this.transform.Find("ParticleDiorama1").GetComponent<ParticleSystem>().shape;
            shape.radius = Mathf.Lerp(shape.radius, 10, transitionStep);

            diorama1 = GameObject.FindGameObjectWithTag("Diorama1").GetComponent<Transform>();
            foreach (Transform go in diorama1)
            {
                transition1 = Mathf.Lerp(transition1, 5, transitionStep);
                go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", transition1);
            }

        }
        if (transition1 > 4)
        {
            var emission = this.transform.Find("ParticleDiorama1").GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }

        if (diorama2Active == true && transition2 != 5)
        {
            var emission = this.transform.Find("ParticleDiorama2").GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
            var shape = this.transform.Find("ParticleDiorama2").GetComponent<ParticleSystem>().shape;
            shape.radius = Mathf.Lerp(shape.radius, 10, transitionStep);

            diorama2 = GameObject.FindGameObjectWithTag("Diorama2").GetComponent<Transform>();
            foreach (Transform go in diorama2)
            {
                transition2 = Mathf.Lerp(transition2, 5, transitionStep);
                go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", transition2);
            }
        }
        if (transition2 > 4)
        {
            var emission = this.transform.Find("ParticleDiorama2").GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }

    }
}
