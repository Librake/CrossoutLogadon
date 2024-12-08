namespace CrossoutLogadon;

using System;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using System.Media;
using Microsoft.VisualBasic.Logging;
using System.Windows.Forms.VisualStyles;

partial class Form1
{
    private System.Windows.Forms.Button btnBrowseOutput;
    private System.Windows.Forms.Button btnOutput;
    private System.Windows.Forms.TextBox lblOutputFolderPath;
    private System.Windows.Forms.DateTimePicker dateTimePickerStart;
    private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
    private System.Windows.Forms.Label lblLastSaveTime;
    private System.Windows.Forms.Label lblStartDate;
    private System.Windows.Forms.Label lblEndDate;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label lblSessionCount;
    private SoundPlayer backgroundMusicPlayer;
    private System.Windows.Forms.Button btnOpenWebsite;
    private System.Windows.Forms.Button btnOpenLogs;


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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        btnBrowseOutput = new Button();
        btnOutput = new Button();
        //lblOutputFolderPath = new TextBox();
        lblOutputFolderPath = new System.Windows.Forms.TextBox();
        dateTimePickerStart = new DateTimePicker();
        dateTimePickerEnd = new DateTimePicker();
        lblLastSaveTime = new Label();
        lblStartDate = new Label();
        lblEndDate = new Label();
        progressBar = new ProgressBar();
        lblSessionCount = new Label();
        btnOpenWebsite = new Button();
        btnOpenLogs = new Button();
        backgroundMusicPlayer = new SoundPlayer(Properties.Resources.BGM);
        SuspendLayout();
        // 
        // btnBrowseOutput
        // 
        btnBrowseOutput.Location = new Point(500, 13);
        btnBrowseOutput.Name = "btnBrowseOutput";
        btnBrowseOutput.Size = new Size(75, 30);
        btnBrowseOutput.TabIndex = 0;
        btnBrowseOutput.Text = "Обзор";
        btnBrowseOutput.UseVisualStyleBackColor = true;
        btnBrowseOutput.Click += btnBrowseOutput_Click;
        // 
        // btnOutput
        // 
        btnOutput.Location = new Point(500, 330);
        btnOutput.Name = "btnOutput";
        btnOutput.Size = new Size(75, 30);
        btnOutput.TabIndex = 5;
        btnOutput.Text = "Вывод";
        btnOutput.UseVisualStyleBackColor = true;
        btnOutput.Click += btnOutput_Click;
        // 
        // lblOutputFolderPath
        // 
        lblOutputFolderPath.Location = new System.Drawing.Point(20, 15);
        lblOutputFolderPath.Name = "lblOutputFolderPath";
        lblOutputFolderPath.Text = "Папка для вывода не выбрана";
        lblOutputFolderPath.Size = new System.Drawing.Size(450, 30);
        lblOutputFolderPath.TabIndex = 1;
        lblOutputFolderPath.Click += (s, e) => lblOutputFolderPath.SelectAll();
        lblOutputFolderPath.ReadOnly = true;


        // 
        // dateTimePickerStart
        // 
        dateTimePickerStart.Location = new Point(20, 85);
        dateTimePickerStart.Name = "dateTimePickerStart";
        dateTimePickerStart.Size = new Size(200, 27);
        dateTimePickerStart.TabIndex = 7;
        dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;
        // 
        // dateTimePickerEnd
        // 
        dateTimePickerEnd.Location = new Point(240, 85);
        dateTimePickerEnd.Name = "dateTimePickerEnd";
        dateTimePickerEnd.Size = new Size(200, 27);
        dateTimePickerEnd.TabIndex = 8;
        dateTimePickerEnd.ValueChanged += dateTimePickerEnd_ValueChanged;
        // 
        // lblLastSaveTime
        // 
        lblLastSaveTime.AutoSize = true;
        lblLastSaveTime.Location = new Point(20, 55);
        lblLastSaveTime.Name = "lblLastSaveTime";
        lblLastSaveTime.Size = new Size(0, 20);
        lblLastSaveTime.TabIndex = 6;
        // 
        // lblStartDate
        // 
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(20, 115);
        lblStartDate.Name = "lblStartDate";
        lblStartDate.Size = new Size(61, 20);
        lblStartDate.TabIndex = 9;
        lblStartDate.Text = "Начало";
        // 
        // lblEndDate
        // 
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(240, 115);
        lblEndDate.Name = "lblEndDate";
        lblEndDate.Size = new Size(53, 20);
        lblEndDate.TabIndex = 10;
        lblEndDate.Text = "Конец";
        // 
        // progressBar
        // 
        progressBar.Location = new Point(20, 342);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(450, 7);
        progressBar.TabIndex = 11;
        // 
        // lblSessionCount
        // 
        lblSessionCount.AutoSize = true;
        lblSessionCount.Location = new Point(20, 270);
        lblSessionCount.Name = "lblSessionCount";
        lblSessionCount.Size = new Size(118, 20);
        lblSessionCount.TabIndex = 12;
        lblSessionCount.Text = "Число сессий: 0";
        // 
        // btnOpenWebsite
        // 
        btnOpenWebsite.Location = new Point(110, 300);
        btnOpenWebsite.Name = "btnOpenWebsite";
        btnOpenWebsite.Size = new Size(75, 30);
        btnOpenWebsite.TabIndex = 13;
        btnOpenWebsite.Text = "Сайт";
        btnOpenWebsite.UseVisualStyleBackColor = true;
        btnOpenWebsite.Click += btnOpenWebsite_Click;
        // 
        // btnOpenLogs
        // 
        btnOpenLogs.Location = new Point(20, 300);
        btnOpenLogs.Name = "btnOpenLogs";
        btnOpenLogs.Size = new Size(75, 30);
        btnOpenLogs.TabIndex = 14;
        btnOpenLogs.Text = "Логи";
        btnOpenLogs.UseVisualStyleBackColor = true;
        btnOpenLogs.Click += btnOpenLogs_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        BackgroundImage = Properties.Resources.BackgroundImage;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(600, 375);
        Controls.Add(lblStartDate);
        Controls.Add(lblEndDate);
        Controls.Add(lblLastSaveTime);
        Controls.Add(dateTimePickerEnd);
        Controls.Add(dateTimePickerStart);
        Controls.Add(lblOutputFolderPath);
        Controls.Add(btnBrowseOutput);
        Controls.Add(btnOutput);
        Controls.Add(progressBar);
        Controls.Add(lblSessionCount);
        Controls.Add(btnOpenWebsite);
        Controls.Add(btnOpenLogs);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "Form1";
        Text = "ЛогАх БаБах";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
        backgroundMusicPlayer.PlayLooping();
    }

    private void btnOpenLogs_Click(object sender, EventArgs e)
    {
        string folderPath = logStorage.LogsFolderPath;

        if (System.IO.Directory.Exists(folderPath))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = folderPath,
                UseShellExecute = true
            });
        }
        else
        {
            MessageBox.Show("Папка не найдена. Проверьте путь.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Обработчик события нажатия кнопки "Сайт"
    private void btnOpenWebsite_Click(object sender, EventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://crossout-info.com/",
            UseShellExecute = true // Используем системный браузер
        });
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
                btnOutput.Enabled = true; // Включить кнопку "Вывод" после выбора папки
            }
        }
    }



    private void Form1_Load(object sender, EventArgs e)
    {
        string outputFolderPath = LoadOutputFolderPath();
        DateTime lastUsedDate = Properties.Settings.Default.LastUsedDate;

        if (string.IsNullOrEmpty(outputFolderPath))
        {
            lblOutputFolderPath.Text = "Выбери папку для вывода";
            lblOutputFolderPath.ReadOnly = true;
            btnOutput.Enabled = false; // Блокируем кнопку "Вывод"
        }
        else
        {
            lblOutputFolderPath.Text = outputFolderPath;
        }

        if (lastUsedDate == default(DateTime))
        {
            lblLastSaveTime.Text = "Выбери интервал";
        }
        else
        {
            
            dateTimePickerStart.Value = lastUsedDate;
            dateTimePickerEnd.Value = DateTime.Today;
            lblLastSaveTime.Text = $"Последний вывод: {lastUsedDate:dd/MM/yyyy HH:mm}";
        }
    }

    private void btnOutput_Click(object sender, EventArgs e)
    {
        string folderPath = lblOutputFolderPath.Text;
        if (string.IsNullOrEmpty(folderPath) || folderPath == "Выбери папку для вывода")
        {
            MessageBox.Show("Пожалуйста, выберите папку для вывода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        LogWriter logWriter = new LogWriter(folderPath);

        Properties.Settings.Default.LastUsedDate = DateTime.Now;
        Properties.Settings.Default.Save();

        lblLastSaveTime.Text = $"Последний вывод: {Properties.Settings.Default.LastUsedDate:dd/MM/yyyy HH:mm}";

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

        // После завершения обработки, позволяешь пользователю выбрать папку снова
        lblOutputFolderPath.ReadOnly = false;
        btnOutput.Enabled = true;
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

    private void ResetProgressBar()
    {
        progressBar.Value = 0;
    }

    private void UpdateSessionCount()
    {
        var filteredLogs = logStorage.logs
            .Where(log => log.startTime.Date >= dateTimePickerStart.Value.Date && log.startTime.Date <= dateTimePickerEnd.Value.Date)
            .OrderBy(log => log.startTime)
            .ToList();

        lblSessionCount.Text = $"Число сессий: {filteredLogs.Count}";
    }

    private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
    {
        ResetProgressBar();
        UpdateSessionCount();
    }

    private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
    {
        ResetProgressBar();
        UpdateSessionCount();
    }
}
