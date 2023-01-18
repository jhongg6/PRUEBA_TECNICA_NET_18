using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OperatorController : ApiController
    {
        // POST api/<controller>
        public string Post([FromBody] Operator oOperator)
        {
            if (isOperatorValid(oOperator) && characterValidations(oOperator) && dataValidation(oOperator))
            {
                return OperatorData.Register(oOperator);
            }
            else
            {
                return "Erros encontrados en el registro, verifique nuevamente la información.";
            }
            
        }

        private bool isOperatorValid(Operator op) 
        {
            if (op.IdentityCard == 0 || op.NameClient == null || op.SurnameClient == null) 
            {
                return false;
            }
            return true;
        }

        private bool characterValidations(Operator op)
        {
            if (!Regex.IsMatch(op.NameClient, @"^[a-zA-Z0-9]+$") || !Regex.IsMatch(op.SurnameClient, @"^[a-zA-Z0-9]+$"))
            { 
                return false;
            }
            return true;
        }

        private bool dataValidation(Operator op) 
        {
            if (op.Address1 == null && op.Email1 == null)
            {
                return false;
            }
            return true;
        }
    }
}