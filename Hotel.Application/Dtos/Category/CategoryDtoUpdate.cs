﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Dtos.Category
{
    public class CategoryDtoUpdate : CategoryDtoBase
    {
        public int IdCategoria { get; set; }
        public bool? Estado { get; internal set; }
        public DateTime? FechaMod { get; internal set; }
    }
}
