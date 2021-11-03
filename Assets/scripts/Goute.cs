using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goute : MonoBehaviour
{
    public Vector3 vel;
    public float force = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(vel * force);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision enter)
    {
        Destroy(this.gameObject, 1);
    }
}
