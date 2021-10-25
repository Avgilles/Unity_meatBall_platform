using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBoy : MonoBehaviour
{
    public float speed = 2;
    public float jumpSpeed = 2;
    public float gravity = 0.98f;
    private Vector3 mouvement;
    private CharacterController controller;



    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        mouvement.z = Input.GetAxisRaw("Horizontal");
        mouvement.y -= gravity * Time.deltaTime;
        
        if (controller.isGrounded)
        {
            mouvement.y = 0;
        }
        controller.Move(mouvement * Time.deltaTime);
    }

    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
}
