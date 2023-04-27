using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameTxt;
    public TMP_InputField passTxt;


    public void logear()
    {
        string log = " WHERE username = '"
        + usernameTxt.text + "' AND password = '"
        + passTxt.text + "';";

        AdminMYSQL admin = GameObject.Find("AdministradorBBDD").GetComponent<AdminMYSQL>();

        MySqlDataReader resultado = admin.select(log);

        if (resultado.HasRows)
        {
            Debug.Log("conectado correctamenteeeeee.");
            resultado.Close();
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.Log("NO CONECTADO.");
            resultado.Close();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
