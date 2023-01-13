﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula02.Entities
{
    public class Funcao
    {
        private Guid _id;
        private string _descricao;

        public Guid Id
        {
         
            set {
                if (value == Guid.Empty)
                    throw new ArgumentException("Por favor,informe a função");

                _id = value;
            }    
            get => _id; 
        }
        public string Descricao
        {
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor,informe uma descrição da função.");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{6,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe uma descrição válida.");


                _descricao = value; 
            }
            get => _descricao;
        }
    }
}
