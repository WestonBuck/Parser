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
            //for (int i = 0; i<)

            Parser(Language);
            
        }

        static void Parser (List<string> Language)
        {
            int depth = 0; int incrementer = 0;
            string assignmentString = "";
            char c;
            foreach (string word in Language)
            {
                c = word[0];
                if (word.Length == 1 && Char.IsLetter(word[0]) == true )
                {
                    int i = 0;
                    if (word != "" + ".")
                    {
                        assignmentString += word;
                    }
                    //else
                    //{
                    //    assignmentString += word[0];
                    //    assignmentString += word[1];
                    //}
                    //while (word != "" + ".")
                    //{

                    //    assignmentString += word;
                    //    i++;
                    //}
                }
                else if (word.Length == 1)
                {
                    assignmentString += word;
                }
                else if (word.Length == 2)
                {
                    assignmentString += word[0];
                    assignmentString += word[1];
                    if (assignmentString[1] == '=')
                    {
                        Assignment(assignmentString);
                    }
                }
            }
        }
        static void Begin(int depth)
        {
            for (int i = 0; i<depth; i++)
            {
                Console.WriteLine("|");
            }
            Console.WriteLine("+<Statement_List>");
            Console.WriteLine("+begin.");
        }

        static void Identifier (int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.WriteLine("|");
            }
            Console.WriteLine("+<Identifier>");
        }

        //does assignments and expressions.
        static void Assignment (string assignmentString)
        {
            
            Console.WriteLine("+<statement>");
            Console.WriteLine("|+<assignment>");
            Console.WriteLine("||+<identifier>");
            if(assignmentString.Length == 6)
            {
                Console.WriteLine("|||+" + assignmentString[0]);
                Console.WriteLine("||+" + assignmentString[1]);
                Console.WriteLine("||+<expression>");
                Console.WriteLine("|||+<identifier>");
                Console.WriteLine("||||+" + assignmentString[2]);
                Console.WriteLine("|||+" + assignmentString[3]);
                Console.WriteLine("|||+<identifier>");
                Console.WriteLine("||||+" + assignmentString[4]);
                Console.WriteLine("||+" + assignmentString[5]);
            }
            else if (assignmentString.Length == 4)
            {
                Console.WriteLine("|||+" + assignmentString[0]);
                Console.WriteLine("||+" + assignmentString[1]);
                Console.WriteLine("||+<expression>");
                Console.WriteLine("|||+<number>");
                Console.WriteLine("||||+" + assignmentString[2]);
                Console.WriteLine("||+" + assignmentString[3]);
            }
            
        }
        static void Statement (int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.WriteLine("|");
            }
            Console.WriteLine("+<statement>");
        }

        static void End (int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.WriteLine("|");
            }
            Console.WriteLine("+end.");
        }
    }
}
