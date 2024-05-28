namespace Todo
{
    public class ControllerTask
    {
        public static void Create(string titulo, string data, string hora)
        {
            new Task(titulo, data, hora);

        }
        public static List<Task> Read()
        {
            return Task.Listar();
        }
        public static string Update(int indece, string titulo, string data, string hora)
        {
            List<Task> tasks = Task.Listar();
            if (indece >= 0 && indece < tasks.Count)
            {
                Task.Editar(indece, titulo, data, hora);
                return "Task atualizada com sucesso";
            }
            else
            {
                return "Task não encontrada";
            }

        }
        public static string Delete(int indece)
        {
            List<Task> tasks = Task.Listar();
            if (indece >= 0 && indece < tasks.Count)
            {
                Task.Deletar(indece);
                return "Task deletada com sucesso";
            }
            else
            {
                return "Task não encontrada";
            }
        }
        public static string Check(int indece)
        {
            List<Task> tasks = Task.Listar();
            if (indece >= 0 && indece < tasks.Count)
            {
                Task task = tasks[indece];
                if (task.Concluida)
                {
                    Task.marcar(indece, false);
                }
                else
                {
                    Task.marcar(indece, true);
                }
                return "Task Marcada com sucesso";
            }
            else
            {
                return "Task não encontrada";
            }
        }
        public static string AllCheck()
        {
            List<Task> tasks = Task.Listar();
            if (tasks.Count == 0)
            {
                return "não tem task";
            }
            else
            {
                int i = 0;
                foreach (Task task in tasks)
                {
                    if (!task.Concluida)
                    {
                        Task.marcar(i, true);
                    }
                    i++;
                }
                return "Tasks Marcadas com sucesso";
            }
        }
    }
}
