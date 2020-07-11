using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public float moveSpeed = 2;
    public float minDistance = 0;
    public float maxDistance = 0;
    Vector3 kitchen;
    GameObject[] doors;
    float distance;
    Vector3 currentPosition;
    Vector3 target;

    bool enteredDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        kitchen = GameObject.FindGameObjectWithTag("Kitchen").transform.position;
        doors = GameObject.FindGameObjectsWithTag("Door");
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        distance = Vector3.Distance(currentPosition ,kitchen);
        
        
        if(!enteredDoor){
            target = FindClosestDoor();
            if(target == currentPosition){
                enteredDoor = true;
                Debug.Log("Entred Door!");
            }
        } 
        else {
            target = kitchen;
            //Debug.Log("Distance: " + distance + " Current Position: " + currentPosition  + " Target Postition: " + target);
        }

        Debug.Log("Distance: " + distance + " Current Position: " + currentPosition  + " Target Postition: " + target);

        if(Vector3.Distance(transform.position,target) >= minDistance){
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currentPosition,target, moveSpeed * Time.deltaTime);
        }

        
    }

    Vector3 FindClosestDoor(){
        Vector3 bestDoor = new Vector3(Mathf.Infinity,Mathf.Infinity,Mathf.Infinity);
        float distance;
        float disToBest;

        
        foreach(GameObject door in doors){
            distance = Vector3.Distance(currentPosition,door.transform.position);
            disToBest = Vector3.Distance(currentPosition,bestDoor);
            if(distance < disToBest){
                bestDoor = door.transform.position;
            }
            
        }

        return bestDoor;
    }
}
