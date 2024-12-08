namespace CrossoutLogadon;

using System;
using System.Diagnostics;
using System.Windows.Forms;

partial class Form1
{
    private System.Windows.Forms.Button btnBrowseOutput;
    private System.Windows.Forms.Button btnOutput;
    private System.Windows.Forms.TextBox txtOutputFolderPath;

    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.btnBrowseOutput = new System.Windows.Forms.Button();
        this.btnOutput = new System.Windows.Forms.Button();
        this.txtOutputFolderPath = new System.Windows.Forms.TextBox();

        SuspendLayout();

        // 
        // btnBrowseOutput
        // 
        this.btnBrowseOutput.Location = new System.Drawing.Point(700, 20);
        this.btnBrowseOutput.Name = "btnBrowseOutput";
        this.btnBrowseOutput.Size = new System.Drawing.Size(75, 30);
        this.btnBrowseOutput.TabIndex = 0;
        this.btnBrowseOutput.Text = "Browse";
        this.btnBrowseOutput.UseVisualStyleBackColor = true;
        this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);

        // 
        // btnOutput
        // 
        this.btnOutput.Location = new System.Drawing.Point(700, 60);
        this.btnOutput.Name = "btnOutput";
        this.btnOutput.Size = new System.Drawing.Size(75, 30);
        this.btnOutput.TabIndex = 5;
        this.btnOutput.Text = "Output";
        this.btnOutput.UseVisualStyleBackColor = true;
        this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);

        // 
        // txtOutputFolderPath
        // 
        this.txtOutputFolderPath.Location = new System.Drawing.Point(20, 20);
        this.txtOutputFolderPath.Name = "txtOutputFolderPath";
        this.txtOutputFolderPath.Size = new System.Drawing.Size(660, 27);
        this.txtOutputFolderPath.TabIndex = 1;

        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 300);
        Controls.Add(this.txtOutputFolderPath);
        Controls.Add(this.btnBrowseOutput);
        Controls.Add(this.btnOutput);
        Name = "Form1";
        Text = "Form1";
        Load += new System.EventHandler(this.Form1_Load);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private void btnBrowseOutput_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = "Выберите папку для сохранения выходного файла";
            folderDialog.ShowNewFolderButton = true;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolderPath.Text = folderDialog.SelectedPath;
                SaveOutputFolderPath(txtOutputFolderPath.Text);
            }
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        txtOutputFolderPath.Text = LoadOutputFolderPath();
    }

    private void btnOutput_Click(object sender, EventArgs e)
    {
        // Create a LogWriter with the selected folder path
        string folderPath = txtOutputFolderPath.Text;
        LogWriter logWriter = new LogWriter(folderPath);

        // Now you can use the logWriter object as needed.
        foreach (LogSession log in logStorage.logs)
        {
            logWriter.Write(log.ReadContent());
        }
    }

    private void SaveOutputFolderPath(string path)
    {
        Properties.Settings.Default.OutputFolderPath = path;
        Properties.Settings.Default.Save();
    }

    private string LoadOutputFolderPath()
    {
        return Properties.Settings.Default.OutputFolderPath;
    }
}
