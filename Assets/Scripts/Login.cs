using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameTxt;
    public TMP_InputField passTxt;
    public TMP_InputField repeatPass;

    public GameObject login;
    public GameObject register;
    public void logear()
    {
        string log = " WHERE username = '"
        + usernameTxt.text + "' AND password = '"
        + passTxt.text + "';";

        AdminMYSQL admin = GameObject.Find("AdministradorBBDD").GetComponent<AdminMYSQL>();

        MySqlDataReader resultado = admin.select(log);

        if (resultado.HasRows)
        {
            bool playOutput = EditorUtility.DisplayDialog("Acceso correcto", "Accediendo al juego", "Aceptar", "Volver");
            if (playOutput)
            {
                Debug.Log("conectado correctamenteeeeee.");
                resultado.Close();
                SceneManager.LoadScene("SampleScene");
            }
            else
            resultado.Close();
        }
        else
        {
            bool playOutput = EditorUtility.DisplayDialog("Error", "Datos incorrectos, intente de nuevo.", "Ok");
            if (playOutput)
            {
                Debug.Log("NO CONECTADO.");

                resultado.Close();
            }
            else
                Debug.Log("NO CONECTADO.");
            resultado.Close();
        }
    }

    public void registerNewUser()
    {

        if (passTxt.text == repeatPass.text)
        {
            string log = " WHERE username = '" + usernameTxt.text + "' AND password = '"
        + passTxt.text + "';";
            AdminMYSQL adminMYSQL = GameObject.Find("AdministradorBBDD").GetComponent<AdminMYSQL>();

            MySqlDataReader resultado = adminMYSQL.select(log);

            if (resultado.HasRows)
            {
                Debug.Log("ya eciste ese usuario.");
                resultado.Close();

            }
            else
            {
                resultado.Close();
                log = "`account` (`username`, `password`) VALUES ('" + usernameTxt.text + "', '" + passTxt.text + "')";
                resultado = adminMYSQL.insert(log);
                Debug.Log("usuario creado correctamente");
                resultado.Close();
                showHideRegister();
            }
        }
        else
        {
            Debug.Log("contraseñas no iguales");
        }
    }

    public void showHideRegister()
    {
        if (login.activeSelf)
        {
            login.SetActive(false);
            register.SetActive(true);
        }
        else
        {
            login.SetActive(true);
            register.SetActive(false);
        }
    }
}
