using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(229,40,40,255);
    [SerializeField] Color32 noPackageColor = new Color32(0,255,0,255);
    bool hasPackage = false;
    [SerializeField] float destDelay = 0.5f;
    SpriteRenderer spriteRenderer;
    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        // Debug.Log("Ouch!");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package")
        {
            if (!hasPackage)
            {
                Debug.Log("Package secured");
                hasPackage = true;
                spriteRenderer.color = hasPackageColor;
                Destroy(other.gameObject, destDelay);
            }
            else
            {
                Debug.Log("Deliver your package first");
            }
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package dropped off");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
