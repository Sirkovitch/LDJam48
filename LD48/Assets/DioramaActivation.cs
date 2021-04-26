using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaActivation : MonoBehaviour
{
    private GameObject manager;

    public bool activateDiorama1 = false;
    public bool activateDiorama2 = false;
    public bool activateDiorama3 = false;
    public bool activateDiorama4 = false;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("DioramaManager");
        manager.GetComponent<DioramaManager>().diorama1Active = activateDiorama1;
        manager.GetComponent<DioramaManager>().diorama2Active = activateDiorama2;
        manager.GetComponent<DioramaManager>().diorama3Active = activateDiorama3;
        manager.GetComponent<DioramaManager>().diorama4Active = activateDiorama4;



    }


}
