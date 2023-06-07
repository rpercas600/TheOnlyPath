using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void openDoor()
    {
        animator.SetBool("Closed", true);
    }
    public void closeDoor()
    {
        animator.SetBool("Closed", false);
    }
}
