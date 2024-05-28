namespace Todo
{
    public class Program
    {
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.WriteLine("-------TODO LIST-------");
                Console.WriteLine("[1] Criar tarefa");
                Console.WriteLine("[2] Listar tarefas");
                Console.WriteLine("[3] Editar tarefa");
                Console.WriteLine("[4] Deletar tarefa");
                Console.WriteLine("[5] Check");
                Console.WriteLine("[6] Check All");
                Console.WriteLine("[7] Sair");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        ViewTask.Create();
                        break;
                    case 2:
                        ViewTask.Read();
                        break;
                    case 3:
                        ViewTask.Update();
                        break;
                    case 4:
                        ViewTask.Delete();
                        break;
                    case 5:
                        ViewTask.Check();
                        break;
                    case 6:
                        ViewTask.AllCheck();
                        break;
                    case 7:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (op != 7);

        }
    }
}