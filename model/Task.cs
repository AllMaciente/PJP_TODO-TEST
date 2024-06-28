using Repository;
using System.Collections.Generic;

namespace Model
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

            Repo.tasks.Add(this);
        }

        public static List<Task> Listar()
        {
            return Repo.tasks;
        }

        public static void Deletar(int indice)
        {
            Repo.tasks.RemoveAt(indice);
        }

        public static void Editar(int indice, string titulo, string data, string hora)
        {
            Repo.tasks[indice].Titulo = titulo;
            Repo.tasks[indice].Data = data;
            Repo.tasks[indice].Hora = hora;
        }

        public static void Marcar(int indice, bool check)
        {
            Repo.tasks[indice].Concluida = check;
        }
    }
}
