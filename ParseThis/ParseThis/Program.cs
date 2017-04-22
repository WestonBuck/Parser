//weston buck
//4/21/17
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
            char[] delimiterChars = { ' ', ',', '\t' };
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
            List<string> ifList = new List<string>();
            List<string> condList = new List<string>();
            List<string> elseList = new List<string>();

            string assignmentString = "";
            Console.Clear();
            Console.WriteLine("begin.");
            for (int i = 0; i< Language.Count; i++)
            {
               // c = word[0];
                if (Language[i] == "begin")
                {
                    Begin();
                } 

                if (Language[i].Length == 1 && Char.IsLetter(Language[i][0]) == true)
                {
                    if (Language[i] != "" + ".")
                    {
                        assignmentString += Language[i];
                    }
                }

                else if (Language[i].Length == 1)
                {
                    assignmentString += Language[i];
                }

                else if (Language[i].Length == 2 && Language[i][1] == '.')
                {

                    assignmentString += Language[i][0];
                    assignmentString += Language[i][1];
                    if (assignmentString[1] == '=')
                    {
                        Assignment(assignmentString);
                        assignmentString = "";
                    }
                }

                if (Language[i] == "if")
                {
                    ifList.Add(Language[i]);
                    i++;
                    ifList.Add(Language[i]);
                    i++;
                    ifList.Add(Language[i]);
                    i++;
                    ifList.Add(Language[i][0].ToString());
                    ifList.Add(Language[i][1].ToString());
                    i++;

                    //if conditions
                    condList.Add(Language[i]); // begin
                    i++;
                    condList.Add(Language[i]);
                    i++;
                    condList.Add(Language[i]);
                    i++;
                    condList.Add(Language[i][0].ToString());
                    condList.Add(Language[i][1].ToString());
                    i++;
                    condList.Add(Language[i]);//end
                    i++;
                    elseList.Add(Language[i]); //else
                    i++;
                    elseList.Add(Language[i]); //begin.
                    i++;
                    elseList.Add(Language[i]); // e
                    i++;
                    elseList.Add(Language[i]); // =
                    i++;
                    elseList.Add(Language[i][0].ToString()); // a
                    elseList.Add(Language[i][1].ToString()); //.
                    i++;
                    elseList.Add(Language[i]); //end.
                    if_Statement(ifList, condList, elseList);
                }
                if (Language[i] == "end.")
                {
                    End();
                }

            }
        }
        static void Begin()
        {
            Console.WriteLine("+<Statement_List>");
            Console.WriteLine("+begin.");
        }

        static void End()
        {
            Console.WriteLine("+end.");
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

        static void if_Statement(List<string> assignmentString, List <string> condition, List<string> elseStatement)
        {
            Console.WriteLine("+<statement>");
            Console.WriteLine("|+<if_statement>");

            if (assignmentString.Count == 5)
            {
                Console.WriteLine("||+" + assignmentString[0]);
                Console.WriteLine("||+<condition>");
                Console.WriteLine("|||+<identifier>");
                Console.WriteLine("||||+" + assignmentString[1]);
                Console.WriteLine("|||+" + assignmentString[2]);
                Console.WriteLine("|||+<identifier>");
                Console.WriteLine("||||+" + assignmentString[3]);
                Console.WriteLine("||+" + assignmentString[4]);
            }
            Console.WriteLine("||+<statement_list>");
            Console.WriteLine("|||+begin.");
            Console.WriteLine("|||+<statement>");
            Console.WriteLine("||||+<assignment>");
            Console.WriteLine("|||||+<identifier>");
            Console.WriteLine("||||||+" + condition[1]);
            Console.WriteLine("|||||+" + condition[2]);
            Console.WriteLine("|||||+<expression>");
            Console.WriteLine("||||||+<identifier>");
            Console.WriteLine("|||||||+" + condition[3]);
            Console.WriteLine("|||||+" + condition[4]);
            Console.WriteLine("|||+end.");

            Console.WriteLine("||+" + elseStatement[0]);
            Console.WriteLine("|||+<statement_list>");
            Console.WriteLine("|||+" + elseStatement[1]);
            Console.WriteLine("|||+<statement>");
            Console.WriteLine("||||+<assignment>");
            Console.WriteLine("|||||+<identifier>");
            Console.WriteLine("||||||+" + elseStatement[2]);
            Console.WriteLine("|||||+" + elseStatement[3]);
            Console.WriteLine("||||||+<expression>");
            Console.WriteLine("|||||||+<identifier>");
            Console.WriteLine("||||||||+" + elseStatement[4]);
            Console.WriteLine("||||||+" + elseStatement[5]);
            Console.WriteLine("||||+" + elseStatement[6]);
        }
    }
}
