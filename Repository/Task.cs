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
        public static void Add(ModelTask task)
        {
            InitConexao();
            string insert = "INSERT INTO task (nome, data, hora) VALUES (@Nome, @Data, @Hora );";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try
            {
                if (task.Titulo == null || task.Data == null || task.Hora == null)
                {
                    MessageBox.Show("Deu ruim, favor preencher a task");
                }
                else
                {
                    command.Parameters.AddWithValue("@Nome", task.Titulo);
                    command.Parameters.AddWithValue("@Data", task.Data);
                    command.Parameters.AddWithValue("@Hora", task.Hora);

                    int rowsAffected = command.ExecuteNonQuery();
                    task.Id = Convert.ToInt32(command.LastInsertedId);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Task cadastrada com sucesso");
                        tasks.Add(task);
                    }
                    else
                    {
                        MessageBox.Show("Deu ruim, não deu pra adicionar");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Deu ruim: " + e.Message);
            }

            CloseConexao();
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
