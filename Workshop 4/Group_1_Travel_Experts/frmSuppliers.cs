using Group_1_Travel_Experts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

/*
 * This app allows users to perform CRUD operations on select tables in the TravelExperts database
 * This form allows users to add, modify or delete suppliers from the suppliers table
 * Author: Scott Holmes
 * SAIT, OOSD course, CPRG-207 - Threaded Project (Part 2), Workshop #4 - C#.NET, Group 1
 * When: January-February 2022
 */

namespace Group_1_Travel_Experts
{
    public partial class frmSuppliers : Form
    {
        Suppliers selectedSupplier = null; // used to add a new supplier to the db

        public frmSuppliers()
        {
            InitializeComponent();
        }

        // when the form loads
        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            RefreshDataGridViewSuppliers(); // displays the newest Supplier data
        }

        // when the user clicks the add button
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            frmSuppliersAddUpdate secondForm = new frmSuppliersAddUpdate(); // create an instance of the secondform
            secondForm.isAdd = true; // tells the second form that the user is trying to add a supplier
            secondForm.supplier = null; // were not modifying an existing supplier, so for now supplier is null

            DialogResult result = secondForm.ShowDialog(); // displays the second form

            if (result == DialogResult.OK) // second form has supplier object with data
            {
                selectedSupplier = secondForm.supplier; // get the new supplier data
                // add the new supplier to the db and save the changes
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    try
                    {
                        // need to make a new supplierId because the DB can't do it for us (SupplierId is not an identity column)
                        int newSupplierId = db.Suppliers.Max(s => s.SupplierId) + 1; 
                        selectedSupplier.SupplierId = newSupplierId;

                        // update the db with the new supplier
                        db.Suppliers.Add(selectedSupplier);
                        db.SaveChanges();
                        dataGridViewSuppliers.Columns.Clear();
                        RefreshDataGridViewSuppliers();
                    }
                    // catch any exceptions and display them
                    catch (DbUpdateException ex)
                    {
                        this.HandleDbUpdateException(ex); // this method is described below
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while adding a supplier: " + ex.Message, ex.GetType().ToString());
                    }
                } 
            }
        }

        // when the user clicks the modify button
        private void buttonModify_Click(object sender, EventArgs e)
        {
            frmSuppliersAddUpdate secondForm = new frmSuppliersAddUpdate(); // create an instance of the secondform
            secondForm.isAdd = false; // we want to modify

            // find the DataGridView selected row in the db and set the supplier value on the second form to it
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedSupplier = db.Suppliers.Find(dataGridViewSuppliers.SelectedCells[0].Value); // the selected row from DataGridView is found in the DB
                    secondForm.supplier = selectedSupplier;
                }
            }
            // catch any exceptions
            catch (Exception ex)
            {
                MessageBox.Show("Error while getting the supplier's data: " + ex.Message, ex.GetType().ToString());
            }

            DialogResult result = secondForm.ShowDialog(); // Displays the second form as a modal

            // the user has submitted the modifications
            if (result == DialogResult.OK)
            {
                // update the supplier in the database
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        db.Update(selectedSupplier);
                        db.SaveChanges();
                        RefreshDataGridViewSuppliers(); // refresh the datagridview
                    }
                }
                // catch any exceptions
                catch (DbUpdateException ex)
                {
                    this.HandleDbUpdateException(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while getting the supplier's data: " + ex.Message, ex.GetType().ToString());
                }
            }
        }

        // when the user clicks the delete button
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // check if a row is selected
            if (dataGridViewSuppliers.SelectedRows.Count > 0)
            {
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        // find the selected row from the DataGridView in the DB
                        selectedSupplier = db.Suppliers.Find(dataGridViewSuppliers.SelectedCells[0].Value); 
                        // Get the user to confirm they want to delete the selected supplier
                        DialogResult confirmation = MessageBox.Show($"Are you sure you want to delete {selectedSupplier.SupName}?", "Confirm Delete",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmation == DialogResult.Yes) // the user says yes
                        {
                            // delete the supplier and save the changes
                            db.Suppliers.Remove(selectedSupplier);
                            db.SaveChanges();
                            RefreshDataGridViewSuppliers(); // refresh the datagridview
                        }
                    }
                }
                // catch any exceptions
                catch (DbUpdateException ex)
                {
                    this.HandleDbUpdateException(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while getting the supplier's data: " + ex.Message, ex.GetType().ToString());
                }
            }
            // no row was selected
            else
            {
                MessageBox.Show("You need to select a supplier first", "Delete Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // when the exit button is clicked
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // closes the form
        }


        // Class methods:


        /// <summary>
        /// Displays data from the suppliers table in the datagridviewSuppliers
        /// </summary>
        public void RefreshDataGridViewSuppliers()
        {
            dataGridViewSuppliers.DataSource = null; // setting DataSource as null helps to clear the listbox in the next line
            dataGridViewSuppliers.Rows.Clear(); // clearing the DataGridViewSuppliers

            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext()) // creating a new DBContext instance
                {
                    var suppliers = db.Suppliers.Select(s => new
                    {
                        s.SupplierId,
                        s.SupName
                    }).OrderBy(s => s.SupName).ToList();

                    dataGridViewSuppliers.DataSource = suppliers; // displays the data from the Suppliers table in the data grid

                    // Rename the column
                    dataGridViewSuppliers.Columns["SupplierId"].HeaderText = "Supplier ID";
                    dataGridViewSuppliers.Columns["SupName"].HeaderText = "Supplier Name";

                    // styling the column headers
                    dataGridViewSuppliers.EnableHeadersVisualStyles = false; // enabling manual background color change in the next code row
                    dataGridViewSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque; // setting the desired background color
                    dataGridViewSuppliers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Bisque; // to avoid highlighting selected columns
                    dataGridViewSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Maroon; // setting the same font color as for other rows
                    dataGridViewSuppliers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // setting central text alignment

                    // format alternating rows
                    dataGridViewSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;

                    // Resize the columns
                    dataGridViewSuppliers.Columns[0].Width = 150;
                    dataGridViewSuppliers.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while getting the suppliers's data: " + ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Handles errors associated with performing SaveChanges when adding, modifying or deleting data from the DB
        /// </summary>
        /// <param name="ex"></param>
        private void HandleDbUpdateException(DbUpdateException ex)
        {
            // get the inner exception with potentially multiple errors
            var sqlException = (SqlException)ex.InnerException;
            string message = "";
            foreach (SqlError err in sqlException.Errors)
            {
                message += $"Error {err.Number}: {err.Message}\n";
            }
            MessageBox.Show(message, "Database error(s)");
        }
    }
}
