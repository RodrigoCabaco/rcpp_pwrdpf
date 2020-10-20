using System;
using TextToAsciiArt;
using System.Collections.Generic;
using System.IO;
namespace rcpp
{
    class Program
    {
        /*
                      _____                                    _ _____            __ _ _           
                     |  __ \                                  | |  __ \          / _(_) |          
             _ __ ___| |__) |_ _ ___ _____      _____  _ __ __| | |__) | __ ___ | |_ _| | ___ _ __ 
            | '__/ __|  ___/ _` / __/ __\ \ /\ / / _ \| '__/ _` |  ___/ '__/ _ \|  _| | |/ _ \ '__|
            | | | (__| |  | (_| \__ \__ \\ V  V / (_) | | | (_| | |   | | | (_) | | | | |  __/ |   
            |_|  \___|_|   \__,_|___/___/ \_/\_/ \___/|_|  \__,_|_|   |_|  \___/|_| |_|_|\___|_|   
                                                                                                    
                                                                                        

             _     _   _                   ____   _ _   _           _                             _______           _      _              _____      _                     
            | |   | | | |            _    / / /  (_) | | |         | |                           / /  __ \         | |    (_)            / ____|    | |                    
            | |__ | |_| |_ _ __  ___(_)  / / /_ _ _| |_| |__  _   _| |__   ___ ___  _ __ ___    / /| |__) |___   __| |_ __ _  __ _  ___ | |     __ _| |__   __ _  ___ ___  
            | '_ \| __| __| '_ \/ __|   / / / _` | | __| '_ \| | | | '_ \ / __/ _ \| '_ ` _ \  / / |  _  // _ \ / _` | '__| |/ _` |/ _ \| |    / _` | '_ \ / _` |/ __/ _ \ 
            | | | | |_| |_| |_) \__ \_ / / / (_| | | |_| | | | |_| | |_) | (_| (_) | | | | | |/ /  | | \ \ (_) | (_| | |  | | (_| | (_) | |___| (_| | |_) | (_| | (_| (_) |
            |_| |_|\__|\__| .__/|___(_)_/_/ \__, |_|\__|_| |_|\__,_|_.__(_)___\___/|_| |_| |_/_/   |_|  \_\___/ \__,_|_|  |_|\__, |\___/ \_____\__,_|_.__/ \__,_|\___\___/ 
                        | |                __/ |                                                                            __/ |                                        
                        |_|               |___/                                                                            |___/                                         
        */
        static void Main(string[] args)
        {   
            Console.ForegroundColor = ConsoleColor.White;
            TextToAsciiArt.ArtWriter ascii= new ArtWriter();
            List<string> passwordList = new List<string>();
            List<string> initialList = new List<string>();
            Console.ForegroundColor = ConsoleColor.Blue;
            ascii.WriteConsole("rcpp");
            Console.ForegroundColor = ConsoleColor.White;
            string firstName;
            string lastName;
            string yearOfBirth;
            string username;
            Console.Write("\n");

          if(args.Length<1)
          {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("FATAL: No Arguments\nPlease select a mode / argument\nUse rcpp -h for a help menu");
              Console.ForegroundColor = ConsoleColor.White;
          }else
          {
            foreach(var argument in args){
                if(argument=="-h"){
                    ShowHelp();
                }
                if(argument=="-i"){
                    InterfaceDisplay();
                }
            }
          }
        void InterfaceDisplay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            ascii.WriteConsole("rcpp");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
            Console.Write("First Name > ");  
            firstName = Console.ReadLine();
            initialList.Add(firstName);
            Console.Write("Last Name > ");
            lastName = Console.ReadLine();
            initialList.Add(lastName); 
            Console.Write("User/Nickname > ");
            username = Console.ReadLine();
            initialList.Add(username);
            Console.Write("Year of Birth (Optional) > ");
            yearOfBirth = Console.ReadLine();
            initialList.Add(yearOfBirth);
            Console.Write("Additional Words (Optional) [Separated by ,] > ");
                foreach(var x in Console.ReadLine().Split(','))
                {
                    initialList.Add(x);
                } 

            Console.WriteLine("\nPress enter to generate wordlist...");
            Console.ReadLine();
            GenerateWorldList();
        }
        void ShowHelp()
        {
            Console.WriteLine("Arguments:");
            Console.WriteLine("    -h (show this menu)\n    -i (interface for profiling)");
        }
        void GenerateWorldList()
        {
            StreamWriter generateList = File.CreateText(firstName+"_"+lastName+".txt");
            generateList.Close();
            foreach(var f in initialList){
                foreach(var l in initialList){
                    generateList = File.AppendText(firstName+"_"+lastName+".txt");
                    passwordList.Add(f+l);
                    passwordList.Add(f+"_"+l);
                    passwordList.Add(f+"_"+l+"_"); 
                    passwordList.Add(f+l+"_");
                    passwordList.Add(f);
                    passwordList.Add(l);
                    int counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    generateList.Close();
                    for(int i = 0;i<100;i++)
                    {
                    generateList = File.AppendText(firstName+"_"+lastName+".txt");
                    passwordList.Add(f+l+i);
                    passwordList.Add(f+"_"+l+i);
                    passwordList.Add(f+"_"+l+"_"+i); 
                    passwordList.Add(f+l+"_"+i);      
                    passwordList.Add(f+"_"+i);
                    passwordList.Add(l+i);
                    passwordList.Add(f+i);
                    passwordList.Add(l+"_"+i);       
                    passwordList.Add(firstName+"_"+i);
                    passwordList.Add(lastName+"_"+i);
                    counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    generateList.Close();    
                    }
                  /*  for(int j = 0;j<80;j++)
                    {
                    int i = j + 1960;
                    passwordList.Add(f+l+i);
                    passwordList.Add(f+"_"+l+i);
                    passwordList.Add(f+"_"+l+"_"+i); 
                    passwordList.Add(f+l+"_"+i);      
                    passwordList.Add(f+"_"+i);
                    passwordList.Add(l+i);
                    passwordList.Add(f+i);
                    passwordList.Add(l+"_"+i);       
                    passwordList.Add(firstName+"_"+i);
                    passwordList.Add(lastName+"_"+i);
                    passwordList.Add(firstName+lastName+"_"+i);       
                    }
                    int counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    generateList.Close();

                }*/
            }

        }
                passwordList.Add(lastName+firstName+yearOfBirth);
            
                passwordList.Add(lastName+firstName+yearOfBirth+"?");
            
                passwordList.Add(lastName+"_"+firstName+yearOfBirth);
            
                passwordList.Add(firstName+"_"+lastName+yearOfBirth);
            
                passwordList.Add(firstName+lastName+yearOfBirth);
            
                passwordList.Add(firstName+username+yearOfBirth+"_");
            
                passwordList.Add(username+"_"+firstName+yearOfBirth);
            
                passwordList.Add(username+yearOfBirth+"?");
            
                passwordList.Add(lastName+username+"_"+yearOfBirth);

                passwordList.Add(username+"_"+yearOfBirth);
                
                passwordList.Add(username+"_"+yearOfBirth+"?");
    }
  }
 }
}
