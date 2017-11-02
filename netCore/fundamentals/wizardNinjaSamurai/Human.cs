using System;

namespace wizardNinjaSamurai{
    public class Human
    {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj)
        {
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health -= strength * 5;
            }
        }
    }

    public class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            intelligence = 25;
            health = 50;
        }
        public void heal()
        {
            health = this.health;
            health += 10 * this.intelligence;
        }
        public void fireball(object obj)
        {
            Random r = new Random();
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health -= r.Next(20,50);
            }
        }
    }

    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            dexterity = 175;
        }
        public void steal(object obj)
        {
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health -= 5;
                this.health += 10;
            }
        }
        public void get_away()
        {
            this.health -= 15;
        }
    }

    public class Samurai : Human
    {
        private static int instances = 0;
        
        public Samurai(string name) : base(name)
        {
            health = 200;
            instances++;
        }
        public void death_blow(object obj)
        {
            Human enemy = obj as Human;
            if ( enemy.health < 50 )
            {
                enemy.health = 0;
            }
            else
            {
                Console.WriteLine("Failed Attack");
            }
        }
        public void meditate()
        {
            this.health = 200;
        }
        public int get_samurai()
        {
            return instances;
        }
    }

}