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
            int counter = 0;
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
            foreach(var f in initialList){
                foreach(var l in initialList){
                    if(f!=l){
                    if(passwordList.Contains(f+l) == false){
                    passwordList.Add(f+l);
                     counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    }
                    if(passwordList.Contains(f+"_"+l) == false){
                    passwordList.Add(f+"_"+l);
                     counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    }
                    if(passwordList.Contains(f+"_"+l+"_") == false){
                    passwordList.Add(f+"_"+l+"_"); 
                     counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    }
                    if(passwordList.Contains(f+l+"_") == false){
                    passwordList.Add(f+l+"_");
                     counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    }
                    if(passwordList.Contains(f) == false){
                    passwordList.Add(f);
                     counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    }
                    for(int i = 0;i<100;i++)
                    {
                        if(passwordList.Contains(f+l+i) == false){
                    passwordList.Add(f+l+i);
                     counter = passwordList.Count;
                      counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                        }
                        if(passwordList.Contains(f+"_"+l+i) == false){
                    passwordList.Add(f+"_"+l+i);
                    counter = passwordList.Count;
                      counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                        }
                        if(passwordList.Contains(f+"_"+l+"_"+i) == false){
                    passwordList.Add(f+"_"+l+"_"+i);
                    counter = passwordList.Count; 
                      counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                        }
                    if(passwordList.Contains(f+l+"_"+i) == false){
                    passwordList.Add(f+l+"_"+i); 
                    counter = passwordList.Count;     
                      counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    }
                    if(passwordList.Contains(f+"_"+l) == false){
                    passwordList.Add(f+"_"+i);
                    counter = passwordList.Count;
                      counter--;
                    }
                    if(passwordList.Contains(f+i) == false){
                    passwordList.Add(f+i);
                      counter = passwordList.Count;
                      counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    }
                  
                    }
                    }
    
            }

        }

                    for(int i=0;i<100;i++){
                     passwordList.Add(firstName+"_"+i);
                     counter = passwordList.Count;
                      counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    passwordList.Add(lastName+"_"+i);
                    counter = passwordList.Count;
                      counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    passwordList.Add(firstName+lastName+"_"+i);   
                    counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                    }
                passwordList.Add(lastName+firstName+yearOfBirth);
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
            
                passwordList.Add(lastName+firstName+yearOfBirth+"?");
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
            
                passwordList.Add(lastName+"_"+firstName+yearOfBirth);
             counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                passwordList.Add(firstName+"_"+lastName+yearOfBirth);
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
            
                passwordList.Add(firstName+lastName+yearOfBirth);
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
            
                passwordList.Add(firstName+username+yearOfBirth+"_");
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
            
                passwordList.Add(username+"_"+firstName+yearOfBirth);
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
            
                passwordList.Add(username+yearOfBirth+"?");
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
            
                passwordList.Add(lastName+username+"_"+yearOfBirth);
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);

                passwordList.Add(username+"_"+yearOfBirth);
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);
                
                passwordList.Add(username+"_"+yearOfBirth+"?");
                 counter = passwordList.Count;
                    counter--;
                    Console.WriteLine("Generating: "+passwordList[counter] +" ("+counter+")");
                    generateList.WriteLine(passwordList[counter]);

    }
  }
 }
}
