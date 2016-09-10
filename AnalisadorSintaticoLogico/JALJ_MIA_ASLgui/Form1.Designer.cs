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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeViewResult = new System.Windows.Forms.TreeView();
            this.listBoxErrors = new System.Windows.Forms.ListBox();
            this.errorProviderInput = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.flowLayoutPanel1.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(795, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Limpar Resultados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "slice_symbol_1.png");
            this.imageList1.Images.SetKeyName(1, "slice_symbol_2.png");
            this.imageList1.Images.SetKeyName(2, "slice_symbol_3.png");
            this.imageList1.Images.SetKeyName(3, "slice_symbol_4.png");
            this.imageList1.Images.SetKeyName(4, "slice_symbol_5.png");
            this.imageList1.Images.SetKeyName(5, "slice_symbol_6.png");
            this.imageList1.Images.SetKeyName(6, "slice_symbol_7.png");
            this.imageList1.Images.SetKeyName(7, "slice_symbol_8.png");
            this.imageList1.Images.SetKeyName(8, "slice_symbol_9.png");
            this.imageList1.Images.SetKeyName(9, "slice_symbol_10.png");
            this.imageList1.Images.SetKeyName(10, "slice_symbol_11.png");
            this.imageList1.Images.SetKeyName(11, "slice_symbol_12.png");
            this.imageList1.Images.SetKeyName(12, "slice_symbol_13.png");
            this.imageList1.Images.SetKeyName(13, "slice_symbol_14.png");
            this.imageList1.Images.SetKeyName(14, "slice_symbol_15.png");
            this.imageList1.Images.SetKeyName(15, "slice_symbol_17.png");
            this.imageList1.Images.SetKeyName(16, "slice_symbol_18.png");
            this.imageList1.Images.SetKeyName(17, "slice_symbol_19.png");
            this.imageList1.Images.SetKeyName(18, "slice_symbol_20.png");
            this.imageList1.Images.SetKeyName(19, "slice_symbol_21.png");
            this.imageList1.Images.SetKeyName(20, "slice_symbol_22.png");
            this.imageList1.Images.SetKeyName(21, "slice_symbol_23.png");
            this.imageList1.Images.SetKeyName(22, "slice_symbol_24.png");
            this.imageList1.Images.SetKeyName(23, "slice_symbol_25.png");
            this.imageList1.Images.SetKeyName(24, "slice_symbol_26.png");
            this.imageList1.Images.SetKeyName(25, "slice_symbol_27.png");
            this.imageList1.Images.SetKeyName(26, "slice_symbol_28.png");
            this.imageList1.Images.SetKeyName(27, "slice_symbol_29.png");
            this.imageList1.Images.SetKeyName(28, "slice_symbol_30.png");
            this.imageList1.Images.SetKeyName(29, "slice_symbol_31.png");
            this.imageList1.Images.SetKeyName(30, "slice_symbol_33.png");
            this.imageList1.Images.SetKeyName(31, "slice_symbol_34.png");
            this.imageList1.Images.SetKeyName(32, "slice_symbol_44.png");
            this.imageList1.Images.SetKeyName(33, "slice_symbol_45.png");
            this.imageList1.Images.SetKeyName(34, "slice_symbol_46.png");
            this.imageList1.Images.SetKeyName(35, "slice_symbol_47.png");
            this.imageList1.Images.SetKeyName(36, "slice_symbol_65.png");
            this.imageList1.Images.SetKeyName(37, "slice_symbol_66.png");
            this.imageList1.Images.SetKeyName(38, "slice_symbol_67.png");
            this.imageList1.Images.SetKeyName(39, "slice_symbol_68.png");
            this.imageList1.Images.SetKeyName(40, "slice_symbol_69.png");
            this.imageList1.Images.SetKeyName(41, "slice_symbol_70.png");
            this.imageList1.Images.SetKeyName(42, "slice_symbol_71.png");
            this.imageList1.Images.SetKeyName(43, "slice_symbol_72.png");
            this.imageList1.Images.SetKeyName(44, "slice_symbol_73.png");
            this.imageList1.Images.SetKeyName(45, "slice_symbol_74.png");
            this.imageList1.Images.SetKeyName(46, "slice_symbol_75.png");
            this.imageList1.Images.SetKeyName(47, "slice_symbol_76.png");
            this.imageList1.Images.SetKeyName(48, "slice_symbol_77.png");
            this.imageList1.Images.SetKeyName(49, "slice_symbol_78.png");
            this.imageList1.Images.SetKeyName(50, "slice_symbol_79.png");
            this.imageList1.Images.SetKeyName(51, "slice_symbol_81.png");
            this.imageList1.Images.SetKeyName(52, "slice_symbol_82.png");
            this.imageList1.Images.SetKeyName(53, "slice_symbol_83.png");
            this.imageList1.Images.SetKeyName(54, "slice_symbol_84.png");
            this.imageList1.Images.SetKeyName(55, "slice_symbol_85.png");
            this.imageList1.Images.SetKeyName(56, "slice_symbol_86.png");
            this.imageList1.Images.SetKeyName(57, "slice_symbol_87.png");
            this.imageList1.Images.SetKeyName(58, "slice_symbol_88.png");
            this.imageList1.Images.SetKeyName(59, "slice_symbol_89.png");
            this.imageList1.Images.SetKeyName(60, "slice_symbol_90.png");
            this.imageList1.Images.SetKeyName(61, "slice_symbol_91.png");
            this.imageList1.Images.SetKeyName(62, "slice_symbol_92.png");
            this.imageList1.Images.SetKeyName(63, "slice_symbol_93.png");
            this.imageList1.Images.SetKeyName(64, "slice_symbol_94.png");
            this.imageList1.Images.SetKeyName(65, "slice_symbol_95.png");
            this.imageList1.Images.SetKeyName(66, "slice_symbol_97.png");
            this.imageList1.Images.SetKeyName(67, "slice_symbol_98.png");
            this.imageList1.Images.SetKeyName(68, "slice_symbol_108.png");
            this.imageList1.Images.SetKeyName(69, "slice_symbol_109.png");
            this.imageList1.Images.SetKeyName(70, "slice_symbol_110.png");
            this.imageList1.Images.SetKeyName(71, "slice_symbol_111.png");
            this.imageList1.Images.SetKeyName(72, "slice_symbol_129.png");
            this.imageList1.Images.SetKeyName(73, "slice_symbol_130.png");
            this.imageList1.Images.SetKeyName(74, "slice_symbol_131.png");
            this.imageList1.Images.SetKeyName(75, "slice_symbol_132.png");
            this.imageList1.Images.SetKeyName(76, "slice_symbol_133.png");
            this.imageList1.Images.SetKeyName(77, "slice_symbol_134.png");
            this.imageList1.Images.SetKeyName(78, "slice_symbol_135.png");
            this.imageList1.Images.SetKeyName(79, "slice_symbol_136.png");
            this.imageList1.Images.SetKeyName(80, "slice_symbol_137.png");
            this.imageList1.Images.SetKeyName(81, "slice_symbol_138.png");
            this.imageList1.Images.SetKeyName(82, "slice_symbol_139.png");
            this.imageList1.Images.SetKeyName(83, "slice_symbol_140.png");
            this.imageList1.Images.SetKeyName(84, "slice_symbol_141.png");
            this.imageList1.Images.SetKeyName(85, "slice_symbol_142.png");
            this.imageList1.Images.SetKeyName(86, "slice_symbol_143.png");
            this.imageList1.Images.SetKeyName(87, "slice_symbol_145.png");
            this.imageList1.Images.SetKeyName(88, "slice_symbol_146.png");
            this.imageList1.Images.SetKeyName(89, "slice_symbol_147.png");
            this.imageList1.Images.SetKeyName(90, "slice_symbol_148.png");
            this.imageList1.Images.SetKeyName(91, "slice_symbol_149.png");
            this.imageList1.Images.SetKeyName(92, "slice_symbol_150.png");
            this.imageList1.Images.SetKeyName(93, "slice_symbol_151.png");
            this.imageList1.Images.SetKeyName(94, "slice_symbol_152.png");
            this.imageList1.Images.SetKeyName(95, "slice_symbol_153.png");
            this.imageList1.Images.SetKeyName(96, "slice_symbol_154.png");
            this.imageList1.Images.SetKeyName(97, "slice_symbol_155.png");
            this.imageList1.Images.SetKeyName(98, "slice_symbol_156.png");
            this.imageList1.Images.SetKeyName(99, "slice_symbol_157.png");
            this.imageList1.Images.SetKeyName(100, "slice_symbol_158.png");
            this.imageList1.Images.SetKeyName(101, "slice_symbol_159.png");
            this.imageList1.Images.SetKeyName(102, "slice_symbol_161.png");
            this.imageList1.Images.SetKeyName(103, "slice_symbol_162.png");
            this.imageList1.Images.SetKeyName(104, "slice_symbol_172.png");
            this.imageList1.Images.SetKeyName(105, "slice_symbol_173.png");
            this.imageList1.Images.SetKeyName(106, "slice_symbol_174.png");
            this.imageList1.Images.SetKeyName(107, "slice_symbol_175.png");
            this.imageList1.Images.SetKeyName(108, "slice_symbol_193.png");
            this.imageList1.Images.SetKeyName(109, "slice_symbol_194.png");
            this.imageList1.Images.SetKeyName(110, "slice_symbol_195.png");
            this.imageList1.Images.SetKeyName(111, "slice_symbol_196.png");
            this.imageList1.Images.SetKeyName(112, "slice_symbol_197.png");
            this.imageList1.Images.SetKeyName(113, "slice_symbol_198.png");
            this.imageList1.Images.SetKeyName(114, "slice_symbol_199.png");
            this.imageList1.Images.SetKeyName(115, "slice_symbol_200.png");
            this.imageList1.Images.SetKeyName(116, "slice_symbol_201.png");
            this.imageList1.Images.SetKeyName(117, "slice_symbol_202.png");
            this.imageList1.Images.SetKeyName(118, "slice_symbol_203.png");
            this.imageList1.Images.SetKeyName(119, "slice_symbol_204.png");
            this.imageList1.Images.SetKeyName(120, "slice_symbol_205.png");
            this.imageList1.Images.SetKeyName(121, "slice_symbol_206.png");
            this.imageList1.Images.SetKeyName(122, "slice_symbol_207.png");
            this.imageList1.Images.SetKeyName(123, "slice_symbol_209.png");
            this.imageList1.Images.SetKeyName(124, "slice_symbol_210.png");
            this.imageList1.Images.SetKeyName(125, "slice_symbol_211.png");
            this.imageList1.Images.SetKeyName(126, "slice_symbol_212.png");
            this.imageList1.Images.SetKeyName(127, "slice_symbol_213.png");
            this.imageList1.Images.SetKeyName(128, "slice_symbol_214.png");
            this.imageList1.Images.SetKeyName(129, "slice_symbol_215.png");
            this.imageList1.Images.SetKeyName(130, "slice_symbol_216.png");
            this.imageList1.Images.SetKeyName(131, "slice_symbol_217.png");
            this.imageList1.Images.SetKeyName(132, "slice_symbol_218.png");
            this.imageList1.Images.SetKeyName(133, "slice_symbol_219.png");
            this.imageList1.Images.SetKeyName(134, "slice_symbol_220.png");
            this.imageList1.Images.SetKeyName(135, "slice_symbol_221.png");
            this.imageList1.Images.SetKeyName(136, "slice_symbol_222.png");
            this.imageList1.Images.SetKeyName(137, "slice_symbol_223.png");
            this.imageList1.Images.SetKeyName(138, "slice_symbol_225.png");
            this.imageList1.Images.SetKeyName(139, "slice_symbol_226.png");
            this.imageList1.Images.SetKeyName(140, "slice_symbol_236.png");
            this.imageList1.Images.SetKeyName(141, "slice_symbol_237.png");
            this.imageList1.Images.SetKeyName(142, "slice_symbol_238.png");
            this.imageList1.Images.SetKeyName(143, "slice_symbol_239.png");
            this.imageList1.Images.SetKeyName(144, "slice_symbol_257.png");
            this.imageList1.Images.SetKeyName(145, "slice_symbol_258.png");
            this.imageList1.Images.SetKeyName(146, "slice_symbol_259.png");
            this.imageList1.Images.SetKeyName(147, "slice_symbol_260.png");
            this.imageList1.Images.SetKeyName(148, "slice_symbol_261.png");
            this.imageList1.Images.SetKeyName(149, "slice_symbol_262.png");
            this.imageList1.Images.SetKeyName(150, "slice_symbol_263.png");
            this.imageList1.Images.SetKeyName(151, "slice_symbol_264.png");
            this.imageList1.Images.SetKeyName(152, "slice_symbol_265.png");
            this.imageList1.Images.SetKeyName(153, "slice_symbol_266.png");
            this.imageList1.Images.SetKeyName(154, "slice_symbol_267.png");
            this.imageList1.Images.SetKeyName(155, "slice_symbol_268.png");
            this.imageList1.Images.SetKeyName(156, "slice_symbol_269.png");
            this.imageList1.Images.SetKeyName(157, "slice_symbol_270.png");
            this.imageList1.Images.SetKeyName(158, "slice_symbol_271.png");
            this.imageList1.Images.SetKeyName(159, "slice_symbol_273.png");
            this.imageList1.Images.SetKeyName(160, "slice_symbol_274.png");
            this.imageList1.Images.SetKeyName(161, "slice_symbol_275.png");
            this.imageList1.Images.SetKeyName(162, "slice_symbol_276.png");
            this.imageList1.Images.SetKeyName(163, "slice_symbol_277.png");
            this.imageList1.Images.SetKeyName(164, "slice_symbol_278.png");
            this.imageList1.Images.SetKeyName(165, "slice_symbol_279.png");
            this.imageList1.Images.SetKeyName(166, "slice_symbol_280.png");
            this.imageList1.Images.SetKeyName(167, "slice_symbol_281.png");
            this.imageList1.Images.SetKeyName(168, "slice_symbol_282.png");
            this.imageList1.Images.SetKeyName(169, "slice_symbol_283.png");
            this.imageList1.Images.SetKeyName(170, "slice_symbol_284.png");
            this.imageList1.Images.SetKeyName(171, "slice_symbol_285.png");
            this.imageList1.Images.SetKeyName(172, "slice_symbol_286.png");
            this.imageList1.Images.SetKeyName(173, "slice_symbol_287.png");
            this.imageList1.Images.SetKeyName(174, "slice_symbol_289.png");
            this.imageList1.Images.SetKeyName(175, "slice_symbol_290.png");
            this.imageList1.Images.SetKeyName(176, "slice_symbol_300.png");
            this.imageList1.Images.SetKeyName(177, "slice_symbol_301.png");
            this.imageList1.Images.SetKeyName(178, "slice_symbol_302.png");
            this.imageList1.Images.SetKeyName(179, "slice_symbol_303.png");
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProviderInput;
        private System.Windows.Forms.ImageList imageList1;
    }
}

