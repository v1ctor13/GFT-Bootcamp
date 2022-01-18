using System.Collections.Generic;

namespace RPG {

    public static class WorldStats {
        
        public static Hero player;
        public static Hero hero2 = new Warrior("Carlos", 1);
        public static Hero hero3 = new Mage("Wagner", 1);
        public static Hero hero4 = new Rogue("Ruth", 1);

        public static List<Hero> party;

        public static int dungeonDepth;

    }

}