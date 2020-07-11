using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 2f;
    public Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(0, playerSpeed * Time.deltaTime, 0);
            isWalking();
        }
        else if(Input.GetKey(KeyCode.S)){
            transform.Translate(0, - playerSpeed * Time.deltaTime, 0);
            isWalking();
        }
        else if(Input.GetKey(KeyCode.A)){
            transform.Translate( - playerSpeed * Time.deltaTime, 0, 0);
            isWalking();
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
            isWalking();
        }
        else {
            isWalking(false);
        }
    }

    void isWalking(bool val = true){
        animator.SetBool("isWalking",val);
    }
}
