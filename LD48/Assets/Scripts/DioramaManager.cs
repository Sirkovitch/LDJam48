using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaManager : MonoBehaviour
{
    public float transitionStep = 0.01f;

    private Transform diorama1;
    private Transform diorama2;
    private Transform diorama3;
    private Transform diorama4;
    private float transition1 = 0;
    private float transition2 = 0;
    private float transition3 = 0;
    private float transition4 = 0;
    private Vector3 diorama1Pos;
    private Vector3 diorama2Pos;
    private Vector3 diorama3Pos;
    private Vector3 diorama4Pos;

    public bool diorama1Active = false;
    public bool diorama2Active = false;
    public bool diorama3Active = false;
    public bool diorama4Active = false;

    private bool diorama1Start = false;
    private bool diorama2Start = false;
    private bool diorama3Start = false;
    private bool diorama4Start = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (diorama1Active == true && transition1 != 5)
        {
            if (diorama1Start == false)
            {
                diorama1Start = true;
                diorama1Pos = this.transform.Find("Diorama1Pos").transform.position;
                diorama1 = GameObject.FindGameObjectWithTag("Diorama1").GetComponent<Transform>();
                foreach (Transform go in diorama1)
                {
                    if(go.gameObject.GetComponent<Renderer>() != null)
                    {
                        go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", 0);
                        go.gameObject.GetComponent<Renderer>().material.SetVector("_DioramaPos", diorama1Pos);
                    }

                }
            }

            diorama1 = GameObject.FindGameObjectWithTag("Diorama1").GetComponent<Transform>();
            foreach (Transform go in diorama1)
            {
                if (go.gameObject.GetComponent<Renderer>() != null)
                {
                    transition1 = Mathf.Lerp(transition1, 5, transitionStep);
                    go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", transition1);
                }

            }

        }


        if (diorama2Active == true && transition2 != 5)
        {
            if (diorama2Start == false)
            {
                diorama2Start = true;
                diorama2Pos = this.transform.Find("Diorama2Pos").transform.position;
                diorama2 = GameObject.FindGameObjectWithTag("Diorama2").GetComponent<Transform>();
                foreach (Transform go in diorama2)
                {
                    if (go.gameObject.GetComponent<Renderer>() != null)
                    {
                        go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", 0);
                        go.gameObject.GetComponent<Renderer>().material.SetVector("_DioramaPos", diorama2Pos);
                    }


                }
            }

            diorama2 = GameObject.FindGameObjectWithTag("Diorama2").GetComponent<Transform>();
            foreach (Transform go in diorama2)
            {
                if (go.gameObject.GetComponent<Renderer>() != null)
                {
                    transition2 = Mathf.Lerp(transition2, 5, transitionStep);
                    go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", transition2);
                }

            }
        }


        if (diorama3Active == true && transition3 != 5)
        {
            if (diorama3Start == false)
            {
                diorama3Start = true;
                diorama3Pos = this.transform.Find("Diorama3Pos").transform.position;
                diorama3 = GameObject.FindGameObjectWithTag("Diorama3").GetComponent<Transform>();
                foreach (Transform go in diorama3)
                {
                    if (go.gameObject.GetComponent<Renderer>() != null)
                    {
                        go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", 0);
                        go.gameObject.GetComponent<Renderer>().material.SetVector("_DioramaPos", diorama3Pos);
                    }

                }
            }

            diorama3 = GameObject.FindGameObjectWithTag("Diorama3").GetComponent<Transform>();
            foreach (Transform go in diorama3)
            {
                if (go.gameObject.GetComponent<Renderer>() != null)
                {
                    transition3 = Mathf.Lerp(transition3, 15, transitionStep/10);
                    go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", transition3);
                }

            }
        }

        if (diorama4Active == true && transition4 != 5)
        {
            if (diorama4Start == false)
            {
                diorama4Start = true;
                diorama4Pos = this.transform.Find("Diorama4Pos").transform.position;
                diorama4 = GameObject.FindGameObjectWithTag("Diorama4").GetComponent<Transform>();
                foreach (Transform go in diorama4)
                {
                    if (go.gameObject.GetComponent<Renderer>() != null)
                    {
                        go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", 0);
                        go.gameObject.GetComponent<Renderer>().material.SetVector("_DioramaPos", diorama4Pos);
                    }


                }
            }

            diorama4 = GameObject.FindGameObjectWithTag("Diorama4").GetComponent<Transform>();
            foreach (Transform go in diorama4)
            {
                if (go.gameObject.GetComponent<Renderer>() != null)
                {
                    transition4 = Mathf.Lerp(transition4, 5, transitionStep);
                    go.gameObject.GetComponent<Renderer>().material.SetFloat("_Transition", transition4);
                }

            }
        }

    }
}
