using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Models
{
    [Serializable]
    public class Charmander : Pokemon
    {
        public override void Evolve()
        {
            CurrentTransformation = "Charmeleon";
            Powers.Add("Ember");
            Powers.Add("Scratch");
        }
    }
}
