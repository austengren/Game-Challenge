using System;

namespace GameChallenge
{
    class ProgramUI
    {
        private HeroRepository _heroRepo = new HeroRepository();
        private EnemyRepository _enemyRepo = new EnemyRepository();

        public void Run()
        {
            SetUpGame();
            RunGame();
            EndGame();
        }

        private void SetUpGame()
        {
            CreateHero();
            CreateEnemy();
            ShowHeroDetails();
            ShowEnemyDetails();
        }

        private void CreateHero()
        {
            Console.WriteLine("Hey Dude! What is your name bro?\n");
            string name = Console.ReadLine();

            _heroRepo.CreateCharacter(name);
        }

        private void CreateEnemy()
        {
            Console.WriteLine("Who totally bums you out?\n");
            string name = Console.ReadLine();

            _enemyRepo.CreateCharacter(name);
        }

        private void ShowHeroDetails()
        {
            var hero = _heroRepo.CharacterDetails();
            Console.WriteLine($"Here are the details for {hero.Name}:\n");
            Console.WriteLine($"Character Details for {hero.Name}\n" +
                $"Points: {hero.Points}\n");
        }

        private void ShowEnemyDetails()
        {
            var enemy = _enemyRepo.CharacterDetails();
            Console.WriteLine($"Here are the details for {enemy.Name}:\n");
            Console.WriteLine($"Character Details for {enemy.Name}\n" +
                $"Points: {enemy.Points}\n");
        }

        private void RunGame()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();
            //var Hero = new Hero();
            //var Enemy = new Enemy();

            while (hero.IsAlive && enemy.IsAlive)
            {
                PromptPlayer();

                if (hero.Points <= 0)
                {
                    Console.WriteLine($"Game Over! {hero.Name} is the looser and {enemy.Name} is the Winner!");
                    break;
                }

                if (enemy.Points <= 0)
                {
                    Console.WriteLine($"Game Over! {enemy.Name} is the looser and {hero.Name} is the Winner!");
                    break;
                }
            }
            Console.ReadLine();
        }

        private void PromptPlayer()
        {
            Console.WriteLine("What would you like to do:\n" +
                "1. Attack\n" +
                "2. Flee\n" +
                "3. Bro-It-Up\n");
            var input = int.Parse(Console.ReadLine());
            HandleBattleInput(input);
        }

        private void HandleBattleInput(int input)
        {
            switch (input)
            {
                case 1:
                    Attack();
                    break;
                case 2:
                    Flee();
                    break;
                case 3:
                    BroItUp();
                    break;
                default:
                    break;
            }
        }

        private void Attack()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            _heroRepo.TakeDamage(enemy.AttackPower);
            _enemyRepo.TakeDamage(hero.AttackPower);


            Console.WriteLine($"{hero.Name}'s current points {hero.Points}");
            Console.WriteLine($"{enemy.Name}'s current points {enemy.Points}");
        }

        private void Flee()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            _heroRepo.CowardBonus(enemy.FleePower);
            _enemyRepo.CowardBonus(hero.FleePower);


            Console.WriteLine($"{hero.Name}'s current points {hero.Points}");
            Console.WriteLine($"{enemy.Name}'s current points {enemy.Points}");
        }

        private void BroItUp()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            _heroRepo.BroMode(enemy.BroPower);
            _enemyRepo.BroMode(hero.BroPower);


            Console.WriteLine($"{hero.Name}'s current points {hero.Points}");
            Console.WriteLine($"{enemy.Name}'s current points {enemy.Points}");
        }

        private void EndGame()
        {
        }
    }
}