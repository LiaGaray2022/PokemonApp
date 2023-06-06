using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PokemonApp.Models;
using Xamarin.Forms;

namespace PokemonApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Pokemon> Pokemons { get; set; } = new ObservableCollection<Pokemon>();
        public string Name { get; set; }
        public DateTime Birthdate { get; set; } = DateTime.Now;
        public string CurrentTransformation { get; set; }
        public string Power { get; set; }

        public Command CreatePichuCommand { get; }
        public Command CreateCharmanderCommand { get; }
        public Command CreateSquirtleCommand { get; }
        public Command EvolveCommand { get; }

        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "pokemons.bin");

        public MainPageViewModel()
        {
            LoadPokemons();

            CreatePichuCommand = new Command(CreatePichu);
            CreateCharmanderCommand = new Command(CreateCharmander);
            CreateSquirtleCommand = new Command(CreateSquirtle);
            EvolveCommand = new Command<EvolutionItem>(EvolvePokemon);
        }

        private void CreatePichu()
        {
            Pichu pichu = new Pichu
            {
                Name = Name,
                Birthdate = Birthdate,
                CurrentTransformation = CurrentTransformation
            };

            pichu.Powers.Add(Power);
            Pokemons.Add(pichu);

            SavePokemons();

            Name = string.Empty;
            Birthdate = DateTime.Now;
            CurrentTransformation = string.Empty;
            Power = string.Empty;
        }

        private void CreateCharmander()
        {
            Charmander charmander = new Charmander
            {
                Name = Name,
                Birthdate = Birthdate,
                CurrentTransformation = CurrentTransformation
            };

            charmander.Powers.Add(Power);
            Pokemons.Add(charmander);

            SavePokemons();

            Name = string.Empty;
            Birthdate = DateTime.Now;
            CurrentTransformation = string.Empty;
            Power = string.Empty;
        }

        private void CreateSquirtle()
        {
            Squirtle squirtle = new Squirtle
            {
                Name = Name,
                Birthdate = Birthdate,
                CurrentTransformation = CurrentTransformation
            };

            squirtle.Powers.Add(Power);
            Pokemons.Add(squirtle);

            SavePokemons();

            Name = string.Empty;
            Birthdate = DateTime.Now;
            CurrentTransformation = string.Empty;
            Power = string.Empty;
        }

        private void EvolvePokemon(EvolutionItem evolutionItem)
        {
            if (evolutionItem.Pokemon is Pokemon pokemon)
            {
                pokemon.Evolve();
                SavePokemons();
            }
        }

        private void SavePokemons()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = File.Create(filePath))
            {
                formatter.Serialize(fileStream, Pokemons);
            }
        }

        private void LoadPokemons()
        {
            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    Pokemons = (ObservableCollection<Pokemon>)formatter.Deserialize(fileStream);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class EvolutionItem
    {
        public Pokemon Pokemon { get; set; }
        public string DisplayName { get; set; }
    }
}
