﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    class Enemy : Character
    {
        public int BadAdditude { get; set; }

        public Enemy()
        {
            BadAdditude = 100;
        }
    }
}