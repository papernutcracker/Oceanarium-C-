using System;
using System.Collections.Generic;

namespace OceanariumProject
{
    public class Oceanarium
    {
        private List<MarineCreature> _inhabitants;

        public Oceanarium()
        {
            _inhabitants = new List<MarineCreature>();
        }
        public void AddCreature(MarineCreature creature)
        {
            _inhabitants.Add(creature);
            Console.WriteLine($"\nSUCCESS: {creature.Name} has been added to the Oceanarium!");
        }
        public void ShowAllInhabitants()
        {
            Console.WriteLine("\n=== Oceanarium Inhabitants ===");
            if (_inhabitants.Count == 0)
            {
                Console.WriteLine("The Oceanarium is currently empty.");
                return;
            }

            foreach (var creature in _inhabitants)
            {
                creature.DisplayInfo();
            }
            Console.WriteLine("==============================\n");
        }
    }
}
