
namespace 联通星期五
{
    partial class UnifriLoginUC
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.unifrisrcb = new System.Windows.Forms.Button();
            this.unifripnumt = new System.Windows.Forms.TextBox();
            this.phonenuml = new System.Windows.Forms.Label();
            this.unifrircl = new System.Windows.Forms.Label();
            this.unifrircodet = new System.Windows.Forms.TextBox();
            this.logingetckb = new System.Windows.Forms.Button();
            this.closeb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // unifrisrcb
            // 
            this.unifrisrcb.Location = new System.Drawing.Point(164, 8);
            this.unifrisrcb.Name = "unifrisrcb";
            this.unifrisrcb.Size = new System.Drawing.Size(78, 23);
            this.unifrisrcb.TabIndex = 0;
            this.unifrisrcb.Text = "发送验证码";
            this.unifrisrcb.UseVisualStyleBackColor = true;
            this.unifrisrcb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Unifrisrcb_MouseDown);
            // 
            // unifripnumt
            // 
            this.unifripnumt.Location = new System.Drawing.Point(54, 9);
            this.unifripnumt.Name = "unifripnumt";
            this.unifripnumt.Size = new System.Drawing.Size(104, 21);
            this.unifripnumt.TabIndex = 1;
            // 
            // phonenuml
            // 
            this.phonenuml.AutoSize = true;
            this.phonenuml.Location = new System.Drawing.Point(1, 14);
            this.phonenuml.Name = "phonenuml";
            this.phonenuml.Size = new System.Drawing.Size(47, 12);
            this.phonenuml.TabIndex = 2;
            this.phonenuml.Text = "手机号:";
            // 
            // unifrircl
            // 
            this.unifrircl.AutoSize = true;
            this.unifrircl.Location = new System.Drawing.Point(1, 40);
            this.unifrircl.Name = "unifrircl";
            this.unifrircl.Size = new System.Drawing.Size(71, 12);
            this.unifrircl.TabIndex = 3;
            this.unifrircl.Text = "输入验证码:";
            // 
            // unifrircodet
            // 
            this.unifrircodet.Location = new System.Drawing.Point(78, 36);
            this.unifrircodet.Name = "unifrircodet";
            this.unifrircodet.Size = new System.Drawing.Size(164, 21);
            this.unifrircodet.TabIndex = 4;
            // 
            // logingetckb
            // 
            this.logingetckb.Location = new System.Drawing.Point(140, 63);
            this.logingetckb.Name = "logingetckb";
            this.logingetckb.Size = new System.Drawing.Size(102, 23);
            this.logingetckb.TabIndex = 5;
            this.logingetckb.Text = "登录取Cookie";
            this.logingetckb.UseVisualStyleBackColor = true;
            this.logingetckb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Logingetckb_MouseDown);
            // 
            // closeb
            // 
            this.closeb.Location = new System.Drawing.Point(3, 63);
            this.closeb.Name = "closeb";
            this.closeb.Size = new System.Drawing.Size(47, 23);
            this.closeb.TabIndex = 6;
            this.closeb.Text = "关闭";
            this.closeb.UseVisualStyleBackColor = true;
            this.closeb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Closeb_MouseDown);
            // 
            // unifriLoginUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.closeb);
            this.Controls.Add(this.logingetckb);
            this.Controls.Add(this.unifrircodet);
            this.Controls.Add(this.unifrircl);
            this.Controls.Add(this.phonenuml);
            this.Controls.Add(this.unifripnumt);
            this.Controls.Add(this.unifrisrcb);
            this.Name = "unifriLoginUC";
            this.Size = new System.Drawing.Size(250, 95);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button unifrisrcb;
        private System.Windows.Forms.TextBox unifripnumt;
        private System.Windows.Forms.Label phonenuml;
        private System.Windows.Forms.Label unifrircl;
        private System.Windows.Forms.TextBox unifrircodet;
        private System.Windows.Forms.Button logingetckb;
        private System.Windows.Forms.Button closeb;
    }
}
