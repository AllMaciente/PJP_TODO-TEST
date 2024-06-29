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
                        MessageBox.Show("tarefa cadastrada com sucesso");
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
        public static void Update(int indice, string nome, string data, string hora)
        {
            InitConexao();
            string query = "UPDATE task SET nome = @Nome, data = @Data, hora = @Hora WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, conexao);
            ModelTask task = tasks[indice];
            try
            {
                if (nome != null || data != null || hora != null)
                {
                    command.Parameters.AddWithValue("@Id", task.Id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Data", data);
                    command.Parameters.AddWithValue("@Hora", hora);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        task.Titulo = nome;
                        task.Data = data;
                        task.Hora = hora;
                    }
                    else
                    {
                        MessageBox.Show(rowsAffected.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("tarefa não encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro durante a execução do comando: " + ex.Message);
            }
            CloseConexao();
        }

        public static void Delete(int index)
        {
            InitConexao();
            string delete = "DELETE FROM task WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@Id", tasks[index].Id);
            // executar
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                tasks.RemoveAt(index);
                MessageBox.Show("Tarefa deletada com sucesso.");
            }
            else
            {
                MessageBox.Show("Tarefa não encontrado.");
            }
            CloseConexao();
        }
    }
}
