using System.Collections.Generic;
using ModelTask = Model.Task;

namespace Controller
{
    public class ControllerTask
    {
        public static void Create(string titulo, string data, string hora)
        {
            new ModelTask(titulo, data, hora);
        }

        public static List<ModelTask> Read()
        {
            return ModelTask.Listar();
        }

        public static string Update(int indice, string titulo, string data, string hora)
        {
            var tasks = ModelTask.Listar();
            if (indice >= 0 && indice < tasks.Count)
            {
                ModelTask.Editar(indice, titulo, data, hora);
                return "Task atualizada com sucesso";
            }
            else
            {
                return "Task não encontrada";
            }
        }

        public static string Delete(int indice)
        {
            var tasks = ModelTask.Listar();
            if (indice >= 0 && indice < tasks.Count)
            {
                ModelTask.Deletar(indice);
                return "Task deletada com sucesso";
            }
            else
            {
                return "Task não encontrada";
            }
        }

        public static string Check(int indice)
        {
            var tasks = ModelTask.Listar();
            if (indice >= 0 && indice < tasks.Count)
            {
                var task = tasks[indice];
                ModelTask.Marcar(indice, !task.Concluida);
                return "Task marcada com sucesso";
            }
            else
            {
                return "Task não encontrada";
            }
        }

        public static string AllCheck()
        {
            var tasks = ModelTask.Listar();
            if (tasks.Count == 0)
            {
                return "Não tem task";
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (!tasks[i].Concluida)
                    {
                        ModelTask.Marcar(i, true);
                    }
                }
                return "Tasks marcadas com sucesso";
            }
        }
    }
}
