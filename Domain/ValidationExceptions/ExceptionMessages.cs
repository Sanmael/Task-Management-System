﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValidationExceptions
{
    public static class ExceptionMessages
    {
        public static string EmailAlreadyExists = "O E-mail '{0}' já está em uso. Escolha um e-mail diferente.";
        public static string PhoneAlreadyExists = "O numero de Telefone '{0}' já está em uso. Escolha um numero diferente.";
        
    }
}
