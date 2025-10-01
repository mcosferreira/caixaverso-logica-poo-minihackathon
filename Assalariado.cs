using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    public class Assalariado : Funcionario
    {

        public int Horas { get; set; }

        public Assalariado(string nome, double salario) : base(nome, salario)
        {
        }
    }
}
