using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    public class Horista : Funcionario
    {
        public int Horas { get; set; }
        public Horista(string nome, double salario, int horas) : base(nome, salario)
        {
            Horas = horas;
        }

        public override void RetornarSalario()
        {
            Console.WriteLine($"O salário do funcionário {Nome} é R$ {Horas * Salario:F2}.");
        }
    }
}
