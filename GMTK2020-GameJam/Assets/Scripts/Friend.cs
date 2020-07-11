using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public float moveSpeed = 2;
    public float minDistance = 3;
    public float maxDistance = 10;
    Vector3 kitchen;
    float distance;
    Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        kitchen = GameObject.FindGameObjectWithTag("Kitchen").transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        distance = Vector3.Distance(currentPosition ,kitchen);
        Debug.Log("Distance: " + distance + " Current Position: " + currentPosition  + " Kitchen Postition: " + kitchen);
        if(Vector3.Distance(transform.position,kitchen) >= minDistance){
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currentPosition,kitchen, moveSpeed * Time.deltaTime);
        }

        
    }
}
