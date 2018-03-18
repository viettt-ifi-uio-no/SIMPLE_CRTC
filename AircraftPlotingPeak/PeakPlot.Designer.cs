namespace AircraftPlotingPeak
{
    partial class PeakPlot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.allFlights = new System.Windows.Forms.RadioButton();
            this.rdDomestic = new System.Windows.Forms.RadioButton();
            this.rdIntl = new System.Windows.Forms.RadioButton();
            this.btnLoadArrFile = new System.Windows.Forms.Button();
            this.btnLoadDepartureData = new System.Windows.Forms.Button();
            this.tblPlot = new System.Windows.Forms.TableLayoutPanel();
            this.tblLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayout
            // 
            this.tblLayout.ColumnCount = 1;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tblLayout.Controls.Add(this.tblPlot, 0, 0);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 0);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 2;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tblLayout.Size = new System.Drawing.Size(2116, 1315);
            this.tblLayout.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadArrFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadDepartureData, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 1265);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2110, 47);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.allFlights);
            this.flowLayoutPanel1.Controls.Add(this.rdDomestic);
            this.flowLayoutPanel1.Controls.Add(this.rdIntl);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(847, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1260, 41);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // allFlights
            // 
            this.allFlights.AutoSize = true;
            this.allFlights.Dock = System.Windows.Forms.DockStyle.Left;
            this.allFlights.Location = new System.Drawing.Point(3, 3);
            this.allFlights.Name = "allFlights";
            this.allFlights.Size = new System.Drawing.Size(137, 29);
            this.allFlights.TabIndex = 0;
            this.allFlights.TabStop = true;
            this.allFlights.Text = "All Flights";
            this.allFlights.UseVisualStyleBackColor = true;
            this.allFlights.CheckedChanged += new System.EventHandler(this.allFlights_CheckedChanged);
            // 
            // rdDomestic
            // 
            this.rdDomestic.AutoSize = true;
            this.rdDomestic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdDomestic.Location = new System.Drawing.Point(146, 3);
            this.rdDomestic.Name = "rdDomestic";
            this.rdDomestic.Size = new System.Drawing.Size(178, 29);
            this.rdDomestic.TabIndex = 1;
            this.rdDomestic.TabStop = true;
            this.rdDomestic.Text = "Domestic only";
            this.rdDomestic.UseVisualStyleBackColor = true;
            this.rdDomestic.CheckedChanged += new System.EventHandler(this.rdDomestic_CheckedChanged);
            // 
            // rdIntl
            // 
            this.rdIntl.AutoSize = true;
            this.rdIntl.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdIntl.Location = new System.Drawing.Point(330, 3);
            this.rdIntl.Name = "rdIntl";
            this.rdIntl.Size = new System.Drawing.Size(211, 29);
            this.rdIntl.TabIndex = 2;
            this.rdIntl.TabStop = true;
            this.rdIntl.Text = "International Only";
            this.rdIntl.UseVisualStyleBackColor = true;
            this.rdIntl.CheckedChanged += new System.EventHandler(this.rdIntl_CheckedChanged);
            // 
            // btnLoadArrFile
            // 
            this.btnLoadArrFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadArrFile.Location = new System.Drawing.Point(3, 3);
            this.btnLoadArrFile.Name = "btnLoadArrFile";
            this.btnLoadArrFile.Size = new System.Drawing.Size(416, 41);
            this.btnLoadArrFile.TabIndex = 1;
            this.btnLoadArrFile.Text = "Load arrival data";
            this.btnLoadArrFile.UseVisualStyleBackColor = true;
            this.btnLoadArrFile.Click += new System.EventHandler(this.btnLoadArrFile_Click);
            // 
            // btnLoadDepartureData
            // 
            this.btnLoadDepartureData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadDepartureData.Enabled = false;
            this.btnLoadDepartureData.Location = new System.Drawing.Point(425, 3);
            this.btnLoadDepartureData.Name = "btnLoadDepartureData";
            this.btnLoadDepartureData.Size = new System.Drawing.Size(416, 41);
            this.btnLoadDepartureData.TabIndex = 2;
            this.btnLoadDepartureData.Text = "Load departure data";
            this.btnLoadDepartureData.UseVisualStyleBackColor = true;
            this.btnLoadDepartureData.Click += new System.EventHandler(this.btnLoadDepartureData_Click);
            // 
            // tblPlot
            // 
            this.tblPlot.ColumnCount = 1;
            this.tblPlot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPlot.Location = new System.Drawing.Point(3, 3);
            this.tblPlot.Name = "tblPlot";
            this.tblPlot.RowCount = 2;
            this.tblPlot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblPlot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblPlot.Size = new System.Drawing.Size(2110, 1256);
            this.tblPlot.TabIndex = 1;
            // 
            // PeakPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2116, 1315);
            this.Controls.Add(this.tblLayout);
            this.Name = "PeakPlot";
            this.Text = "PeakPlot";
            this.tblLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton allFlights;
        private System.Windows.Forms.RadioButton rdDomestic;
        private System.Windows.Forms.RadioButton rdIntl;
        private System.Windows.Forms.Button btnLoadArrFile;
        private System.Windows.Forms.Button btnLoadDepartureData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblPlot;
    }
}