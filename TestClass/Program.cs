using System;

namespace TestClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Personne p = new Personne("Nathan", 20);
            p.AfficherInformations(); 
        }

        public class Personne
        {
            //Attributs
            private string nom;
            private int age;

            // Constructeur
            public Personne(string nom, int age)
            {
                this.nom = nom;
                this.age = age;
            }

            //Méthode
            public void AfficherInformations()
            {
                Console.WriteLine($"Nom: {nom}, Age: {age}");
            }
        }
    }
}