using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    

    void Update()
    {
        transform.Rotate(new Vector3 (Mathf.Sin(Time.time) * .7f, 0, 0));

    }
}
