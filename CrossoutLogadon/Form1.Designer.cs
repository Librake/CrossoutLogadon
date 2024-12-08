namespace CrossoutLogadon;

using System;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualBasic.Logging;

partial class Form1
{
    private System.Windows.Forms.Button btnBrowseOutput;
    private System.Windows.Forms.Button btnOutput;
    private System.Windows.Forms.Label lblOutputFolderPath;
    private System.Windows.Forms.DateTimePicker dateTimePickerStart;
    private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
    private System.Windows.Forms.Label lblLastSaveTime;
    private System.Windows.Forms.Label lblStartDate;
    private System.Windows.Forms.Label lblEndDate;
    private System.Windows.Forms.ProgressBar progressBar;

    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.btnBrowseOutput = new System.Windows.Forms.Button();
        this.btnOutput = new System.Windows.Forms.Button();
        this.lblOutputFolderPath = new System.Windows.Forms.Label();
        this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
        this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
        this.lblLastSaveTime = new System.Windows.Forms.Label();
        this.lblStartDate = new System.Windows.Forms.Label();
        this.lblEndDate = new System.Windows.Forms.Label();
        this.progressBar = new System.Windows.Forms.ProgressBar();

        SuspendLayout();

        // 
        // btnBrowseOutput
        // 
        this.btnBrowseOutput.Location = new System.Drawing.Point(500, 20);
        this.btnBrowseOutput.Name = "btnBrowseOutput";
        this.btnBrowseOutput.Size = new System.Drawing.Size(75, 30);
        this.btnBrowseOutput.TabIndex = 0;
        this.btnBrowseOutput.Text = "Обзор";
        this.btnBrowseOutput.UseVisualStyleBackColor = true;
        this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);

        // 
        // btnOutput
        // 
        this.btnOutput.Location = new System.Drawing.Point(500, 110);
        this.btnOutput.Name = "btnOutput";
        this.btnOutput.Size = new System.Drawing.Size(75, 30);
        this.btnOutput.TabIndex = 5;
        this.btnOutput.Text = "Вывод";
        this.btnOutput.UseVisualStyleBackColor = true;
        this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);

        // 
        // lblOutputFolderPath
        // 
        this.lblOutputFolderPath.Location = new System.Drawing.Point(20, 20);
        this.lblOutputFolderPath.Name = "lblOutputFolderPath";
        this.lblOutputFolderPath.Size = new System.Drawing.Size(450, 27);
        this.lblOutputFolderPath.TabIndex = 1;
        this.lblOutputFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.lblOutputFolderPath.Text = "Папка для вывода не выбрана";
        this.lblOutputFolderPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        // 
        // dateTimePickerStart
        // 
        this.dateTimePickerStart.Location = new System.Drawing.Point(20, 85);
        this.dateTimePickerStart.Name = "dateTimePickerStart";
        this.dateTimePickerStart.Size = new System.Drawing.Size(200, 27);
        this.dateTimePickerStart.TabIndex = 7;

        // 
        // dateTimePickerEnd
        // 
        this.dateTimePickerEnd.Location = new System.Drawing.Point(240, 85);
        this.dateTimePickerEnd.Name = "dateTimePickerEnd";
        this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 27);
        this.dateTimePickerEnd.TabIndex = 8;

        // 
        // lblLastSaveTime
        // 
        this.lblLastSaveTime.AutoSize = true;
        this.lblLastSaveTime.Location = new System.Drawing.Point(20, 60);
        this.lblLastSaveTime.Name = "lblLastSaveTime";
        this.lblLastSaveTime.Size = new System.Drawing.Size(144, 20);
        this.lblLastSaveTime.TabIndex = 6;

        // 
        // lblStartDate
        // 
        this.lblStartDate.AutoSize = true;
        this.lblStartDate.Location = new System.Drawing.Point(20, 115);
        this.lblStartDate.Name = "lblStartDate";
        this.lblStartDate.Size = new System.Drawing.Size(69, 20);
        this.lblStartDate.TabIndex = 9;
        this.lblStartDate.Text = "Начало";

        // 
        // lblEndDate
        // 
        this.lblEndDate.AutoSize = true;
        this.lblEndDate.Location = new System.Drawing.Point(240, 115);
        this.lblEndDate.Name = "lblEndDate";
        this.lblEndDate.Size = new System.Drawing.Size(63, 20);
        this.lblEndDate.TabIndex = 10;
        this.lblEndDate.Text = "Конец";

        // 
        // progressBar
        // 
        this.progressBar.Location = new System.Drawing.Point(20, 150);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(450, 5);
        this.progressBar.TabIndex = 11;

        // 
        // Form1
        // 
        this.BackgroundImage = Properties.Resources.BackgroundImage; // Укажите имя изображения
        this.BackgroundImageLayout = ImageLayout.Stretch; // Масштабировать изображение
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(600, 375);
        Controls.Add(this.lblStartDate);
        Controls.Add(this.lblEndDate);
        Controls.Add(this.lblLastSaveTime);
        Controls.Add(this.dateTimePickerEnd);
        Controls.Add(this.dateTimePickerStart);
        Controls.Add(this.lblOutputFolderPath);
        Controls.Add(this.btnBrowseOutput);
        Controls.Add(this.btnOutput);
        Controls.Add(this.progressBar);
        Name = "Form1";
        Text = "ЛогАх БаБах";
        Load += new System.EventHandler(this.Form1_Load);
        ResumeLayout(false);
        PerformLayout();
    }

    private void btnBrowseOutput_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = "Выбери папку для вывода";
            folderDialog.ShowNewFolderButton = true;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                lblOutputFolderPath.Text = folderDialog.SelectedPath;
                SaveOutputFolderPath(lblOutputFolderPath.Text);
            }
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        lblOutputFolderPath.Text = LoadOutputFolderPath();
        dateTimePickerStart.Value = Properties.Settings.Default.LastUsedDate;
        dateTimePickerEnd.Value = DateTime.Today;
        lblLastSaveTime.Text = $"Последний вывод: {Properties.Settings.Default.LastUsedDate:dd/MM/yyyy HH:mm}";
    }

    private void btnOutput_Click(object sender, EventArgs e)
    {
        string folderPath = lblOutputFolderPath.Text;
        LogWriter logWriter = new LogWriter(folderPath);

        Properties.Settings.Default.LastUsedDate = DateTime.Now;
        Properties.Settings.Default.Save();

        lblLastSaveTime.Text = $"Last Save Time: {Properties.Settings.Default.LastUsedDate:dd/MM/yyyy HH:mm}";

        var filteredLogs = logStorage.logs
            .Where(log => log.startTime.Date >= dateTimePickerStart.Value.Date && log.startTime.Date <= dateTimePickerEnd.Value.Date)
            .OrderBy(log => log.startTime)
            .ToList();

        progressBar.Maximum = filteredLogs.Count;
        progressBar.Value = 0;

        foreach (var log in filteredLogs)
        {
            Debug.WriteLine(log.startTime);
            logWriter.Write(log.ReadContent());

            progressBar.Value++;
        }

        Debug.WriteLine("==================");
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
