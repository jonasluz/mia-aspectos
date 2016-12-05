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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelInput = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonFNC = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.splitContainerOutput = new System.Windows.Forms.SplitContainer();
            this.treeViewResult = new System.Windows.Forms.TreeView();
            this.listBoxErrors = new System.Windows.Forms.ListBox();
            this.errorProviderInput = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBoxTree = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.flowLayoutPanelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutput)).BeginInit();
            this.splitContainerOutput.Panel1.SuspendLayout();
            this.splitContainerOutput.Panel2.SuspendLayout();
            this.splitContainerOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTree)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.flowLayoutPanelInput);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.AllowDrop = true;
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerOutput);
            this.splitContainerMain.Size = new System.Drawing.Size(975, 604);
            this.splitContainerMain.SplitterDistance = 70;
            this.splitContainerMain.TabIndex = 0;
            // 
            // flowLayoutPanelInput
            // 
            this.flowLayoutPanelInput.Controls.Add(this.textBoxInput);
            this.flowLayoutPanelInput.Controls.Add(this.buttonSubmit);
            this.flowLayoutPanelInput.Controls.Add(this.buttonFNC);
            this.flowLayoutPanelInput.Controls.Add(this.buttonClear);
            this.flowLayoutPanelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInput.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelInput.Name = "flowLayoutPanelInput";
            this.flowLayoutPanelInput.Padding = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanelInput.Size = new System.Drawing.Size(975, 70);
            this.flowLayoutPanelInput.TabIndex = 0;
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
            this.buttonSubmit.Size = new System.Drawing.Size(70, 29);
            this.buttonSubmit.TabIndex = 1;
            this.buttonSubmit.Text = "Árvore";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonFNC
            // 
            this.buttonFNC.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFNC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFNC.Location = new System.Drawing.Point(713, 18);
            this.buttonFNC.Name = "buttonFNC";
            this.buttonFNC.Size = new System.Drawing.Size(70, 29);
            this.buttonFNC.TabIndex = 3;
            this.buttonFNC.Text = "FNC";
            this.buttonFNC.UseVisualStyleBackColor = true;
            this.buttonFNC.Click += new System.EventHandler(this.buttonFNC_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(789, 18);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(70, 29);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Limpar";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // splitContainerOutput
            // 
            this.splitContainerOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOutput.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOutput.Name = "splitContainerOutput";
            this.splitContainerOutput.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOutput.Panel1
            // 
            this.splitContainerOutput.Panel1.Controls.Add(this.pictureBoxTree);
            this.splitContainerOutput.Panel1.Controls.Add(this.treeViewResult);
            // 
            // splitContainerOutput.Panel2
            // 
            this.splitContainerOutput.Panel2.Controls.Add(this.listBoxErrors);
            this.splitContainerOutput.Size = new System.Drawing.Size(975, 530);
            this.splitContainerOutput.SplitterDistance = 413;
            this.splitContainerOutput.TabIndex = 0;
            // 
            // treeViewResult
            // 
            this.treeViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewResult.LineColor = System.Drawing.Color.MediumBlue;
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
            // pictureBoxTree
            // 
            this.pictureBoxTree.BackColor = System.Drawing.Color.White;
            this.pictureBoxTree.Location = new System.Drawing.Point(32, 14);
            this.pictureBoxTree.Name = "pictureBoxTree";
            this.pictureBoxTree.Size = new System.Drawing.Size(889, 373);
            this.pictureBoxTree.TabIndex = 1;
            this.pictureBoxTree.TabStop = false;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 604);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "FormMain";
            this.Text = "Analisador Sintático Lógico, por Jonas Luz";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.flowLayoutPanelInput.ResumeLayout(false);
            this.flowLayoutPanelInput.PerformLayout();
            this.splitContainerOutput.Panel1.ResumeLayout(false);
            this.splitContainerOutput.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutput)).EndInit();
            this.splitContainerOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.SplitContainer splitContainerOutput;
        private System.Windows.Forms.TreeView treeViewResult;
        private System.Windows.Forms.ListBox listBoxErrors;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ErrorProvider errorProviderInput;
        private System.Windows.Forms.Button buttonFNC;
        private System.Windows.Forms.PictureBox pictureBoxTree;
    }
}

