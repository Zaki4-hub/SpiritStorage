using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claim : MonoBehaviour
{
    public float distance = 3f;
    public LayerMask grabLayerMask;

    private GameObject grabbedThing;
    private Rigidbody myThing;
    private float distanceToTheObject;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TryGrabObject();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReleaseObject();
        }

        if (grabbedThing != null)
        {
            MoveObject();
        }
    }

    private void TryGrabObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, grabLayerMask))
        {
            if (grabbedThing == null)
            {
                grabbedThing = hit.collider.gameObject;
                myThing = grabbedThing.GetComponent<Rigidbody>();

                if (myThing != null)
                {
                    myThing.isKinematic = true;
                    distanceToTheObject = Vector3.Distance(transform.position, grabbedThing.transform.position) - 0.2f;
                }
            }
            else
            {
                grabbedThing = null;
            }
        }
    }

    private void ReleaseObject()
    {
        if (myThing != null)
        {
            myThing.isKinematic = false;
            myThing = null;
        }
        grabbedThing = null;
    }

    private void MoveObject()
    {
        if (myThing != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 targetPosition = ray.GetPoint(distanceToTheObject);

            
            grabbedThing.transform.position = targetPosition;
        }
    }
}
