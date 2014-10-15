namespace _01WindowsFormsDataBinding
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
            this.label1 = new System.Windows.Forms.Label();
            this.carInventoryGridView = new System.Windows.Forms.DataGridView();
            this.grpbxDeleteCar = new System.Windows.Forms.GroupBox();
            this.txtCarToRemove = new System.Windows.Forms.TextBox();
            this.btnRemoveCar = new System.Windows.Forms.Button();
            this.grpbxFilterMakes = new System.Windows.Forms.GroupBox();
            this.btnDisplayMakes = new System.Windows.Forms.Button();
            this.txtMakeToView = new System.Windows.Forms.TextBox();
            this.btnChangeMakes = new System.Windows.Forms.Button();
            this.dataGridYugosView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).BeginInit();
            this.grpbxDeleteCar.SuspendLayout();
            this.grpbxFilterMakes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Here is what we have in stock";
            // 
            // carInventoryGridView
            // 
            this.carInventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carInventoryGridView.Location = new System.Drawing.Point(12, 41);
            this.carInventoryGridView.Name = "carInventoryGridView";
            this.carInventoryGridView.Size = new System.Drawing.Size(541, 184);
            this.carInventoryGridView.TabIndex = 1;
            // 
            // grpbxDeleteCar
            // 
            this.grpbxDeleteCar.Controls.Add(this.btnRemoveCar);
            this.grpbxDeleteCar.Controls.Add(this.txtCarToRemove);
            this.grpbxDeleteCar.Location = new System.Drawing.Point(16, 231);
            this.grpbxDeleteCar.Name = "grpbxDeleteCar";
            this.grpbxDeleteCar.Size = new System.Drawing.Size(263, 78);
            this.grpbxDeleteCar.TabIndex = 2;
            this.grpbxDeleteCar.TabStop = false;
            this.grpbxDeleteCar.Text = "Enter ID of Car to Delete";
            // 
            // txtCarToRemove
            // 
            this.txtCarToRemove.Location = new System.Drawing.Point(6, 31);
            this.txtCarToRemove.Name = "txtCarToRemove";
            this.txtCarToRemove.Size = new System.Drawing.Size(143, 20);
            this.txtCarToRemove.TabIndex = 0;
            // 
            // btnRemoveCar
            // 
            this.btnRemoveCar.Location = new System.Drawing.Point(167, 28);
            this.btnRemoveCar.Name = "btnRemoveCar";
            this.btnRemoveCar.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCar.TabIndex = 1;
            this.btnRemoveCar.Text = "Delete!";
            this.btnRemoveCar.UseVisualStyleBackColor = true;
            this.btnRemoveCar.Click += new System.EventHandler(this.btnRemoveCar_Click);
            // 
            // grpbxFilterMakes
            // 
            this.grpbxFilterMakes.Controls.Add(this.btnDisplayMakes);
            this.grpbxFilterMakes.Controls.Add(this.txtMakeToView);
            this.grpbxFilterMakes.Location = new System.Drawing.Point(285, 231);
            this.grpbxFilterMakes.Name = "grpbxFilterMakes";
            this.grpbxFilterMakes.Size = new System.Drawing.Size(268, 78);
            this.grpbxFilterMakes.TabIndex = 3;
            this.grpbxFilterMakes.TabStop = false;
            this.grpbxFilterMakes.Text = "Enter Make to View";
            // 
            // btnDisplayMakes
            // 
            this.btnDisplayMakes.Location = new System.Drawing.Point(167, 28);
            this.btnDisplayMakes.Name = "btnDisplayMakes";
            this.btnDisplayMakes.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayMakes.TabIndex = 1;
            this.btnDisplayMakes.Text = "View";
            this.btnDisplayMakes.UseVisualStyleBackColor = true;
            this.btnDisplayMakes.Click += new System.EventHandler(this.btnDisplayMakes_Click);
            // 
            // txtMakeToView
            // 
            this.txtMakeToView.Location = new System.Drawing.Point(6, 31);
            this.txtMakeToView.Name = "txtMakeToView";
            this.txtMakeToView.Size = new System.Drawing.Size(143, 20);
            this.txtMakeToView.TabIndex = 0;
            // 
            // btnChangeMakes
            // 
            this.btnChangeMakes.Location = new System.Drawing.Point(285, 9);
            this.btnChangeMakes.Name = "btnChangeMakes";
            this.btnChangeMakes.Size = new System.Drawing.Size(268, 23);
            this.btnChangeMakes.TabIndex = 4;
            this.btnChangeMakes.Text = "Change All BMWs to Yugos";
            this.btnChangeMakes.UseVisualStyleBackColor = true;
            this.btnChangeMakes.Click += new System.EventHandler(this.btnChangeMakes_Click);
            // 
            // dataGridYugosView
            // 
            this.dataGridYugosView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridYugosView.Location = new System.Drawing.Point(12, 346);
            this.dataGridYugosView.Name = "dataGridYugosView";
            this.dataGridYugosView.Size = new System.Drawing.Size(541, 114);
            this.dataGridYugosView.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Only Yugos";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 472);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridYugosView);
            this.Controls.Add(this.btnChangeMakes);
            this.Controls.Add(this.grpbxFilterMakes);
            this.Controls.Add(this.grpbxDeleteCar);
            this.Controls.Add(this.carInventoryGridView);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Windows Forms Data Binding";
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).EndInit();
            this.grpbxDeleteCar.ResumeLayout(false);
            this.grpbxDeleteCar.PerformLayout();
            this.grpbxFilterMakes.ResumeLayout(false);
            this.grpbxFilterMakes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView carInventoryGridView;
        private System.Windows.Forms.GroupBox grpbxDeleteCar;
        private System.Windows.Forms.Button btnRemoveCar;
        private System.Windows.Forms.TextBox txtCarToRemove;
        private System.Windows.Forms.GroupBox grpbxFilterMakes;
        private System.Windows.Forms.Button btnDisplayMakes;
        private System.Windows.Forms.TextBox txtMakeToView;
        private System.Windows.Forms.Button btnChangeMakes;
        private System.Windows.Forms.DataGridView dataGridYugosView;
        private System.Windows.Forms.Label label2;
    }
}

