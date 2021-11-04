using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class Girl : MonoBehaviour
{
    public float gravity = 9.8f;
    private Vector3 mouvement;
    private CharacterController controller;
    public float speed = 1.5f;
    private float delayJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayJump -= Time.deltaTime;

        mouvement.y -= gravity * Time.deltaTime;
        if (controller.isGrounded && delayJump <= 0)
        {
            mouvement.y = speed;
            delayJump = .5f;
        }
        controller.Move(mouvement * Time.deltaTime *speed );

    }

    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
}
