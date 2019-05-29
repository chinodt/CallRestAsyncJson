namespace TestRestAsync
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Check State";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(55, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(390, 20);
            this.txtInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "Check Operation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(464, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 46);
            this.button3.TabIndex = 4;
            this.button3.Text = "Check Devices Operation";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 46);
            this.button4.TabIndex = 5;
            this.button4.Text = "Open Sale";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 168);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 46);
            this.button5.TabIndex = 6;
            this.button5.Text = "Execute Sale/Payment";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(309, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(141, 46);
            this.button6.TabIndex = 7;
            this.button6.Text = "Cancel Sale";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(15, 116);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(141, 46);
            this.button7.TabIndex = 8;
            this.button7.Text = "Payment";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(162, 64);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(141, 46);
            this.button8.TabIndex = 9;
            this.button8.Text = "Finish Sale";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Result";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(55, 38);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(390, 20);
            this.txtResult.TabIndex = 10;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(162, 116);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(141, 46);
            this.button9.TabIndex = 12;
            this.button9.Text = "Check Levels";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 295);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button button9;
    }
}

