namespace RPG {

    public class Enemy {
        private int health;
        private int level;
        private int physicalDefense;
        private int magicDefense;
        private bool alive;
        private EnemyType enemyType;

        public Enemy (EnemyType enemyType, int level) {
            this.level = level;
            this.alive = true;

            switch (enemyType) {
                case EnemyType.GHOST:
                    this.health = (10 * level) / 2;
                    this.physicalDefense = 10000;
                    this.magicDefense = (150 * level) / 2;
                    this.enemyType = enemyType;
                    break;
                case EnemyType.DARK_GOBLIN:
                    this.health = (20 * level) / 2;
                    this.physicalDefense = (60 * level) / 2;
                    this.magicDefense = (50 * level) / 2;
                    this.enemyType = enemyType;
                    break;
                case EnemyType.DARK_MAGE:
                    this.health = (30 * level) / 2;
                    this.physicalDefense = (20 * level) / 2;
                    this.magicDefense = (350 * level) / 2;
                    this.enemyType = enemyType;
                    break;
                case EnemyType.DARK_RANGER:
                    this.health = (40 * level) / 2;
                    this.physicalDefense = (30 * level) / 2;
                    this.magicDefense = (10 * level) / 2;
                    this.enemyType = enemyType;
                    break;
            }
        }

        // Returns back the amount of attack Base Points
        public int Attack(AttackType attack) {
            return 0;
        }

        public bool IsAlive () {
            return this.alive;
        }

        public void Kill () {
            this.alive = false;
        }

        /* ↓ ----- Getters and Setters ----- ↓ */

        public int GetLevel () {
            return this.level;
        }

        public void SetLevel (int value) {
            this.level = value;
        }

        public int GetHealth () {
            return this.health;    
        }

        public void SetHealth (int value) {
            this.health = value;
        }

        public string GetEnemyType () {
            return this.enemyType.ToString();
        }

    }

}