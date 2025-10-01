using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    public class Assalariado : Funcionario
    {
        public Assalariado(string nome, double salario) : base(nome, salario)
        {
        }
        public override double RetornarSalario()
        {
            return Salario;
        }
    }
}
