using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    public class Comissionado: Funcionario
    {
        public bool Comissao { get; set; }

        public Comissionado(string nome, double salario, bool comissao) : base(nome, salario, comissao)
        {
            Comissao = comissao;
        }

        public override double RetornarSalario()
        {
            return salario ? comissao * 1.1 : Salario;
        }
    }
}
