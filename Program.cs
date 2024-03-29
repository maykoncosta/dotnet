using System;
using System.Collections.Generic;

class Program
{
    static int geradorId = 0;
    static List<Equipamento> refrigeradores = new List<Equipamento>();
    static List<Equipamento> mixers = new List<Equipamento>();
    static List<Insumo> insumos = new List<Insumo>();

    static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("1. Cadastrar equipamento");
            Console.WriteLine("2. Visualizar todos os insumos");
            Console.WriteLine("3. Visualizar equipamentos");
            Console.WriteLine("4. Realizar Checkin do insumo");
            Console.WriteLine("5. Realizar Checkout do insumo");
            Console.WriteLine("6. Sair");
            Console.WriteLine("Escolha uma opção:");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarEquipamento();
                    break;
                case 2:
                    VisualizarInsumos();
                    break;
                case 3:
                    VisualizarEquipamentos();
                    break;
                case 4:
                    RealizarCheckin();
                    break;
                case 5:
                    RealizarCheckout();
                    break;
                case 6:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }

    static void CadastrarEquipamento()
    {
        Console.WriteLine("Digite o nome do equipamento:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o tipo do equipamento (1 para refrigerador, 2 para mixer):");
        int tipo = int.Parse(Console.ReadLine());

        geradorId = geradorId+1;
        Equipamento equipamento = new Equipamento(geradorId+1, nome );

        if (tipo == 1)
        {
            refrigeradores.Add(equipamento);
        }
        else if (tipo == 2)
        {
            mixers.Add(equipamento);
        }
        else
        {
            Console.WriteLine("Tipo de equipamento inválido");
        }
    }

    static void VisualizarEquipamentos()
    {
        Console.WriteLine("Digite o tipo do equipamento (1 para refrigerador, 2 para mixer):");
        int tipo = int.Parse(Console.ReadLine());
        if(tipo == 1)
        {
            Console.WriteLine("Todos os refrigeradores: ");
            foreach (var refrigerador in refrigeradores)
            {
                Console.WriteLine($"Id: {refrigerador.Id}, Nome: {refrigerador.Nome}");
            }
        }
        else if(tipo == 2)
        {
            Console.WriteLine("Todos os mixers: ");
            foreach (var mixer in mixers)
            {
                Console.WriteLine($"Id: {mixer.Id}, Nome: {mixer.Nome}");
            }
        }
        else
        {
            Console.WriteLine($"Não encontrado");
        }
        
    }

    static void VisualizarInsumos()
    {
        Console.WriteLine("Todos os insumos:");
        foreach (var insumo in insumos)
        {
            Console.WriteLine($"Id: {insumo.Id}, Tipo: {insumo.Tipo}, Data de Validade: {insumo.DataValidade}");
        }
    }

    static void RealizarCheckin()
    {
        Console.WriteLine("Digite o tipo do equipamento (1 para refrigerador, 2 para mixer):");
        int tipo = int.Parse(Console.ReadLine());

        geradorId = geradorId+1;
        Equipamento equipamento = null;
        if (tipo == 1)
        {
            Console.WriteLine("Refrigeradores disponíveis:" );
            foreach (var refri in refrigeradores)
            {
                Console.WriteLine($"Id: {refri.Id}, Nome: {refri.Nome}");
            }
            Console.WriteLine("Digite o Id do refrigerador:");
            int id = int.Parse(Console.ReadLine());
            equipamento = refrigeradores.Find(r => r.Id == id);
        }
        else if (tipo == 2)
        {
            Console.WriteLine("Mixers disponíveis:");
            foreach (var mixer in mixers)
            {
                Console.WriteLine($"Id: {mixer.Id}, Nome: {mixer.Nome}");
            }
            Console.WriteLine("Digite o Id do mixer:");
            int id = int.Parse(Console.ReadLine());
            equipamento = mixers.Find(m => m.Id == id);
        }
        else
        {
            Console.WriteLine("Tipo de equipamento inválido");
            return;
        }

        if (equipamento == null)
        {
            Console.WriteLine("Equipamento não encontrado");
            return;
        }

        Console.WriteLine("Digite o tipo do insumo:");
        string tipoInsumo = Console.ReadLine();
        Console.WriteLine("Digite a data de validade do insumo:");
        string dataValidade = Console.ReadLine();

        Insumo insumo = new Insumo ( geradorId+1, tipoInsumo,  dataValidade );
        insumos.Add(insumo);
    }

    static void RealizarCheckout()
    {
        VisualizarInsumos();
        Console.WriteLine("Digite o Id do insumo para checkout:");
        int id = int.Parse(Console.ReadLine());
        Insumo insumo = insumos.Find(i => i.Id == id);
        if (insumo == null)
        {
            Console.WriteLine("Insumo não encontrado");
            return;
        }

        Console.WriteLine("Insumo encontrado:");
        Console.WriteLine($"Id: {insumo.Id}, Tipo: {insumo.Tipo}, Data de Validade: {insumo.DataValidade}");
        Console.WriteLine("Digite o tipo do equipamento (1 para refrigerador, 2 para mixer):");
        int tipo = int.Parse(Console.ReadLine());

        if (tipo == 1)
        {
            Console.WriteLine("Refrigeradores disponíveis:");
            foreach (var refri in refrigeradores)
            {
                Console.WriteLine($"Id: {refri.Id}, Nome: {refri.Nome}");
            }
            Console.WriteLine("Digite o Id do refrigerador:");
            int equipamentoId = int.Parse(Console.ReadLine());
            Equipamento equipamento = refrigeradores.Find(r => r.Id == equipamentoId);
            if (equipamento == null)
            {
                Console.WriteLine("Refrigerador não encontrado");
                return;
            }
            Console.WriteLine($"Insumo removido do refrigerador: {equipamento.Nome}");
        }
        else if (tipo == 2)
        {
            Console.WriteLine("Mixers disponíveis:");
            foreach (var mixer in mixers)
            {
                Console.WriteLine($"Id: {mixer.Id}, Nome: {mixer.Nome}");
            }
            Console.WriteLine("Digite o Id do mixer:");
            int equipamentoId = int.Parse(Console.ReadLine());
            Equipamento equipamento = mixers.Find(m => m.Id == equipamentoId);
            if (equipamento == null)
            {
                Console.WriteLine("Mixer não encontrado");
                return;
            }
            Console.WriteLine($"Insumo removido do mixer: {equipamento.Nome}");
        }
        else
        {
            Console.WriteLine("Tipo de equipamento inválido");
            return;
        }

        insumos.Remove(insumo);
    }
}