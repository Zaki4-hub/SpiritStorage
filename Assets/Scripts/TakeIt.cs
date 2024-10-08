using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeIt : MonoBehaviour

{
    float throwForce = 300;
    RaycastHit hit;
    GameObject item;
    public GameObject tempParent;
    bool isHolding = false;
    float distance;
    Vector3 objectPos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance >= 2.5f)
        {
            isHolding = false;
        }

        if (Input.GetMouseButton(0) && Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>())
        {
            item = hit.transform.gameObject;
            if (isHolding == true)
            {
                isHolding = false;
            }


            else
                if (distance <= 2.5f)
            {
                isHolding = true;
                item.GetComponent<Rigidbody>().useGravity = false;
            }

        }
        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);


            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            //objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            //item.transform.position = objectPos;
        }
    }
}
