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
    class WineItemCollection
    {
        //instanciate beverage entities
        BeverageJSziedeEntities beverageEntities = new BeverageJSziedeEntities();

        //a quick loop to see if the database exists and is accessible
        public bool ImportDatabase(BeverageJSziedeEntities beverageEntities)
        {
            foreach (Beverage beverage in beverageEntities.Beverages)
            {
                //returns true if the database is found
                return true;
            }

            //returns false if the database was not found
            return false;
        }

        //Find an item by its Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;

            //create new beverage to be used as a buffer for the search
            Beverage beverageIDToFind = null;

            try
            {
                //search the database for the first item that has an ID that matches the ID that the user enetered through the console
                beverageIDToFind = beverageEntities.Beverages.Where(beverage => beverage.id == id).First();
            }
            catch
            {
                //Return the returnString as null if no matches were found
                return returnString;
            }

            //return all the properties of the matching item
            returnString = beverageIDToFind.id + " " + beverageIDToFind.name.Trim() + " " + beverageIDToFind.pack + " " + beverageIDToFind.price.ToString("C") + " " + beverageIDToFind.active;
            return returnString;
        }

        //Add a new item to the database
        public Beverage AddNewItem(string id, string name, string pack, decimal price, bool active)
        {
            //create new empty beverage to be added
            Beverage newBeverage = new Beverage();

            //assign properties to the newly created beverage
            newBeverage.id = id;
            newBeverage.name = name;
            newBeverage.pack = pack;
            newBeverage.price = price;
            newBeverage.active = active;

            //return the newly created beverage with filled properties
            return newBeverage;
        }

        //quick and simple method to retrieve wine based on its ID, used for the deletion module in Program
        public Beverage DeleteWine(BeverageJSziedeEntities beverageEntities, string ID)
        {
            return beverageEntities.Beverages.Where(beverage => beverage.id == ID).First();
        }

        public Beverage UpdateWine(string id, string name, string pack, decimal price, bool active)
        {
            //create new empty beverage to be added
            Beverage beverageToUpdate = beverageEntities.Beverages.Where(beverage => beverage.id == id).First();

            //assign properties to the newly created beverage
            beverageToUpdate.id = id;
            beverageToUpdate.name = name;
            beverageToUpdate.pack = pack;
            beverageToUpdate.price = price;
            beverageToUpdate.active = active;


            return beverageToUpdate;
        }
    }
}