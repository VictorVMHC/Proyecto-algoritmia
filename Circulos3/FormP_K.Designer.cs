namespace Circulos3
{
    partial class FormP_K
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormP_K));
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonPrim = new System.Windows.Forms.Button();
            this.buttonKruskal = new System.Windows.Forms.Button();
            this.labelPeso = new System.Windows.Forms.Label();
            this.listBoxARM = new System.Windows.Forms.ListBox();
            this.listBoxDFS = new System.Windows.Forms.ListBox();
            this.listBoxSubArbol = new System.Windows.Forms.ListBox();
            this.buttonMosKrus = new System.Windows.Forms.Button();
            this.buttonMosPrim = new System.Windows.Forms.Button();
            this.numericUpDownAgent1 = new System.Windows.Forms.NumericUpDown();
            this.buttonMovKrus = new System.Windows.Forms.Button();
            this.buttonMovPrim = new System.Windows.Forms.Button();
            this.numericUpDownAgent2 = new System.Windows.Forms.NumericUpDown();
            this.movKruskalA2 = new System.Windows.Forms.Button();
            this.MovPrimA2 = new System.Windows.Forms.Button();
            this.MosDFSA1 = new System.Windows.Forms.Button();
            this.MosDFSA2 = new System.Windows.Forms.Button();
            this.pictureBoxA1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxA2 = new System.Windows.Forms.PictureBox();
            this.buttonDraw2 = new System.Windows.Forms.Button();
            this.Animation = new System.Windows.Forms.Button();
            this.labelA1 = new System.Windows.Forms.Label();
            this.labela2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(635, 570);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImageMouseClick);
            // 
            // buttonPrim
            // 
            this.buttonPrim.BackColor = System.Drawing.Color.DimGray;
            this.buttonPrim.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrim.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPrim.Location = new System.Drawing.Point(691, 12);
            this.buttonPrim.Name = "buttonPrim";
            this.buttonPrim.Size = new System.Drawing.Size(75, 35);
            this.buttonPrim.TabIndex = 1;
            this.buttonPrim.Text = "Prim";
            this.buttonPrim.UseVisualStyleBackColor = false;
            this.buttonPrim.Click += new System.EventHandler(this.ButtonPrim_Click);
            // 
            // buttonKruskal
            // 
            this.buttonKruskal.BackColor = System.Drawing.Color.DimGray;
            this.buttonKruskal.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKruskal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonKruskal.Location = new System.Drawing.Point(808, 12);
            this.buttonKruskal.Name = "buttonKruskal";
            this.buttonKruskal.Size = new System.Drawing.Size(75, 35);
            this.buttonKruskal.TabIndex = 2;
            this.buttonKruskal.Text = "Kruskal";
            this.buttonKruskal.UseVisualStyleBackColor = false;
            this.buttonKruskal.Click += new System.EventHandler(this.ButtonKruskal_Click);
            // 
            // labelPeso
            // 
            this.labelPeso.AutoSize = true;
            this.labelPeso.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeso.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPeso.Location = new System.Drawing.Point(943, 9);
            this.labelPeso.Name = "labelPeso";
            this.labelPeso.Size = new System.Drawing.Size(0, 17);
            this.labelPeso.TabIndex = 3;
            this.labelPeso.Click += new System.EventHandler(this.Label1_Click);
            // 
            // listBoxARM
            // 
            this.listBoxARM.BackColor = System.Drawing.Color.DimGray;
            this.listBoxARM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxARM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBoxARM.FormattingEnabled = true;
            this.listBoxARM.HorizontalScrollbar = true;
            this.listBoxARM.ItemHeight = 18;
            this.listBoxARM.Location = new System.Drawing.Point(943, 25);
            this.listBoxARM.Name = "listBoxARM";
            this.listBoxARM.Size = new System.Drawing.Size(317, 256);
            this.listBoxARM.TabIndex = 4;
            this.listBoxARM.SelectedIndexChanged += new System.EventHandler(this.ListBoxARMSelectedIndexChanged);
            // 
            // listBoxDFS
            // 
            this.listBoxDFS.BackColor = System.Drawing.Color.DimGray;
            this.listBoxDFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDFS.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBoxDFS.FormattingEnabled = true;
            this.listBoxDFS.HorizontalScrollbar = true;
            this.listBoxDFS.ItemHeight = 18;
            this.listBoxDFS.Location = new System.Drawing.Point(653, 422);
            this.listBoxDFS.Name = "listBoxDFS";
            this.listBoxDFS.Size = new System.Drawing.Size(284, 148);
            this.listBoxDFS.TabIndex = 5;
            // 
            // listBoxSubArbol
            // 
            this.listBoxSubArbol.BackColor = System.Drawing.Color.DimGray;
            this.listBoxSubArbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSubArbol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBoxSubArbol.FormattingEnabled = true;
            this.listBoxSubArbol.HorizontalScrollbar = true;
            this.listBoxSubArbol.ItemHeight = 18;
            this.listBoxSubArbol.Location = new System.Drawing.Point(943, 305);
            this.listBoxSubArbol.Name = "listBoxSubArbol";
            this.listBoxSubArbol.Size = new System.Drawing.Size(317, 274);
            this.listBoxSubArbol.TabIndex = 6;
            // 
            // buttonMosKrus
            // 
            this.buttonMosKrus.BackColor = System.Drawing.Color.DimGray;
            this.buttonMosKrus.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMosKrus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMosKrus.Location = new System.Drawing.Point(799, 53);
            this.buttonMosKrus.Name = "buttonMosKrus";
            this.buttonMosKrus.Size = new System.Drawing.Size(93, 38);
            this.buttonMosKrus.TabIndex = 7;
            this.buttonMosKrus.Text = "Mostrar datos de Kruskal";
            this.buttonMosKrus.UseVisualStyleBackColor = false;
            this.buttonMosKrus.Click += new System.EventHandler(this.ButtonMosKrusClick);
            // 
            // buttonMosPrim
            // 
            this.buttonMosPrim.BackColor = System.Drawing.Color.DimGray;
            this.buttonMosPrim.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMosPrim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMosPrim.Location = new System.Drawing.Point(682, 53);
            this.buttonMosPrim.Name = "buttonMosPrim";
            this.buttonMosPrim.Size = new System.Drawing.Size(93, 38);
            this.buttonMosPrim.TabIndex = 8;
            this.buttonMosPrim.Text = "Mostrar datos de Prim";
            this.buttonMosPrim.UseVisualStyleBackColor = false;
            this.buttonMosPrim.Click += new System.EventHandler(this.ButtonMosPrimClick);
            // 
            // numericUpDownAgent1
            // 
            this.numericUpDownAgent1.BackColor = System.Drawing.Color.DimGray;
            this.numericUpDownAgent1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownAgent1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.numericUpDownAgent1.Location = new System.Drawing.Point(832, 140);
            this.numericUpDownAgent1.Name = "numericUpDownAgent1";
            this.numericUpDownAgent1.Size = new System.Drawing.Size(51, 21);
            this.numericUpDownAgent1.TabIndex = 9;
            // 
            // buttonMovKrus
            // 
            this.buttonMovKrus.BackColor = System.Drawing.Color.DimGray;
            this.buttonMovKrus.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMovKrus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMovKrus.Location = new System.Drawing.Point(799, 167);
            this.buttonMovKrus.Name = "buttonMovKrus";
            this.buttonMovKrus.Size = new System.Drawing.Size(112, 24);
            this.buttonMovKrus.TabIndex = 10;
            this.buttonMovKrus.Text = "Mover en kruskal";
            this.buttonMovKrus.UseVisualStyleBackColor = false;
            this.buttonMovKrus.Click += new System.EventHandler(this.ButtonMovKrusClick);
            // 
            // buttonMovPrim
            // 
            this.buttonMovPrim.BackColor = System.Drawing.Color.DimGray;
            this.buttonMovPrim.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMovPrim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMovPrim.Location = new System.Drawing.Point(799, 197);
            this.buttonMovPrim.Name = "buttonMovPrim";
            this.buttonMovPrim.Size = new System.Drawing.Size(112, 23);
            this.buttonMovPrim.TabIndex = 11;
            this.buttonMovPrim.Text = "Mover en Prim";
            this.buttonMovPrim.UseVisualStyleBackColor = false;
            this.buttonMovPrim.Click += new System.EventHandler(this.ButtonMovPrimClick);
            // 
            // numericUpDownAgent2
            // 
            this.numericUpDownAgent2.BackColor = System.Drawing.Color.DimGray;
            this.numericUpDownAgent2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownAgent2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.numericUpDownAgent2.Location = new System.Drawing.Point(832, 300);
            this.numericUpDownAgent2.Name = "numericUpDownAgent2";
            this.numericUpDownAgent2.Size = new System.Drawing.Size(51, 21);
            this.numericUpDownAgent2.TabIndex = 12;
            // 
            // movKruskalA2
            // 
            this.movKruskalA2.BackColor = System.Drawing.Color.DimGray;
            this.movKruskalA2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movKruskalA2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.movKruskalA2.Location = new System.Drawing.Point(799, 326);
            this.movKruskalA2.Name = "movKruskalA2";
            this.movKruskalA2.Size = new System.Drawing.Size(112, 23);
            this.movKruskalA2.TabIndex = 13;
            this.movKruskalA2.Text = "Mover en Kruskal";
            this.movKruskalA2.UseVisualStyleBackColor = false;
            this.movKruskalA2.Click += new System.EventHandler(this.MovKruskalA2Click);
            // 
            // MovPrimA2
            // 
            this.MovPrimA2.BackColor = System.Drawing.Color.DimGray;
            this.MovPrimA2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovPrimA2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MovPrimA2.Location = new System.Drawing.Point(799, 355);
            this.MovPrimA2.Name = "MovPrimA2";
            this.MovPrimA2.Size = new System.Drawing.Size(112, 23);
            this.MovPrimA2.TabIndex = 14;
            this.MovPrimA2.Text = "Mover en Prim";
            this.MovPrimA2.UseVisualStyleBackColor = false;
            this.MovPrimA2.Click += new System.EventHandler(this.MovPrimA2Click);
            // 
            // MosDFSA1
            // 
            this.MosDFSA1.BackColor = System.Drawing.Color.DimGray;
            this.MosDFSA1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MosDFSA1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MosDFSA1.Location = new System.Drawing.Point(653, 393);
            this.MosDFSA1.Name = "MosDFSA1";
            this.MosDFSA1.Size = new System.Drawing.Size(93, 23);
            this.MosDFSA1.TabIndex = 15;
            this.MosDFSA1.Text = "DFS Agente 1";
            this.MosDFSA1.UseVisualStyleBackColor = false;
            this.MosDFSA1.Click += new System.EventHandler(this.MosDFSA1Click);
            // 
            // MosDFSA2
            // 
            this.MosDFSA2.BackColor = System.Drawing.Color.DimGray;
            this.MosDFSA2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MosDFSA2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MosDFSA2.Location = new System.Drawing.Point(752, 393);
            this.MosDFSA2.Name = "MosDFSA2";
            this.MosDFSA2.Size = new System.Drawing.Size(93, 23);
            this.MosDFSA2.TabIndex = 16;
            this.MosDFSA2.Text = "DFS Agente 2";
            this.MosDFSA2.UseVisualStyleBackColor = false;
            this.MosDFSA2.Click += new System.EventHandler(this.MosDFSA2Click);
            // 
            // pictureBoxA1
            // 
            this.pictureBoxA1.Location = new System.Drawing.Point(654, 149);
            this.pictureBoxA1.Name = "pictureBoxA1";
            this.pictureBoxA1.Size = new System.Drawing.Size(139, 102);
            this.pictureBoxA1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxA1.TabIndex = 17;
            this.pictureBoxA1.TabStop = false;
            // 
            // pictureBoxA2
            // 
            this.pictureBoxA2.Location = new System.Drawing.Point(654, 285);
            this.pictureBoxA2.Name = "pictureBoxA2";
            this.pictureBoxA2.Size = new System.Drawing.Size(139, 102);
            this.pictureBoxA2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxA2.TabIndex = 18;
            this.pictureBoxA2.TabStop = false;
            // 
            // buttonDraw2
            // 
            this.buttonDraw2.BackColor = System.Drawing.Color.DimGray;
            this.buttonDraw2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDraw2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDraw2.Location = new System.Drawing.Point(723, 97);
            this.buttonDraw2.Name = "buttonDraw2";
            this.buttonDraw2.Size = new System.Drawing.Size(122, 23);
            this.buttonDraw2.TabIndex = 19;
            this.buttonDraw2.Text = "Dibujar ambos";
            this.buttonDraw2.UseVisualStyleBackColor = false;
            this.buttonDraw2.Click += new System.EventHandler(this.ButtonDraw2Click);
            // 
            // Animation
            // 
            this.Animation.BackColor = System.Drawing.Color.DimGray;
            this.Animation.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Animation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Animation.Location = new System.Drawing.Point(832, 248);
            this.Animation.Name = "Animation";
            this.Animation.Size = new System.Drawing.Size(99, 37);
            this.Animation.TabIndex = 20;
            this.Animation.Text = "Animacion";
            this.Animation.UseVisualStyleBackColor = false;
            this.Animation.Click += new System.EventHandler(this.AnimationClick);
            // 
            // labelA1
            // 
            this.labelA1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelA1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelA1.Location = new System.Drawing.Point(653, 123);
            this.labelA1.Name = "labelA1";
            this.labelA1.Size = new System.Drawing.Size(153, 23);
            this.labelA1.TabIndex = 21;
            this.labelA1.Text = "Configuracion agente 1";
            // 
            // labela2
            // 
            this.labela2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labela2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labela2.Location = new System.Drawing.Point(653, 259);
            this.labela2.Name = "labela2";
            this.labela2.Size = new System.Drawing.Size(153, 23);
            this.labela2.TabIndex = 22;
            this.labela2.Text = "Configuracion agente 2";
            // 
            // FormP_K
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1286, 598);
            this.Controls.Add(this.labela2);
            this.Controls.Add(this.labelA1);
            this.Controls.Add(this.Animation);
            this.Controls.Add(this.buttonDraw2);
            this.Controls.Add(this.pictureBoxA2);
            this.Controls.Add(this.pictureBoxA1);
            this.Controls.Add(this.MosDFSA2);
            this.Controls.Add(this.MosDFSA1);
            this.Controls.Add(this.MovPrimA2);
            this.Controls.Add(this.movKruskalA2);
            this.Controls.Add(this.numericUpDownAgent2);
            this.Controls.Add(this.buttonMovPrim);
            this.Controls.Add(this.buttonMovKrus);
            this.Controls.Add(this.numericUpDownAgent1);
            this.Controls.Add(this.buttonMosPrim);
            this.Controls.Add(this.buttonMosKrus);
            this.Controls.Add(this.listBoxSubArbol);
            this.Controls.Add(this.listBoxDFS);
            this.Controls.Add(this.listBoxARM);
            this.Controls.Add(this.labelPeso);
            this.Controls.Add(this.buttonKruskal);
            this.Controls.Add(this.buttonPrim);
            this.Controls.Add(this.pictureBoxImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormP_K";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prim y Kruskal";
            this.Load += new System.EventHandler(this.FormP_K_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonPrim;
        private System.Windows.Forms.Button buttonKruskal;
        private System.Windows.Forms.Label labelPeso;
        private System.Windows.Forms.ListBox listBoxARM;
        private System.Windows.Forms.ListBox listBoxDFS;
        private System.Windows.Forms.ListBox listBoxSubArbol;
        private System.Windows.Forms.Button buttonMosKrus;
        private System.Windows.Forms.Button buttonMosPrim;
        private System.Windows.Forms.NumericUpDown numericUpDownAgent1;
        private System.Windows.Forms.Button buttonMovKrus;
        private System.Windows.Forms.Button buttonMovPrim;
        private System.Windows.Forms.NumericUpDown numericUpDownAgent2;
        private System.Windows.Forms.Button movKruskalA2;
        private System.Windows.Forms.Button MovPrimA2;
        private System.Windows.Forms.Button MosDFSA1;
        private System.Windows.Forms.Button MosDFSA2;
        private System.Windows.Forms.PictureBox pictureBoxA1;
        private System.Windows.Forms.PictureBox pictureBoxA2;
        private System.Windows.Forms.Button buttonDraw2;
        private System.Windows.Forms.Button Animation;
        private System.Windows.Forms.Label labelA1;
        private System.Windows.Forms.Label labela2;
    }
}