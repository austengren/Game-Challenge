﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    class Hero : Character
    {
        public int DudePower { get; set; }

        public Hero()
        {
            DudePower = 100;
        }
    }
}
