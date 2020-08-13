using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().Herido();
        enabled = false;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        box.enabled = false;
    }
}
