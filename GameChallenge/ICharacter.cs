using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    interface ICharacter<T>
    {
        void CreateCharacter(string name);
        T CharacterDetails();
        void TakeDamage(int attackDamage);
        void CowardBonus(int FleeBonus);
        void BroMode(int BroPoint);
    }
}
