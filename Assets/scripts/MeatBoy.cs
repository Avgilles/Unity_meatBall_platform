using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class MeatBoy : MonoBehaviour
{
    public float speed = 2f;
    public float jumpSpeed = 2f;
    public float gravity = 9.8f;
    private Vector3 mouvement;
    private CharacterController controller;
    public GameObject gouttePrefab;
    public Vector3 goutteOffset;

    public float DelayGoute;
    private float cptGoutte;


    public int JumpMax = 1;
    private int jumpsCount;

    private Vector3 defaultPos;

    private Vector3 lastMove;
    private float verticalVelocity;
    private bool isSprinting;


    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && jumpsCount < JumpMax)
        {
            //Debug.Log(lastMove);
            mouvement.y = jumpSpeed;
            jumpsCount++;
        }

        // mouvement.y -= gravity * Time.deltaTime;
        GetInput(true);
        mouvement.y -= gravity * Time.deltaTime;
        

        if (controller.isGrounded)
        {
            lastMove = mouvement;

            //lastMove = mouvement;
            //mouvement.y = 0;
            jumpsCount = 0;
        }
       


        

        /** Pour les gouttes  */

        if(mouvement.z != 0f)
        {
            cptGoutte -= Time.deltaTime;
            if(cptGoutte <= 0f)
            {
                //Instantiate(gouttePrefab, gouttePrefab.transform.position, Quaternion.identity);
                GameObject goutte = Instantiate(gouttePrefab, transform.transform.position + goutteOffset, Quaternion.identity) as GameObject;
                goutte.GetComponent<Goute>().vel = new Vector3(-mouvement.x, speed, 0f);
                cptGoutte = DelayGoute;
            }
        }
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        WallJump(hit);

    }

    void WallJump(ControllerColliderHit hitSent)
    {
        if (!controller.isGrounded && hitSent.normal.y < .1f)
        {
            //Debug.Log(hit.normal.z);
            Debug.DrawRay(hitSent.point, hitSent.normal, Color.red, 1.25f);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.DrawRay(hitSent.point, hitSent.normal, Color.blue, 8f);
                mouvement.y = mouvement.y + 1;

                // faire le déplacement opposé ??
            }
        }
    }

    void GetInput(bool deplacement)
    {
        if(deplacement == true)
        {
            mouvement.z = Input.GetAxisRaw("Horizontal");
            isSprinting = Input.GetKey(KeyCode.LeftShift);
            if (isSprinting) mouvement.z = mouvement.z *2; 
            controller.Move(mouvement * Time.deltaTime * speed);
        }
        

    }
    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    public void Die()
    {
        CharacterController cc = controller.GetComponent < CharacterController > ();
        cc.enabled = false;
        transform.position = defaultPos;
        cc.enabled = true;
    }
}
