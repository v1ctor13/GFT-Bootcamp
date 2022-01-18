using System;

namespace RPG {
    public abstract class Hero : IHeroActions {
        private string name;
        private int health;
        private int level;

        public void UseItem (Item item) {
            switch (item) {
                case Item.HEALTH_POTION:
                    //TODO
                    break;
                case Item.MANA_POTION:
                    //TODO
                    break;
                case Item.STAMINA_POTION:
                    //TODO
                    break;
                default:
                    break;
            }
        }

        public virtual void Attack (AttackType attackType, Enemy enemy){}

        public virtual void printCombatStats () {}

        /* ↓ ----- Getters and Setters ----- ↓ */

        public int GetLevel () {
            return this.level;
        }

        public void SetLevel (int value) {
            this.level = value;
        }

        public string GetName () {
            return this.name;
        }

        public void SetName (string value) {
            this.name = value;
        }

        public int GetHealth () {
            return this.health;    
        }

        public void SetHealth (int value) {
            this.health = value;
        }

    }
}