using System;

namespace RPG {

    public class Ranger : Hero{
        private int modificator;
        private int stamina;

        private int physicalDefense;
        private int physicalAttack;
        private int magicDefense;

        private HeroClass heroClass = HeroClass.RANGER;

        public Ranger(string name, int level) {
            this.SetName(name);
            this.SetLevel(level);

            this.modificator = 3;
            this.stamina = 400;
            this.SetHealth((300 * this.GetLevel()) / 2);
            this.physicalDefense = (50 * this.GetLevel() * this.modificator) / 2;
            this.physicalAttack = (175 * this.GetLevel() * this.modificator) / 2;
            this.magicDefense = (200 * this.GetLevel() * this.modificator) / 2;
        }

        public override void Attack(AttackType attack, Enemy enemy) {
            Random dice = new Random();
            int attackChanceToHit = dice.Next(1,7);

            if(attackChanceToHit < 6){
                switch(attack) {
                    case AttackType.WEAK:
                        enemy.SetHealth(enemy.GetHealth() - this.physicalAttack / 2);
                        if(enemy.GetHealth() <= 0){
                            Util.WriteRed("Killed");
                            enemy.Kill();
                        }
                        break;
                }
            }
            else{
                Util.WriteRed("Missed!");
            }
        }

        public override void printCombatStats () {
            Console.Write($"{this.GetName() } -> [HP - { this.GetHealth() }]     [STAMINA - { this.stamina }]     [CLASS: { this.heroClass }]\n\n\n");
        }

        /* ↓ ----- Getters and Setters ----- ↓ */
        public override string ToString () {
            return $"Name: {this.GetName()}, Level: {this.GetLevel()}, Class: {this.heroClass}";
        }

        public int GetStamina () {
            return this.stamina;    
        }

        public void SetStamina (int value) {
            this.stamina = value;
        }
    
    }
}