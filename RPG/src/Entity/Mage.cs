using System;

namespace RPG {

    public class Mage : Hero {
        private int modificator;
        private int mana;

        private int physicalDefense;
        private int physicalAttack;
        private int magicAttack;
        private int magicDefense;

        private HeroClass heroClass = HeroClass.MAGE;

        public Mage(string name, int level) {
            this.SetName(name);
            this.SetLevel(level);

            this.modificator = 4;
            this.SetHealth((125 * this.GetLevel()) / 2);
            this.mana = 200;
            this.modificator = 3;
            this.physicalDefense = (10 * this.GetLevel() * this.modificator) / 2;
            this.physicalAttack = (10 * this.GetLevel() * this.modificator) / 2;
            this.magicDefense = (200 * this.GetLevel() * this.modificator) / 2;
            this.magicAttack = (150 * this.GetLevel() * this.modificator) / 2;
        }

        public override void Attack(AttackType attack, Enemy enemy) {
            Random dice = new Random();
            int attackChanceToHit = dice.Next(1,7);

            if(attackChanceToHit < 6){
                switch(attack) {
                    case AttackType.WEAK:
                        enemy.SetHealth(enemy.GetHealth() - this.magicAttack / 2);
                        if(enemy.GetHealth() <= 0){
                            Util.WriteRed($"Hit enemy by {this.magicAttack / 2}");
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
            Console.Write($"{this.GetName() } -> [HP - { this.GetHealth() }]     [MANA - { this.mana }]     [CLASS: { this.heroClass }]\n\n\n");
        }

        /* ↓ ----- Getters and Setters ----- ↓ */
        public override string ToString () {
            return $"Name: {this.GetName()}, Level: {this.GetLevel()}, Class: {this.heroClass}";
        }

        public int GetMana () {
            return this.mana;    
        }

        public void SetMana (int value) {
            this.mana = value;
        }
    }

}