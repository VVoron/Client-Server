namespace Chat
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxUserName = new System.Windows.Forms.TextBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.tBoxChat = new System.Windows.Forms.TextBox();
            this.tBoxMsg = new System.Windows.Forms.TextBox();
            this.BtnSendMsg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите имя пользователя:";
            // 
            // tBoxUserName
            // 
            this.tBoxUserName.Location = new System.Drawing.Point(291, 21);
            this.tBoxUserName.Name = "tBoxUserName";
            this.tBoxUserName.Size = new System.Drawing.Size(147, 20);
            this.tBoxUserName.TabIndex = 1;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(444, 19);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(106, 23);
            this.BtnConnect.TabIndex = 2;
            this.BtnConnect.Text = "Подключиться";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // tBoxChat
            // 
            this.tBoxChat.Location = new System.Drawing.Point(47, 66);
            this.tBoxChat.Multiline = true;
            this.tBoxChat.Name = "tBoxChat";
            this.tBoxChat.Size = new System.Drawing.Size(652, 194);
            this.tBoxChat.TabIndex = 3;
            // 
            // tBoxMsg
            // 
            this.tBoxMsg.Location = new System.Drawing.Point(47, 266);
            this.tBoxMsg.Multiline = true;
            this.tBoxMsg.Name = "tBoxMsg";
            this.tBoxMsg.Size = new System.Drawing.Size(534, 23);
            this.tBoxMsg.TabIndex = 4;
            // 
            // BtnSendMsg
            // 
            this.BtnSendMsg.Location = new System.Drawing.Point(587, 266);
            this.BtnSendMsg.Name = "BtnSendMsg";
            this.BtnSendMsg.Size = new System.Drawing.Size(112, 23);
            this.BtnSendMsg.TabIndex = 5;
            this.BtnSendMsg.Text = "Отправить";
            this.BtnSendMsg.UseVisualStyleBackColor = true;
            this.BtnSendMsg.Click += new System.EventHandler(this.BtnSendMsg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 311);
            this.Controls.Add(this.BtnSendMsg);
            this.Controls.Add(this.tBoxMsg);
            this.Controls.Add(this.tBoxChat);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.tBoxUserName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxUserName;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox tBoxChat;
        private System.Windows.Forms.TextBox tBoxMsg;
        private System.Windows.Forms.Button BtnSendMsg;
    }
}

