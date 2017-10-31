namespace human
{
    public class Human
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Health { get; set; }

        //Initializing human object
        public Human(string name, int strength = 3, int intelligence = 3, int dexterity = 3, int health = 100)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }

        //Allow attributes to be changed of human objects
        public void setAttributes(string name, int strength, int intelligence, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }

        //Attack function, takes in ANY kind of object and makes sure you can only attack other humans
        public string attack(object npc, int damage)
        {
            if (npc is Human)
            {
                Human player = (Human)npc;
                damage = damage * 5;
                player.Health -= damage;
                return $"{player.Name} took {damage} damage!";

            }
            else
            {
                return "You cannot attack attack non-human players";
            }
                    
        }

    }
}