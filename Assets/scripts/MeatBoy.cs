using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBoy : MonoBehaviour
{
    public float speed = 2f;
    public float jumpSpeed = 2f;
    public float gravity = 9.8f;
    private Vector3 mouvement;
    private CharacterController controller;

    public int JumpMax = 2;
    private int jumpsCount;

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
            jumpsCount = 0;
        }


        controller.Move(mouvement * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && jumpsCount < JumpMax)
        {
            mouvement.y = jumpSpeed;
            jumpsCount++;
        }

        
    }

    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
}
