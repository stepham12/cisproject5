﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Stephanie Amo
//Project 5

namespace cis237_assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Console Window Size
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 140;

            // Set a constant for the size of the collection
            const int beverageCollectionSize = 4000;

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            // Create an instance of the BeverageCollection class
            BeverageCollection beverageCollection = new BeverageCollection(beverageCollectionSize);

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // While the choice is not exit program
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        // Print Entire List Of Items
                        string allItemsString = beverageCollection.ToString();
                        if (!String.IsNullOrWhiteSpace(allItemsString))
                        {
                            // Display all of the items
                            userInterface.DisplayAllItems(allItemsString);
                        }
                        else
                        {
                            // Display error message for all items
                            userInterface.DisplayAllItemsError();
                        }
                        break;

                    case 2:
                        // Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = beverageCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 3:
                        // Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (beverageCollection.FindById(newItemInformation[0]) == null)
                        {
                            beverageCollection.AddNewItem(
                                newItemInformation[0],
                                newItemInformation[1],
                                newItemInformation[2],
                                decimal.Parse(newItemInformation[3]),
                                (newItemInformation[4] == "True")
                            );
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;
                    case 4:
                        //Update an existing beverage
                        break;
                    case 5:
                        //Delete an existing beverage
                        break;
                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }
        }
    }
}
