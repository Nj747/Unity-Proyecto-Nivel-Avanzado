using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsManager : MonoBehaviour {

    public Manager manager;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.UpdateGemsCount();
        GetComponent<CircleCollider2D>().enabled = false;
        animator.SetBool("Collected", true);
        Destroy(gameObject,1f);
    }
}
