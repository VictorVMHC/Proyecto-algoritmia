/*
 * Created by SharpDevelop.
 * User: manue
 * Date: 04/09/2019
 * Time: 10:56 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Circulos3
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button cargar;
		private System.Windows.Forms.Button analiza;
		private System.Windows.Forms.PictureBox pictureBoxO;
		private System.Windows.Forms.PictureBox pictureBoxA;
		private System.Windows.Forms.Label IMO;
		private System.Windows.Forms.Label IMA;
		private System.Windows.Forms.ListBox listBoxC;
		private System.Windows.Forms.Label labelLc;
		private System.Windows.Forms.Button buttonOrdenarC;
		private System.Windows.Forms.Button buttonGrafo;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabControl tabControlelements;
		private System.Windows.Forms.Button buttonClosestPP;
		private System.Windows.Forms.TreeView treeViewGR;
		private System.Windows.Forms.Button buttonBubblegr;
		private System.Windows.Forms.Button buttonDeleteVertex;
		private System.Windows.Forms.NumericUpDown numericUpDownListCircle;
		private System.Windows.Forms.Label label1;
		//private System.Windows.Forms.Button buttonClosestPP;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cargar = new System.Windows.Forms.Button();
            this.analiza = new System.Windows.Forms.Button();
            this.pictureBoxO = new System.Windows.Forms.PictureBox();
            this.pictureBoxA = new System.Windows.Forms.PictureBox();
            this.IMO = new System.Windows.Forms.Label();
            this.IMA = new System.Windows.Forms.Label();
            this.listBoxC = new System.Windows.Forms.ListBox();
            this.labelLc = new System.Windows.Forms.Label();
            this.buttonOrdenarC = new System.Windows.Forms.Button();
            this.buttonGrafo = new System.Windows.Forms.Button();
            this.tabControlelements = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDeleteVertex = new System.Windows.Forms.Button();
            this.numericUpDownListCircle = new System.Windows.Forms.NumericUpDown();
            this.buttonBubblegr = new System.Windows.Forms.Button();
            this.treeViewGR = new System.Windows.Forms.TreeView();
            this.buttonClosestPP = new System.Windows.Forms.Button();
            this.Agentes = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.prim_Kruskal = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonForDijkstra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA)).BeginInit();
            this.tabControlelements.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownListCircle)).BeginInit();
            this.Agentes.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cargar
            // 
            this.cargar.BackColor = System.Drawing.Color.Black;
            this.cargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cargar.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.cargar.FlatAppearance.BorderSize = 3;
            this.cargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cargar.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cargar.Location = new System.Drawing.Point(12, 12);
            this.cargar.Name = "cargar";
            this.cargar.Size = new System.Drawing.Size(145, 44);
            this.cargar.TabIndex = 0;
            this.cargar.Text = "Seleccionar Imagen";
            this.cargar.UseVisualStyleBackColor = false;
            this.cargar.Click += new System.EventHandler(this.CargarClick);
            // 
            // analiza
            // 
            this.analiza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.analiza.Location = new System.Drawing.Point(6, 204);
            this.analiza.Name = "analiza";
            this.analiza.Size = new System.Drawing.Size(145, 42);
            this.analiza.TabIndex = 1;
            this.analiza.Text = "Analiza Imagen";
            this.analiza.UseVisualStyleBackColor = true;
            this.analiza.Click += new System.EventHandler(this.AnalizaClick);
            // 
            // pictureBoxO
            // 
            this.pictureBoxO.Location = new System.Drawing.Point(12, 137);
            this.pictureBoxO.Name = "pictureBoxO";
            this.pictureBoxO.Size = new System.Drawing.Size(219, 205);
            this.pictureBoxO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxO.TabIndex = 2;
            this.pictureBoxO.TabStop = false;
            // 
            // pictureBoxA
            // 
            this.pictureBoxA.Location = new System.Drawing.Point(237, 54);
            this.pictureBoxA.Name = "pictureBoxA";
            this.pictureBoxA.Size = new System.Drawing.Size(500, 424);
            this.pictureBoxA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxA.TabIndex = 3;
            this.pictureBoxA.TabStop = false;
            // 
            // IMO
            // 
            this.IMO.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IMO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IMO.Location = new System.Drawing.Point(12, 111);
            this.IMO.Name = "IMO";
            this.IMO.Size = new System.Drawing.Size(134, 23);
            this.IMO.TabIndex = 4;
            this.IMO.Text = "Imagen Original";
            // 
            // IMA
            // 
            this.IMA.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IMA.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IMA.Location = new System.Drawing.Point(276, 28);
            this.IMA.Name = "IMA";
            this.IMA.Size = new System.Drawing.Size(124, 23);
            this.IMA.TabIndex = 5;
            this.IMA.Text = "Imagen Analizada";
            // 
            // listBoxC
            // 
            this.listBoxC.BackColor = System.Drawing.Color.Silver;
            this.listBoxC.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxC.FormattingEnabled = true;
            this.listBoxC.ItemHeight = 14;
            this.listBoxC.Location = new System.Drawing.Point(153, 179);
            this.listBoxC.Name = "listBoxC";
            this.listBoxC.Size = new System.Drawing.Size(249, 116);
            this.listBoxC.TabIndex = 6;
            // 
            // labelLc
            // 
            this.labelLc.Location = new System.Drawing.Point(153, 153);
            this.labelLc.Name = "labelLc";
            this.labelLc.Size = new System.Drawing.Size(100, 23);
            this.labelLc.TabIndex = 7;
            this.labelLc.Text = "Lista de circulos";
            // 
            // buttonOrdenarC
            // 
            this.buttonOrdenarC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOrdenarC.Location = new System.Drawing.Point(6, 252);
            this.buttonOrdenarC.Name = "buttonOrdenarC";
            this.buttonOrdenarC.Size = new System.Drawing.Size(145, 32);
            this.buttonOrdenarC.TabIndex = 8;
            this.buttonOrdenarC.Text = "Ordena de mayor a menor";
            this.buttonOrdenarC.UseVisualStyleBackColor = true;
            this.buttonOrdenarC.Click += new System.EventHandler(this.ButtonOrdenarCClick);
            // 
            // buttonGrafo
            // 
            this.buttonGrafo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGrafo.Location = new System.Drawing.Point(7, 21);
            this.buttonGrafo.Name = "buttonGrafo";
            this.buttonGrafo.Size = new System.Drawing.Size(130, 28);
            this.buttonGrafo.TabIndex = 9;
            this.buttonGrafo.Text = "Crear grafo";
            this.buttonGrafo.UseVisualStyleBackColor = true;
            this.buttonGrafo.Click += new System.EventHandler(this.ButtonGrafoClick);
            // 
            // tabControlelements
            // 
            this.tabControlelements.Controls.Add(this.tabPage1);
            this.tabControlelements.Controls.Add(this.tabPage2);
            this.tabControlelements.Controls.Add(this.Agentes);
            this.tabControlelements.Controls.Add(this.tabPage3);
            this.tabControlelements.Controls.Add(this.tabPage4);
            this.tabControlelements.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControlelements.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlelements.ItemSize = new System.Drawing.Size(120, 22);
            this.tabControlelements.Location = new System.Drawing.Point(743, 7);
            this.tabControlelements.Name = "tabControlelements";
            this.tabControlelements.SelectedIndex = 0;
            this.tabControlelements.Size = new System.Drawing.Size(605, 508);
            this.tabControlelements.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlelements.TabIndex = 10;
            this.tabControlelements.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.Controls.Add(this.analiza);
            this.tabPage1.Controls.Add(this.buttonOrdenarC);
            this.tabPage1.Controls.Add(this.listBoxC);
            this.tabPage1.Controls.Add(this.labelLc);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detectar circulos";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DimGray;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.buttonDeleteVertex);
            this.tabPage2.Controls.Add(this.numericUpDownListCircle);
            this.tabPage2.Controls.Add(this.buttonBubblegr);
            this.tabPage2.Controls.Add(this.treeViewGR);
            this.tabPage2.Controls.Add(this.buttonClosestPP);
            this.tabPage2.Controls.Add(this.buttonGrafo);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grafo";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 45);
            this.label1.TabIndex = 15;
            this.label1.Text = "Numero de vertices en el grafo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDeleteVertex
            // 
            this.buttonDeleteVertex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteVertex.Location = new System.Drawing.Point(8, 272);
            this.buttonDeleteVertex.Name = "buttonDeleteVertex";
            this.buttonDeleteVertex.Size = new System.Drawing.Size(129, 26);
            this.buttonDeleteVertex.TabIndex = 14;
            this.buttonDeleteVertex.Text = "Eliminar vertice";
            this.buttonDeleteVertex.UseVisualStyleBackColor = true;
            this.buttonDeleteVertex.Click += new System.EventHandler(this.ButtonDeleteVertexClick);
            // 
            // numericUpDownListCircle
            // 
            this.numericUpDownListCircle.Location = new System.Drawing.Point(7, 219);
            this.numericUpDownListCircle.Name = "numericUpDownListCircle";
            this.numericUpDownListCircle.Size = new System.Drawing.Size(130, 24);
            this.numericUpDownListCircle.TabIndex = 13;
            // 
            // buttonBubblegr
            // 
            this.buttonBubblegr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBubblegr.Location = new System.Drawing.Point(8, 105);
            this.buttonBubblegr.Name = "buttonBubblegr";
            this.buttonBubblegr.Size = new System.Drawing.Size(129, 41);
            this.buttonBubblegr.TabIndex = 12;
            this.buttonBubblegr.Text = "Ordenar descendente ";
            this.buttonBubblegr.UseVisualStyleBackColor = true;
            this.buttonBubblegr.Click += new System.EventHandler(this.ButtonBubblegrClick);
            // 
            // treeViewGR
            // 
            this.treeViewGR.BackColor = System.Drawing.Color.Silver;
            this.treeViewGR.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewGR.Location = new System.Drawing.Point(143, 21);
            this.treeViewGR.Name = "treeViewGR";
            this.treeViewGR.Size = new System.Drawing.Size(336, 451);
            this.treeViewGR.TabIndex = 11;
            // 
            // buttonClosestPP
            // 
            this.buttonClosestPP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClosestPP.Location = new System.Drawing.Point(8, 55);
            this.buttonClosestPP.Name = "buttonClosestPP";
            this.buttonClosestPP.Size = new System.Drawing.Size(129, 42);
            this.buttonClosestPP.TabIndex = 10;
            this.buttonClosestPP.Text = "Par de puntos mas cercanos";
            this.buttonClosestPP.UseVisualStyleBackColor = true;
            this.buttonClosestPP.Click += new System.EventHandler(this.ButtonClosestPPClick);
            // 
            // Agentes
            // 
            this.Agentes.BackColor = System.Drawing.Color.DimGray;
            this.Agentes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Agentes.Controls.Add(this.button1);
            this.Agentes.Location = new System.Drawing.Point(4, 26);
            this.Agentes.Name = "Agentes";
            this.Agentes.Padding = new System.Windows.Forms.Padding(3);
            this.Agentes.Size = new System.Drawing.Size(597, 478);
            this.Agentes.TabIndex = 2;
            this.Agentes.Text = "Agentes";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(198, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 109);
            this.button1.TabIndex = 0;
            this.button1.Text = "Crear Form para agentes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DimGray;
            this.tabPage3.Controls.Add(this.prim_Kruskal);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(597, 478);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Prim y Kruskal";
            // 
            // prim_Kruskal
            // 
            this.prim_Kruskal.BackColor = System.Drawing.Color.Black;
            this.prim_Kruskal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prim_Kruskal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.prim_Kruskal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prim_Kruskal.Location = new System.Drawing.Point(214, 200);
            this.prim_Kruskal.Name = "prim_Kruskal";
            this.prim_Kruskal.Size = new System.Drawing.Size(252, 109);
            this.prim_Kruskal.TabIndex = 1;
            this.prim_Kruskal.Text = "Crear Form para Prim y kruskal";
            this.prim_Kruskal.UseVisualStyleBackColor = false;
            this.prim_Kruskal.Click += new System.EventHandler(this.Prim_Kruskal_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.DimGray;
            this.tabPage4.Controls.Add(this.buttonForDijkstra);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(597, 478);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Dijkstra";
            // 
            // buttonForDijkstra
            // 
            this.buttonForDijkstra.BackColor = System.Drawing.Color.Black;
            this.buttonForDijkstra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonForDijkstra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonForDijkstra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonForDijkstra.Location = new System.Drawing.Point(190, 200);
            this.buttonForDijkstra.Name = "buttonForDijkstra";
            this.buttonForDijkstra.Size = new System.Drawing.Size(252, 109);
            this.buttonForDijkstra.TabIndex = 2;
            this.buttonForDijkstra.Text = "Crear Form para Dijkstra";
            this.buttonForDijkstra.UseVisualStyleBackColor = false;
            this.buttonForDijkstra.Click += new System.EventHandler(this.ButtonForDijkstra_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1360, 527);
            this.Controls.Add(this.tabControlelements);
            this.Controls.Add(this.IMO);
            this.Controls.Add(this.IMA);
            this.Controls.Add(this.pictureBoxA);
            this.Controls.Add(this.pictureBoxO);
            this.Controls.Add(this.cargar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seminario de algoritmia";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA)).EndInit();
            this.tabControlelements.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownListCircle)).EndInit();
            this.Agentes.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.TabPage Agentes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button prim_Kruskal;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonForDijkstra;
    }
}

