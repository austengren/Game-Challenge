using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    class EnemyRepository : ICharacter
    {
        private Enemy _enemy;

        public void CreateCharacter(string name)
        {
            _enemy = new Enemy
            {
                Name = name,
                AttackPower = 12,
                FleePower = 2,
                BroPower = 10,
                Points = 100,
                IsAlive = true,
                BadAdditude = 100
            };
        }

        public Character CharacterDetails()
        {
            return _enemy;
        }

        public void TakeDamage(int attackDamage)
        {
            _enemy.Points -= attackDamage;
        }

        public void CowardBonus(int FleeBonus)
        {
            _enemy.Points -= FleeBonus;
        }

        public void BroMode(int BroPoint)
        {
            _enemy.Points += BroPoint;
        }
    }
}
