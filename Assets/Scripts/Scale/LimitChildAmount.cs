// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class LimitChildAmount : MonoBehaviour
// {
//     //The way Gameobjects with the ItemDrag script finds it's original parent is through tags.
//     //There could be instances of parents with the same tags exists.
//     
//     //Code inspired by HiddenMonk: https://forum.unity.com/threads/set-a-parents-child-to-allow-only-one-child-per-object.341296/
//     //Very slightly modified. Instead of setting parent to null, a step parent has been made.
//
//     [SerializeField] int maxChildAmount = 1;
//     [SerializeField] GameObject stepParents;
//     [SerializeField] public List<GameObject> availableStepParent;
//     GameObject[] potentialStepParents;
//     GameObject stepParent;
//     
//     void Awake()
//     {
//         potentialStepParents = GameObject.FindGameObjectsWithTag(gameObject.tag);
//         for (int i = 0; i < potentialStepParents.Length; i++)
//         {
//             stepParent = GameObject.FindGameObjectsWithTag(gameObject.tag);
//             availableStepParent.Add(stepParent);
//         }
//         availableStepParent.Remove(gameObject);
//     }
//     
//     void Update() {
//         if(transform.childCount > maxChildAmount) {
//             for(int i = maxChildAmount; i < transform.childCount; i++) {
//                 if (availableStepParent[i].transform.childCount == 1) return;
//                 transform.GetChild(i).SetParent(availableStepParent[i].transform);
//             }
//         }
//     }
// }

// //The way Gameobjects with the ItemDrag script finds it's original parent is through tags.
// //There could be instances of parents with the same tags exists.
//     
// //Code inspired by HiddenMonk: https://forum.unity.com/threads/set-a-parents-child-to-allow-only-one-child-per-object.341296/
//
// [SerializeField] public int maxChildAmount = 1;
// [SerializeField] public GameObject[] availableStepParent;
//
// void Awake()
// {
//     availableStepParent = GameObject.FindGameObjectsWithTag(gameObject.tag);
// }
//
// void Update()
// {
//     FindStepParent();
// }
//
// public void FindStepParent(GameObject newStepParent) {
//     if (transform.childCount <= maxChildAmount) return;
//     print("egg");
//     for(int i = maxChildAmount; i < transform.childCount; i++) {
//         transform.GetChild(i).SetParent(availableStepParent[i].transform);
//     }
// }

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LimitChildAmount : MonoBehaviour {
    //The way Gameobjects with the ItemDrag script finds it's original parent is through tags.
    //There could be instances of parents with the same tags exists.
    
    //Code originally inspired by HiddenMonk: https://forum.unity.com/threads/set-a-parents-child-to-allow-only-one-child-per-object.341296/

    [SerializeField] int maxChildAmount = 1;
    [SerializeField] List<GameObject> potentialStepParent;
    GameObject[] potentialStepParents;
    GameObject pents;
    [SerializeField] GameObject testStepParent;
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