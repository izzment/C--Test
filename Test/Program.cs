using System.Globalization;
using System.Text.RegularExpressions;


DateTime result;
const string filename = "user_info.txt";
int age = 0;


// Prompt the user to input their name and birthday
Console.WriteLine("Welcome to the test.");
Console.WriteLine("What is your name?");
string username = Console.ReadLine();

Console.WriteLine("When were you born? (mm/dd/yy)?");
string birthday = Console.ReadLine();

// Validate the birthdate format using a regular expression (mm/dd/yy)
Regex Birthdate = new Regex(@"\d{1,2}\/\d{1,2}\/\d{2,4}");

if (Birthdate.IsMatch(birthday)){
// Calculate and display the user's age based on the birthdate
    if (DateTime.TryParse(birthday, out result)){
        DateTime now = DateTime.Now;
        TimeSpan interval = now - result;
        age = (int)interval.TotalDays/365;
        Console.WriteLine($"You are {age} years old.");
// Save the user's information to a file named "user_info.txt"
        using (StreamWriter sw = File.CreateText(filename)){
            sw.WriteLine($"Username: {username}");
            sw.WriteLine($"Age: {age} years");
        }

// Read and display the contents of the "user_info.txt" file
        string content;
        content = File.ReadAllText(filename);
        Console.WriteLine(content);
    }

// Prompt the user to enter a directory path
    Console.WriteLine("Please enter a directory path:");
    string dirname = Console.ReadLine();

// List all files within the specified directory
    if(Directory.Exists(dirname)){
        List<string> thefiles = new List<string>(Directory.EnumerateFiles(dirname));
        foreach(string dir in thefiles){
            Console.WriteLine(dir);
        }
    } else{
        Console.WriteLine("Could not find directory.");
    }
// Prompt the user to input a string
Console.WriteLine("Please input a string.");
string str = Console.ReadLine();

// Format the string to title case
string capString = str.ToUpper();
Console.WriteLine(capString);

// Explicitly trigger garbage collection
GC.Collect();
}




