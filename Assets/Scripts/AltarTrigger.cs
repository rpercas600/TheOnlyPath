using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarTrigger : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D bCollider;
    [SerializeField]
    private GameObject door;

    private void Awake()
    {
        animator = door.GetComponent<Animator>();
        bCollider = door.GetComponent<BoxCollider2D>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("Closed", false);
        bCollider.enabled = false;
        Debug.Log("se pisa el altar");
    }

    public void OnTriggerStay2D(Collider2D other) {
        animator.SetBool("Closed", false);
        bCollider.enabled = false;
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Closed", true);
        bCollider.enabled = true;
        Debug.Log("se sale del altar");
    }

}
