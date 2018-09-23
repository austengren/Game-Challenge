using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    class HeroRepository : ICharacter
    {
        //-- Fields
        private Hero _hero;


        public void CreateCharacter(string name)
        {
            _hero = new Hero
            {
                Name = name,
                IsAlive = true,
                AttackPower = 15,
                FleePower = 5,
                BroPower = 5,
                Points = 100,
                DudePower = 100
            };
        }

        public Character CharacterDetails()
        {
            return _hero;
        }

        public void TakeDamage(int attackDamage)
        {
            _hero.Points -= attackDamage;
        }

        public void CowardBonus(int FleeBonus)
        {
            _hero.Points -= FleeBonus;
        }

        public void BroMode(int BroPoint)
        {
            _hero.Points += BroPoint;
        }
    }
}
