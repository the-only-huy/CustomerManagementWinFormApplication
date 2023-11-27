namespace DemoSearchCustomer
{
    partial class frmCustomer
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
            panel1 = new Panel();
            lblTitle = new Label();
            panel2 = new Panel();
            btnClose = new Button();
            btnSave = new Button();
            lblCustomerID = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtCustomerID = new TextBox();
            txtFullName = new TextBox();
            txtEmailAddress = new TextBox();
            txtPassword = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(795, 89);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(352, 36);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(90, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer Form";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom;
            panel2.Controls.Add(btnClose);
            panel2.Controls.Add(btnSave);
            panel2.Location = new Point(1, 349);
            panel2.Name = "panel2";
            panel2.Size = new Size(795, 100);
            panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(597, 45);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(107, 45);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Location = new Point(44, 126);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(73, 15);
            lblCustomerID.TabIndex = 2;
            lblCustomerID.Text = "CustomerID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 175);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 3;
            label2.Text = "FullName:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 223);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 4;
            label3.Text = "Email Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 277);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 5;
            label4.Text = "Password:";
            // 
            // txtCustomerID
            // 
            txtCustomerID.Location = new Point(163, 123);
            txtCustomerID.Name = "txtCustomerID";
            txtCustomerID.Size = new Size(609, 23);
            txtCustomerID.TabIndex = 6;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(163, 172);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(609, 23);
            txtFullName.TabIndex = 7;
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.Location = new Point(163, 223);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.Size = new Size(609, 23);
            txtEmailAddress.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(163, 274);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(609, 23);
            txtPassword.TabIndex = 9;
            // 
            // frmCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPassword);
            Controls.Add(txtEmailAddress);
            Controls.Add(txtFullName);
            Controls.Add(txtCustomerID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblCustomerID);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmCustomer";
            Text = "frmCustomers";
            Load += frmCustomers_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lblTitle;
        private Button btnClose;
        private Button btnSave;
        private Label lblCustomerID;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtCustomerID;
        private TextBox txtFullName;
        private TextBox txtEmailAddress;
        private TextBox txtPassword;
    }
}