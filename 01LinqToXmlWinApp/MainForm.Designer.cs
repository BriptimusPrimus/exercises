namespace _01LinqToXmlWinApp
{
    partial class MainForm
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
            this.txtInventory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpbxAddItem = new System.Windows.Forms.GroupBox();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtPetName = new System.Windows.Forms.TextBox();
            this.btnAddNewItem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMakeToLookUp = new System.Windows.Forms.TextBox();
            this.btnLookUpColors = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grpbxAddItem.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInventory
            // 
            this.txtInventory.Location = new System.Drawing.Point(25, 35);
            this.txtInventory.Multiline = true;
            this.txtInventory.Name = "txtInventory";
            this.txtInventory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInventory.Size = new System.Drawing.Size(259, 232);
            this.txtInventory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Inventory";
            // 
            // grpbxAddItem
            // 
            this.grpbxAddItem.Controls.Add(this.btnAddNewItem);
            this.grpbxAddItem.Controls.Add(this.txtPetName);
            this.grpbxAddItem.Controls.Add(this.txtColor);
            this.grpbxAddItem.Controls.Add(this.label4);
            this.grpbxAddItem.Controls.Add(this.label3);
            this.grpbxAddItem.Controls.Add(this.label2);
            this.grpbxAddItem.Controls.Add(this.txtMake);
            this.grpbxAddItem.Location = new System.Drawing.Point(322, 35);
            this.grpbxAddItem.Name = "grpbxAddItem";
            this.grpbxAddItem.Size = new System.Drawing.Size(333, 155);
            this.grpbxAddItem.TabIndex = 2;
            this.grpbxAddItem.TabStop = false;
            this.grpbxAddItem.Text = "Add Inventory Item";
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(81, 37);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(210, 20);
            this.txtMake.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Make";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pet Name";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(81, 63);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(210, 20);
            this.txtColor.TabIndex = 4;
            // 
            // txtPetName
            // 
            this.txtPetName.Location = new System.Drawing.Point(81, 89);
            this.txtPetName.Name = "txtPetName";
            this.txtPetName.Size = new System.Drawing.Size(210, 20);
            this.txtPetName.TabIndex = 5;
            // 
            // btnAddNewItem
            // 
            this.btnAddNewItem.Location = new System.Drawing.Point(171, 115);
            this.btnAddNewItem.Name = "btnAddNewItem";
            this.btnAddNewItem.Size = new System.Drawing.Size(120, 23);
            this.btnAddNewItem.TabIndex = 6;
            this.btnAddNewItem.Text = "Add";
            this.btnAddNewItem.UseVisualStyleBackColor = true;
            this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnLookUpColors);
            this.groupBox1.Controls.Add(this.txtMakeToLookUp);
            this.groupBox1.Location = new System.Drawing.Point(322, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Look up Colors for Make";
            // 
            // txtMakeToLookUp
            // 
            this.txtMakeToLookUp.Location = new System.Drawing.Point(129, 35);
            this.txtMakeToLookUp.Name = "txtMakeToLookUp";
            this.txtMakeToLookUp.Size = new System.Drawing.Size(162, 20);
            this.txtMakeToLookUp.TabIndex = 0;
            // 
            // btnLookUpColors
            // 
            this.btnLookUpColors.Location = new System.Drawing.Point(129, 61);
            this.btnLookUpColors.Name = "btnLookUpColors";
            this.btnLookUpColors.Size = new System.Drawing.Size(162, 23);
            this.btnLookUpColors.TabIndex = 1;
            this.btnLookUpColors.Text = "Look up Colors";
            this.btnLookUpColors.UseVisualStyleBackColor = true;
            this.btnLookUpColors.Click += new System.EventHandler(this.btnLookUpColors_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Make to Look Up";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 362);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbxAddItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInventory);
            this.Name = "MainForm";
            this.Text = "Fun with LINQ to XML";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpbxAddItem.ResumeLayout(false);
            this.grpbxAddItem.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInventory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpbxAddItem;
        private System.Windows.Forms.Button btnAddNewItem;
        private System.Windows.Forms.TextBox txtPetName;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLookUpColors;
        private System.Windows.Forms.TextBox txtMakeToLookUp;
    }
}

