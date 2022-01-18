using System;
using System.Collections.Generic;
using static System.Console;

namespace RPG {
    class Program {
        static void Main(string[] args) {
            
            ForegroundColor = ConsoleColor.Blue;

            PrintMainScreen();
            
            ExitGame();
        }

        private static void PrintMainScreen () {
            int choice;
            do {
                Console.Clear();
                WriteLine("----- Welcome to the game -----");
                WriteLine("1 - New Game");
                WriteLine("2 - Load Game");
                WriteLine("3 - Exit");
                Write("\noption: ");
                choice = ReadMainScreenChoice();
                HandleMainScreenChoice(choice);
            } while (choice != 3) ;
            
        }

        private static int ReadMainScreenChoice () {
            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);
            return choice;
        }

        private static void HandleMainScreenChoice (int choice) {
            switch (choice) {
                case 1:
                    NewGame();
                    Prologue();
                    WorldStats.dungeonDepth = 1;
                    GameLoop();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Util.WriteRed("Opção Inválida.");
                    ReadKey();
                    break;
            }
        }

        private static void NewGame () {
            string mainCharacterName;

            Clear();
            WriteLine("----- NEW GAME -----");
            Write("Main character name: ");
            mainCharacterName = ReadLine();

            WriteLine("\nChoose a class for your character: ");
            WriteLine("1 - Warrior");
            WriteLine("2 - Mage");
            WriteLine("3 - Rogue");
            WriteLine("4 - Ranger");
            Write("\nOption: ");
            int mainCharacterClassChoice = int.Parse(ReadLine());

            createChar(mainCharacterName, mainCharacterClassChoice);
        }

        public static void createChar(string mainCharacterName, int choice) {
            switch (choice) {
                case 1:
                    WorldStats.player = new Warrior(mainCharacterName, 1);
                    break;
                case 2:
                    WorldStats.player = new Mage(mainCharacterName, 1);
                    break;
                case 3:
                    WorldStats.player = new Rogue(mainCharacterName, 1);
                    break;
                case 4:
                    WorldStats.player = new Ranger(mainCharacterName, 1);
                    break;
                default:
                    WriteLine("Invalid choice");
                    break;
            }
        }

        private static void GameLoop () {
            Clear();
            int dungeonDepth = WorldStats.dungeonDepth;

            Hero player = WorldStats.player;
            List<Hero> party = new List<Hero>();
            party.Add(player);
            party.Add(WorldStats.hero2);
            party.Add(WorldStats.hero3);
            party.Add(WorldStats.hero4);

            while( WorldStats.player.GetHealth() > 0 ){
                switch(WorldStats.dungeonDepth){
                    case 1:
                        DungeonDepth1(party);
                        break;
                    default:
                        break;
                }

                Clear();

                ReadKey();
            }

            WriteLine("VOCÊ MORREU.");
        }
                

        private static void Prologue () {
            Clear();
            Util.WriteBlue($" > { WorldStats.player.GetName() } and the other party members are travelling in the woods, trying to reach the King's castle.");
            ReadKey();
            Util.WriteBlue($" > He called you to an Adventure.");
            ReadKey();
            Util.WriteBlue($" > As the party goes deeper in the woods, you realize the sun does not reach your eyes anymore, even though it's around noon.");
            ReadKey();
            Util.WriteBlue($" > Some fog starts to grow very dense and you can't see anything at all. You light a torch so you can see around 3 meters in front of you.");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero3, $" All this fog and darkness... Oh no... I think we are in the Fog Forest!");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero2, $"I'm too young to die!");
            ReadKey();
            Util.WriteBlue($" > You can hear some kind of monster moving around your party.");
            ReadKey();
            Util.WriteBlue($" > You turn yourself back, in the noise direction, but can't see anything.");
            ReadKey();
            Util.WriteBlue($" > Everybody gets theirs weapons ready.");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero4, $"What you're talking about? Why are we going to die?");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero3, $"The Fog Forest is some kind of entity that feeds of adventures. No adventurer ever survived the Fog Forest before. It's impossible to see the monsters and they are really strong. It's also impossible to scape, if you don't get killed by any monster, you're going to wander in the woods for the rest of your life.");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero2, "So that's it. We're done. That's why my family told me not to go out in adventures.");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero3, "Wait. There's one more thing. I heard once that it's possible to scape the forest if you destroy the entity that controls it. That's just a rumor though.");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero4, "That sounds like a plan. At least it's better than sit here and wait.");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero2, "I accepted my fate already. You should do it too.");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero3, $"Before the fog appeared I remember seeing a dungeon in our north direction. What do you say { WorldStats.player.GetName() }, should we enter the dungeon and look for the entity there?");
            ReadKey();
            Util.WriteHeroText(WorldStats.player, "...");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero2, "Common, you know he never talks, he just listens, and sometimes we know what he's thinking.");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero4, $"It looks like he wants to go. Hey { WorldStats.player.GetName() } do you think this is a good idea?");
            ReadKey();
            Util.WriteHeroText(WorldStats.player, "...");
            ReadKey();
            Util.WriteHeroText(WorldStats.hero3, "Well said. Let's go then.");
            ReadKey();
            Util.WriteBlue(" > As the party finish talking, you walk some meters towards what you think is the north direction.");
            ReadKey();
            Util.WriteBlue(" > You see a big and dark cavern entrance.");
            ReadKey();
            Util.WriteBlue(" > The party enters the cavern to seek the entity of the Fog Forest.");
            ReadKey();
        }

        private static void DungeonDepth1 (List<Hero> party) {
            List<Enemy> enemies = new List<Enemy>();
            DungeonDepth1InstantiateEnemies(enemies);

            Combat(enemies, party);
            ReadKey();
        }

        private static void DungeonDepth1InstantiateEnemies (List<Enemy> enemies) {
            for(int i = 0; i < 7; i++){
                enemies.Add(new Enemy(EnemyType.DARK_GOBLIN, 2));
            }
            for(int i = 0; i < 3; i++){
                enemies.Add(new Enemy(EnemyType.GHOST, 2));
            }
        }

        private static void Combat (List<Enemy> enemies, List<Hero> party) {
            Clear();
            bool turnoParty = true;

            foreach(Hero h in party){
                h.printCombatStats();
            }

            if(turnoParty == true){
                foreach(Hero h in party){
                    Clear();
                    WriteLine($"what will { h.GetName() } do?\n");
                    WriteLine("1 - Weak Attack");
                    WriteLine("2 - Strong Attack");
                    WriteLine("3 - Special Attack");
                    WriteLine("4 - Use Item");
                    Write("Option: ");

                    int actionChoice;
                    actionChoice = int.Parse(Console.ReadLine());

                    if(actionChoice == 4){
                        //TODO USE ITEM
                    }

                    Clear();

                    WriteLine($"What enemy will { h.GetName() } attack?");
                    int enemyIndex = 1 ;
                    foreach(Enemy e in enemies){
                        WriteLine($"{ enemyIndex } - {e.GetEnemyType()} [ALIVE - {e.IsAlive()}]");
                        enemyIndex++;
                    }
                    Write("Option: ");

                    int enemyChoice = int.Parse(Console.ReadLine());

                    switch(actionChoice){
                        case (int)AttackType.WEAK:
                            h.Attack(AttackType.WEAK, enemies[enemyChoice - 1]);
                            break;
                        case (int)AttackType.STRONG:
                            h.Attack(AttackType.STRONG, enemies[enemyChoice - 1]);
                            break;
                        case (int)AttackType.SPECIAL:
                            h.Attack(AttackType.SPECIAL, enemies[enemyChoice - 1]);
                            break;
                        default:
                            WriteLine("Invalid option");
                            break;
                    }
                    ReadKey();
                }
                turnoParty = !turnoParty; 
            }

            WriteLine();
        }

        private static void printPlayerStats (Hero player) {
            Write($"Player - { WorldStats.player }\n");
            Write($"Dungeon Depth - { WorldStats.dungeonDepth }\n");
        }

        private static void ExitGame () {
            Console.ResetColor();
        } 
    }
}
