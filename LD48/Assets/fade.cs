using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    public bool fadeOut = false;
    private float value = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut == true)
        {
            value = Mathf.Lerp(value, 0, 0.01f);
            this.GetComponent<Renderer>().material.SetFloat("_fade", value);
        }
    }
}
