using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FileCrypter
{
    public partial class Form1 : Form
    {
        byte[] FileToMutate;
        byte[] Key;
        EnDecrypter ed;
        public Form1()
        {
            InitializeComponent();
            ed = new CryptionClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0)
            {
                Key = Encoding.Default.GetBytes(textBox1.Text);
            }
            else
            {
                Key = ed.GenerateByteKey(15);
            }
            if (Key != null)
            {
                ed.PerformMutaion(ref FileToMutate, Key);
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileToMutate = File.ReadAllBytes(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileToMutate != null)
            {
                File.WriteAllBytes(openFileDialog1.FileName, FileToMutate);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog1.FileName, FileToMutate);
            }
        }
    }
}
