using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    class HeroRepository : ICharacter<Hero>
    {
        //-- Fields
        private Hero _hero;

        public void CreateCharacter(string name)
        {
            _hero = new Hero
            {
                Name = name,
                IsAlive = true,
                AttackPower = SetAttackPower(),
                FleePower = SetFleePower(),
                BroPower = SetBroPower(),
                Points = 100,
                DudeMessage = "Solid name Bro and check it out you start out with 100 points!"
            };
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

        private int SetAttackPower()
        {
            Random rnd = new Random();
            var attackNum = rnd.Next(5, 15);
            return attackNum;
        }

        private int SetFleePower()
        {
            Random rnd = new Random();
            var attackNum = rnd.Next(3, 10);
            return attackNum;
        }

        private int SetBroPower()
        {
            Random rnd = new Random();
            var attackNum = rnd.Next(1, 5);
            return attackNum;
        }

        public Hero CharacterDetails()
        {
            return _hero;
        }
    }
}
