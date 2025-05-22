using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private string cutsceneKey = "FirstCutscene";
    [SerializeField] private bool hasPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed)
            return;

        if (other.gameObject.CompareTag("Player"))
        {
            if (CutsceneManager.Instance != null)
            {
                Debug.Log("Start Cutscene: " + cutsceneKey);
                CutsceneManager.Instance.StartCutScene(cutsceneKey);
                hasPlayed = true;
            }
        }
    }
}
