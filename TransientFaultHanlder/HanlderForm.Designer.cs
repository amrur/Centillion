namespace TransientFaultHanlder
{
    partial class HanlderForm
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
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPollyRetry = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCircuitBreaker = new System.Windows.Forms.Button();
            this.btnPollyWaitRetryDiff = new System.Windows.Forms.Button();
            this.btnPollyWaitRetry = new System.Windows.Forms.Button();
            this.btnPollyWaitRetryHandleResult = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWaitTime = new System.Windows.Forms.MaskedTextBox();
            this.txtRetryCount = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 19;
            this.lstLog.Location = new System.Drawing.Point(12, 152);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1131, 460);
            this.lstLog.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1027, 32);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 47);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPollyRetry
            // 
            this.btnPollyRetry.Location = new System.Drawing.Point(14, 30);
            this.btnPollyRetry.Name = "btnPollyRetry";
            this.btnPollyRetry.Size = new System.Drawing.Size(74, 37);
            this.btnPollyRetry.TabIndex = 3;
            this.btnPollyRetry.Text = "Retry";
            this.btnPollyRetry.UseVisualStyleBackColor = true;
            this.btnPollyRetry.Click += new System.EventHandler(this.btnPollyRetry_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCircuitBreaker);
            this.groupBox1.Controls.Add(this.btnPollyWaitRetryDiff);
            this.groupBox1.Controls.Add(this.btnPollyWaitRetry);
            this.groupBox1.Controls.Add(this.btnPollyWaitRetryHandleResult);
            this.groupBox1.Controls.Add(this.btnPollyRetry);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 85);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Polly ( Retry - RetryForever, WaitAndRetry, WaitAndRetryForever)";
            // 
            // btnCircuitBreaker
            // 
            this.btnCircuitBreaker.Location = new System.Drawing.Point(575, 30);
            this.btnCircuitBreaker.Name = "btnCircuitBreaker";
            this.btnCircuitBreaker.Size = new System.Drawing.Size(114, 37);
            this.btnCircuitBreaker.TabIndex = 7;
            this.btnCircuitBreaker.Text = "Circuit Breaker";
            this.btnCircuitBreaker.UseVisualStyleBackColor = true;
            this.btnCircuitBreaker.Click += new System.EventHandler(this.btnCircuitBreaker_Click);
            // 
            // btnPollyWaitRetryDiff
            // 
            this.btnPollyWaitRetryDiff.Location = new System.Drawing.Point(390, 30);
            this.btnPollyWaitRetryDiff.Name = "btnPollyWaitRetryDiff";
            this.btnPollyWaitRetryDiff.Size = new System.Drawing.Size(167, 37);
            this.btnPollyWaitRetryDiff.TabIndex = 6;
            this.btnPollyWaitRetryDiff.Text = "Wait Retry (Diff Wait)";
            this.btnPollyWaitRetryDiff.UseVisualStyleBackColor = true;
            this.btnPollyWaitRetryDiff.Click += new System.EventHandler(this.btnPollyWaitRetryDiff_Click);
            // 
            // btnPollyWaitRetry
            // 
            this.btnPollyWaitRetry.Location = new System.Drawing.Point(94, 30);
            this.btnPollyWaitRetry.Name = "btnPollyWaitRetry";
            this.btnPollyWaitRetry.Size = new System.Drawing.Size(90, 37);
            this.btnPollyWaitRetry.TabIndex = 5;
            this.btnPollyWaitRetry.Text = "Wait Retry";
            this.btnPollyWaitRetry.UseVisualStyleBackColor = true;
            this.btnPollyWaitRetry.Click += new System.EventHandler(this.btnPollyWaitRetry_Click);
            // 
            // btnPollyWaitRetryHandleResult
            // 
            this.btnPollyWaitRetryHandleResult.Location = new System.Drawing.Point(192, 30);
            this.btnPollyWaitRetryHandleResult.Name = "btnPollyWaitRetryHandleResult";
            this.btnPollyWaitRetryHandleResult.Size = new System.Drawing.Size(192, 37);
            this.btnPollyWaitRetryHandleResult.TabIndex = 4;
            this.btnPollyWaitRetryHandleResult.Text = "Wait Retry (Handle Result)";
            this.btnPollyWaitRetryHandleResult.UseVisualStyleBackColor = true;
            this.btnPollyWaitRetryHandleResult.Click += new System.EventHandler(this.btnPollyWaitRetryHandleResult_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Retry Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Wait Time (sec)";
            // 
            // txtWaitTime
            // 
            this.txtWaitTime.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaitTime.Location = new System.Drawing.Point(346, 110);
            this.txtWaitTime.Mask = "00";
            this.txtWaitTime.Name = "txtWaitTime";
            this.txtWaitTime.PromptChar = ' ';
            this.txtWaitTime.Size = new System.Drawing.Size(51, 33);
            this.txtWaitTime.TabIndex = 9;
            this.txtWaitTime.Text = "01";
            this.txtWaitTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRetryCount
            // 
            this.txtRetryCount.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetryCount.Location = new System.Drawing.Point(134, 110);
            this.txtRetryCount.Mask = "00";
            this.txtRetryCount.Name = "txtRetryCount";
            this.txtRetryCount.PromptChar = ' ';
            this.txtRetryCount.Size = new System.Drawing.Size(51, 33);
            this.txtRetryCount.TabIndex = 10;
            this.txtRetryCount.Text = "25";
            this.txtRetryCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HanlderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 622);
            this.Controls.Add(this.txtRetryCount);
            this.Controls.Add(this.txtWaitTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lstLog);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HanlderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transient Fault Hanlder";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPollyRetry;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPollyWaitRetryHandleResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtWaitTime;
        private System.Windows.Forms.MaskedTextBox txtRetryCount;
        private System.Windows.Forms.Button btnPollyWaitRetry;
        private System.Windows.Forms.Button btnPollyWaitRetryDiff;
        private System.Windows.Forms.Button btnCircuitBreaker;
    }
}

