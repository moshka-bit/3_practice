﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSql321.Data;

namespace TestSql321.Models
{
    static class UserVariableData
    {
        public static User selectedUserInMainWindow {  get; set; }

        public static Login selectedLoginInMainWindow { get; set; }

        public static Item selectedItemInMainWindow { get; set; }

        public static Busket selectedBasketInMainWindow { get; set; }
    }
}
