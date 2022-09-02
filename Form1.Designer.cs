namespace LifeInsuranceForm
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
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtMI = new System.Windows.Forms.TextBox();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gboInformation = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCoverageAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.gboDiscount = new System.Windows.Forms.GroupBox();
            this.rdoNone = new System.Windows.Forms.RadioButton();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rdoFlatRate = new System.Windows.Forms.RadioButton();
            this.rdoPercentage = new System.Windows.Forms.RadioButton();
            this.gboPolicy = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblRisk = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.gboInformation.SuspendLayout();
            this.gboDiscount.SuspendLayout();
            this.gboPolicy.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(41, 16);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(100, 23);
            this.txtFirst.TabIndex = 0;
            // 
            // txtMI
            // 
            this.txtMI.Location = new System.Drawing.Point(230, 16);
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(100, 23);
            this.txtMI.TabIndex = 1;
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(436, 16);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(100, 23);
            this.txtLast.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "First";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "M. I.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last";
            // 
            // gboInformation
            // 
            this.gboInformation.Controls.Add(this.label7);
            this.gboInformation.Controls.Add(this.txtCoverageAmount);
            this.gboInformation.Controls.Add(this.label6);
            this.gboInformation.Controls.Add(this.label5);
            this.gboInformation.Controls.Add(this.label4);
            this.gboInformation.Controls.Add(this.txtWeight);
            this.gboInformation.Controls.Add(this.txtHeight);
            this.gboInformation.Controls.Add(this.txtAge);
            this.gboInformation.Controls.Add(this.label1);
            this.gboInformation.Controls.Add(this.label3);
            this.gboInformation.Controls.Add(this.txtFirst);
            this.gboInformation.Controls.Add(this.txtLast);
            this.gboInformation.Controls.Add(this.label2);
            this.gboInformation.Controls.Add(this.txtMI);
            this.gboInformation.Location = new System.Drawing.Point(12, 12);
            this.gboInformation.Name = "gboInformation";
            this.gboInformation.Size = new System.Drawing.Size(542, 181);
            this.gboInformation.TabIndex = 6;
            this.gboInformation.TabStop = false;
            this.gboInformation.Text = "Client Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Coverage Amount ($)";
            // 
            // txtCoverageAmount
            // 
            this.txtCoverageAmount.Location = new System.Drawing.Point(147, 129);
            this.txtCoverageAmount.Name = "txtCoverageAmount";
            this.txtCoverageAmount.Size = new System.Drawing.Size(100, 23);
            this.txtCoverageAmount.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Weight (lb)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Height (in.)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Age";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(436, 78);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(100, 23);
            this.txtWeight.TabIndex = 8;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(230, 78);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 23);
            this.txtHeight.TabIndex = 7;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(41, 78);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(100, 23);
            this.txtAge.TabIndex = 6;
            // 
            // gboDiscount
            // 
            this.gboDiscount.Controls.Add(this.rdoNone);
            this.gboDiscount.Controls.Add(this.txtAmount);
            this.gboDiscount.Controls.Add(this.label8);
            this.gboDiscount.Controls.Add(this.rdoFlatRate);
            this.gboDiscount.Controls.Add(this.rdoPercentage);
            this.gboDiscount.Location = new System.Drawing.Point(12, 199);
            this.gboDiscount.Name = "gboDiscount";
            this.gboDiscount.Size = new System.Drawing.Size(268, 83);
            this.gboDiscount.TabIndex = 7;
            this.gboDiscount.TabStop = false;
            this.gboDiscount.Text = "Discount (optional)";
            // 
            // rdoNone
            // 
            this.rdoNone.AutoSize = true;
            this.rdoNone.Location = new System.Drawing.Point(100, 47);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new System.Drawing.Size(54, 19);
            this.rdoNone.TabIndex = 12;
            this.rdoNone.TabStop = true;
            this.rdoNone.Text = "None";
            this.rdoNone.UseVisualStyleBackColor = true;
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Location = new System.Drawing.Point(157, 21);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 23);
            this.txtAmount.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Amount";
            // 
            // rdoFlatRate
            // 
            this.rdoFlatRate.AutoSize = true;
            this.rdoFlatRate.Location = new System.Drawing.Point(6, 47);
            this.rdoFlatRate.Name = "rdoFlatRate";
            this.rdoFlatRate.Size = new System.Drawing.Size(70, 19);
            this.rdoFlatRate.TabIndex = 9;
            this.rdoFlatRate.TabStop = true;
            this.rdoFlatRate.Text = "Flat Rate";
            this.rdoFlatRate.UseVisualStyleBackColor = true;
            // 
            // rdoPercentage
            // 
            this.rdoPercentage.AutoSize = true;
            this.rdoPercentage.Location = new System.Drawing.Point(6, 22);
            this.rdoPercentage.Name = "rdoPercentage";
            this.rdoPercentage.Size = new System.Drawing.Size(84, 19);
            this.rdoPercentage.TabIndex = 8;
            this.rdoPercentage.TabStop = true;
            this.rdoPercentage.Text = "Percentage";
            this.rdoPercentage.UseVisualStyleBackColor = true;
            // 
            // gboPolicy
            // 
            this.gboPolicy.Controls.Add(this.lblDiscount);
            this.gboPolicy.Controls.Add(this.lblTotal);
            this.gboPolicy.Controls.Add(this.label10);
            this.gboPolicy.Controls.Add(this.lblSub);
            this.gboPolicy.Controls.Add(this.lblRisk);
            this.gboPolicy.Location = new System.Drawing.Point(12, 288);
            this.gboPolicy.Name = "gboPolicy";
            this.gboPolicy.Size = new System.Drawing.Size(268, 136);
            this.gboPolicy.TabIndex = 8;
            this.gboPolicy.TabStop = false;
            this.gboPolicy.Text = "Policy Information";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(35, 103);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 15);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Tax (0.06) : ";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Location = new System.Drawing.Point(11, 58);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(61, 15);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Sub Total :";
            // 
            // lblRisk
            // 
            this.lblRisk.AutoSize = true;
            this.lblRisk.Location = new System.Drawing.Point(6, 19);
            this.lblRisk.Name = "lblRisk";
            this.lblRisk.Size = new System.Drawing.Size(73, 15);
            this.lblRisk.TabIndex = 0;
            this.lblRisk.Text = "Risk Factor : ";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(297, 206);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(236, 34);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Get Policy";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(297, 246);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(236, 34);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(13, 73);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(63, 15);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "Discount : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 441);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.gboPolicy);
            this.Controls.Add(this.gboDiscount);
            this.Controls.Add(this.gboInformation);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gboInformation.ResumeLayout(false);
            this.gboInformation.PerformLayout();
            this.gboDiscount.ResumeLayout(false);
            this.gboDiscount.PerformLayout();
            this.gboPolicy.ResumeLayout(false);
            this.gboPolicy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtFirst;
        private TextBox txtMI;
        private TextBox txtLast;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox gboInformation;
        private Label label7;
        private TextBox txtCoverageAmount;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtWeight;
        private TextBox txtHeight;
        private TextBox txtAge;
        private GroupBox gboDiscount;
        private TextBox txtAmount;
        private Label label8;
        private RadioButton rdoFlatRate;
        private RadioButton rdoPercentage;
        private GroupBox gboPolicy;
        private Label lblTotal;
        private Label label10;
        private Label lblSub;
        private Label lblRisk;
        private Button btnSubmit;
        private Button btnClear;
        private RadioButton rdoNone;
        private Label lblDiscount;
    }
}