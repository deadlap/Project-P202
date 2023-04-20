using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBulge : MonoBehaviour
{
    public int currentWP;
    [SerializeField] float moveSpeed = .01f;
    [SerializeField] GameObject[] waypoints;

    void Update()
    {
        if (currentWP == 3) 
            Destroy(gameObject);
        if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) <= 0.01)
        {
            currentWP++;
            transform.Rotate(0,0,90);
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWP].transform.position,
            Time.deltaTime * moveSpeed);
    }
}
