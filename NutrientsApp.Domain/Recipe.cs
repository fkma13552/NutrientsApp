using System;
using System.Collections.Generic;
using NutrientsApp.Data;
using NutrientsApp.Entities;

namespace NutrientsApp.Domain
{
    public class Recipe
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String HowTo { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

