
namespace IDE_AnalisadorLexico
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuItems = new System.Windows.Forms.MenuStrip();
            this.ArquivoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirProgramaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompilarItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarProgramaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cdFonteTextBox = new System.Windows.Forms.TextBox();
            this.menuItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItems
            // 
            this.menuItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ArquivoItem,
            this.CompilarItem});
            this.menuItems.Location = new System.Drawing.Point(0, 0);
            this.menuItems.Name = "menuItems";
            this.menuItems.Size = new System.Drawing.Size(901, 24);
            this.menuItems.TabIndex = 0;
            this.menuItems.Text = "menuItems";
            // 
            // ArquivoItem
            // 
            this.ArquivoItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirProgramaItem,
            this.sairItem});
            this.ArquivoItem.Name = "ArquivoItem";
            this.ArquivoItem.Size = new System.Drawing.Size(61, 20);
            this.ArquivoItem.Text = "Arquivo";
            this.ArquivoItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // abrirProgramaItem
            // 
            this.abrirProgramaItem.Name = "abrirProgramaItem";
            this.abrirProgramaItem.Size = new System.Drawing.Size(155, 22);
            this.abrirProgramaItem.Text = "Abrir Programa";
            // 
            // sairItem
            // 
            this.sairItem.Name = "sairItem";
            this.sairItem.Size = new System.Drawing.Size(155, 22);
            this.sairItem.Text = "Sair";
            // 
            // CompilarItem
            // 
            this.CompilarItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compilarProgramaItem});
            this.CompilarItem.Name = "CompilarItem";
            this.CompilarItem.Size = new System.Drawing.Size(68, 20);
            this.CompilarItem.Text = "Compilar";
            // 
            // compilarProgramaItem
            // 
            this.compilarProgramaItem.Name = "compilarProgramaItem";
            this.compilarProgramaItem.Size = new System.Drawing.Size(178, 22);
            this.compilarProgramaItem.Text = "Compilar Programa";
            // 
            // cdFonteTextBox
            // 
            this.cdFonteTextBox.Enabled = false;
            this.cdFonteTextBox.Location = new System.Drawing.Point(12, 27);
            this.cdFonteTextBox.Multiline = true;
            this.cdFonteTextBox.Name = "cdFonteTextBox";
            this.cdFonteTextBox.Size = new System.Drawing.Size(877, 375);
            this.cdFonteTextBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 414);
            this.Controls.Add(this.cdFonteTextBox);
            this.Controls.Add(this.menuItems);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuItems.ResumeLayout(false);
            this.menuItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuItems;
        private System.Windows.Forms.ToolStripMenuItem ArquivoItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CompilarItem;
        private System.Windows.Forms.ToolStripMenuItem abrirProgramaItem;
        private System.Windows.Forms.ToolStripMenuItem sairItem;
        private System.Windows.Forms.ToolStripMenuItem compilarProgramaItem;
        private System.Windows.Forms.TextBox cdFonteTextBox;
    }
}

