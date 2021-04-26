using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneControl : MonoBehaviour
{
    private GameObject dioramaManager;
    private Renderer thisRn;
    private float transi = 0;

    // Start is called before the first frame update
    void Start()
    {
        dioramaManager = GameObject.FindGameObjectWithTag("DioramaManager");
        thisRn = this.GetComponent<Renderer>();
        transi = 0;
        thisRn.material.SetFloat("_Transition", transi);

    }

    // Update is called once per frame
    void Update()
    {
        if (dioramaManager.GetComponent<DioramaManager>().diorama1Active == true && dioramaManager.GetComponent<DioramaManager>().diorama3Active == false)
        {
            transi = Mathf.Lerp(transi, 3.5f, 0.01f);
            thisRn.material.SetFloat("_Transition", transi);
        }
        if (dioramaManager.GetComponent<DioramaManager>().diorama3Active == true)
        {
            transi = Mathf.Lerp(transi, 18f, 0.001f);
            thisRn.material.SetFloat("_Transition", transi);
        }
    }
}
