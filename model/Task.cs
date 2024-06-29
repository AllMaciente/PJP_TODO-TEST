using Repository;
using System.Collections.Generic;

namespace Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public bool Concluida { get; set; }

        public Task()
        {

        }
        public Task(string titulo, string data, string hora)
        {
            Titulo = titulo;
            Data = data;
            Hora = hora;
            Concluida = false;

            Repo.Add(this);
        }

        public static void Sincronizar()
        {
            Repo.Sincronizar();
        }

        public static List<Task> Listar()
        {
            return Repo.tasks;
        }

        public static void Deletar(int indice)
        {
            Repo.Delete(indice);
        }

        public static void Editar(int indice, string titulo, string data, string hora)
        {
            Repo.Update(indice, titulo, data, hora);
        }

        public static void Marcar(int indice, bool check)
        {
            Repo.tasks[indice].Concluida = check;
        }
    }
}
