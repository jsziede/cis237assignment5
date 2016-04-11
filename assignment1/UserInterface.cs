//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 7;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the wine program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            //ID =====================
            Console.WriteLine();
            Console.WriteLine("What is the new item's Id?");
            Console.Write("> ");
            string id = Console.ReadLine();

            //Description =====================
            Console.WriteLine("What is the new item's Description?");
            Console.Write("> ");
            string description = Console.ReadLine();

            //Pack =====================
            Console.WriteLine("What is the new item's Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();

            //Price =====================
            bool isDecimal = false;     //bool to be used for the while loop
            string price = null; 
            while (isDecimal == false)  //while loop to ensure user enters a value that can be casted into a decimal
            {
                Console.WriteLine("What is the new item's Price?");
                Console.Write("> ");
                price = Console.ReadLine();
                try
                {
                    Convert.ToDecimal(price);
                    isDecimal = true;
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Error! Please enter a valid number.");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                }
            }

            //Active =====================
            string active = null;               //string to use in Program for a bool cast
            bool isValid = false;               //bool to use for the while loop
            while (isValid == false)            //while loop to ensure the user enters a string that can be converted to a bool
            {
                Console.WriteLine("Is the new item active?" + Environment.NewLine + "Please enter 'true' or 'false'.");
                Console.Write("> ");
                string compareString = Console.ReadLine();
                if (compareString.ToUpper() == "TRUE")      //if user enters true, regardless of case
                {
                    active = "true";
                    isValid = true;
                }
                else if (compareString.ToUpper() == "FALSE")    //if the user enters false, regardless of case
                {
                    active = "false";
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Error: Invalid Input.");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Properties of the new Wine:");
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Description: " + description);
            Console.WriteLine("Pack: " + pack);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Active: " + active);
            Console.WriteLine();

            //the user's entered properties are returned to Program
            return new string[] { id, description, pack, price, active };
        }

        //Get New Item Information From The User.
        public string[] UpdateItemInformation()
        {
            //Description =====================
            Console.WriteLine("What is the new item's Description?");
            Console.Write("> ");
            string description = Console.ReadLine();

            //Pack =====================
            Console.WriteLine("What is the new item's Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();

            //Price =====================
            bool isDecimal = false;     //bool to be used for the while loop
            string price = null;
            while (isDecimal == false)  //while loop to ensure user enters a value that can be casted into a decimal
            {
                Console.WriteLine("What is the new item's Price?");
                Console.Write("> ");
                price = Console.ReadLine();
                try
                {
                    Convert.ToDecimal(price);
                    isDecimal = true;
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Error! Please enter a valid number.");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                }
            }

            //Active =====================
            string active = null;               //string to use in Program for a bool cast
            bool isValid = false;               //bool to use for the while loop
            while (isValid == false)            //while loop to ensure the user enters a string that can be converted to a bool
            {
                Console.WriteLine("Is the new item active?" + Environment.NewLine + "Please enter 'true' or 'false'.");
                Console.Write("> ");
                string compareString = Console.ReadLine();
                if (compareString.ToUpper() == "TRUE")      //if user enters true, regardless of case
                {
                    active = "true";
                    isValid = true;
                }
                else if (compareString.ToUpper() == "FALSE")    //if the user enters false, regardless of case
                {
                    active = "false";
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Error: Invalid Input.");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Properties of the Updated Wine:");
            Console.WriteLine("Description: " + description);
            Console.WriteLine("Pack: " + pack);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Active: " + active);
            Console.WriteLine();

            //the user's entered properties are returned to Program
            return new string[] { description, pack, price, active };
        }

        public string WineToUpdate()
        {
            Console.WriteLine("Plese enter the ID of the Wine you would like to update.");
            return Console.ReadLine();
        }

        //Display Import Success
        public void DisplayImportSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Wine List Has Been Imported Successfully");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }

        //Display Import Error
        public void DisplayImportError()
        {
            Console.WriteLine();
            Console.WriteLine("There was an error reading the database.");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }

        //Display All Items
        public void DisplayAllItems(string[] allItemsOutput)
        {
            Console.WriteLine();
            foreach (string itemOutput in allItemsOutput)
            {
                Console.WriteLine(itemOutput);
            }
        }

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }

        //Display Item Found Success
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine(itemInformation);
        }

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }

        //Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }


        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Load Wine List from the Database");
            Console.WriteLine("2. Print The Entire List Of Items");
            Console.WriteLine("3. Search For An Item");
            Console.WriteLine("4. Add New Item To The List");
            Console.WriteLine("5. Delete An Item from the List");
            Console.WriteLine("6. Update an Existing Item in the List");
            Console.WriteLine("7. Exit Program");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;

        }

        //prints the entire database of wines
        public void PrintDatabase(BeverageJSziedeEntities beverageEntities)
        {
            //foreach to process each element
            foreach (Beverage beverage in beverageEntities.Beverages)
            {
                //console prints the all the properties of each element
                Console.WriteLine(beverage.id + " " + beverage.name + " " + beverage.pack + " " + beverage.price.ToString("C") + " " + beverage.active);
            }
        }

        public string WineToBeDeleted()
        {
            Console.WriteLine("Plese enter the ID of the Wine you would like to delete.");
            return Console.ReadLine();
        }

        public void WineDeletionConfirmation(Beverage beverage)
        {
            Console.WriteLine("Deleting " + beverage.name.Trim() + ".");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();

        }

        public void WineDeletionError()
        {
            Console.WriteLine();
            Console.WriteLine("Error! No wine with that ID was found.");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }

        public void WineUpdateSuccess(string ID)
        {
            Console.WriteLine();
            Console.WriteLine("Wine with ID " + ID + " has been successfully updated.");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }
    }
}
