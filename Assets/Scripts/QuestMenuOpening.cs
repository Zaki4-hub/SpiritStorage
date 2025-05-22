using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenuOpening : MonoBehaviour
{
    public GameObject QuestMenu;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
        QuestMenu.SetActive(!QuestMenu.activeInHierarchy);
        }
}
}
