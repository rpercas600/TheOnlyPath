using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public Transform homePos;
    private Animator animator;
    private Transform target;

    //desde donde nos ve
    [SerializeField]
    private float maxRange;
    //hasta donde nos persigue, para que no choque con nosotros le damos valor 1 en el editor.
    [SerializeField]
    private float minRange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //controla la posicion del enemigo comparandola con la nuestra, si se encuentra entre ese rango se mueve
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            followPlayer();
          //si me alejo lo suficiente para salir del maxrange se vuelve al punto inicial  
        } else if(Vector3.Distance(target.position, transform.position)>=maxRange){
            goHome();
        }

    }
    private void followPlayer()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("MoveX", (target.position.x - transform.position.x));
        animator.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    private void goHome()
    {
        animator.SetFloat("MoveX", (homePos.position.x - transform.position.x));
        animator.SetFloat("MoveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, moveSpeed * Time.deltaTime);

        //cuando llegue al punto de inicio para la animación
        if(Vector3.Distance(transform.position, homePos.position) == 0) {
            animator.SetBool("isMoving", false);
                    }
    }

}