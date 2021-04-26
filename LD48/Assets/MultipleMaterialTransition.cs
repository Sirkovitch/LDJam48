using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleMaterialTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var transi = this.GetComponent<Renderer>().materials[0].GetFloat("_Transition");
        this.GetComponent<Renderer>().materials[1].SetFloat("_Transition", transi*1.5f);
    }
}
