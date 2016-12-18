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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Premissas");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Teorema");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Deduções");
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelInput = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonAST = new System.Windows.Forms.Button();
            this.buttonFNC = new System.Windows.Forms.Button();
            this.buttonPremisse = new System.Windows.Forms.Button();
            this.buttonTheorem = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.splitContainerOutput = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTree = new System.Windows.Forms.TabPage();
            this.pictureBoxTree = new System.Windows.Forms.PictureBox();
            this.tabPageCNF = new System.Windows.Forms.TabPage();
            this.richTextBoxCNF = new System.Windows.Forms.RichTextBox();
            this.tabPageATP = new System.Windows.Forms.TabPage();
            this.splitContainerATP = new System.Windows.Forms.SplitContainer();
            this.treeViewTheory = new System.Windows.Forms.TreeView();
            this.richTextBoxResolution = new System.Windows.Forms.RichTextBox();
            this.listBoxErrors = new System.Windows.Forms.ListBox();
            this.errorProviderInput = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.flowLayoutPanelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutput)).BeginInit();
            this.splitContainerOutput.Panel1.SuspendLayout();
            this.splitContainerOutput.Panel2.SuspendLayout();
            this.splitContainerOutput.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTree)).BeginInit();
            this.tabPageCNF.SuspendLayout();
            this.tabPageATP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerATP)).BeginInit();
            this.splitContainerATP.Panel1.SuspendLayout();
            this.splitContainerATP.Panel2.SuspendLayout();
            this.splitContainerATP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).BeginInit();
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
            this.splitContainerMain.Size = new System.Drawing.Size(955, 604);
            this.splitContainerMain.SplitterDistance = 61;
            this.splitContainerMain.TabIndex = 0;
            // 
            // flowLayoutPanelInput
            // 
            this.flowLayoutPanelInput.Controls.Add(this.textBoxInput);
            this.flowLayoutPanelInput.Controls.Add(this.buttonAST);
            this.flowLayoutPanelInput.Controls.Add(this.buttonFNC);
            this.flowLayoutPanelInput.Controls.Add(this.buttonPremisse);
            this.flowLayoutPanelInput.Controls.Add(this.buttonTheorem);
            this.flowLayoutPanelInput.Controls.Add(this.buttonClear);
            this.flowLayoutPanelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInput.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelInput.Name = "flowLayoutPanelInput";
            this.flowLayoutPanelInput.Padding = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanelInput.Size = new System.Drawing.Size(955, 61);
            this.flowLayoutPanelInput.TabIndex = 0;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.Location = new System.Drawing.Point(18, 18);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(476, 29);
            this.textBoxInput.TabIndex = 0;
            // 
            // buttonAST
            // 
            this.buttonAST.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAST.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAST.Location = new System.Drawing.Point(500, 18);
            this.buttonAST.Name = "buttonAST";
            this.buttonAST.Size = new System.Drawing.Size(70, 29);
            this.buttonAST.TabIndex = 1;
            this.buttonAST.Text = "Árvore";
            this.buttonAST.UseVisualStyleBackColor = true;
            this.buttonAST.Click += new System.EventHandler(this.buttonAst_Click);
            // 
            // buttonFNC
            // 
            this.buttonFNC.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFNC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFNC.Location = new System.Drawing.Point(576, 18);
            this.buttonFNC.Name = "buttonFNC";
            this.buttonFNC.Size = new System.Drawing.Size(70, 29);
            this.buttonFNC.TabIndex = 3;
            this.buttonFNC.Text = "FNC";
            this.buttonFNC.UseVisualStyleBackColor = true;
            this.buttonFNC.Click += new System.EventHandler(this.buttonFNC_Click);
            // 
            // buttonPremisse
            // 
            this.buttonPremisse.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPremisse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPremisse.Location = new System.Drawing.Point(652, 18);
            this.buttonPremisse.Name = "buttonPremisse";
            this.buttonPremisse.Size = new System.Drawing.Size(84, 29);
            this.buttonPremisse.TabIndex = 4;
            this.buttonPremisse.Text = "Premissa";
            this.buttonPremisse.UseVisualStyleBackColor = true;
            this.buttonPremisse.Click += new System.EventHandler(this.buttonPremisse_Click);
            // 
            // buttonTheorem
            // 
            this.buttonTheorem.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonTheorem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTheorem.Location = new System.Drawing.Point(742, 18);
            this.buttonTheorem.Name = "buttonTheorem";
            this.buttonTheorem.Size = new System.Drawing.Size(82, 29);
            this.buttonTheorem.TabIndex = 5;
            this.buttonTheorem.Text = "Teorema";
            this.buttonTheorem.UseVisualStyleBackColor = true;
            this.buttonTheorem.Click += new System.EventHandler(this.buttonTheorem_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(830, 18);
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
            this.splitContainerOutput.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainerOutput.Panel2
            // 
            this.splitContainerOutput.Panel2.Controls.Add(this.listBoxErrors);
            this.splitContainerOutput.Size = new System.Drawing.Size(955, 539);
            this.splitContainerOutput.SplitterDistance = 419;
            this.splitContainerOutput.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTree);
            this.tabControl1.Controls.Add(this.tabPageCNF);
            this.tabControl1.Controls.Add(this.tabPageATP);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(955, 419);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageTree
            // 
            this.tabPageTree.Controls.Add(this.pictureBoxTree);
            this.tabPageTree.Location = new System.Drawing.Point(4, 22);
            this.tabPageTree.Name = "tabPageTree";
            this.tabPageTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTree.Size = new System.Drawing.Size(947, 393);
            this.tabPageTree.TabIndex = 0;
            this.tabPageTree.Text = "Árvore";
            this.tabPageTree.UseVisualStyleBackColor = true;
            // 
            // pictureBoxTree
            // 
            this.pictureBoxTree.BackColor = System.Drawing.Color.White;
            this.pictureBoxTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTree.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxTree.Name = "pictureBoxTree";
            this.pictureBoxTree.Size = new System.Drawing.Size(941, 387);
            this.pictureBoxTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxTree.TabIndex = 1;
            this.pictureBoxTree.TabStop = false;
            // 
            // tabPageCNF
            // 
            this.tabPageCNF.Controls.Add(this.richTextBoxCNF);
            this.tabPageCNF.Location = new System.Drawing.Point(4, 22);
            this.tabPageCNF.Name = "tabPageCNF";
            this.tabPageCNF.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCNF.Size = new System.Drawing.Size(947, 393);
            this.tabPageCNF.TabIndex = 1;
            this.tabPageCNF.Text = "FNC";
            this.tabPageCNF.UseVisualStyleBackColor = true;
            // 
            // richTextBoxCNF
            // 
            this.richTextBoxCNF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxCNF.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxCNF.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxCNF.Name = "richTextBoxCNF";
            this.richTextBoxCNF.Size = new System.Drawing.Size(941, 387);
            this.richTextBoxCNF.TabIndex = 0;
            this.richTextBoxCNF.Text = "";
            // 
            // tabPageATP
            // 
            this.tabPageATP.Controls.Add(this.splitContainerATP);
            this.tabPageATP.Location = new System.Drawing.Point(4, 22);
            this.tabPageATP.Name = "tabPageATP";
            this.tabPageATP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageATP.Size = new System.Drawing.Size(947, 393);
            this.tabPageATP.TabIndex = 2;
            this.tabPageATP.Text = "PAT";
            this.tabPageATP.UseVisualStyleBackColor = true;
            // 
            // splitContainerATP
            // 
            this.splitContainerATP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerATP.Location = new System.Drawing.Point(3, 3);
            this.splitContainerATP.Name = "splitContainerATP";
            // 
            // splitContainerATP.Panel1
            // 
            this.splitContainerATP.Panel1.Controls.Add(this.treeViewTheory);
            // 
            // splitContainerATP.Panel2
            // 
            this.splitContainerATP.Panel2.Controls.Add(this.richTextBoxResolution);
            this.splitContainerATP.Size = new System.Drawing.Size(941, 387);
            this.splitContainerATP.SplitterDistance = 313;
            this.splitContainerATP.TabIndex = 3;
            // 
            // treeViewTheory
            // 
            this.treeViewTheory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTheory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewTheory.Location = new System.Drawing.Point(0, 0);
            this.treeViewTheory.Name = "treeViewTheory";
            treeNode4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            treeNode4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            treeNode4.Name = "NodePremisses";
            treeNode4.Text = "Premissas";
            treeNode5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            treeNode5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            treeNode5.Name = "NodeTheorem";
            treeNode5.Text = "Teorema";
            treeNode6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            treeNode6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            treeNode6.Name = "NodeDeductions";
            treeNode6.Text = "Deduções";
            this.treeViewTheory.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeViewTheory.Size = new System.Drawing.Size(313, 387);
            this.treeViewTheory.TabIndex = 1;
            // 
            // richTextBoxResolution
            // 
            this.richTextBoxResolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxResolution.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxResolution.Name = "richTextBoxResolution";
            this.richTextBoxResolution.Size = new System.Drawing.Size(624, 387);
            this.richTextBoxResolution.TabIndex = 2;
            this.richTextBoxResolution.Text = "";
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
            this.listBoxErrors.Size = new System.Drawing.Size(955, 116);
            this.listBoxErrors.TabIndex = 0;
            // 
            // errorProviderInput
            // 
            this.errorProviderInput.ContainerControl = this;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonAST;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 604);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPageTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTree)).EndInit();
            this.tabPageCNF.ResumeLayout(false);
            this.tabPageATP.ResumeLayout(false);
            this.splitContainerATP.Panel1.ResumeLayout(false);
            this.splitContainerATP.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerATP)).EndInit();
            this.splitContainerATP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonAST;
        private System.Windows.Forms.SplitContainer splitContainerOutput;
        private System.Windows.Forms.ListBox listBoxErrors;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ErrorProvider errorProviderInput;
        private System.Windows.Forms.Button buttonFNC;
        private System.Windows.Forms.PictureBox pictureBoxTree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTree;
        private System.Windows.Forms.TabPage tabPageCNF;
        private System.Windows.Forms.TabPage tabPageATP;
        private System.Windows.Forms.RichTextBox richTextBoxCNF;
        private System.Windows.Forms.TreeView treeViewTheory;
        private System.Windows.Forms.RichTextBox richTextBoxResolution;
        private System.Windows.Forms.SplitContainer splitContainerATP;
        private System.Windows.Forms.Button buttonPremisse;
        private System.Windows.Forms.Button buttonTheorem;
    }
}

