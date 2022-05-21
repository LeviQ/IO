﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PrologValidatorForms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pathName = folderBrowserDialog1.SelectedPath;
                label1.Text = pathName;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                finalPath = folderBrowserDialog1.SelectedPath;
                label2.Text = finalPath;
            }
        }

        private string DisplayErrors(string path, string finalPath)
        {
            string result = "";

            if(path == "")
            {
                result += "Nie podano ścieżki z rozwiązaniem!\n";
            }
            else if(InputValidator.ValidateDirectory(path) != true)
            {
                result += "podana ścieżka jest w nieprawidłowym formacie, poprawny: Kx_yyyyyy_Z\n";
            }
            if(finalPath == "")
            {
                result += "nie podano ścieżki do zapisu pliku .xlsx!\n";
            }

            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            labelInfo.Text = DisplayErrors(pathName, finalPath);
            if(InputValidator.ValidateDirectory(pathName) == true && finalPath !="")
            {
                ValSolution vs = new ValSolution(pathName, labelInfo, finalPath);
                vs.AnalyzeSolution();
            }
            
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            string inputPath = cb1.PresentPath;
            string outputpath = cb2.PresentPath;
            if (InputValidator.ValidateDirectory(inputPath) == true)
            {
                ValSolution vs = new ValSolution(inputPath, labelInfo, outputpath);
                vs.AnalyzeSolution();
            }
            else
            {
                MessageBox.Show($"Nieprawidłowy format ścięzki z rozwiązaniem! Prawidłowy format: Kx_yyyyyy_Z", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb2_Load(object sender, EventArgs e)
        {

        }

        private void cb1_Load(object sender, EventArgs e)
        {

        }
    }
}