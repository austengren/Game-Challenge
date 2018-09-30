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
            HeroWinsEndGame();
            EnemyWinsEndGame();
        }

        private void SetUpGame()
        {
            GameIntro();
            CreateHero();
            CreateEnemy();
            ShowHeroDetails();
            ShowEnemyDetails();
        }

        private void GameIntro()
        {
            Console.WriteLine("Welcome to do the Dude Game!");
            Console.WriteLine("In this game you are the Dude. You pick someone who totally bums you out.");
            Console.WriteLine("Then it's game on until someone reaches 0 points.");
            Console.WriteLine("Press enter to start!");
            Console.ReadLine();
        }

        private void CreateHero()
        {
            Console.Clear();
            Console.WriteLine("Hey Dude! What is your name bro?\n");
            string name = Console.ReadLine();

            _heroRepo.CreateCharacter(name);
        }

        private void CreateEnemy()
        {
            Console.Clear();
            Console.WriteLine("Who totally bums you out?\n");
            string name = Console.ReadLine();

            _enemyRepo.CreateCharacter(name);
        }

        private void ShowHeroDetails()
        {
            Console.Clear();
            var hero = _heroRepo.CharacterDetails();
            Console.WriteLine($"Here are the details for {hero.Name}:\n");
            Console.WriteLine($"Character Details:\n" +
                $"Points: {hero.Points}\n" +
                $"{hero.DudeMessage}\n");
        }

        private void ShowEnemyDetails()
        {
            var enemy = _enemyRepo.CharacterDetails();
            Console.WriteLine($"Here are the details for {enemy.Name}:\n");
            Console.WriteLine($"Character Details:\n" +
                $"Points: {enemy.Points}\n" +
                $"{enemy.BumMessage}\n");
        }

        private void RunGame()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            while (hero.IsAlive && enemy.IsAlive)
            {
                PromptPlayer();

                if (hero.Points <= 0)
                {
                    HeroWinsEndGame();
                    break;
                }

                if (enemy.Points <= 0)
                {
                    EnemyWinsEndGame();
                    break;
                }
            }
            Console.ReadLine();
        }

        private void PromptPlayer()
        {
            Console.WriteLine("What would you like to do:\n" +
                "1. Throw that dude a insult\n" +
                "2. Run away Bro\n" +
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
            Console.Clear();
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            _heroRepo.TakeDamage(enemy.AttackPower);
            _enemyRepo.TakeDamage(hero.AttackPower);

            Console.WriteLine($"{hero.Name}'s current points {hero.Points}");

            Console.WriteLine($"{enemy.Name}'s current points {enemy.Points}");
        }

        private void Flee()
        {
            Console.Clear();

            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            _heroRepo.CowardBonus(enemy.FleePower);
            _enemyRepo.CowardBonus(hero.FleePower);


            Console.WriteLine($"{hero.Name}'s current points {hero.Points}");
            Console.WriteLine($"{enemy.Name}'s current points {enemy.Points}");
        }

        private void BroItUp()
        {
            Console.Clear();

            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            _heroRepo.BroMode(enemy.BroPower);
            _enemyRepo.BroMode(hero.BroPower);


            Console.WriteLine($"{hero.Name}'s current points {hero.Points}");
            Console.WriteLine($"{enemy.Name}'s current points {enemy.Points}");
        }

        private void HeroWinsEndGame()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine($"Game Over! {hero.Name} is the loser and {enemy.Name} is the Winner!");
            Console.WriteLine("Press enter to play again!");
            Console.ReadLine();
            Console.Clear();
            Run();
        }

        private void EnemyWinsEndGame()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine($"Game Over! {enemy.Name} is the loser and {hero.Name} is the Winner!");
            Console.WriteLine("Press enter to play again!");
            Console.ReadLine();
            Console.Clear();
            Run();
        }
    }
}