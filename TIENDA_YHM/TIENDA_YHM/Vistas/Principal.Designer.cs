namespace TIENDA_YHM.Vistas
{
    partial class Principal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.MenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUsuarios,
            this.MenuProductos,
            this.MenuCategorias,
            this.consultarSucursalesToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.Name = "MenuUsuarios";
            this.MenuUsuarios.Size = new System.Drawing.Size(64, 20);
            this.MenuUsuarios.Text = "Usuarios";
            this.MenuUsuarios.Click += new System.EventHandler(this.MenuUsuarios_Click);
            // 
            // MenuProductos
            // 
            this.MenuProductos.Name = "MenuProductos";
            this.MenuProductos.Size = new System.Drawing.Size(73, 20);
            this.MenuProductos.Text = "Productos";
            this.MenuProductos.Click += new System.EventHandler(this.MenuProductos_Click);
            // 
            // MenuCategorias
            // 
            this.MenuCategorias.Name = "MenuCategorias";
            this.MenuCategorias.Size = new System.Drawing.Size(75, 20);
            this.MenuCategorias.Text = "Categorías";
            this.MenuCategorias.Click += new System.EventHandler(this.MenuCategorias_Click);
            // 
            // consultarSucursalesToolStripMenuItem
            // 
            this.consultarSucursalesToolStripMenuItem.Name = "consultarSucursalesToolStripMenuItem";
            this.consultarSucursalesToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.consultarSucursalesToolStripMenuItem.Text = "ConsultarSucursales";
            this.consultarSucursalesToolStripMenuItem.Click += new System.EventHandler(this.consultarSucursalesToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Principal";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem MenuProductos;
        private System.Windows.Forms.ToolStripMenuItem MenuCategorias;
        private System.Windows.Forms.ToolStripMenuItem consultarSucursalesToolStripMenuItem;
    }
}