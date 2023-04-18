using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    public Animator animator;
    private float movimientoHorizontal = 0f;
    private float movimientoVertical = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (movimientoHorizontal != 0 && movimientoVertical != 0)
        {
            

        }
        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            animator.SetFloat("YInput", movimientoVertical);

            StartCoroutine(MovePlayer(Vector3.up));

        }
        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            animator.SetFloat("XInput", movimientoHorizontal);
            StartCoroutine(MovePlayer(Vector3.right));

        }
        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));

        }
        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }


    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }
}
