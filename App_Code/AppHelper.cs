using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FWP
{
    public static class AppHelper
    {
        // Displaying success message
        public static void displaySuccessMessage(PlaceHolder SuccessMessage, Literal SuccessText, string message)
        {
            SuccessMessage.Visible = true;
            SuccessText.Text = message;
        }

        // Displaying error message
        public static void displayErrorMessage(PlaceHolder ErrorMessage, Literal ErrorText, string message = "")
        {
            ErrorMessage.Visible = true;
            ErrorText.Text = (message != "") ? message : "Error. Not created.";
        }

        // Displaying warning message
        public static void displayWarningMessage(PlaceHolder WarningMessage, Literal WarningText, string message)
        {
            WarningMessage.Visible = true;
            WarningText.Text = message;
        }

        // Hiding success message
        public static void hideSuccessMessage(PlaceHolder SuccessMessage, Literal SuccessText)
        {
            SuccessMessage.Visible = false;
            SuccessText.Text = "";
        }

        // Hidding error message
        public static void hideErrorMessage(PlaceHolder ErrorMessage, Literal ErrorText)
        {
            ErrorText.Text = "";
            ErrorMessage.Visible = false;
        }

        // Hidding warning message
        public static void hideWarningMessage(PlaceHolder WarningMessage, Literal WarningText)
        {
            WarningMessage.Visible = false;
            WarningText.Text = "";
        }

        // Calculate total manintenance cost for all pets
        public static double getTotalCost(List<Pet> pets)
        {
            if (pets != null)
            {
                double cost = 0;
                foreach (var pet in pets)
                {
                    cost += pet.bills + pet.breed.foodCost + pet.breed.housCost;
                }

                return cost;
            }

            return 0;
        }
    }
}