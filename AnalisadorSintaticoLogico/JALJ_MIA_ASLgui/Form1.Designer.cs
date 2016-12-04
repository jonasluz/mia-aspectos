namespace JALJ_MIA_ASLgui
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeViewResult = new System.Windows.Forms.TreeView();
            this.listBoxErrors = new System.Windows.Forms.ListBox();
            this.errorProviderInput = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(975, 604);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textBoxInput);
            this.flowLayoutPanel1.Controls.Add(this.buttonSubmit);
            this.flowLayoutPanel1.Controls.Add(this.buttonClear);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(975, 70);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.Location = new System.Drawing.Point(18, 18);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(613, 29);
            this.textBoxInput.TabIndex = 0;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(637, 18);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(152, 29);
            this.buttonSubmit.TabIndex = 1;
            this.buttonSubmit.Text = "Avaliar";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(795, 18);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(152, 29);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Limpar Resultados";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeViewResult);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBoxErrors);
            this.splitContainer2.Size = new System.Drawing.Size(975, 530);
            this.splitContainer2.SplitterDistance = 413;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeViewResult
            // 
            this.treeViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewResult.Location = new System.Drawing.Point(0, 0);
            this.treeViewResult.Name = "treeViewResult";
            this.treeViewResult.Size = new System.Drawing.Size(975, 413);
            this.treeViewResult.TabIndex = 0;
            // 
            // listBoxErrors
            // 
            this.listBoxErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxErrors.ForeColor = System.Drawing.Color.Maroon;
            this.listBoxErrors.FormattingEnabled = true;
            this.listBoxErrors.ItemHeight = 20;
            this.listBoxErrors.Location = new System.Drawing.Point(0, 0);
            this.listBoxErrors.Name = "listBoxErrors";
            this.listBoxErrors.Size = new System.Drawing.Size(975, 113);
            this.listBoxErrors.TabIndex = 0;
            // 
            // errorProviderInput
            // 
            this.errorProviderInput.ContainerControl = this;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 604);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMain";
            this.Text = "Analisador Sintático Lógico, por Jonas Luz";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeViewResult;
        private System.Windows.Forms.ListBox listBoxErrors;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ErrorProvider errorProviderInput;
    }
}

