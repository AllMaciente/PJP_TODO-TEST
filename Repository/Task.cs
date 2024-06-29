using System.Collections.Generic;

using MySqlConnector;
using Model;
using ModelTask = Model.Task;

namespace Repository
{
    public class Repo
    {
        public static List<ModelTask> tasks = new List<ModelTask>();
        public static MySqlConnection conexao;

        public static void InitConexao()
        {
            string info = "server=localhost;database=todoDB;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try
            {
                conexao.Open();
            }
            catch
            {
                MessageBox.Show("Impossível estabelecer conexão");
            }
        }
        public static void CloseConexao()
        {
            conexao.Close();
        }

        public static List<ModelTask> Sincronizar()
        {
            InitConexao();
            string query = "SELECT * FROM task";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"].ToString());
                ModelTask task = new ModelTask();
                task.Id = id;
                task.Titulo = reader["nome"].ToString();
                task.Data = reader["data"].ToString();
                task.Hora = reader["hora"].ToString();
                tasks.Add(task);

            }
            CloseConexao();
            return tasks;
        }
    }
}
