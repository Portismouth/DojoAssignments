using System;

namespace wizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard sam = new Wizard("Sam");
            Human stephen = new Human("Stephen");
            Ninja mitchell = new Ninja("Mitchell");
            Samurai evan = new Samurai("Evan");

            //Raid boss fight in terminal
            sam.fireball(stephen);
            Console.WriteLine("Boss Sam attacks {0}!, His Health drops to {1}. ", stephen.name, stephen.health);
            sam.fireball(mitchell);
            Console.WriteLine("Boss Sam attacks {0}!, His Health drops to {1}. ", mitchell.name, mitchell.health);
            sam.fireball(evan);
            Console.WriteLine("Boss Sam attacks {0}!, His Health drops to {1}. ", evan.name, evan.health);
            evan.meditate();
            Console.WriteLine("{0} heals and returns to full health: {1}", evan.name, evan.health);
            stephen.attack(sam);
            evan.death_blow(sam);
            Console.WriteLine("Evan uses Death Blow to defeat boss Sam. Her health is {0}", sam.health);
            int all_samurai = evan.get_samurai();
            Console.WriteLine("{0} samurai still standing", all_samurai);
        }
    }
}
