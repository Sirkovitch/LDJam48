using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour
{
    private float intensity = 0;
    // Start is called before the first frame update
    void Start()
    {
        intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        intensity = Mathf.Lerp(intensity, 400000, 0.002f);
        this.GetComponent<Light>().intensity = intensity;
    }
}
