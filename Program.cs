using System;
using System.Globalization;

namespace W5P4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MovieList> list = new List<MovieList>();

            bool chainController = true;

            TextInfo textInfo = new CultureInfo("tr-TR", false).TextInfo;

            while (chainController)
            {
                Console.WriteLine("İstediğiniz bir filmi girip ona puan verebilirsiniz(bitirmek için bitir diyebilirsiniz): \n Film?");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "bitir")
                {
                    chainController = false;
                    continue;
                }

                string autoMovieName = textInfo.ToTitleCase(userInput.ToLower());

                Console.WriteLine("Puanı? (noktalı şekilde verebilirsiniz)");
                double userScoreInput;

                bool isValidValue = double.TryParse(Console.ReadLine(), out userScoreInput);

                if (isValidValue && userScoreInput >= 0 && userScoreInput <= 10)
                {
                    list.Add(new MovieList
                    {
                        MovieName = autoMovieName,
                        MovieScore = userScoreInput,
                    }
                    );
                    Console.WriteLine("Film başarıyla eklendi!");
                }
                else
                {
                    Console.WriteLine("Geçersiz bir puan girdiniz 0-10 arası olsun lütfen");
                }
            }

            Console.WriteLine("Girilen filmler: ");

            var movieFilter = list.Where(movie => movie.MovieScore >= 4.0 && movie.MovieScore <= 9.0);

            foreach (MovieList item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("4-9 arası filmleriniz: ");

            foreach (MovieList item in movieFilter)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("A ile başlayan filmleriniz");
            var movieFilterTwo = list.Where(movie => movie.MovieName.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            foreach (var varMovie in movieFilterTwo)
            {
                Console.WriteLine(varMovie.ToString());
            }
        }
    }
}