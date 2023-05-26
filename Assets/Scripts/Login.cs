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
    public TMP_InputField repeatPass;

    public Text user1;

    public Text tp1;
    public Text textSuccessFail;

    public Text textErrorAdminPanel;
    public Text userAdminFoundTxt;
    public Text passAdminFoundTxt;
    public Text adminAdminFoundTxt;
    public TMP_InputField searchAdminField;
    public TMP_InputField userFoundField;
    public TMP_InputField passFoundField;
    public TMP_InputField adminFoundField;
    public GameObject login;
    public GameObject register;

    public GameObject common;
    public GameObject timePlayed;

    public GameObject adminPanel;


    public void logear()
    {
        
        string log = " WHERE username = '"
        + usernameTxt.text + "' AND password = '"
        + passTxt.text + "';";

        AdminMYSQL admin = GameObject.Find("AdministradorBBDD").GetComponent<AdminMYSQL>();
        MySqlDataReader resultado = admin.select(log);


        if (resultado.HasRows)
        {
            if (resultado.Read())  //necesario para leer los datos que devuelve
            {
                if (resultado.GetString(2) == "y") //miro a ver si es admin
                {

                    Debug.Log("conectado como admin");
                    showHideAdminPanel();
                    resultado.Close();

                }
                else
                {
                    Debug.Log("Conectado como jugador normal.");
                    //   bool playOutput = EditorUtility.DisplayDialog("Acceso correcto", "Accediendo al juego", "Aceptar", "Volver");
                    //   if (playOutput)
                    //  {
                    Debug.Log("conectado correctamenteeeeee.");
                    resultado.Close();
                    textSuccessFail.color = Color.green;
                    textSuccessFail.text = "Conectado correctamente";
                    changeToGameScene();
                    //  }
                    //   else
                    //  resultado.Close();
                }
            }

        }
        else
        {
            // bool playOutput = EditorUtility.DisplayDialog("Error", "Datos incorrectos, intente de nuevo.", "Ok");
            //  if (playOutput)
            //   {
            Debug.Log("NO CONECTADO.");
            textSuccessFail.color = Color.red;
            textSuccessFail.text = "Error al introducir los datos.";
            resultado.Close();
            //    }
            //   else
            //       Debug.Log("NO CONECTADO.");
            //    resultado.Close();
        }
    }

    public void searchUser()
    {
        string log = " WHERE username = '"
        + searchAdminField.text + "';";

        AdminMYSQL admin = GameObject.Find("AdministradorBBDD").GetComponent<AdminMYSQL>();

        MySqlDataReader resultado = admin.select(log);
        if (resultado.HasRows)
        {
            if (resultado.Read())  //necesario para leer los datos que devuelve
            {
                textErrorAdminPanel.text = "";
                userAdminFoundTxt.text = resultado.GetString(0);
                passAdminFoundTxt.text = resultado.GetString(1);
                adminAdminFoundTxt.text = resultado.GetString(2);
                resultado.Close();
            }

        }
        else
        {
            textErrorAdminPanel.color = Color.red;
            textErrorAdminPanel.text = "User not found.";
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
                Debug.Log("ya existe ese usuario.");
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

    public void showHideTimePlayed()
    {
        if (login.activeSelf)
        {
            login.SetActive(false);
            timePlayed.SetActive(true);
            common.SetActive(false);

        }
        else
        {
            clearCommonTextFields();
            login.SetActive(true);
            timePlayed.SetActive(false);
            common.SetActive(true);

        }
    }

    public void showHideAdminPanel()
    {
        if (login.activeSelf)
        {
            login.SetActive(false);
            adminPanel.SetActive(true);
            common.SetActive(false);

        }
        else
        {
            login.SetActive(true);
            adminPanel.SetActive(false);
            common.SetActive(true);

        }
    }

    public void changeToGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void clearCommonTextFields()
    {
        passTxt.text = "";
        usernameTxt.text = "";
    }
}
