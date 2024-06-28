namespace Todo
{
    public class ViewTask
    {
        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("---------Create--------");
            Console.WriteLine("Digite o nome da tarefa: ");
            string nome = Console.ReadLine() ?? "";
            Console.WriteLine("Digite a data da tarefa(dd-mm-yyyy): ");
            string data = Console.ReadLine() ?? "";
            Console.WriteLine("Digite a Hora da tarefa(24h): ");
            string hora = Console.ReadLine() ?? "";

            ControllerTask.Create(nome, data, hora);
            Console.WriteLine("Tarefa criada com sucesso!\n");

        }
        public static void Read()
        {
            Console.Clear();
            Console.WriteLine("----------Read---------");
            List<Task> tasks = ControllerTask.Read();
            if (tasks.Count == 0)
            {
                Console.WriteLine("Não há tarefas cadastradas!\n");
            }
            else
            {
                int i = 0;
                foreach (Task task in tasks)
                {
                    char value;
                    if (task.Concluida)
                    {
                        value = 'x';
                    }
                    else
                    {
                        value = ' ';
                    }
                    Console.WriteLine($"{i} - [{value}] {task.Titulo} - {task.Data} - {task.Hora}");
                    i++;
                }
            }

        }
        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("---------Update--------");
            Console.WriteLine("Digite o indece da tarefa: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o nome da tarefa: ");
            string nome = Console.ReadLine() ?? "";
            Console.WriteLine("Digite a data da tarefa: ");
            string data = Console.ReadLine() ?? "";
            Console.WriteLine("Digite a Hora da tarefa: ");
            string hora = Console.ReadLine() ?? "";
            string ret = ControllerTask.Update(index, nome, data, hora);
            Console.Write(ret);
            Console.WriteLine("\n");

        }
        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("---------Delete--------");
            Console.WriteLine("Digite o indece da tarefa: ");
            int index = Convert.ToInt32(Console.ReadLine());
            string ret = ControllerTask.Delete(index);
            Console.Write(ret);
            Console.WriteLine("\n");
        }
        public static void Check()
        {
            Console.Clear();
            Console.WriteLine("---------Check--------");
            Console.WriteLine("Digite o indece da tarefa: ");
            int index = Convert.ToInt32(Console.ReadLine());
            string ret = ControllerTask.Check(index);
            Console.Write(ret);
            Console.WriteLine("\n");
        }
        public static void AllCheck()
        {
            string ret = ControllerTask.AllCheck();
            Console.Write(ret);
            Console.WriteLine("\n");
        }
    }
}
