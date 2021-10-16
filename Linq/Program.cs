using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {

            Species tigreBlanc = new Species("Tigre blanc");
            Species cougarBlanc = new Species("Cougar blanc");
            Species tortueAlbinos = new Species("Tortue albinos");


            List<Animal> listeEspecesProtegees = new List<Animal> { };
            ListeEspeceBuilder.FillList(listeEspecesProtegees, tortueAlbinos, 15);
            ListeEspeceBuilder.FillList(listeEspecesProtegees, tigreBlanc, 100);
            ListeEspeceBuilder.FillList(listeEspecesProtegees, cougarBlanc, 3);

            //AffichageListe(listeEspecesProtegees);

            Console.WriteLine($"Nombre d'espèces à protéger : {listeEspecesProtegees.Count}" );
            Console.WriteLine("________________________________________________________");

            IEnumerable<Animal> listeTiigreBlanc = listeEspecesProtegees.Where((s) => s.Species.NomDeEspece == "Tigre blanc");
            Console.WriteLine($"Nombre de tigres blancs à protéger : {listeTiigreBlanc.ToList().Count}");

            //AffichageListe(listeTiigreBlanc.ToList());
            Console.WriteLine("________________________________________________________");
            
            IEnumerable<Animal> listeTortueAlbinos = listeEspecesProtegees.Where(s => s.Species == tortueAlbinos);
            Console.WriteLine($"Nombre de tortues albinos à protéger : {listeTortueAlbinos.ToList().Count}");

            //AffichageListe(listeTortueAlbinos.ToList());
            Console.WriteLine("________________________________________________________");

            IEnumerable<Animal> listeCougarBlanc = from animal in listeEspecesProtegees
                                                   where animal.Species.NomDeEspece == "Cougar blanc"
                                                   select animal;
            Console.WriteLine($"Nombre de cougars blancs à protéger : {listeCougarBlanc.ToList().Count}");

            // AffichageListe(listeCougarBlanc.ToList());
            Console.WriteLine("________________________________________________________");




            Console.ReadLine();


        }

        private static void AffichageListe(List<Animal> listeEspecesProtegees)
        {
            foreach (Animal animal in listeEspecesProtegees)
            {
                Console.WriteLine($"ID :  Espece : ");
                Console.WriteLine($"{animal.Id}  {animal.Species.NomDeEspece}");
            }
        }
    }

    class Animal
    {
        public Species Species { get; set; }
        public int Id { get; set; }

        public Animal(int id,  Species species)
        {
            Id = id;
            this.Species = species;
        }
    }

    class ListeEspeceBuilder
    {
        public static int idAnimal = 0;

        public static void FillList(List<Animal> listeAnimaux, Species espece, int nombreAnimauxParEspece)
        {
            for (int i = 1; i < nombreAnimauxParEspece + 1; i++)
            {
                idAnimal++;
                listeAnimaux.Add(new Animal(idAnimal, espece));
            }
        }
    }

    class Species
    {
        public string NomDeEspece;
        public Species (string nomDeEspece)
        {
            NomDeEspece = nomDeEspece; 
        }
    }



}
