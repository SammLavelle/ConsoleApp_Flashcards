using ConsoleApp_Flashcards;
using Microsoft.Data.Sqlite;


DbOperations.CreateTables();

bool closeApp = false;
while(closeApp == false) {
    Console.WriteLine("----- MENU -----\n");
    Console.WriteLine("Please select an option from below.\n");
    Console.WriteLine(@"1 - Study.
2 - Edit stacks.
0 - Close.");

    string userInput = Console.ReadLine().Trim();
    switch (userInput)
    {
        case "0":
            Console.WriteLine("\nGoodbye");
            closeApp = true;
            Environment.Exit(0);
            break;

        case "2":
            Console.WriteLine("Select a stack to edit by typing it's ID, or press 'a' to create a new stack.\n");
            DbOperations.ListStacks();
            string stackSelected = Console.ReadLine().Trim().ToLower();
            switch (stackSelected)
            {
                case "a":
                    Console.WriteLine("What would you like to call oyur new stack?\n");
                    string stackName = Console.ReadLine();
                    DbOperations.AddStack(stackName);

                    break;
            }
            break;

    }
}

