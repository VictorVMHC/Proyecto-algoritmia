namespace Circulos3
{
    partial class FormDijkstra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDijkstra));
            this.pictureBoxGrafoBmp = new System.Windows.Forms.PictureBox();
            this.listBoxSolucion = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.adornoagente = new System.Windows.Forms.PictureBox();
            this.controlOfSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafoBmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornoagente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlOfSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGrafoBmp
            // 
            this.pictureBoxGrafoBmp.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxGrafoBmp.Name = "pictureBoxGrafoBmp";
            this.pictureBoxGrafoBmp.Size = new System.Drawing.Size(652, 504);
            this.pictureBoxGrafoBmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGrafoBmp.TabIndex = 0;
            this.pictureBoxGrafoBmp.TabStop = false;
            this.pictureBoxGrafoBmp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxGrafoBmp_MouseClick);
            this.pictureBoxGrafoBmp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxGrafoBmp_MouseMove);
            // 
            // listBoxSolucion
            // 
            this.listBoxSolucion.BackColor = System.Drawing.Color.DimGray;
            this.listBoxSolucion.ForeColor = System.Drawing.Color.White;
            this.listBoxSolucion.FormattingEnabled = true;
            this.listBoxSolucion.HorizontalScrollbar = true;
            this.listBoxSolucion.Location = new System.Drawing.Point(670, 278);
            this.listBoxSolucion.Name = "listBoxSolucion";
            this.listBoxSolucion.Size = new System.Drawing.Size(388, 238);
            this.listBoxSolucion.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(824, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Animar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // adornoagente
            // 
            this.adornoagente.Location = new System.Drawing.Point(693, 96);
            this.adornoagente.Name = "adornoagente";
            this.adornoagente.Size = new System.Drawing.Size(136, 109);
            this.adornoagente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.adornoagente.TabIndex = 3;
            this.adornoagente.TabStop = false;
            // 
            // controlOfSpeed
            // 
            this.controlOfSpeed.BackColor = System.Drawing.Color.DimGray;
            this.controlOfSpeed.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlOfSpeed.ForeColor = System.Drawing.Color.White;
            this.controlOfSpeed.Location = new System.Drawing.Point(906, 146);
            this.controlOfSpeed.Name = "controlOfSpeed";
            this.controlOfSpeed.Size = new System.Drawing.Size(57, 25);
            this.controlOfSpeed.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(864, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Velocidad del agente";
            // 
            // FormDijkstra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1070, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.controlOfSpeed);
            this.Controls.Add(this.adornoagente);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxSolucion);
            this.Controls.Add(this.pictureBoxGrafoBmp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDijkstra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dijkstra";
            this.Load += new System.EventHandler(this.FormDijkstra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafoBmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adornoagente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlOfSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGrafoBmp;
        private System.Windows.Forms.ListBox listBoxSolucion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox adornoagente;
        private System.Windows.Forms.NumericUpDown controlOfSpeed;
        private System.Windows.Forms.Label label1;
    }
}