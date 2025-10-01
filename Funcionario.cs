using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    public class Funcionario
    {

        private double salario;
        private string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                if (value == "" || value == null)
                    Console.WriteLine("Não é possível informar um nome vazio");
                else
                    nome = value;
            }
        }

        public double Salario
        {
            get { return salario; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Não é permitido salário negativo!");
                else
                    salario = value;
            }
        }

        public Funcionario(string nome, double salario)
        {
            this.nome = nome;
            this.salario = salario;
        }

        public virtual void RetornarSalario()
        {
            Console.WriteLine($"O salário do funcionário {Nome} é R$ {Salario:F2}");
        }
    }
}
