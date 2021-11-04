using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scie : MonoBehaviour
{
    public float speed = 90;
    public GameObject gouttePrefab;
    public Texture tache;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(gouttePrefab, transform.position, Quaternion.identity);
            GetComponent<Renderer>().material.mainTexture = tache;
            other.GetComponent<MeatBoy>().Die();
        }
    }
}
