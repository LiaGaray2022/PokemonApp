using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Models

{
    [Serializable]
    public class Pokemon
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string CurrentTransformation { get; set; }
        public List<string> Powers { get; } = new List<string>();

        public virtual void Evolve()
        {
            // Implementar la lógica para evolucionar el Pokémon
        }

        public override string ToString()
        {
            return $"Name: {Name} - Birthdate: {Birthdate.ToShortDateString()} - Current Transformation: {CurrentTransformation}";
        }
    }
}
