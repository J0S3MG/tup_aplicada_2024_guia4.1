using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioDB.Models
{
    public class Envio
    {
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public List<Costo> costos { get; set; } = new List<Costo>();//Una lista de objetos Costo.Funciona como ArrayList pero con especificacion de tipo.

        public override string ToString()//sobre escribe el metodo de Objetc. //Heredan todos los objetos
        {
            return $"{Id} - {ValorTotal}";
        }
        public List<Envio> ListarTodo()//nos devuelve una lista de tipo Envio.
        {
            var lista = new List<Envio>();//Se crea una lista que recibe los tipos Envio que se van a  retornar.

            using (var conn = new SqlConnection() { ConnectionString = "Server=TUPDEV; DATABASE=EnviosDB; user='alumno'; password='alumno'; Trusted_Connection=True; " })
            {//con "var conn = new SqlConnection()" nos conectamos a la base de datos.

                var cmd = conn.CreateCommand();//llamaos al metodo para interactuar a travez de consultas con la base de datos.
                cmd.CommandText = "SELECT * FROM Envios";//hacemos una consulta a SQL como texto
                cmd.CommandType = CommandType.Text;//Permite transformar la consulta de texto a codigo con el "CommandType.Text"

                conn.Open();//Habre la conexion con la base de datos.

                var rd = cmd.ExecuteReader();//tiene un contador interno .
                while (rd.Read() == true)//Lee el siguiente
                {
                    lista.Add(new Envio()
                    {
                        Id = rd.GetInt32(rd.GetOrdinal("Id")),//Lee columna por columna en la Base de Datos y lo almacena en ID.
                        ValorTotal = Convert.ToDouble(rd.GetDecimal(rd.GetOrdinal("Valor_Total"))),//Lee columna por columna en la Base de Datos y lo almacena en ValorTotal antes lo transforma en double.
                    });
                }
                conn.Close();// Cierra la conexion con la base de datos.
            }

            return lista;
        }
    }
}
