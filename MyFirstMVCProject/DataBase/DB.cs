using MyFirstMVCProject.Models;
using Pomelo.Data.MySql;
using System;
using System.Collections.Generic;
using System.Data.Common;
namespace MyFirstMVCProject.DataBase
{
    public class DB
    {
        private string databaseName = "banco";
        public string Password = "pass";
        static private MySqlConnection connection = null;
        private static DbConnection _instance = null;
        static string query=null; 
        static MySqlCommand cmd = null;
        public MySqlDataReader rd=null;

        public bool IsConnect() {
                if (connection == null) {
                if (_instance == null) _instance = new MySqlConnection();
                if (String.IsNullOrEmpty(databaseName)) return false;
                string connstring = string.Format("Server=localhost; database={0}; UID=root; password=", databaseName);  connection = new MySqlConnection(connstring); }       
                return true;}

        
        public Object DevolverTodas() {
            IsConnect();
            Open();
            List<CreditCard> AllCreditCards = new List<CreditCard> { };
            query= "SELECT* FROM creditcards;";
            cmd = new MySqlCommand(query, connection);
            rd = cmd.ExecuteReader();
            if (rd.HasRows){ while (rd.Read()) { AllCreditCards.Add(new CreditCard ( rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4) ));}}
            Close();
            return AllCreditCards;}

        public void CrearTarjeta(CreditCard tc) {
            IsConnect();
            query = "INSERT INTO creditcards(`NumeroTarjeta`, `CodigoSeguridad`, `FechaCaducidad`, `Pin`) VALUES ( '" + tc.NumeroTarjeta + "', '" + tc.CodigoSeguridad + "', '" + tc.FechaCaducidad + "', '" + tc.Pin + "')";
            cmd = new MySqlCommand(query, connection);
            try { Open(); rd = cmd.ExecuteReader(); Close(); }
            catch (Exception ex) { }
        }

            public void BorrarTarjeta(int id)  {
                IsConnect();
                query = "DELETE FROM creditcards where Id="  +id  ;
                cmd = new MySqlCommand(query, connection);
                try {  Open(); rd = cmd.ExecuteReader(); Close(); }
                catch (Exception ex) { }
            }

        public object SeleccionarTarjeta(int id) {
            IsConnect();
           query = "SELECT *  FROM creditcards where Id=" + id;
           cmd = new MySqlCommand(query, connection);
            CreditCard cc = null ;
            try { Open(); MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read()) { if (rd.HasRows) {cc = new CreditCard(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4)); } }
                Close();
                return cc;
            }
            catch (Exception ex) { }
            return null;
        }

        public Object ActualizarTarjeta(CreditCard tc) {
            IsConnect();
            query = "UPDATE `creditcards` SET `NumeroTarjeta` = '" + tc.NumeroTarjeta + "', `CodigoSeguridad` = '" + tc.CodigoSeguridad + "' , `FechaCaducidad`= '" + tc.FechaCaducidad + "',`Pin`= '" + tc.Pin + "' WHERE `Id` = " + tc.Id+";";
            cmd = new MySqlCommand(query, connection);
            try {Open(); rd = cmd.ExecuteReader();Close();}
            catch (Exception ex) { }
            return null;
        }

        public void Close() { connection.Close(); }
        public void Open() { connection.Open(); }



    }
}
    
















