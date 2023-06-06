using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Models

{
    [Serializable]
    public class Pichu : Pokemon
    {
        public override void Evolve()
        {
            CurrentTransformation = "Pikachu";
            Powers.Add("Thunder Shock");
            Powers.Add("Quick Attack");
        }
    }
}

