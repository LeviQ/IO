﻿
namespace PrologValidatorForms
{
    partial class Main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.cb2 = new PrologValidatorForms.Eksplorator();
            this.cb1 = new PrologValidatorForms.Eksplorator();
            this.btn_export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(936, 771);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Wybierz folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1078, 771);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "[ ścieżka twojego rozwiązania powinna być w formacie: Kx_yyyyyy_Z ]";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(936, 817);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Wybierz folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1078, 817);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(479, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "[ wybierz miejsce w którym powinien zostać zapisany plik wynikowy ]";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(936, 862);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Zatwierdź";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(32, 637);
            this.btn_confirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(1534, 48);
            this.btn_confirm.TabIndex = 8;
            this.btn_confirm.Text = "Zatwierdź";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(1078, 862);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(196, 20);
            this.labelInfo.TabIndex = 9;
            this.labelInfo.Text = "Jakiś tekst żeby nie zgubić";
            // 
            // cb2
            // 
            this.cb2.Location = new System.Drawing.Point(796, 62);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(788, 568);
            this.cb2.TabIndex = 7;
            this.cb2.Load += new System.EventHandler(this.cb2_Load);
            // 
            // cb1
            // 
            this.cb1.Location = new System.Drawing.Point(16, 62);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(788, 568);
            this.cb1.TabIndex = 6;
            this.cb1.Load += new System.EventHandler(this.cb1_Load);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(32, 728);
            this.btn_export.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(112, 35);
            this.btn_export.TabIndex = 10;
            this.btn_export.Text = "Zapisz";
            this.btn_export.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 706);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.cb2);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "Prolog Validator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private string pathName = "";
        private string finalPath = "";

        private System.Windows.Forms.Button button1; 
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private Eksplorator cb1;
        private Eksplorator cb2;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button btn_export;
    }
}
