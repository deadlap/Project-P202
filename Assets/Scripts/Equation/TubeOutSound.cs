using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeOutSound : MonoBehaviour
{
    AudioSource tubeOut;

    void Awake()
    {
        tubeOut = GetComponent<AudioSource>();
    }

    void TubeOut()
    {
        tubeOut.PlayOneShot(tubeOut.clip);
    }
}
