
namespace Unifri
{
    partial class UnifriMainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.phonenuml = new System.Windows.Forms.Label();
            this.cookiet = new System.Windows.Forms.TextBox();
            this.cookiel = new System.Windows.Forms.Label();
            this.unifriaccountt = new System.Windows.Forms.TextBox();
            this.getgoodslb = new System.Windows.Forms.Button();
            this.returnmsgt = new System.Windows.Forms.TextBox();
            this.goodslv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unifritl = new System.Windows.Forms.Label();
            this.unifrit = new System.Windows.Forms.Label();
            this.manualrushb = new System.Windows.Forms.Button();
            this.returnmsgl = new System.Windows.Forms.Label();
            this.unifrietl = new System.Windows.Forms.Label();
            this.unifriett = new System.Windows.Forms.TextBox();
            this.unifriftimel = new System.Windows.Forms.Label();
            this.unifriftimet = new System.Windows.Forms.TextBox();
            this.autorushb = new System.Windows.Forms.Button();
            this.stopautob = new System.Windows.Forms.Button();
            this.bggetunifritime = new System.ComponentModel.BackgroundWorker();
            this.noticcb = new System.Windows.Forms.CheckBox();
            this.getcookieb = new System.Windows.Forms.Button();
            this.bgunifrirushonce = new System.ComponentModel.BackgroundWorker();
            this.bgunifrirushsuc = new System.ComponentModel.BackgroundWorker();
            this.timeoutt = new System.Windows.Forms.TextBox();
            this.timeoutl = new System.Windows.Forms.Label();
            this.acIdl = new System.Windows.Forms.Label();
            this.acIdt = new System.Windows.Forms.TextBox();
            this.workwxr = new System.Windows.Forms.RadioButton();
            this.barkr = new System.Windows.Forms.RadioButton();
            this.dingtalkr = new System.Windows.Forms.RadioButton();
            this.idorkeyt = new System.Windows.Forms.TextBox();
            this.blockrushcb = new System.Windows.Forms.CheckBox();
            this.captchacb = new System.Windows.Forms.CheckBox();
            this.noticpatht = new System.Windows.Forms.TextBox();
            this.bgsetcheck = new System.ComponentModel.BackgroundWorker();
            this.unifriCaptcha1 = new Unifri.UnifriCaptcha();
            this.unifriLoginUC1 = new Unifri.UnifriLoginUC();
            this.SuspendLayout();
            // 
            // phonenuml
            // 
            this.phonenuml.AutoSize = true;
            this.phonenuml.Location = new System.Drawing.Point(2, 123);
            this.phonenuml.Name = "phonenuml";
            this.phonenuml.Size = new System.Drawing.Size(44, 34);
            this.phonenuml.TabIndex = 15;
            this.phonenuml.Text = "手机号\r\n仅区分";
            // 
            // cookiet
            // 
            this.cookiet.Location = new System.Drawing.Point(60, 31);
            this.cookiet.Multiline = true;
            this.cookiet.Name = "cookiet";
            this.cookiet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cookiet.Size = new System.Drawing.Size(144, 89);
            this.cookiet.TabIndex = 1;
            // 
            // cookiel
            // 
            this.cookiel.AutoSize = true;
            this.cookiel.Location = new System.Drawing.Point(2, 34);
            this.cookiel.Name = "cookiel";
            this.cookiel.Size = new System.Drawing.Size(52, 17);
            this.cookiel.TabIndex = 14;
            this.cookiel.Text = "Cookie:";
            // 
            // unifriaccountt
            // 
            this.unifriaccountt.Location = new System.Drawing.Point(60, 132);
            this.unifriaccountt.Name = "unifriaccountt";
            this.unifriaccountt.Size = new System.Drawing.Size(144, 23);
            this.unifriaccountt.TabIndex = 2;
            // 
            // getgoodslb
            // 
            this.getgoodslb.Location = new System.Drawing.Point(5, 54);
            this.getgoodslb.Name = "getgoodslb";
            this.getgoodslb.Size = new System.Drawing.Size(49, 66);
            this.getgoodslb.TabIndex = 3;
            this.getgoodslb.Text = "获取商品列表";
            this.getgoodslb.UseVisualStyleBackColor = true;
            this.getgoodslb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Getgoods_MouseDown);
            // 
            // returnmsgt
            // 
            this.returnmsgt.BackColor = System.Drawing.SystemColors.Window;
            this.returnmsgt.ForeColor = System.Drawing.Color.Blue;
            this.returnmsgt.Location = new System.Drawing.Point(209, 254);
            this.returnmsgt.Multiline = true;
            this.returnmsgt.Name = "returnmsgt";
            this.returnmsgt.ReadOnly = true;
            this.returnmsgt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.returnmsgt.Size = new System.Drawing.Size(523, 154);
            this.returnmsgt.TabIndex = 13;
            // 
            // goodslv
            // 
            this.goodslv.CheckBoxes = true;
            this.goodslv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.goodslv.FullRowSelect = true;
            this.goodslv.GridLines = true;
            this.goodslv.HideSelection = false;
            this.goodslv.Location = new System.Drawing.Point(209, 3);
            this.goodslv.MultiSelect = false;
            this.goodslv.Name = "goodslv";
            this.goodslv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.goodslv.Size = new System.Drawing.Size(591, 228);
            this.goodslv.TabIndex = 4;
            this.goodslv.UseCompatibleStateImageBehavior = false;
            this.goodslv.View = System.Windows.Forms.View.Details;
            this.goodslv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.Goodslv_ItemChecked);
            this.goodslv.SelectedIndexChanged += new System.EventHandler(this.Goodslv_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "开始时间&状态";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "商品名称";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "商品ID";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 240;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "商品价格";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 70;
            // 
            // unifritl
            // 
            this.unifritl.AutoSize = true;
            this.unifritl.ForeColor = System.Drawing.Color.Blue;
            this.unifritl.Location = new System.Drawing.Point(3, 169);
            this.unifritl.Name = "unifritl";
            this.unifritl.Size = new System.Drawing.Size(59, 17);
            this.unifritl.TabIndex = 16;
            this.unifritl.Text = "本地时间:";
            this.unifritl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Unifritl_MouseDown);
            // 
            // unifrit
            // 
            this.unifrit.AutoSize = true;
            this.unifrit.ForeColor = System.Drawing.Color.Blue;
            this.unifrit.Location = new System.Drawing.Point(58, 169);
            this.unifrit.Name = "unifrit";
            this.unifrit.Size = new System.Drawing.Size(116, 17);
            this.unifrit.TabIndex = 17;
            this.unifrit.Text = "选择商品后显示时间";
            // 
            // manualrushb
            // 
            this.manualrushb.Location = new System.Drawing.Point(738, 329);
            this.manualrushb.Name = "manualrushb";
            this.manualrushb.Size = new System.Drawing.Size(62, 79);
            this.manualrushb.TabIndex = 5;
            this.manualrushb.Text = "手动\r\n抢购";
            this.manualrushb.UseVisualStyleBackColor = true;
            this.manualrushb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Manualrush_MouseDown);
            // 
            // returnmsgl
            // 
            this.returnmsgl.AutoSize = true;
            this.returnmsgl.ForeColor = System.Drawing.Color.Red;
            this.returnmsgl.Location = new System.Drawing.Point(206, 234);
            this.returnmsgl.Name = "returnmsgl";
            this.returnmsgl.Size = new System.Drawing.Size(59, 17);
            this.returnmsgl.TabIndex = 20;
            this.returnmsgl.Text = "返回信息:";
            // 
            // unifrietl
            // 
            this.unifrietl.AutoSize = true;
            this.unifrietl.Location = new System.Drawing.Point(2, 224);
            this.unifrietl.Name = "unifrietl";
            this.unifrietl.Size = new System.Drawing.Size(83, 17);
            this.unifrietl.TabIndex = 18;
            this.unifrietl.Text = "提前毫秒时间:";
            // 
            // unifriett
            // 
            this.unifriett.Location = new System.Drawing.Point(91, 221);
            this.unifriett.Name = "unifriett";
            this.unifriett.Size = new System.Drawing.Size(113, 23);
            this.unifriett.TabIndex = 6;
            // 
            // unifriftimel
            // 
            this.unifriftimel.AutoSize = true;
            this.unifriftimel.Location = new System.Drawing.Point(2, 254);
            this.unifriftimel.Name = "unifriftimel";
            this.unifriftimel.Size = new System.Drawing.Size(83, 17);
            this.unifriftimel.TabIndex = 19;
            this.unifriftimel.Text = "捡漏间隔毫秒:";
            // 
            // unifriftimet
            // 
            this.unifriftimet.Location = new System.Drawing.Point(91, 251);
            this.unifriftimet.Name = "unifriftimet";
            this.unifriftimet.Size = new System.Drawing.Size(113, 23);
            this.unifriftimet.TabIndex = 7;
            // 
            // autorushb
            // 
            this.autorushb.Location = new System.Drawing.Point(5, 385);
            this.autorushb.Name = "autorushb";
            this.autorushb.Size = new System.Drawing.Size(140, 23);
            this.autorushb.TabIndex = 10;
            this.autorushb.Text = "点击定时+自动捡漏";
            this.autorushb.UseVisualStyleBackColor = true;
            this.autorushb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Autorush_MouseDown);
            // 
            // stopautob
            // 
            this.stopautob.Location = new System.Drawing.Point(154, 385);
            this.stopautob.Name = "stopautob";
            this.stopautob.Size = new System.Drawing.Size(50, 23);
            this.stopautob.TabIndex = 11;
            this.stopautob.Text = "停止";
            this.stopautob.UseVisualStyleBackColor = true;
            this.stopautob.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stopauto_MouseDown);
            // 
            // bggetunifritime
            // 
            this.bggetunifritime.WorkerSupportsCancellation = true;
            this.bggetunifritime.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGGunifritime_DoWork);
            // 
            // noticcb
            // 
            this.noticcb.AutoSize = true;
            this.noticcb.Location = new System.Drawing.Point(5, 302);
            this.noticcb.Name = "noticcb";
            this.noticcb.Size = new System.Drawing.Size(123, 21);
            this.noticcb.TabIndex = 8;
            this.noticcb.Text = "勾选开启推送通知";
            this.noticcb.UseVisualStyleBackColor = true;
            // 
            // getcookieb
            // 
            this.getcookieb.Location = new System.Drawing.Point(738, 254);
            this.getcookieb.Name = "getcookieb";
            this.getcookieb.Size = new System.Drawing.Size(62, 69);
            this.getcookieb.TabIndex = 22;
            this.getcookieb.Text = "获取Cookie";
            this.getcookieb.UseVisualStyleBackColor = true;
            this.getcookieb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Getcookie_MouseDown);
            this.getcookieb.MouseEnter += new System.EventHandler(this.Getcookie_MouseEnter);
            // 
            // bgunifrirushonce
            // 
            this.bgunifrirushonce.WorkerSupportsCancellation = true;
            this.bgunifrirushonce.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGunifrirushonce_DoWork);
            // 
            // bgunifrirushsuc
            // 
            this.bgunifrirushsuc.WorkerSupportsCancellation = true;
            this.bgunifrirushsuc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGunifrirushsuc_DoWork);
            // 
            // timeoutt
            // 
            this.timeoutt.Location = new System.Drawing.Point(91, 192);
            this.timeoutt.Name = "timeoutt";
            this.timeoutt.Size = new System.Drawing.Size(113, 23);
            this.timeoutt.TabIndex = 23;
            // 
            // timeoutl
            // 
            this.timeoutl.AutoSize = true;
            this.timeoutl.Location = new System.Drawing.Point(2, 195);
            this.timeoutl.Name = "timeoutl";
            this.timeoutl.Size = new System.Drawing.Size(83, 17);
            this.timeoutl.TabIndex = 24;
            this.timeoutl.Text = "网络超时毫秒:";
            // 
            // acIdl
            // 
            this.acIdl.AutoSize = true;
            this.acIdl.Location = new System.Drawing.Point(3, 6);
            this.acIdl.Name = "acIdl";
            this.acIdl.Size = new System.Drawing.Size(36, 17);
            this.acIdl.TabIndex = 25;
            this.acIdl.Text = "acId:";
            // 
            // acIdt
            // 
            this.acIdt.Location = new System.Drawing.Point(60, 3);
            this.acIdt.Name = "acIdt";
            this.acIdt.Size = new System.Drawing.Size(144, 23);
            this.acIdt.TabIndex = 26;
            // 
            // workwxr
            // 
            this.workwxr.AutoSize = true;
            this.workwxr.Location = new System.Drawing.Point(5, 329);
            this.workwxr.Name = "workwxr";
            this.workwxr.Size = new System.Drawing.Size(74, 21);
            this.workwxr.TabIndex = 27;
            this.workwxr.Text = "企业微信";
            this.workwxr.UseVisualStyleBackColor = true;
            this.workwxr.CheckedChanged += new System.EventHandler(this.Workwxr_CheckedChanged);
            // 
            // barkr
            // 
            this.barkr.AutoSize = true;
            this.barkr.Location = new System.Drawing.Point(75, 329);
            this.barkr.Name = "barkr";
            this.barkr.Size = new System.Drawing.Size(53, 21);
            this.barkr.TabIndex = 28;
            this.barkr.Text = "Bark";
            this.barkr.UseVisualStyleBackColor = true;
            this.barkr.CheckedChanged += new System.EventHandler(this.Barkr_CheckedChanged);
            // 
            // dingtalkr
            // 
            this.dingtalkr.AutoSize = true;
            this.dingtalkr.Location = new System.Drawing.Point(123, 329);
            this.dingtalkr.Name = "dingtalkr";
            this.dingtalkr.Size = new System.Drawing.Size(86, 21);
            this.dingtalkr.TabIndex = 29;
            this.dingtalkr.Text = "钉钉机器人";
            this.dingtalkr.UseVisualStyleBackColor = true;
            this.dingtalkr.CheckedChanged += new System.EventHandler(this.Dingtalkr_CheckedChanged);
            // 
            // idorkeyt
            // 
            this.idorkeyt.Location = new System.Drawing.Point(5, 356);
            this.idorkeyt.Name = "idorkeyt";
            this.idorkeyt.Size = new System.Drawing.Size(198, 23);
            this.idorkeyt.TabIndex = 30;
            // 
            // blockrushcb
            // 
            this.blockrushcb.AutoSize = true;
            this.blockrushcb.Location = new System.Drawing.Point(5, 280);
            this.blockrushcb.Name = "blockrushcb";
            this.blockrushcb.Size = new System.Drawing.Size(99, 21);
            this.blockrushcb.TabIndex = 31;
            this.blockrushcb.Text = "黑号是否继续";
            this.blockrushcb.UseVisualStyleBackColor = true;
            // 
            // captchacb
            // 
            this.captchacb.AutoSize = true;
            this.captchacb.Location = new System.Drawing.Point(105, 280);
            this.captchacb.Name = "captchacb";
            this.captchacb.Size = new System.Drawing.Size(99, 21);
            this.captchacb.TabIndex = 32;
            this.captchacb.Text = "半黑是否验证";
            this.captchacb.UseVisualStyleBackColor = true;
            // 
            // noticpatht
            // 
            this.noticpatht.Location = new System.Drawing.Point(123, 300);
            this.noticpatht.Name = "noticpatht";
            this.noticpatht.Size = new System.Drawing.Size(81, 23);
            this.noticpatht.TabIndex = 33;
            // 
            // bgsetcheck
            // 
            this.bgsetcheck.WorkerSupportsCancellation = true;
            this.bgsetcheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGsetcheck_DoWork);
            // 
            // unifriCaptcha1
            // 
            this.unifriCaptcha1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unifriCaptcha1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unifriCaptcha1.Httpors = null;
            this.unifriCaptcha1.Location = new System.Drawing.Point(385, 90);
            this.unifriCaptcha1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.unifriCaptcha1.Name = "unifriCaptcha1";
            this.unifriCaptcha1.Size = new System.Drawing.Size(170, 82);
            this.unifriCaptcha1.TabIndex = 35;
            this.unifriCaptcha1.UnifriappId = null;
            this.unifriCaptcha1.Unifricookie = null;
            this.unifriCaptcha1.Visible = false;
            // 
            // unifriLoginUC1
            // 
            this.unifriLoginUC1.AutoScroll = true;
            this.unifriLoginUC1.AutoSize = true;
            this.unifriLoginUC1.BackColor = System.Drawing.Color.White;
            this.unifriLoginUC1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.unifriLoginUC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unifriLoginUC1.Httpors = null;
            this.unifriLoginUC1.Location = new System.Drawing.Point(322, 71);
            this.unifriLoginUC1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.unifriLoginUC1.Name = "unifriLoginUC1";
            this.unifriLoginUC1.Size = new System.Drawing.Size(287, 125);
            this.unifriLoginUC1.TabIndex = 34;
            this.unifriLoginUC1.Visible = false;
            // 
            // UnifriMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(804, 413);
            this.Controls.Add(this.unifriCaptcha1);
            this.Controls.Add(this.unifriLoginUC1);
            this.Controls.Add(this.getcookieb);
            this.Controls.Add(this.noticpatht);
            this.Controls.Add(this.captchacb);
            this.Controls.Add(this.blockrushcb);
            this.Controls.Add(this.idorkeyt);
            this.Controls.Add(this.dingtalkr);
            this.Controls.Add(this.barkr);
            this.Controls.Add(this.workwxr);
            this.Controls.Add(this.acIdt);
            this.Controls.Add(this.acIdl);
            this.Controls.Add(this.timeoutl);
            this.Controls.Add(this.timeoutt);
            this.Controls.Add(this.noticcb);
            this.Controls.Add(this.stopautob);
            this.Controls.Add(this.autorushb);
            this.Controls.Add(this.unifriftimet);
            this.Controls.Add(this.unifriftimel);
            this.Controls.Add(this.unifriett);
            this.Controls.Add(this.unifrietl);
            this.Controls.Add(this.returnmsgl);
            this.Controls.Add(this.manualrushb);
            this.Controls.Add(this.unifrit);
            this.Controls.Add(this.unifritl);
            this.Controls.Add(this.goodslv);
            this.Controls.Add(this.returnmsgt);
            this.Controls.Add(this.getgoodslb);
            this.Controls.Add(this.cookiet);
            this.Controls.Add(this.cookiel);
            this.Controls.Add(this.unifriaccountt);
            this.Controls.Add(this.phonenuml);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "UnifriMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "联通星期五";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label phonenuml;
        private System.Windows.Forms.TextBox unifriaccountt;
        private System.Windows.Forms.Label cookiel;
        private System.Windows.Forms.TextBox cookiet;
        private System.Windows.Forms.Button getgoodslb;
        private System.Windows.Forms.TextBox returnmsgt;
        private System.Windows.Forms.ListView goodslv;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label unifritl;
        private System.Windows.Forms.Label unifrit;
        private System.Windows.Forms.Button manualrushb;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label returnmsgl;
        private System.Windows.Forms.Label unifrietl;
        private System.Windows.Forms.TextBox unifriett;
        private System.Windows.Forms.Label unifriftimel;
        private System.Windows.Forms.TextBox unifriftimet;
        private System.Windows.Forms.Button autorushb;
        private System.Windows.Forms.Button stopautob;
        private System.ComponentModel.BackgroundWorker bggetunifritime;
        private System.Windows.Forms.CheckBox noticcb;
        private System.Windows.Forms.Button getcookieb;
        private System.ComponentModel.BackgroundWorker bgunifrirushonce;
        private System.ComponentModel.BackgroundWorker bgunifrirushsuc;
        private System.Windows.Forms.TextBox timeoutt;
        private System.Windows.Forms.Label timeoutl;
        private System.Windows.Forms.Label acIdl;
        private System.Windows.Forms.TextBox acIdt;
        private System.Windows.Forms.RadioButton workwxr;
        private System.Windows.Forms.RadioButton barkr;
        private System.Windows.Forms.RadioButton dingtalkr;
        private System.Windows.Forms.TextBox idorkeyt;
        private System.Windows.Forms.CheckBox blockrushcb;
        private System.Windows.Forms.CheckBox captchacb;
        private System.Windows.Forms.TextBox noticpatht;
        private System.ComponentModel.BackgroundWorker bgsetcheck;
        private UnifriLoginUC unifriLoginUC1;
        private UnifriCaptcha unifriCaptcha1;
    }
}

