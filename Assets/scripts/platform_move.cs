using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_move : MonoBehaviour
{
    public Transform planete1;
    public Transform planete2;
    public float speed = 5f;

    public float distanceMin = 2f;
    public bool surPlanette1 = false;
    public bool surPlanette2 = true;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        distance = Vector3.Distance(pos, planete1.position);

    }

    // Update is called once per frame
    void Update()
    {
        MooveForward();
    }

    /** A refactoriser */

    void MooveForward()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log(distance);
        if (surPlanette1 == true)
        {
            distance = Vector3.Distance(pos, planete2.position);
            /** moove spaceship  */
            transform.position = Vector3.MoveTowards(pos, planete2.position, Time.deltaTime * speed);
            //transform.LookAt(planete2.position);

            if (distance < distanceMin)
            {
                Debug.Log("surplanette2 = true");
                surPlanette1 = false;
                surPlanette2 = true;
            }
        }
        else if (surPlanette2 == true)
        {
            distance = Vector3.Distance(pos, planete1.position);
            /** moove spaceship  */
            transform.position = Vector3.MoveTowards(pos, planete1.position, Time.deltaTime * speed);
            transform.LookAt(planete1.position);


            if (distance < distanceMin)
            {
                Debug.Log("surplanette1 = true");
                surPlanette1 = true;
                surPlanette2 = false;

            }
        }
    }
}
