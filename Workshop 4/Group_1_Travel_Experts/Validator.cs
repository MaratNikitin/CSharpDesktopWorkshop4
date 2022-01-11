using System;

/*
 * This app helps doing CRUD operations with the select tables of the 'TravelExperts' database.
 * This file with Validator class contains all the data validation methods used in this project.
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */

namespace Group_1_Travel_Experts
{
    public static class Validator
	{
        public static string LineEnd { get; set; } = "\n"; // it's a way of inserting line end symbol

        /// <summary>
        /// This validation method checks if data is entered inside a control
        /// </summary>
        /// <param name="value"> Value from a control to be validated </param>
        /// <param name="name"> Tag name of the control </param>
        /// <returns> A message string for a user about missing required data </returns>
        public static string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg += name + " is a required field." + LineEnd;
            }
            return msg;
        }

        /// <summary>
        /// This validation method checks if data entered inside a control can be converted into a decimal number
        /// </summary>
        /// <param name="value"> Value from a control to be validated </param>
        /// <param name="name"> Tag name of the control </param>
        /// <returns> A message string for a user reminding that a decimal number is needed </returns>
        public static string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg += name + " must be a valid decimal value." + LineEnd;
            }
            return msg;
        }

        /// <summary>
        /// This validation method checks if data entered inside a control can be converted into a DateTime value
        /// </summary>
        /// <param name="value"> Value from a control to be validated </param>
        /// <param name="name"> Tag name of the control </param>
        /// <returns> A message string for a user reminding that a DateTime value is needed </returns>
        public static string IsValidDate(string value, string name)
        {
            string msg = "";
            if (!DateTime.TryParse(value, out _))
            {
                msg += name + " must be a valid date (e.g. '2022-02-15')." + LineEnd;
            }
            return msg;
        }

        /// <summary>
        /// This validation method checks that data entered inside a control doesn't exceed the maximum number of characters allowed for its database column
        /// </summary>
        /// <param name="value"> Value from a control to be validated </param>
        /// <param name="name"> Tag name of the control </param>
        /// <param name="maxAllowedNumberOfCharacters"> Maximum allowed number of characters for the database's column </param>
        /// <returns> A message string for a user reminding that number of characters for the DB column is limited </returns>
        public static string IsWithinAllowedRangeOfCharacters(string value, string name, int maxAllowedNumberOfCharacters)
        {
            string msg = "";
            if (value.Length > maxAllowedNumberOfCharacters)
            {
                msg += name + " can not have more than " + maxAllowedNumberOfCharacters + 
                    " characters because of the database's column design restriction." + LineEnd;
            }
            return msg;
        }

        /// <summary>
        /// This method validates that the Agency Commission is less than the Base Price and only if both compared values can be converted to decimal numbers
        /// </summary>
        /// <param name="packageBasePrice">Package's base price value</param>
        /// <param name="packageAgencyCommission">Agency's commission value</param>
        /// <returns>A message string for a user reminding that the Agency Commission cannot equal or exceedshould be less than the Base Price</returns>
        public static string IsAdequateAgencyCommission(string packageBasePrice, string packageAgencyCommission)
        {
            string msg = "";
            if (Decimal.TryParse(packageBasePrice, out _) && Decimal.TryParse(packageAgencyCommission, out _))
            { 
                
                if (Convert.ToDecimal(packageAgencyCommission) >= Convert.ToDecimal(packageBasePrice))
                {
                    msg += "The Agency Commission cannot be greater than the Base Price." + LineEnd;
                }               
            }
            return msg;
        }


        /// <summary>
        /// This method validates that a package's End Date is later than the Start Date
        /// </summary>
        /// <param name="packageStartDate">Package's Start Date</param>
        /// <param name="packageEndDate">Package's End Date</param>
        /// <returns>A message string for a user reminding that a package's End Date should be later than the Start Date</returns>
        public static string PackageEndDateIsLaterThanStartDate(string packageStartDate, string packageEndDate)
        {
            string msg = "";
            if (DateTime.TryParse(packageStartDate, out _) && DateTime.TryParse(packageEndDate, out _))
            { 
                if (Convert.ToDateTime(packageStartDate) >= Convert.ToDateTime(packageEndDate))
                {
                    msg += "Package End Date must be later than Package Start Date" + LineEnd;
                }
            }
            return msg;
        }
    }
}
