using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLOOD : MonoBehaviour
{
    public GameObject gouttePrefab;
    public Vector3 goutteOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject goutte = Instantiate(gouttePrefab, transform.transform.position + goutteOffset, Quaternion.identity) as GameObject;
        goutte.GetComponent<Goute>().vel = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f));
        
    }
}
