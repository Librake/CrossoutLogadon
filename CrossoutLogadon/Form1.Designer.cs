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
    private System.Windows.Forms.TextBox txtOutputFolderPath;
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
        this.txtOutputFolderPath = new System.Windows.Forms.TextBox();
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
        this.btnOutput.Location = new System.Drawing.Point(700, 110);
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
        this.lblStartDate.Text = "Start Date";

        // 
        // lblEndDate
        // 
        this.lblEndDate.AutoSize = true;
        this.lblEndDate.Location = new System.Drawing.Point(240, 115);
        this.lblEndDate.Name = "lblEndDate";
        this.lblEndDate.Size = new System.Drawing.Size(63, 20);
        this.lblEndDate.TabIndex = 10;
        this.lblEndDate.Text = "End Date";

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
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 200);
        Controls.Add(this.lblStartDate);
        Controls.Add(this.lblEndDate);
        Controls.Add(this.lblLastSaveTime);
        Controls.Add(this.dateTimePickerEnd);
        Controls.Add(this.dateTimePickerStart);
        Controls.Add(this.txtOutputFolderPath);
        Controls.Add(this.btnBrowseOutput);
        Controls.Add(this.btnOutput);
        Controls.Add(this.progressBar);
        Name = "Form1";
        Text = "Form1";
        Load += new System.EventHandler(this.Form1_Load);
        ResumeLayout(false);
        PerformLayout();
    }

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
        dateTimePickerStart.Value = Properties.Settings.Default.LastUsedDate;
        dateTimePickerEnd.Value = DateTime.Today;
        lblLastSaveTime.Text = $"Last Save Time: {Properties.Settings.Default.LastUsedDate.ToString("dd/MM/yyyy HH:mm")}";
    }

    private void btnOutput_Click(object sender, EventArgs e)
    {
        // Create a LogWriter with the selected folder path
        string folderPath = txtOutputFolderPath.Text;
        LogWriter logWriter = new LogWriter(folderPath);

        // Save the selected date range as the last used date
        Properties.Settings.Default.LastUsedDate = DateTime.Now;
        Properties.Settings.Default.Save();

        // Display the last saved date and time
        lblLastSaveTime.Text = $"Last Save Time: {Properties.Settings.Default.LastUsedDate.ToString("dd/MM/yyyy HH:mm")}";

        // Filter logs based on the selected date range
        var filteredLogs = logStorage.logs
            .Where(log => log.startTime.Date >= dateTimePickerStart.Value.Date && log.startTime.Date <= dateTimePickerEnd.Value.Date)
            .OrderBy(log => log.startTime)
            .ToList();

        // Set progress bar maximum value
        progressBar.Maximum = filteredLogs.Count;
        progressBar.Value = 0;

        // Output filtered logs
        foreach (var log in filteredLogs)
        {
            Debug.WriteLine(log.startTime);
            logWriter.Write(log.ReadContent());

            // Update progress bar
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
