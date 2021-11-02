using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float TurnS = 200f;
    [SerializeField] float Speed = 10f;
    [SerializeField] float Bump = 5f;
    [SerializeField] float bSpeed = 20f;
    void Start()
    {
        
    }

    void Update()
    {
        float steerA = Input.GetAxis("Horizontal") * TurnS * Time.deltaTime;
        float fSpeed = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.Rotate(0,0,-steerA);
        transform.Translate(0,fSpeed,0);
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Speed = Bump;
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Booster")
        {
            Speed = bSpeed;
        }
    }
}
