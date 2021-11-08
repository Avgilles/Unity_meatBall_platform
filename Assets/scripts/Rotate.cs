using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject mysim;
    private float aimSpeed;
    public float dampening;
    public Transform[] points;

    public enum Target
    {
        point1,
        point2
    };

    public Target tState;

    public void MenuIdle()
    {
        Ray idle = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(idle.origin, idle.direction * 5, Color.blue);

        if (Physics.Raycast(idle, out hit, 5))
        {
            GameObject hitObj = hit.collider.gameObject;

            if (hitObj.tag == "P1")
                tState = Target.point2;
            if (hitObj.tag == "P2")
                tState = Target.point1;
        }
    }

    void Update()
    {


        aimSpeed = dampening * Time.deltaTime;
        MenuIdle();

        switch (tState)
        {
            case Target.point1:
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(points[0].position - transform.position), aimSpeed);
                break;

            case Target.point2:
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(points[1].position - transform.position), aimSpeed);
                break;

        }
    }
}
