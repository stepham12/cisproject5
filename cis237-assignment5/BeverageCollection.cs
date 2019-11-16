using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Stephanie Amo
//Project 5

namespace cis237_assignment5
{
    class BeverageCollection
    {
        //Make a new instance of the CarContext
        BeverageContext beverageContext = new BeverageContext();


        // Private Variables
        private Beverage[] beverages;
        private int beverageLength;

        // Constructor. Must pass the size of the collection.
        public BeverageCollection(int size)
        {
            this.beverages = new Beverage[size];
            this.beverageLength = 0;
        }

        // Add a new item to the collection
        public void AddNewItem(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            // Add a new Beverage to the collection. Increase the Length variable.
            //beverages[beverageLength] = new Beverage(id, name, pack, price, active);
            beverageLength++;
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

        // Find an item by it's Id
        public string FindById(string id)
        {
            string returnString = null;

            Beverage foundBeverage = beverageContext.Beverages.Find(id);
            if (foundBeverage != null)
            {
                returnString = $"{foundBeverage.id} {foundBeverage.name} {foundBeverage.pack}" +
                  $"{foundBeverage.price} {foundBeverage.active}";
            }


            // Return the returnString
            return returnString;
        }
    }
}
