using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Instance;
    [SerializeField] private List<CutSceneStruct> cutSceneStructs = new List<CutSceneStruct>();
    public static Dictionary<string, GameObject> cutscenedatabase = new Dictionary<string, GameObject>();
    public static GameObject activeCutscene;

    public void Awake()
    {
        Instance = this;
        InitializeCutsceneDataBase();
        foreach (var cutScene in cutscenedatabase)
        {
            cutScene.Value.SetActive(false);
        }
    }

    void InitializeCutsceneDataBase()
    {
        cutscenedatabase.Clear();

        for (int i = 0; i < cutSceneStructs.Count; i++)
        {
            cutscenedatabase.Add(cutSceneStructs[i].cutsceneKey, cutSceneStructs[i].cutsceneObj);
        }
    }

    public void StartCutScene(string cutSceneKey)
    {
        if (!cutscenedatabase.ContainsKey(cutSceneKey))
        {
            Debug.LogError("NotCutScene: " + cutSceneKey);
            return;
        }

        if (activeCutscene != null)
        {
            Debug.LogWarning("Cutscene already playing.");
            return;
        }

        activeCutscene = cutscenedatabase[cutSceneKey];

        foreach (var cutScene in cutscenedatabase)
        {
            cutScene.Value.SetActive(false);
        }

        activeCutscene.SetActive(true);

        var director = activeCutscene.GetComponent<PlayableDirector>();
        if (director != null)
        {
            director.stopped += OnCutsceneFinished;
            director.Play();
        }
        else
        {
            Debug.LogWarning("No PlayableDirector found on cutscene object.");
        }
    }

    private void OnCutsceneFinished(PlayableDirector director)
    {
        director.stopped -= OnCutsceneFinished;
        if (activeCutscene != null)
        {
            activeCutscene.SetActive(false);
            activeCutscene = null;
            Debug.Log("Cutscene finished.");
        }
    }

    public void StopCutScene()
    {
        if (activeCutscene != null)
        {
            var director = activeCutscene.GetComponent<PlayableDirector>();
            if (director != null)
            {
                director.Stop();
                director.stopped -= OnCutsceneFinished;
            }
            activeCutscene.SetActive(false);
            activeCutscene = null;
            Debug.Log("Stop");
        }
    }
}

[System.Serializable]
public struct CutSceneStruct
{
    public string cutsceneKey;
    public GameObject cutsceneObj;
}
