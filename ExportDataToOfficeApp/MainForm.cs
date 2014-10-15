using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CarLibrary;

namespace ExportDataToOfficeApp
{
    public partial class MainForm : Form
    {
        List<MiniVan> carsInStock = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateGrid()
        {
            // Reset the source of data.
            dataGridCars.DataSource = null;
            dataGridCars.DataSource = carsInStock;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            carsInStock = new List<MiniVan>
            {
                //new MiniVan {Color="Green", Make="VW", PetName="Mary"},
                //new MiniVan {Color="Red", Make="Saab", PetName="Mel"},
                //new MiniVan {Color="Black", Make="Ford", PetName="Hank"},
                //new MiniVan {Color="Yellow", Make="BMW", PetName="Davie"}
            };
            MiniVan v = new MiniVan();
            v.Color = "Green"; v.Make = "VW"; 
            v.PetName = "Mary";
            carsInStock.Add(v);

            UpdateGrid();
        }

    }
}
