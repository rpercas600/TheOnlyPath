using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;


public class AdminMYSQL : MonoBehaviour
{
    
    public string serverName;
    public string databaseName;
    public string username;
    public string password;

    private string datosConexion;
    private MySqlConnection conexion;
    // Start is called before the first frame update
    void Start()
    {
        datosConexion = "Server="+serverName+";Database="+databaseName+";Uid="+username+";Pwd="+password+";";
        ConnectToDBServer();
    }

    
    void ConnectToDBServer()
    {
        conexion = new MySqlConnection(datosConexion);

        try {
            conexion.Open();
            Debug.Log("Conexion hecha");
        } catch(MySqlException error) {
            Debug.Log("no conecta bbdd "+error);
        }
    }

    public MySqlDataReader select(string select) {

        string sql = "SELECT * FROM account "+select;
        MySqlCommand cmd = new MySqlCommand(sql, conexion);
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }

    public MySqlDataReader selectFromPosition(string select) {

        string sql = "SELECT * FROM position WHERE username = "+select;
        MySqlCommand cmd = new MySqlCommand(sql, conexion);
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }

     public MySqlDataReader insert(string insert) {

        string sql = "INSERT INTO " + insert;
        MySqlCommand cmd = new MySqlCommand(sql, conexion);
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }

    public MySqlDataReader delete(string delete) {

        string sql = "DELETE from account WHERE " + delete;
        MySqlCommand cmd = new MySqlCommand(sql, conexion);
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }

    public MySqlDataReader updatePlayedTime(string update) {

        string sql = "UPDATE playedtime " + update;
        MySqlCommand cmd = new MySqlCommand(sql, conexion);
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }

    public MySqlDataReader selectPlayedTime(string select) {

        string sql = "SELECT playedtime FROM playedtime " + select;
        MySqlCommand cmd = new MySqlCommand(sql, conexion);
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }

        public MySqlDataReader rankingPlayedTime() {

        string sql = "SELECT * FROM `playedtime` order by playedtime desc limit 3;";
        MySqlCommand cmd = new MySqlCommand(sql, conexion);
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }

    public MySqlDataReader updateAccount(string update) {

        string sql = "UPDATE account " + update;
        MySqlCommand cmd = new MySqlCommand(sql, conexion);
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }

    public MySqlDataReader updatePosition(string update) {

        string sql = "UPDATE position " + update;
        MySqlCommand cmd = new MySqlCommand(sql, conexion);
        MySqlDataReader resultado = cmd.ExecuteReader();
        return resultado;
    }
}
