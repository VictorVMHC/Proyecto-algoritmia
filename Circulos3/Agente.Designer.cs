/*
 * Created by SharpDevelop.
 * User: manue
 * Date: 12/10/2019
 * Time: 09:58 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Circulos3
{
	partial class Agente
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agente));
            this.pictureBoxAgenteF = new System.Windows.Forms.PictureBox();
            this.animation = new System.Windows.Forms.Button();
            this.buttonClean = new System.Windows.Forms.Button();
            this.buttonAleatorio = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelAgentes = new System.Windows.Forms.Label();
            this.buttonAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAgenteF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAgenteF
            // 
            this.pictureBoxAgenteF.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxAgenteF.Name = "pictureBoxAgenteF";
            this.pictureBoxAgenteF.Size = new System.Drawing.Size(710, 490);
            this.pictureBoxAgenteF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAgenteF.TabIndex = 0;
            this.pictureBoxAgenteF.TabStop = false;
            this.pictureBoxAgenteF.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxAgenteF_MouseClick);
            // 
            // animation
            // 
            this.animation.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animation.Location = new System.Drawing.Point(776, 12);
            this.animation.Name = "animation";
            this.animation.Size = new System.Drawing.Size(120, 31);
            this.animation.TabIndex = 1;
            this.animation.Text = "Animar";
            this.animation.UseVisualStyleBackColor = true;
            this.animation.Click += new System.EventHandler(this.Animation_Click);
            // 
            // buttonClean
            // 
            this.buttonClean.Location = new System.Drawing.Point(776, 49);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(120, 23);
            this.buttonClean.TabIndex = 2;
            this.buttonClean.Text = "Limpiar todo";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.ButtonClean_Click);
            // 
            // buttonAleatorio
            // 
            this.buttonAleatorio.Location = new System.Drawing.Point(776, 78);
            this.buttonAleatorio.Name = "buttonAleatorio";
            this.buttonAleatorio.Size = new System.Drawing.Size(120, 60);
            this.buttonAleatorio.TabIndex = 3;
            this.buttonAleatorio.Text = "Crear agentes aleatorio";
            this.buttonAleatorio.UseVisualStyleBackColor = true;
            this.buttonAleatorio.Click += new System.EventHandler(this.ButtonAleatorio_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(776, 178);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 4;
            // 
            // labelAgentes
            // 
            this.labelAgentes.AutoSize = true;
            this.labelAgentes.Cursor = System.Windows.Forms.Cursors.No;
            this.labelAgentes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelAgentes.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgentes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelAgentes.Location = new System.Drawing.Point(753, 150);
            this.labelAgentes.Name = "labelAgentes";
            this.labelAgentes.Size = new System.Drawing.Size(106, 15);
            this.labelAgentes.TabIndex = 5;
            this.labelAgentes.Text = "Numero de agentes";
            this.labelAgentes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(804, 214);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregar.TabIndex = 6;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.ButtonAgregar_Click);
            // 
            // Agente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(921, 514);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.labelAgentes);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonAleatorio);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.animation);
            this.Controls.Add(this.pictureBoxAgenteF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Agente";
            this.Text = "Agente";
            this.Load += new System.EventHandler(this.Agente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAgenteF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.PictureBox pictureBoxAgenteF;
        private System.Windows.Forms.Button animation;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.Button buttonAleatorio;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelAgentes;
        private System.Windows.Forms.Button buttonAgregar;
    }
}
