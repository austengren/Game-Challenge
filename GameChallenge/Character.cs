using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    abstract class Character
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int AttackPower { get; set; }
        public int FleePower { get; set; }
        public int BroPower { get; set; }
        public bool IsAlive { get; set; }
    }
}
