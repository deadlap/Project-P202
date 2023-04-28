using System;
using UnityEngine;

public class MoveBulge : MonoBehaviour {
    public int currentWP;
    int originalYPos = -484;
    [SerializeField] bool goesLeft;
    [SerializeField] float moveSpeed = .01f;
    [SerializeField] GameObject[] waypoints;

    void Update() {
        Move();
    }

    void Move() {
        if (currentWP == waypoints.Length) {
            currentWP = 0;
            ReturnToOriginalPosition();
            return;
        }
        if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) <= 0.01) {
            currentWP++;
            if(goesLeft)
                transform.Rotate(0,0,-90);
            else
                transform.Rotate(0,0,90);
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWP].transform.position,
            Time.deltaTime * moveSpeed);
    }
    
    void ReturnToOriginalPosition() {
        var originalPos = new Vector3(0, originalYPos, 0);
        transform.position = Vector3.MoveTowards(transform.position, originalPos, 0);
        gameObject.SetActive(false);
    }
}
