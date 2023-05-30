using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
public class PlayerController : MonoBehaviour
{

    private float miliseconds;
    private float seconds;
    private float minutes;
    private float hours;
    public Animator anim;

    public float moveSpeed;

    private Rigidbody2D rb;

    private Time myPlayedTime;
    private float x;
    private float y;

    private Vector2 input;
    private bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(1, 1);
                //cojo los datos de bbdd para ir aumentando el tiempo
        string log = " WHERE username = '"+Login.getUsername()+"';";
        Debug.Log(log);
        AdminMYSQL admin = GameObject.Find("AdministradorBBDD").GetComponent<AdminMYSQL>();
        
        
        MySqlDataReader resultado = admin.selectPlayedTime(log);
        if (resultado.HasRows)
        {
        if (resultado.Read())  //necesario para leer los datos que devuelve
            {
                Debug.Log("llega aqui");
                string stringToFormat = resultado.GetString(0);
                Debug.Log(stringToFormat);
            }
            
        }
        
        //resultado.Close();
    }

    private void Update()
    {

        GetInput();
        Animate();
        miliseconds += Time.deltaTime;
        if (miliseconds >= 1.0f)
        {
            miliseconds -= 1.0f;
            seconds++;
            if (seconds > 59)
            {
                seconds = 0;
                minutes++;
                 if (minutes > 59)
            {
                minutes = 0;
                hours++;
            }
            }
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }
    private void Animate()
    {
        //si se presiona algun botón que controla el movimiento, WASD, flechas, se mueve
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("Moving", moving);
    }


    private void OnApplicationQuit()
    {
        Debug.Log("termina el juego");
        string log = " SET username = '"+Login.getUsername()+"', playedtime='"+hours+":"+minutes+":"+seconds+"' WHERE username = '"+Login.getUsername()+"';";
        Debug.Log(log);
        AdminMYSQL admin = GameObject.Find("AdministradorBBDD").GetComponent<AdminMYSQL>();
        MySqlDataReader resultado = admin.updatePlayedTime(log);
        resultado.Close();
    }
}
