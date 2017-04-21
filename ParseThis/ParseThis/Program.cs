using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseThis
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempList;
            List<string> Language = new List<string>();
            char[] delimiterChars = { ' ', ',', ':', '\t' };
            Console.WriteLine("Please enter your language to be parsed:");
            tempList = Console.ReadLine();
            string[] words = tempList.Split(delimiterChars);

            Console.WriteLine("done");

            //remove whitespaces to get only instructions amd put that into a list.
            foreach (string word in words)
            {
                int i = 0;
                Console.WriteLine(word);
                if (word != "")
                {
                    Language.Add(word);
                }
                i++;
            }

            Parser(Language);
            
        }

        static void Parser (List<string> Language)
        {
            int depth = 0;
            string assignmentString = "";
            char c;
            foreach (string word in Language)
            {
                c = word[0];
                if (word.Length == 1 && Char.IsLetter(word[0]) == true )
                {
                    int i = 0;
                    while (word != ".")
                    {

                        assignmentString += word[i];
                        i++;
                    }
                }
            }
        }
        void Begin()
        {
            Console.WriteLine("+<Statement_List>");
            Console.WriteLine("+begin.");
        }

        void Identifier ()
        {
            Console.WriteLine("+<Identifier>");
        }

        void Assignment ()
        {
            Console.WriteLine("+<Assignment>");
        }
        void Statement ()
        {
            Console.WriteLine("+<statement>");
        }

        void End ()
        {
            Console.WriteLine("+end.");
        }
    }
}
