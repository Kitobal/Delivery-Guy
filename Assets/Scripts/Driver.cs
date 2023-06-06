using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    Coroutine engineCoroutine;
    [SerializeField] float turnSpeed = 0.1f;
    [SerializeField] float acceleration = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * acceleration * Time.deltaTime;
        transform.Rotate(0,0,-turnAmount);
        transform.Translate(0,moveAmount,0);
    }
}
