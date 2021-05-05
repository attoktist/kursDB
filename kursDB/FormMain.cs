using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.ReportingServices;

namespace kursDB
{
    public partial class FormMain : Form
    {
        #region constant fields
        private const string standardTitle = "CapsEditor";
        // default text in titlebar
        private const uint margin = 10;
        // horizontal and vertical margin in client area
        #endregion

        private int printingPageNo = 0;

        #region Member fields
        private ArrayList documentLines = new ArrayList();   // the 'document'
        private uint lineHeight;        // height in pixels of one line
        private Size documentSize;      // how big a client area is needed to 
                                        // display document
        private uint nLines;            // number of lines in document
        private Font mainFont;          // font used to display all lines
        private Font emptyDocumentFont; // font used to display empty message
        private Brush mainBrush = Brushes.Blue;
        // brush used to display document text
        private Brush emptyDocumentBrush = Brushes.Red;
        // brush used to display empty document message
        private Point mouseDoubleClickPosition;
        // location mouse is pointing to when double-clicked
        private OpenFileDialog fileOpenDialog = new OpenFileDialog();
        // standard open file dialog
        private bool documentHasData = false;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuFile;
        private System.Windows.Forms.MenuItem menuFileOpen;
        private System.Windows.Forms.MenuItem menuFileExit;
        private System.Windows.Forms.MenuItem menuFilePrint;
        private System.Windows.Forms.MenuItem menuFilePrintPreview;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        // set to true if document has some data in it
        #endregion


        public FormMain()
        {
            InitializeComponent();
            if(Program.usergroup == 2)
            {
                softwareProductsDataGridView.ReadOnly = true;
                softwareProductsSaleDataGridView.ReadOnly = true;
                computerPlatformDataGridView.ReadOnly = true;
                degreeOfProtectionDataGridView.ReadOnly = true;
                landsDataGridView.ReadOnly = true;
                licenseDataGridView.ReadOnly = true;
                manufacturerDataGridView.ReadOnly = true;
                oSDataGridView.ReadOnly = true;
                placeOfSaleDataGridView.ReadOnly = true;
                softwareProductsBindingNavigator.Enabled = false;
                softwareProductsSaleBindingNavigator.Enabled = false;
                computerPlatformBindingNavigator.Enabled = false;
                degreeOfProtectionBindingNavigator.Enabled = false;
                landsBindingNavigator.Enabled = false;
                licenseBindingNavigator.Enabled = false;
                manufacturerBindingNavigator.Enabled = false;
                oSBindingNavigator.Enabled = false;
                placeOfSaleBindingNavigator.Enabled = false;

            }
            else if(Program.usergroup == 1)
            {
                softwareProductsDataGridView.ReadOnly = false;
                softwareProductsSaleDataGridView.ReadOnly = false;
                computerPlatformDataGridView.ReadOnly = false;
                degreeOfProtectionDataGridView.ReadOnly = false;
                landsDataGridView.ReadOnly = false;
                licenseDataGridView.ReadOnly = false;
                manufacturerDataGridView.ReadOnly = false;
                oSDataGridView.ReadOnly = false;
                placeOfSaleDataGridView.ReadOnly = true;
            }
        }

        private void softwareProductsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.softwareProductsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.lab3DataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка. Данные не обновлены.");
            }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab3DataSet.PlaceOfSale". При необходимости она может быть перемещена или удалена.
            this.placeOfSaleTableAdapter.Fill(this.lab3DataSet.PlaceOfSale);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab3DataSet.OS". При необходимости она может быть перемещена или удалена.
            this.oSTableAdapter.Fill(this.lab3DataSet.OS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab3DataSet.Manufacturer". При необходимости она может быть перемещена или удалена.
            this.manufacturerTableAdapter.Fill(this.lab3DataSet.Manufacturer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab3DataSet.License". При необходимости она может быть перемещена или удалена.
            this.licenseTableAdapter.Fill(this.lab3DataSet.License);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab3DataSet.Lands". При необходимости она может быть перемещена или удалена.
            this.landsTableAdapter.Fill(this.lab3DataSet.Lands);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab3DataSet.DegreeOfProtection". При необходимости она может быть перемещена или удалена.
            this.degreeOfProtectionTableAdapter.Fill(this.lab3DataSet.DegreeOfProtection);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab3DataSet.ComputerPlatform". При необходимости она может быть перемещена или удалена.
            this.computerPlatformTableAdapter.Fill(this.lab3DataSet.ComputerPlatform);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab3DataSet.SoftwareProductsSale". При необходимости она может быть перемещена или удалена.
            this.softwareProductsSaleTableAdapter.Fill(this.lab3DataSet.SoftwareProductsSale);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab3DataSet.SoftwareProducts". При необходимости она может быть перемещена или удалена.
            this.softwareProductsTableAdapter.Fill(this.lab3DataSet.SoftwareProducts);

        }

       

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.softwareProductsSaleBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.lab3DataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка. Данные не обновлены.");
            }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.computerPlatformBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.lab3DataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка. Данные не обновлены.");
            }
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.degreeOfProtectionBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.lab3DataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка. Данные не обновлены.");
            }
        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.landsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.lab3DataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка. Данные не обновлены.");
            }
        }

        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.licenseBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.lab3DataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка. Данные не обновлены.");
            }
        }

        private void toolStripButton42_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.manufacturerBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.lab3DataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка. Данные не обновлены.");
            }
        }

        private void toolStripButton49_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.oSBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.lab3DataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка. Данные не обновлены.");
            }
        }

        private void toolStripButton56_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.placeOfSaleBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.lab3DataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка. Данные не обновлены.");
            }
        }

        private void pd_PrintPageSP(object sender, PrintPageEventArgs e) // Метод печати для printDocument
        {           
            Bitmap bmp = new Bitmap(40, 40);
            int n = softwareProductsDataGridView.ColumnCount;
            int m = softwareProductsDataGridView.SelectedRows.Count;
            string[] a = new string[m + 1];
            Bitmap[] b = new Bitmap[m];
            for (int i = 0; i < n; i++)
            {
                a[0] += softwareProductsDataGridView.Columns[i].HeaderText.ToString() + " ";
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = new String(' ', 15);
                    a[i] += softwareProductsDataGridView.SelectedRows[i - 1].Cells[j].Value + str;
                }               
            }
            var font = new Font("Tahoma", 12, FontStyle.Bold); // Шрифт настройте как вам нужно 
            for (int i = 0; i < m + 1; i++)
            {                
                e.Graphics.DrawString(a[i], font, Brushes.Black, 10, (i * 40) + 10);               
            }
        }

        private void PrintPreviewSP_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageSP);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void PrintSP_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageSP);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void pd_PrintPageSPS(object sender, PrintPageEventArgs e) // Метод печати для printDocument
        {
            Bitmap bmp = new Bitmap(40, 40);
            int n = softwareProductsSaleDataGridView.ColumnCount;
            int m = softwareProductsSaleDataGridView.SelectedRows.Count;
            string[] a = new string[m + 1];
            Bitmap[] b = new Bitmap[m];
            for (int i = 0; i < n; i++)
            {
                a[0] += softwareProductsSaleDataGridView.Columns[i].HeaderText.ToString() + " ";
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = new String(' ', 30);
                    a[i] += softwareProductsSaleDataGridView.SelectedRows[i - 1].Cells[j].Value + str;
                }
            }
            var font = new Font("Tahoma", 12, FontStyle.Bold); // Шрифт настройте как вам нужно 
            for (int i = 0; i < m + 1; i++)
            {
                e.Graphics.DrawString(a[i], font, Brushes.Black, 10, (i * 40) + 10);
            }
        }

        private void toolStripButton57_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageSPS);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void toolStripButton58_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageSPS);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }


        private void pd_PrintPageCP(object sender, PrintPageEventArgs e) // Метод печати для printDocument
        {
            Bitmap bmp = new Bitmap(40, 40);
            int n = computerPlatformDataGridView.ColumnCount;
            int m = computerPlatformDataGridView.SelectedRows.Count;
            string[] a = new string[m + 1];
            Bitmap[] b = new Bitmap[m];
            for (int i = 0; i < n; i++)
            {
                a[0] += computerPlatformDataGridView.Columns[i].HeaderText.ToString() + " ";
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = new String(' ', 30);
                    a[i] += computerPlatformDataGridView.SelectedRows[i - 1].Cells[j].Value + str;
                }
            }
            var font = new Font("Tahoma", 12, FontStyle.Bold); // Шрифт настройте как вам нужно 
            for (int i = 0; i < m + 1; i++)
            {
                e.Graphics.DrawString(a[i], font, Brushes.Black, 10, (i * 40) + 10);
            }
        }
        private void toolStripButton60_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageCP);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void toolStripButton59_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageCP);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void pd_PrintPageDOP(object sender, PrintPageEventArgs e) // Метод печати для printDocument
        {
            Bitmap bmp = new Bitmap(40, 40);
            int n = degreeOfProtectionDataGridView.ColumnCount;
            int m = degreeOfProtectionDataGridView.SelectedRows.Count;
            string[] a = new string[m + 1];
            Bitmap[] b = new Bitmap[m];
            for (int i = 0; i < n; i++)
            {
                a[0] += degreeOfProtectionDataGridView.Columns[i].HeaderText.ToString() + " ";
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = new String(' ', 30);
                    a[i] += degreeOfProtectionDataGridView.SelectedRows[i - 1].Cells[j].Value + str;
                }
            }
            var font = new Font("Tahoma", 12, FontStyle.Bold); // Шрифт настройте как вам нужно 
            for (int i = 0; i < m + 1; i++)
            {
                e.Graphics.DrawString(a[i], font, Brushes.Black, 10, (i * 40) + 10);
            }
        }

        private void toolStripButton62_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageDOP);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void toolStripButton61_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageDOP);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void pd_PrintPageL(object sender, PrintPageEventArgs e) // Метод печати для printDocument
        {
            Bitmap bmp = new Bitmap(40, 40);
            int n = landsDataGridView.ColumnCount;
            int m = landsDataGridView.SelectedRows.Count;
            string[] a = new string[m + 1];
            Bitmap[] b = new Bitmap[m];
            for (int i = 0; i < n; i++)
            {
                a[0] += landsDataGridView.Columns[i].HeaderText.ToString() + " ";
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = new String(' ', 30);
                    a[i] += landsDataGridView.SelectedRows[i - 1].Cells[j].Value + str;
                }
            }
            var font = new Font("Tahoma", 12, FontStyle.Bold); // Шрифт настройте как вам нужно 
            for (int i = 0; i < m + 1; i++)
            {
                e.Graphics.DrawString(a[i], font, Brushes.Black, 10, (i * 40) + 10);
            }
        }

        private void toolStripButton64_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageL);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void toolStripButton63_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageL);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void pd_PrintPageLic(object sender, PrintPageEventArgs e) // Метод печати для printDocument
        {
            Bitmap bmp = new Bitmap(40, 40);
            int n = licenseDataGridView.ColumnCount;
            int m = licenseDataGridView.SelectedRows.Count;
            string[] a = new string[m + 1];
            Bitmap[] b = new Bitmap[m];
            for (int i = 0; i < n; i++)
            {
                a[0] += licenseDataGridView.Columns[i].HeaderText.ToString() + " ";
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = new String(' ', 30);
                    a[i] += licenseDataGridView.SelectedRows[i - 1].Cells[j].Value + str;
                }
            }
            var font = new Font("Tahoma", 12, FontStyle.Bold); // Шрифт настройте как вам нужно 
            for (int i = 0; i < m + 1; i++)
            {
                e.Graphics.DrawString(a[i], font, Brushes.Black, 10, (i * 40) + 10);
            }
        }

        private void toolStripButton66_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageLic);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void toolStripButton65_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageLic);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void pd_PrintPageM(object sender, PrintPageEventArgs e) // Метод печати для printDocument
        {
            Bitmap bmp = new Bitmap(40, 40);
            int n = manufacturerDataGridView.ColumnCount;
            int m = manufacturerDataGridView.SelectedRows.Count;
            string[] a = new string[m + 1];
            Bitmap[] b = new Bitmap[m];
            for (int i = 0; i < n; i++)
            {
                a[0] += manufacturerDataGridView.Columns[i].HeaderText.ToString() + " ";
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = new String(' ', 30);
                    a[i] += manufacturerDataGridView.SelectedRows[i - 1].Cells[j].Value + str;
                }
            }
            var font = new Font("Tahoma", 12, FontStyle.Bold); // Шрифт настройте как вам нужно 
            for (int i = 0; i < m + 1; i++)
            {
                e.Graphics.DrawString(a[i], font, Brushes.Black, 10, (i * 40) + 10);
            }
        }

        private void toolStripButton68_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageM);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void toolStripButton67_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageM);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void pd_PrintPageOS(object sender, PrintPageEventArgs e) // Метод печати для printDocument
        {
            Bitmap bmp = new Bitmap(40, 40);
            int n = oSDataGridView.ColumnCount;
            int m = oSDataGridView.SelectedRows.Count;
            string[] a = new string[m + 1];
            Bitmap[] b = new Bitmap[m];
            for (int i = 0; i < n; i++)
            {
                a[0] += oSDataGridView.Columns[i].HeaderText.ToString() + " ";
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = new String(' ', 30);
                    a[i] += oSDataGridView.SelectedRows[i - 1].Cells[j].Value + str;
                }
            }
            var font = new Font("Tahoma", 12, FontStyle.Bold); // Шрифт настройте как вам нужно 
            for (int i = 0; i < m + 1; i++)
            {
                e.Graphics.DrawString(a[i], font, Brushes.Black, 10, (i * 40) + 10);
            }
        }

        private void toolStripButton70_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageOS);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void toolStripButton69_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageOS);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void pd_PrintPagePOS(object sender, PrintPageEventArgs e) // Метод печати для printDocument
        {
            Bitmap bmp = new Bitmap(40, 40);
            int n = placeOfSaleDataGridView.ColumnCount;
            int m = placeOfSaleDataGridView.SelectedRows.Count;
            string[] a = new string[m + 1];
            Bitmap[] b = new Bitmap[m];
            for (int i = 0; i < n; i++)
            {
                a[0] += placeOfSaleDataGridView.Columns[i].HeaderText.ToString() + " ";
            }

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = new String(' ', 30);
                    a[i] += placeOfSaleDataGridView.SelectedRows[i - 1].Cells[j].Value + str;
                }
            }
            var font = new Font("Tahoma", 12, FontStyle.Bold); // Шрифт настройте как вам нужно 
            for (int i = 0; i < m + 1; i++)
            {
                e.Graphics.DrawString(a[i], font, Brushes.Black, 10, (i * 40) + 10);
            }
        }

        private void toolStripButton72_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPagePOS);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void toolStripButton71_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPagePOS);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void buttonAddLicense_Click(object sender, EventArgs e)
        {
            if ((textBoxNOLT.Text != "") && (textBoxLD.Text != ""))
            {
                string sqlExpression = "addLicense";
                Program.connection = @"Data Source=DESKTOP-PN7HNG0;Initial Catalog=lab3;User Id=" + Program.login +";Password=" +Program.password +";";
                using (SqlConnection connection = new SqlConnection(Program.connection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    // указываем, что команда представляет хранимую процедуру
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // параметр для ввода имени
                    SqlParameter nameOfLicenseTypeParam = new SqlParameter
                    {
                        ParameterName = "@Name_of_license_type",
                        Value = textBoxNOLT.Text
                    };
                    // добавляем параметр
                    command.Parameters.Add(nameOfLicenseTypeParam);
                    // параметр для ввода возраста
                    SqlParameter licenseDescriptionParam = new SqlParameter
                    {
                        ParameterName = "@License_description",
                        Value = textBoxLD.Text
                    };
                    command.Parameters.Add(licenseDescriptionParam);

                    try
                    {
                        //var result = command.ExecuteScalar();
                        // если нам не надо возвращать id
                        var result = command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("У вас нет доступа к этой операции.");
                    }

                    MessageBox.Show("Добавлена лицензия: "+textBoxNOLT.Text);
                }
            }
            else
            {
                MessageBox.Show("Вы ввели не все данные для добавления лицензии. Заполните все поля.");
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            int price;
            if (textBoxPrice.Text == "") price = 0;
            else int.TryParse(textBoxPrice.Text, out price);

            string sqlExpression = "FindManufacturer";
            Program.connection = @"Data Source=DESKTOP-PN7HNG0;Initial Catalog=lab3;User Id=" + Program.login + ";Password=" + Program.password + ";";
            dataGridViewFindManufacturer.Rows.Clear();
            using (SqlConnection connection = new SqlConnection(Program.connection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter idManufacturerParam = new SqlParameter
                {
                    ParameterName = "@id_manufacturer",
                    Value = comboBox.SelectedValue
                };
                // добавляем параметр
                command.Parameters.Add(idManufacturerParam);
                // параметр для ввода возраста
                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@price",
                    Value = price
                };
                command.Parameters.Add(priceParam);

                try
                {
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                        while (reader.Read())
                        {
                            int id_SoftwareProducts = reader.GetInt32(0);
                            string Name = reader.GetString(1);
                            int id_manufacturer = reader.GetInt32(2);
                            int id_os = reader.GetInt32(3);
                            System.Data.SqlTypes.SqlMoney vendor_price = reader.GetSqlMoney(4);
                            int vp = (int)vendor_price;
                            int id_license = reader.GetInt32(5);
                            int id_degree = reader.GetInt32(6);
                            dataGridViewFindManufacturer.Rows.Add(Name, id_manufacturer, id_os, vp, id_license, id_degree);
                            //Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
                        }
                    }
                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("У вас нет доступа к этой операции.");
                }

                
            }
        }

        private void buttonLoadTables_Click(object sender, EventArgs e)
        {
            this.softwareProductsTableAdapter.Fill(this.lab3DataSet.SoftwareProducts);
            this.softwareProductsSaleTableAdapter.Fill(this.lab3DataSet.SoftwareProductsSale);
            this.computerPlatformTableAdapter.Fill(this.lab3DataSet.ComputerPlatform);
            this.degreeOfProtectionTableAdapter.Fill(this.lab3DataSet.DegreeOfProtection);
            this.landsTableAdapter.Fill(this.lab3DataSet.Lands);
            this.manufacturerTableAdapter.Fill(this.lab3DataSet.Manufacturer);
            this.licenseTableAdapter.Fill(this.lab3DataSet.License);
            this.oSTableAdapter.Fill(this.lab3DataSet.OS);
            this.placeOfSaleTableAdapter.Fill(this.lab3DataSet.PlaceOfSale);
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            FormReport fm2 = new FormReport();
            fm2.Show();
        }

        private void textBoxFindSP_TextChanged(object sender, EventArgs e)
        {
            //BindingSource bindingSource = new BindingSource(lab3DataSet, "SoftwareProducts");
            try
            {
                BindingSource bindingSource = softwareProductsBindingSource;
                int itemFound = bindingSource.Find("Name", textBoxFindSP.Text);
                bindingSource.Position = itemFound;
                softwareProductsDataGridView.ClearSelection();
                softwareProductsDataGridView.Rows[itemFound].Selected = true;
                softwareProductsDataGridView.CurrentCell = softwareProductsDataGridView[0, itemFound];
            }
            catch
            {

            }
        }

        private void textBoxFindSPS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bindingSource = softwareProductsSaleBindingSource;
                int itemFound = bindingSource.Find("Selling_price", textBoxFindSPS.Text);
                bindingSource.Position = itemFound;
                softwareProductsSaleDataGridView.ClearSelection();
                softwareProductsSaleDataGridView.Rows[itemFound].Selected = true;
                softwareProductsSaleDataGridView.CurrentCell = softwareProductsSaleDataGridView[0, itemFound];
            }
            catch
            {

            }
        }

        private void textBoxFindCP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bindingSource = computerPlatformBindingSource;
                int itemFound = bindingSource.Find("Name_computer_platform", textBoxFindCP.Text);
                bindingSource.Position = itemFound;
                computerPlatformDataGridView.ClearSelection();
                computerPlatformDataGridView.Rows[itemFound].Selected = true;
                computerPlatformDataGridView.CurrentCell = computerPlatformDataGridView[0, itemFound];
            }
            catch
            {

            }
        }

        private void textBoxFindDOP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bindingSource = degreeOfProtectionBindingSource;
                int itemFound = bindingSource.Find("Description_of_protection", textBoxFindDOP.Text);
                bindingSource.Position = itemFound;
                degreeOfProtectionDataGridView.ClearSelection();
                degreeOfProtectionDataGridView.Rows[itemFound].Selected = true;
                degreeOfProtectionDataGridView.CurrentCell = degreeOfProtectionDataGridView[0, itemFound];
            }
            catch
            {

            }
        }

        private void textBoxFindLands_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bindingSource = landsBindingSource;
                int itemFound = bindingSource.Find("Name_land", textBoxFindLands.Text);
                bindingSource.Position = itemFound;
                landsDataGridView.ClearSelection();
                landsDataGridView.Rows[itemFound].Selected = true;
                landsDataGridView.CurrentCell = landsDataGridView[0, itemFound];
            }
            catch
            {

            }
        }

        private void textBoxFindLicense_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bindingSource = licenseBindingSource;
                int itemFound = bindingSource.Find("Name_of_license_type", textBoxFindLicense.Text);
                bindingSource.Position = itemFound;
                licenseDataGridView.ClearSelection();
                licenseDataGridView.Rows[itemFound].Selected = true;
                licenseDataGridView.CurrentCell = licenseDataGridView[0, itemFound];
            }
            catch
            {

            }
        }

        private void textBoxFindManufacturer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bindingSource = manufacturerBindingSource;
                int itemFound = bindingSource.Find("Name_manufacturer", textBoxFindManufacturer.Text);
                bindingSource.Position = itemFound;
                manufacturerDataGridView.ClearSelection();
                manufacturerDataGridView.Rows[itemFound].Selected = true;
                manufacturerDataGridView.CurrentCell = manufacturerDataGridView[0, itemFound];
            }
            catch
            {

            }
        }

        private void textBoxFindOS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bindingSource = oSBindingSource;
                int itemFound = bindingSource.Find("Name_OS", textBoxFindOS.Text);
                bindingSource.Position = itemFound;
                oSDataGridView.ClearSelection();
                oSDataGridView.Rows[itemFound].Selected = true;
                oSDataGridView.CurrentCell = oSDataGridView[0, itemFound];
            }
            catch
            {

            }
        }

        private void textBoxFindPOS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bindingSource = placeOfSaleBindingSource;
                int itemFound = bindingSource.Find("Place_Name", textBoxFindPOS.Text);
                bindingSource.Position = itemFound;
                placeOfSaleDataGridView.ClearSelection();
                placeOfSaleDataGridView.Rows[itemFound].Selected = true;
                placeOfSaleDataGridView.CurrentCell = placeOfSaleDataGridView[0, itemFound];
            }
            catch
            {

            }
        }
    }
}
