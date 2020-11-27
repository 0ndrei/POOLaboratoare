using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        private string FilePath;             
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)        //Adaugam fereastra de deschidere
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = dialog.FileName;
                    richTextBox1.Text = File.ReadAllText(FilePath);
                }
            }
        }

        private void SaveToolStripMenuItem_Click_1(object sender, EventArgs e)           //Adaugam fereastra de salvare
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = dialog.FileName;
                        File.WriteAllText(FilePath, richTextBox1.Text);
                    }
                }
            }
            File.WriteAllText(FilePath, richTextBox1.Text);
        }

        private void WordwarpToolStripMenuItem_Click_1(object sender, EventArgs e)                    //Adaugam fereastra de schimb a textului
        {
            WordwarpToolStripMenuItem.Checked = !WordwarpToolStripMenuItem.Checked;
            richTextBox1.WordWrap = WordwarpToolStripMenuItem.Checked;
        }

        private void SaveasToolStripMenuItem_Click(object sender, EventArgs e)                        //Adaugam fereastra de salvare cum 
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = dialog.FileName;
                    File.WriteAllText(FilePath, richTextBox1.Text);
                }
            }
        }
        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e)             //Adaugam fereastra de inchidere
        {
            Close();

        }

        private void UndoToolStripMenuItem_Click_1(object sender, EventArgs e)                    //Adaugam fereastra de anulare
        {
            richTextBox1.Undo();
        }

        private void CutToolStripMenuItem_Click_1(object sender, EventArgs e)            //Adaugam fereastra de taiere
        {
            richTextBox1.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)             //Adaugam fereastra de copiere
        {
            richTextBox1.Copy();
        }

        private void PasteToolStripMenuItem_Click_1(object sender, EventArgs e)             //Adaugam fereastra de itroducere
        {
            richTextBox1.Paste();
        }

        private void DeleteToolStripMenuItem_Click_1(object sender, EventArgs e)             //Adaugam fereastra de  stergere
        {
            richTextBox1.Clear();
        }

        private void SelectallToolStripMenuItem_Click_1(object sender, EventArgs e)             //Adaugam fereastra de  selectare a tot textului
        {
            richTextBox1.SelectAll();
        }

        private void DataandTimeToolStripMenuItem_Click_1(object sender, EventArgs e)        //Adaugam fereastra cu data si timpul
        {
            richTextBox1.Text += DateTime.Now;
        }

        private void FontToolStripMenuItem_Click_1(object sender, EventArgs e)           //Adaugam fereastra cu text
        {
            using (FontDialog dialog = new FontDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Font = dialog.Font;
                }
            }
        }

        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)       //Adaugam fereastra noua 
        {
                FilePath = string.Empty;
                richTextBox1.Clear();   
        }

        private void PrintToolStripMenuItem_Click_1(object sender, EventArgs e)       //Adaugam fereastra cu print
        {
            printDialog1.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)              //Adaugam fereastra bold(ingrosare) 
        {
            String s = richTextBox1.SelectedText;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            richTextBox1.SelectedText = s;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)              //Adaugam fereastra italic
        {
            String s = richTextBox1.SelectedText;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
            richTextBox1.SelectedText = s;
        }


        private void toolStripButton6_Click(object sender, EventArgs e)              //Adaugam reintoarcerea la default
        {
            String s = richTextBox1.SelectedText;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.SelectedText = s;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)               //Adaugam  text stinga 
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)             //Adaugam  text centru
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)             //Adaugam  text dreapta
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

    }

}
