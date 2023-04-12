using System.Collections.Generic;
using UnityEngine;

public class LimitChildAmount : MonoBehaviour {
    //The way Gameobjects with the ItemDrag script finds it's original parent is through tags.
    //There could be instances of parents with the same tags exists.
    
    //Code originally inspired by HiddenMonk: https://forum.unity.com/threads/set-a-parents-child-to-allow-only-one-child-per-object.341296/

    [SerializeField] int maxChildAmount = 1;
    [SerializeField] List<GameObject> potentialStepParent;
    GameObject[] potentialStepParents;
    GameObject pents;
    void Start() {
        Invoke(nameof(FindStepParent), 0.001f); //invoked with delay to ensure objects has been generated before adding to list.
    }
   
    void Update() {
        SetStepParent();
    }

    void FindStepParent() {
        potentialStepParents = GameObject.FindGameObjectsWithTag(gameObject.tag);
        foreach (var stepParent in potentialStepParents)
        {
            if (stepParent == gameObject) continue; //continue skips the condition in the statement.
            potentialStepParent.Add(stepParent);
        }
    }
    void SetStepParent()
    {
        GameObject availableStepParent = null;
        if (transform.childCount <= maxChildAmount) return;
        foreach (var stepParent in potentialStepParent) 
        {   
            if (stepParent.transform.childCount == maxChildAmount) continue;
            availableStepParent = stepParent;
            break; //jumps out of the loop after a parent has been found.
        }
        if (availableStepParent is null) return;
        transform.GetChild(1).SetParent(availableStepParent.transform);
    }
}