namespace Todo
{
    public class Task
    {
        public string Titulo { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public bool Concluida { get; set; }

        public Task(string titulo, string data, string hora)
        {
            Titulo = titulo;
            Data = data;
            Hora = hora;
            Concluida = false;

            RepoTask.tasks.Add(this);
        }
        public static List<Task> Listar()
        {
            return RepoTask.tasks;
        }
        public static void Deletar(int indece)
        {
            RepoTask.tasks.RemoveAt(indece);
        }
        public static void Editar(int indece, string titulo, string data, string hora)
        {
            RepoTask.tasks[indece].Titulo = titulo;
            RepoTask.tasks[indece].Data = data;
            RepoTask.tasks[indece].Hora = hora;
        }
        public static void marcar(int indece, bool check)
        {
            RepoTask.tasks[indece].Concluida = check;
        }


    }
}
