
namespace Unifri
{
    partial class UnifriCaptcha
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
            this.captchap = new System.Windows.Forms.PictureBox();
            this.captchal = new System.Windows.Forms.Label();
            this.captchat = new System.Windows.Forms.TextBox();
            this.captchab = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.captchap)).BeginInit();
            this.SuspendLayout();
            // 
            // captchap
            // 
            this.captchap.Location = new System.Drawing.Point(93, 42);
            this.captchap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.captchap.Name = "captchap";
            this.captchap.Size = new System.Drawing.Size(70, 30);
            this.captchap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.captchap.TabIndex = 0;
            this.captchap.TabStop = false;
            // 
            // captchal
            // 
            this.captchal.AutoSize = true;
            this.captchal.Location = new System.Drawing.Point(3, 3);
            this.captchal.Name = "captchal";
            this.captchal.Size = new System.Drawing.Size(80, 34);
            this.captchal.TabIndex = 1;
            this.captchal.Text = "输入验证码:\r\n不区分大小写";
            // 
            // captchat
            // 
            this.captchat.Location = new System.Drawing.Point(93, 11);
            this.captchat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.captchat.Name = "captchat";
            this.captchat.Size = new System.Drawing.Size(70, 23);
            this.captchat.TabIndex = 2;
            // 
            // captchab
            // 
            this.captchab.Location = new System.Drawing.Point(3, 41);
            this.captchab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.captchab.Name = "captchab";
            this.captchab.Size = new System.Drawing.Size(80, 30);
            this.captchab.TabIndex = 3;
            this.captchab.Text = "确定";
            this.captchab.UseVisualStyleBackColor = true;
            this.captchab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Captchab_MouseDown);
            // 
            // UnifriCaptcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.captchab);
            this.Controls.Add(this.captchat);
            this.Controls.Add(this.captchal);
            this.Controls.Add(this.captchap);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UnifriCaptcha";
            this.Size = new System.Drawing.Size(170, 82);
            ((System.ComponentModel.ISupportInitialize)(this.captchap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox captchap;
        private System.Windows.Forms.Label captchal;
        private System.Windows.Forms.TextBox captchat;
        private System.Windows.Forms.Button captchab;
    }
}
