using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula02.Entities
{
    
    public class Funcionario
    {
        private Guid _id;
        private string _nome;
        private string _cpf;
        private string _matricula;
        private DateTime _dataAdmissao;
        private Funcao _funcao;
       
        public Guid Id
        {
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("Por favor,informe um ID válido.");
                _id = value;
            }
            get=> _id; 

        }
        public string Nome
        {
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor,infome o nome do funcionário.");
                var regex = new Regex("^[A-Za-zÁ-Üá-ü\\s]{8,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor,imforme um nome válido. ");
                _nome = value; 
            }         
            get=> _nome; 
        }
         
        public string Cpf
        {
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor,imforme o cpf do funcionario .");

                var regex = new Regex("^[0-9]{11}$");
                
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor,imforme o cpf com 11 digitos. ");

                _cpf = value;
            }
            get => _cpf;
        }

        public DateTime DataAdmissao
        {
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("Por favor,imforme a data de admissão do funcionario.");
               
                _dataAdmissao = value;
            }
            get => _dataAdmissao;
        }

        public string Matricula
        {
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor,imforme uma matricula do funcionario.");

                var regex = new Regex("^[A-Za-z0-9]{6,10}$");

                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor,imforme a matricula válido. ");

                _matricula = value; 
            }
            get => _matricula;

        }
        public Funcao Funcao
        {
            set{_funcao = value;}
            get => _funcao;

        }

    }
}
