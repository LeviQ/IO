﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace PrologValidatorForms.Library
{
    class GroupManager
    {
        string groupDirectoryPath;
        string name;
        string destinationDirectory;
        List<StudentTasksManager> studentTasksManagers = new List<StudentTasksManager>();

        public GroupManager(string groupDirectoryPath, string destinationDirectory)
        {
            this.groupDirectoryPath = groupDirectoryPath;
            this.destinationDirectory = destinationDirectory;
            this.name = groupDirectoryPath.Substring(groupDirectoryPath.Length - 7, 7);
            Console.WriteLine($"{name}");
        }

        public void AnalyzeSolution()
        {
            string keyFilePath = groupDirectoryPath + @"\klucz.txt";
            FileInfo fi = new FileInfo(keyFilePath);
            if (fi.Exists)
            {
                KeyManager keyManager = new KeyManager(keyFilePath);
                keyManager.AnalyzeKeyFile();

                foreach (string directory in Directory.GetDirectories(groupDirectoryPath))
                {
                    if (InputValidator.ValidateStudentDirectory(directory))
                    {
                        StudentTasksManager stm = new StudentTasksManager(directory, keyManager);
                        stm.AnalyzeTasks();
                        studentTasksManagers.Add(stm);
                    }
                }
            }
            else
            {
                MessageBox.Show($"W ścieżce: {groupDirectoryPath} brak pliku klucz.txt!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Console.WriteLine(this);
        }

        public void CreateExcelFile()
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Title = "Podsumowanie";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Podsumowanie");

                foreach (StudentTasksManager stm in studentTasksManagers)
                {
                    //Informacje podstawowe
                    ws = excelPackage.Workbook.Worksheets.Add(stm.SolutionName);
                    int basicCellsRow = 2;
                    int basicCellsColumn = 2;
                    ws.Cells[basicCellsRow, basicCellsColumn, basicCellsRow, basicCellsColumn + 1].Merge = true;
                    ws.Cells[basicCellsRow, basicCellsColumn].Value = "Informacje Podstawowe";

                    ws.Cells[basicCellsRow + 1, basicCellsColumn].Value = "Numer Albumu:";
                    ws.Cells[basicCellsRow + 1, basicCellsColumn + 1].Value = Convert.ToInt32(stm.SolutionName.Substring(3, 6));
                    ws.Cells[basicCellsRow + 2, basicCellsColumn].Value = "Numer podejścia:";
                    ws.Cells[basicCellsRow + 2, basicCellsColumn + 1].Value = Convert.ToInt32(stm.SolutionName.Substring(1, 1));
                    ws.Cells[basicCellsRow + 3, basicCellsColumn].Value = "Grupa:";
                    ws.Cells[basicCellsRow + 3, basicCellsColumn + 1].Value = Convert.ToInt32(stm.SolutionName.Substring(10, 1));

                    //Wyglad Informacji podstawowych

                    ws.Cells[basicCellsRow, basicCellsColumn].Style.Font.Bold = true;
                    ws.Cells[basicCellsRow, basicCellsColumn].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[basicCellsRow, basicCellsColumn].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(36, 47, 155));
                    string basicCells1 = "B3:B5";
                    ws.Cells[basicCells1].Style.Font.Bold = true;
                    ws.Cells[basicCells1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[basicCells1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(100, 111, 212));
                    string basicCells2 = "C3:C5";
                    ws.Cells[basicCells2].Style.Font.Bold = true;
                    ws.Cells[basicCells2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[basicCells2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(155, 163, 235));


                    //Informacje o plikach

                    int infCellsRow = 2;
                    int infCellsColumn = 6;

                    ws.Cells[infCellsRow, infCellsColumn, infCellsRow, infCellsColumn + stm.Tasks.Count].Merge = true;
                    ws.Cells[infCellsRow, infCellsColumn].Value = "Informacje o plikach";

                    ws.Cells[infCellsRow + 1, infCellsColumn].Value = "Nazwa pliku";
                    ws.Cells[infCellsRow + 2, infCellsColumn].Value = "Data utworzenia";
                    ws.Cells[infCellsRow + 3, infCellsColumn].Value = "Rozmiar";

                    infCellsColumn++;

                    for (int i = 0; i < stm.Tasks.Count; i++)
                    {
                        ws.Cells[infCellsRow + 1, infCellsColumn + i].Value = stm.Tasks[i].TaskName;
                        ws.Cells[infCellsRow + 2, infCellsColumn + i].Value = stm.Tasks[i].CreationTime;
                        ws.Cells[infCellsRow + 3, infCellsColumn + i].Value = stm.Tasks[i].SizeOfFile;

                        ws.Cells[infCellsRow + 1, infCellsColumn + i, infCellsRow + 3, infCellsColumn + i].Style.Font.Bold = true;
                        ws.Cells[infCellsRow + 1, infCellsColumn + i, infCellsRow + 3, infCellsColumn + i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[infCellsRow + 1, infCellsColumn + i, infCellsRow + 3, infCellsColumn + i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(155, 163, 235));
                    }

                    //Wyglad Informacji o plikach

                    infCellsColumn--;

                    ws.Cells[infCellsRow, infCellsColumn].Style.Font.Bold = true;
                    ws.Cells[infCellsRow, infCellsColumn].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[infCellsRow, infCellsColumn].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(36, 47, 155));

                    ws.Cells[infCellsRow + 1, infCellsColumn, infCellsRow + 3, infCellsColumn].Style.Font.Bold = true;
                    ws.Cells[infCellsRow + 1, infCellsColumn, infCellsRow + 3, infCellsColumn].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[infCellsRow + 1, infCellsColumn, infCellsRow + 3, infCellsColumn].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(100, 111, 212));

                    //Testy

                    int dataCellsRow = 8;
                    int dataCellsColumn = 2;

                    int How_many = stm.MaxTestCount;

                    for (int i = 0; i < stm.Tasks.Count; i++)
                    {
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn].Value = stm.Tasks[i].TaskName;
                        
                        for (int j = 0; j < stm.Tasks[i].Tests.Count; j++)
                        {
                            ws.Cells[dataCellsRow + i + 1, dataCellsColumn + j + 1].Value = stm.Tasks[i].Tests[j].IsCorrect;
                            ws.Cells[dataCellsRow, dataCellsColumn + j + 1].Value = "Test " + Convert.ToString(j+1);
                        }
                    }
                    ws.Cells[dataCellsRow, dataCellsColumn + 1 + How_many].Value = "Ilość zaliczonych testów";
                    ws.Cells[dataCellsRow, dataCellsColumn + 1 + How_many + 1].Value = "Ilość testów przeprowadzonych";
                    ws.Cells[dataCellsRow, dataCellsColumn + 1 + How_many + 2].Value = "Procent zaliczonych testów";
                    for (int i = 0; i < stm.Tasks.Count; i++)
                    {
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many].Value = stm.Tasks[i].CorrectAnswers;
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many + 1].Value = stm.Tasks[i].TotalAnswers;
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many + 2].Value = Convert.ToString((Convert.ToDouble(stm.Tasks[i].CorrectAnswers) / Convert.ToDouble(stm.Tasks[i].TotalAnswers))*100) + '%';

                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many].Style.Font.Bold = true;
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 223, 253));

                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many + 1].Style.Font.Bold = true;
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 223, 253));

                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many + 2].Style.Font.Bold = true;
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[dataCellsRow + i + 1, dataCellsColumn + 1 + How_many + 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 223, 253));
                    }

                    // Napis wyniki Analizy + Styl do tego

                    dataCellsRow--;


                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow, dataCellsColumn + How_many + 3].Merge = true;
                    ws.Cells[dataCellsRow, dataCellsColumn].Value = "Wyniki Analizy";

                    ws.Cells[dataCellsRow, dataCellsColumn].Style.Font.Bold = true;
                    ws.Cells[dataCellsRow, dataCellsColumn].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[dataCellsRow, dataCellsColumn].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(36, 47, 155));

                    dataCellsRow++;

                    //Style do Tablicy z wynikami analizy

                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow, dataCellsColumn + How_many + 3].Style.Font.Bold = true;
                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow, dataCellsColumn + How_many + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow, dataCellsColumn + How_many + 3].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(100, 111, 212));

                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow + stm.Tasks.Count, dataCellsColumn].Style.Font.Bold = true;
                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow + stm.Tasks.Count, dataCellsColumn].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow + stm.Tasks.Count, dataCellsColumn].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(100, 111, 212));

                    dataCellsColumn++;
                    dataCellsRow++;

                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow + stm.Tasks.Count - 1, dataCellsColumn + How_many - 1].Style.Font.Bold = true;
                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow + stm.Tasks.Count - 1, dataCellsColumn + How_many - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[dataCellsRow, dataCellsColumn, dataCellsRow + stm.Tasks.Count - 1, dataCellsColumn + How_many - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(155, 163, 235));

                    dataCellsRow--;
                    dataCellsColumn--;

                    


                    //Automatyczne wyrównanie kolumn

                    ws.Cells[1, 1, 50, 50].AutoFitColumns();
                }


                string finalDir = destinationDirectory + $@"\{name}.xlsx";

                try
                {    
                    FileInfo fi = new FileInfo(finalDir);
                    excelPackage.SaveAs(fi);
                    System.Diagnostics.Process.Start(finalDir);
                }
                catch (System.InvalidOperationException ioe)
                {
                    // Wyjątek odpowiedzialny za próbe otworzenia już otworzonego pliku
                }
                catch (Exception e)
                {
                    
                }
            }
        }

        private string ShowStudents()
        {
            string final = "";
            foreach(StudentTasksManager stm in studentTasksManagers)
            {
                final += "________________________________________________\n";
                final += "<" + stm.ToString() + ">\n\n";
                final += stm.ShowTasks();
                final += "________________________________________________\n";

            }
            return final;
        }

        public override string ToString()
        {
            return "####### " + name + " #######" + "\n" + ShowStudents();
        }
    }
}
