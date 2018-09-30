using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChallenge
{
    class EnemyRepository : ICharacter<Enemy>
    {
        private Enemy _enemy;

        public void CreateCharacter(string name)
        {
            _enemy = new Enemy
            {
                Name = name,
                AttackPower = SetAttackPower(),
                FleePower = SetFleePower(),
                BroPower = SetBroPower(),
                Points = 100,
                IsAlive = true,
                BumMessage = "Look at this guy...Why do they get 100 points to start with."
            };
        }

        public void TakeDamage(int attackDamage)
        {
            _enemy.Points -= attackDamage;
        }

        public void CowardBonus(int FleeBonus)
        {
            _enemy.Points += FleeBonus;
        }

        public void BroMode(int BroPoint)
        {
            _enemy.Points -= BroPoint;
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

        public Enemy CharacterDetails()
        {
            return _enemy;
        }
    }
}
