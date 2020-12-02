using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace importtexttodatagrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("PC ID", typeof(string));
            table.Columns.Add("Procesor", typeof(string));
            table.Columns.Add("Placa de baza", typeof(string));
            table.Columns.Add("Placa de memorie", typeof(string));
            table.Columns.Add("HDD/SSD", typeof(string));
            table.Columns.Add("Placa video", typeof(string));
            table.Columns.Add("Bloc de alimentare", typeof(string));
            table.Columns.Add("Case", typeof(string));
            table.Columns.Add("Pretul", typeof(int));


            dataGridView1.DataSource = table;
        }

        private void button_Import_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Andrew\Documents\Proiecte scolare\C#\Excell\excell-project-main\Test.txt"); //Clasa file este deschiderea unui fisier
            string[] values;

            for(int i = 0; i < lines.Length; i++)    //in codul de mai jos este cintrolat txt fisierl daca are ceva scris in el
            {
                values = lines[i].ToString().Split('/');
                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }

                table.Rows.Add(row);
            }
        }

        private void button_Export(object sender, EventArgs e)   //in rindul dat avem butonul de export in excel 
        {
            Excel.Application exApp = new Excel.Application(); //face fisier nou

            exApp.Workbooks.Add(); //adauga informatia
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet; //Controleza fiecare rind si coloana si introduce in tabelul din excel
            int i, j;
            for (i = 0; i <= dataGridView1.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    wsh.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }
            exApp.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Lucru cu excel
            Excel.Range Rng;   
            Excel.Workbook xlWB;
            Excel.Worksheet xlSht;

            Excel.Application xlApp = new Excel.Application(); //Crearea file Excel
            xlWB = xlApp.Workbooks.Open(@"C:\Users\Andrew\Documents\Proiecte scolare\C#\Excell\excell-project-main\Test.xlsx"); //Deschiderea fisierului
            xlSht = xlWB.Worksheets["Лист1"]; //in cazul dat xlSht = xlWB.ActiveSheet // pagina din excel

            Rng = xlSht.get_Range("I:I"); //luăm întreaga coloană I în variabila Rng
            double sum = xlApp.WorksheetFunction.Sum(Rng); //calculam suma din coloana

            //inchidere a excel
            xlWB.Close(true); //salvarea si inchiderea excel file
            xlApp.Quit();
            releaseObject(xlSht);
            releaseObject(xlWB);
            releaseObject(xlApp);

            MessageBox.Show("Suma calculatoarelor este egala cu: " + sum, "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
