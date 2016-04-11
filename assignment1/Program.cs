//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the Entity Framework Model class
            BeverageJSziedeEntities beverageEntities = new BeverageJSziedeEntities();


            //Create instance of the WineItemCollection Class
            WineItemCollection wineItemCollection = new WineItemCollection();
            
            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 7)
            {
                switch (choice)
                {
                    case 1:
                        //Load the CSV File
                        bool success = wineItemCollection.ImportDatabase(beverageEntities);
                        if (success)
                        {
                            //Display Success Message
                            userInterface.DisplayImportSuccess();
                        }
                        else
                        {
                            //Display Fail Message
                            userInterface.DisplayImportError();
                        }
                        break;

                    case 2:
                        //Print Entire List Of Items
                        userInterface.PrintDatabase(beverageEntities);
                        break;

                    case 3:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = wineItemCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 4:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (wineItemCollection.FindById(newItemInformation[0]) == null)
                        {
                            //Very lengthy line that creates a new Beverage based on the given parameters from the user.
                            //The properties are created by the user from the GetNewItemInformation method in the UserInterface class, then those parameters are used in the AddNewItem
                            //method from the wineItemCollection class. The AddNewItem is of type Beverage and returns a new Beverage that contains the properties entered by the user.
                            beverageEntities.Beverages.Add(wineItemCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2], Convert.ToDecimal(newItemInformation[3]), Convert.ToBoolean(newItemInformation[4])));

                            //The finished Beverage with its properties is then added to the database.
                            beverageEntities.SaveChanges();

                            //The user is alerted of the successful addition of the new Beverage (wine)
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 5:
                        //delete a wine from the list based on its ID

                        //the user enters the ID of the wine they want deleted
                        string wineToBeDeleted = userInterface.WineToBeDeleted();

                        //the queried ID is sent to wineItemCollection and is searched in the database
                        wineItemCollection.FindById(wineToBeDeleted);

                        //if a result is found...
                        if (wineItemCollection.FindById(wineToBeDeleted) != null)
                        {
                            //user is displayed the wine that is going to be deleted
                            userInterface.WineDeletionConfirmation(wineItemCollection.DeleteWine(beverageEntities, wineToBeDeleted)); 

                            //the beverage is removed from the database
                            beverageEntities.Beverages.Remove(wineItemCollection.DeleteWine(beverageEntities, wineToBeDeleted));
                            beverageEntities.SaveChanges();
                        }
                        else
                        {
                            //user is notified that the wine was not deleted
                            userInterface.WineDeletionError();
                        }
                        break;

                    case 6:
                        //update a wine from the list based on its ID
                        string itemToUpdate = userInterface.WineToUpdate();
                        if (wineItemCollection.FindById(itemToUpdate) != null)
                        {
                            //user is requested to supply the parameters of the wine to be updated
                            string[] updateItemInformation = userInterface.UpdateItemInformation();

                            //buffers are created to store the new and old wine data
                            Beverage beverageToUpdate = wineItemCollection.UpdateWine(itemToUpdate, updateItemInformation[0], updateItemInformation[1], Convert.ToDecimal(updateItemInformation[2]), Convert.ToBoolean(updateItemInformation[3]));
                            Beverage beverageToReplace = beverageEntities.Beverages.Where(beverage => beverage.id == itemToUpdate).First();

                            //the outdated wine is deleted
                            beverageEntities.Beverages.Remove(beverageToReplace);

                            //the outdated wine is set to the updated wine
                            beverageToReplace = beverageToUpdate;

                            //the updated wine is added
                            beverageEntities.Beverages.Add(beverageToUpdate);
                            beverageEntities.SaveChanges();

                            userInterface.WineUpdateSuccess(itemToUpdate);
                        }
                        else
                        {
                            //the message is still appropriate even though we are not deleting
                            userInterface.WineDeletionError();
                        }
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
