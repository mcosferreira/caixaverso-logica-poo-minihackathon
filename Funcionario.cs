using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    public class Funcionario
    {
        private String _nome;
        private double _salario;
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Não é possível informar um nome vazio");
                    _nome = "";
                }
                else
                {
                    _nome = value;
                }
            }
        }

        public double Salario
        {
            get { return _salario; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Não é permitido salário negativo!");
                    _salario = 0.0;
                }
                else
                {
                    _salario = value;
                }
            }
        }

        public Funcionario(string nome, double salario)
        {
            this.Nome = nome;
            this.Salario = salario;
        }

        public Funcionario()
        {
        }

        public virtual double RetornarSalario()
        {
            return Salario;
        }
    }
}
