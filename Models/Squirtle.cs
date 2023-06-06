using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Models
{
    [Serializable]
    public class Squirtle : Pokemon
    {
        public override void Evolve()
        {
            CurrentTransformation = "Wartortle";
            Powers.Add("Water Gun");
            Powers.Add("Bite");
        }
    }
}
