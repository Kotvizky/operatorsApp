namespace ProjectsReport
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activityDate = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gNewProgects = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gOldProgects = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gNewProgects)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gOldProgects)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUpdate,
            this.сохранитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsUpdate
            // 
            this.tsUpdate.Name = "tsUpdate";
            this.tsUpdate.Size = new System.Drawing.Size(73, 20);
            this.tsUpdate.Text = "Обновить";
            this.tsUpdate.Click += new System.EventHandler(this.tsUpdate_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // activityDate
            // 
            this.activityDate.Location = new System.Drawing.Point(12, 27);
            this.activityDate.Name = "activityDate";
            this.activityDate.Size = new System.Drawing.Size(144, 20);
            this.activityDate.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 302);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gNewProgects);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(502, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Новые";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gNewProgects
            // 
            this.gNewProgects.AllowUserToAddRows = false;
            this.gNewProgects.AllowUserToDeleteRows = false;
            this.gNewProgects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gNewProgects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gNewProgects.Location = new System.Drawing.Point(3, 3);
            this.gNewProgects.Name = "gNewProgects";
            this.gNewProgects.Size = new System.Drawing.Size(496, 270);
            this.gNewProgects.TabIndex = 0;
            this.gNewProgects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gNewProgects_CellContentClick);
            this.gNewProgects.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gNewProgects_CellPainting);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gOldProgects);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(502, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Помеченные";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gOldProgects
            // 
            this.gOldProgects.AllowUserToAddRows = false;
            this.gOldProgects.AllowUserToDeleteRows = false;
            this.gOldProgects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gOldProgects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gOldProgects.Location = new System.Drawing.Point(3, 3);
            this.gOldProgects.Name = "gOldProgects";
            this.gOldProgects.Size = new System.Drawing.Size(496, 270);
            this.gOldProgects.TabIndex = 1;
            this.gOldProgects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gNewProgects_CellContentClick);
            this.gOldProgects.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gOldProgects_CellPainting);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 378);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.activityDate);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Projects report";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gNewProgects)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gOldProgects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsUpdate;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker activityDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gNewProgects;
        private System.Windows.Forms.DataGridView gOldProgects;
    }
}

