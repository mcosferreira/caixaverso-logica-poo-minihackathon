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

        public Comissionado(string nome, double salario, bool comissao) : base(nome, salario)
        {
            Comissao = comissao;
        }

        public override double RetornarSalario()
        {
            return Comissao ? this.Salario * 1.1 : this.Salario;
        }
    }
}
