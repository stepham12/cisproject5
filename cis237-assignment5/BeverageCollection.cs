using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Stephanie Amo
//Project 5
//Due: 11/19/2019

namespace cis237_assignment5
{
    class BeverageCollection
    {
        //Make a new instance of the BeverageContext
        BeverageContext beverageContext = new BeverageContext();

        // Add a new item to the collection
        public void AddNewItem(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            //Make an instance of a new beverage
            Beverage newBeverageToAdd = new Beverage();

            //Assign properties to the parts of the beverage
            newBeverageToAdd.id = id;
            newBeverageToAdd.name = name;
            newBeverageToAdd.pack = pack;
            newBeverageToAdd.price = price;
            newBeverageToAdd.active = active;

            //Add the new beverage to the Beverages Collection
            beverageContext.Beverages.Add(newBeverageToAdd);

            // Save the changes to the database.
            beverageContext.SaveChanges();
        }

        // ToString override method to convert the collection to a string
        public override string ToString()
        {
            // Declare a return string
            string returnString = "";

            // Loop through all of the beverages
            foreach (Beverage beverage in beverageContext.Beverages)
            {
                // If the current beverage is not null, concat it to the return string
                if (beverage != null)
                {
                    returnString += $"{beverage.id} {beverage.name} {beverage.pack} {beverage.price} {beverage.active}" 
                        +Environment.NewLine;
                }
            }
            // Return the return string
            return returnString;
        }

        // Find an item by its Id
        public string FindById(string id)
        {
            string returnString = null;

            Beverage foundBeverage = beverageContext.Beverages.Find(id);
            if (foundBeverage != null)
            {
                returnString = $"{foundBeverage.id} {foundBeverage.name} {foundBeverage.pack} " +
                  $"{foundBeverage.price} {foundBeverage.active}";
            }


            // Return the returnString
            return returnString;
        }

        // Update an item in the collection
        public void UpdateItem(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            ///Get a beverage out of the database that we would like to update
            Beverage beverageToUpdate = beverageContext.Beverages.Find(id);

            //Update the properties of the beverage we found.
            beverageToUpdate.name = name;
            beverageToUpdate.pack = pack;
            beverageToUpdate.price = price;
            beverageToUpdate.active = active;

            //Save the changes to the database. 
            beverageContext.SaveChanges();
        }

        //Delete an item using its Id
        public void DeleteItem(string id)
        {
            // Get a beverage out of the database that we want to delete
            Beverage beverageToDelete = beverageContext.Beverages.Find(id);

            //Remove the beverage from the Beverages Collection
            beverageContext.Beverages.Remove(beverageToDelete);

            //Save the changes to database
            beverageContext.SaveChanges();
        }
    }
}
