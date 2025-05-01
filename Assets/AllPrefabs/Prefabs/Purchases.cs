using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Purchases : MonoBehaviour
{
    private Animator Movement;
    public GameObject Cereal;
    public GameObject Chips;
    public GameObject Cheese;
    public bool isColided;

    private void Start()
    {
        isColided = false;
        WaypointMover.WaypointChanged += CheckSelectPoint;
        Movement = GetComponent<Animator>();
        Movement.Play("Walk");
        Movement.speed = 2f;
    }

    private void CheckSelectPoint(int i)
    {
        switch (i)
        {
            case 1: RemoveItem(); break;
            case 4: MovementStop(); Movement.Play("Action"); SelectRandomItem(); Invoke("MovementResume", 1); break;
            case 5: Movement.Play("Walk"); break;
            case 6: MovementStop(); Movement.Play("Idle"); break;
        }
    }

    private void OnDisable()
    {
        WaypointMover.WaypointChanged -= CheckSelectPoint;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collider");
            isColided = true;
            GetComponent<WaypointMover>().enabled = true;
            Movement.Play("Walk");
        }
    }

    private void SelectRandomItem()
    {
        var RandomIndex = Random.Range(0, 3);
        switch (RandomIndex)
        {
            case 0: Cereal.SetActive(true); break;
            case 1: Chips.SetActive(true); break;
            case 2: Cheese.SetActive(true); break;
        }
    }

    private void MovementStop()
    {
        GetComponent<WaypointMover>().enabled = false;
        
        
    }

    private void MovementResume()
    {
        GetComponent<WaypointMover>().enabled = true;
        isColided = false;
    }

    private void RemoveItem()
    {
        Cereal.SetActive(false);
        Chips.SetActive(false);
        Cheese.SetActive(false);
    }
}