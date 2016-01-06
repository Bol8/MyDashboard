﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Repository.Validations
{
    public class NIFAttribute:ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var dni = Convert.ToString(value);

            if (String.IsNullOrEmpty(dni))
            {
                return true;
            }

            if (!Regex.IsMatch(value.ToString(), "^(([A-Z]\\d{8})|(\\d{8}[A-Z]))$"))
            {
                return false;
            }

            return true;
        }


    }
}
