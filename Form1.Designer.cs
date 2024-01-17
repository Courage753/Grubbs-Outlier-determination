namespace Grubbs
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxinput = new System.Windows.Forms.TextBox();
            this.textBoxoutput = new System.Windows.Forms.TextBox();
            this.buttoncalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxinput
            // 
            this.textBoxinput.Location = new System.Drawing.Point(112, 38);
            this.textBoxinput.Multiline = true;
            this.textBoxinput.Name = "textBoxinput";
            this.textBoxinput.Size = new System.Drawing.Size(100, 329);
            this.textBoxinput.TabIndex = 0;
            // 
            // textBoxoutput
            // 
            this.textBoxoutput.Location = new System.Drawing.Point(555, 38);
            this.textBoxoutput.Multiline = true;
            this.textBoxoutput.Name = "textBoxoutput";
            this.textBoxoutput.Size = new System.Drawing.Size(100, 329);
            this.textBoxoutput.TabIndex = 1;
            // 
            // buttoncalculate
            // 
            this.buttoncalculate.Location = new System.Drawing.Point(337, 178);
            this.buttoncalculate.Name = "buttoncalculate";
            this.buttoncalculate.Size = new System.Drawing.Size(75, 23);
            this.buttoncalculate.TabIndex = 2;
            this.buttoncalculate.Text = "计算";
            this.buttoncalculate.UseVisualStyleBackColor = true;
            this.buttoncalculate.Click += new System.EventHandler(this.buttoncalculate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttoncalculate);
            this.Controls.Add(this.textBoxoutput);
            this.Controls.Add(this.textBoxinput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxinput;
        private System.Windows.Forms.TextBox textBoxoutput;
        private System.Windows.Forms.Button buttoncalculate;
    }
}

