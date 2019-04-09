using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIClamper : MonoBehaviour
{
    [SerializeField]
    float clamp = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camAngles = Camera.main.transform.eulerAngles;
        float dif = 360.0f / clamp;
        transform.eulerAngles = new Vector3(
            0.0f,
            (Mathf.Floor(camAngles.y / clamp) + 0.5f) * clamp,
            0.0f
        );
    }
}
