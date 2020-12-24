
namespace 联通星期五
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
            this.phonenumt = new System.Windows.Forms.TextBox();
            this.getgoodslb = new System.Windows.Forms.Button();
            this.outputt = new System.Windows.Forms.TextBox();
            this.goodslv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unifritl = new System.Windows.Forms.Label();
            this.unifrit = new System.Windows.Forms.Label();
            this.manualrushb = new System.Windows.Forms.Button();
            this.outputl = new System.Windows.Forms.Label();
            this.unifrietl = new System.Windows.Forms.Label();
            this.unifriett = new System.Windows.Forms.TextBox();
            this.unifriftimel = new System.Windows.Forms.Label();
            this.unifriftimet = new System.Windows.Forms.TextBox();
            this.autorushb = new System.Windows.Forms.Button();
            this.stopautob = new System.Windows.Forms.Button();
            this.bggetunifritime = new System.ComponentModel.BackgroundWorker();
            this.serverccb = new System.Windows.Forms.CheckBox();
            this.servercsckeyt = new System.Windows.Forms.TextBox();
            this.servercweb = new System.Windows.Forms.LinkLabel();
            this.getcookieb = new System.Windows.Forms.Button();
            this.bgunifrirushonce = new System.ComponentModel.BackgroundWorker();
            this.unifriLoginUC1 = new 联通星期五.UnifriLoginUC();
            this.bgunifrirushsuc = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // phonenuml
            // 
            this.phonenuml.AutoSize = true;
            this.phonenuml.Location = new System.Drawing.Point(1, 99);
            this.phonenuml.Name = "phonenuml";
            this.phonenuml.Size = new System.Drawing.Size(44, 34);
            this.phonenuml.TabIndex = 15;
            this.phonenuml.Text = "手机号\r\n 选填";
            // 
            // cookiet
            // 
            this.cookiet.Location = new System.Drawing.Point(59, 3);
            this.cookiet.Multiline = true;
            this.cookiet.Name = "cookiet";
            this.cookiet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cookiet.Size = new System.Drawing.Size(144, 89);
            this.cookiet.TabIndex = 1;
            // 
            // cookiel
            // 
            this.cookiel.AutoSize = true;
            this.cookiel.Location = new System.Drawing.Point(1, 6);
            this.cookiel.Name = "cookiel";
            this.cookiel.Size = new System.Drawing.Size(52, 17);
            this.cookiel.TabIndex = 14;
            this.cookiel.Text = "Cookie:";
            // 
            // phonenumt
            // 
            this.phonenumt.Location = new System.Drawing.Point(54, 104);
            this.phonenumt.Name = "phonenumt";
            this.phonenumt.Size = new System.Drawing.Size(144, 23);
            this.phonenumt.TabIndex = 2;
            // 
            // getgoodslb
            // 
            this.getgoodslb.Location = new System.Drawing.Point(4, 26);
            this.getgoodslb.Name = "getgoodslb";
            this.getgoodslb.Size = new System.Drawing.Size(49, 66);
            this.getgoodslb.TabIndex = 3;
            this.getgoodslb.Text = "获取商品列表";
            this.getgoodslb.UseVisualStyleBackColor = true;
            this.getgoodslb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Getgoods_MouseDown);
            // 
            // outputt
            // 
            this.outputt.BackColor = System.Drawing.SystemColors.Window;
            this.outputt.ForeColor = System.Drawing.Color.Blue;
            this.outputt.Location = new System.Drawing.Point(209, 254);
            this.outputt.Multiline = true;
            this.outputt.Name = "outputt";
            this.outputt.ReadOnly = true;
            this.outputt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputt.Size = new System.Drawing.Size(523, 92);
            this.outputt.TabIndex = 13;
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
            this.unifritl.Location = new System.Drawing.Point(1, 141);
            this.unifritl.Name = "unifritl";
            this.unifritl.Size = new System.Drawing.Size(59, 17);
            this.unifritl.TabIndex = 16;
            this.unifritl.Text = "联通时间:";
            // 
            // unifrit
            // 
            this.unifrit.AutoSize = true;
            this.unifrit.ForeColor = System.Drawing.Color.Blue;
            this.unifrit.Location = new System.Drawing.Point(56, 141);
            this.unifrit.Name = "unifrit";
            this.unifrit.Size = new System.Drawing.Size(140, 17);
            this.unifrit.TabIndex = 17;
            this.unifrit.Text = "选择商品后显示联通时间";
            // 
            // manualrushb
            // 
            this.manualrushb.Location = new System.Drawing.Point(153, 171);
            this.manualrushb.Name = "manualrushb";
            this.manualrushb.Size = new System.Drawing.Size(50, 53);
            this.manualrushb.TabIndex = 5;
            this.manualrushb.Text = "手动抢购";
            this.manualrushb.UseVisualStyleBackColor = true;
            this.manualrushb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Manualrush_MouseDown);
            // 
            // outputl
            // 
            this.outputl.AutoSize = true;
            this.outputl.ForeColor = System.Drawing.Color.Red;
            this.outputl.Location = new System.Drawing.Point(206, 234);
            this.outputl.Name = "outputl";
            this.outputl.Size = new System.Drawing.Size(59, 17);
            this.outputl.TabIndex = 20;
            this.outputl.Text = "返回信息:";
            // 
            // unifrietl
            // 
            this.unifrietl.AutoSize = true;
            this.unifrietl.Location = new System.Drawing.Point(1, 174);
            this.unifrietl.Name = "unifrietl";
            this.unifrietl.Size = new System.Drawing.Size(83, 17);
            this.unifrietl.TabIndex = 18;
            this.unifrietl.Text = "提前多少毫秒:";
            // 
            // unifriett
            // 
            this.unifriett.Location = new System.Drawing.Point(90, 171);
            this.unifriett.Name = "unifriett";
            this.unifriett.Size = new System.Drawing.Size(54, 23);
            this.unifriett.TabIndex = 6;
            // 
            // unifriftimel
            // 
            this.unifriftimel.AutoSize = true;
            this.unifriftimel.Location = new System.Drawing.Point(1, 204);
            this.unifriftimel.Name = "unifriftimel";
            this.unifriftimel.Size = new System.Drawing.Size(83, 17);
            this.unifriftimel.TabIndex = 19;
            this.unifriftimel.Text = "捡漏间隔毫秒:";
            // 
            // unifriftimet
            // 
            this.unifriftimet.Location = new System.Drawing.Point(90, 201);
            this.unifriftimet.Name = "unifriftimet";
            this.unifriftimet.Size = new System.Drawing.Size(54, 23);
            this.unifriftimet.TabIndex = 7;
            // 
            // autorushb
            // 
            this.autorushb.Location = new System.Drawing.Point(4, 295);
            this.autorushb.Name = "autorushb";
            this.autorushb.Size = new System.Drawing.Size(140, 23);
            this.autorushb.TabIndex = 10;
            this.autorushb.Text = "点击定时+自动捡漏";
            this.autorushb.UseVisualStyleBackColor = true;
            this.autorushb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Autorush_MouseDown);
            // 
            // stopautob
            // 
            this.stopautob.Location = new System.Drawing.Point(153, 295);
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
            // serverccb
            // 
            this.serverccb.AutoSize = true;
            this.serverccb.Location = new System.Drawing.Point(4, 232);
            this.serverccb.Name = "serverccb";
            this.serverccb.Size = new System.Drawing.Size(172, 21);
            this.serverccb.TabIndex = 8;
            this.serverccb.Text = "勾选开启Server酱推送通知";
            this.serverccb.UseVisualStyleBackColor = true;
            // 
            // servercsckeyt
            // 
            this.servercsckeyt.Location = new System.Drawing.Point(4, 256);
            this.servercsckeyt.Name = "servercsckeyt";
            this.servercsckeyt.Size = new System.Drawing.Size(199, 23);
            this.servercsckeyt.TabIndex = 9;
            // 
            // servercweb
            // 
            this.servercweb.AutoSize = true;
            this.servercweb.Location = new System.Drawing.Point(16, 329);
            this.servercweb.Name = "servercweb";
            this.servercweb.Size = new System.Drawing.Size(187, 17);
            this.servercweb.TabIndex = 12;
            this.servercweb.TabStop = true;
            this.servercweb.Text = "Server酱教程:http://sc.ftqq.com";
            this.servercweb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Servercweb_LinkClicked);
            // 
            // getcookieb
            // 
            this.getcookieb.Location = new System.Drawing.Point(738, 254);
            this.getcookieb.Name = "getcookieb";
            this.getcookieb.Size = new System.Drawing.Size(62, 92);
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
            // unifriLoginUC1
            // 
            this.unifriLoginUC1.BackColor = System.Drawing.Color.White;
            this.unifriLoginUC1.Httpors = null;
            this.unifriLoginUC1.Location = new System.Drawing.Point(321, 29);
            this.unifriLoginUC1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.unifriLoginUC1.Name = "unifriLoginUC1";
            this.unifriLoginUC1.Size = new System.Drawing.Size(284, 136);
            this.unifriLoginUC1.TabIndex = 23;
            this.unifriLoginUC1.Visible = false;
            // 
            // bgunifrirushsuc
            // 
            this.bgunifrirushsuc.WorkerSupportsCancellation = true;
            this.bgunifrirushsuc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGunifrirushsuc_DoWork);
            // 
            // UnifriMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(804, 351);
            this.Controls.Add(this.getcookieb);
            this.Controls.Add(this.unifriLoginUC1);
            this.Controls.Add(this.servercweb);
            this.Controls.Add(this.servercsckeyt);
            this.Controls.Add(this.serverccb);
            this.Controls.Add(this.stopautob);
            this.Controls.Add(this.autorushb);
            this.Controls.Add(this.unifriftimet);
            this.Controls.Add(this.unifriftimel);
            this.Controls.Add(this.unifriett);
            this.Controls.Add(this.unifrietl);
            this.Controls.Add(this.outputl);
            this.Controls.Add(this.manualrushb);
            this.Controls.Add(this.unifrit);
            this.Controls.Add(this.unifritl);
            this.Controls.Add(this.goodslv);
            this.Controls.Add(this.outputt);
            this.Controls.Add(this.getgoodslb);
            this.Controls.Add(this.cookiet);
            this.Controls.Add(this.cookiel);
            this.Controls.Add(this.phonenumt);
            this.Controls.Add(this.phonenuml);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "UnifriMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "联通星期五";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label phonenuml;
        private System.Windows.Forms.TextBox phonenumt;
        private System.Windows.Forms.Label cookiel;
        private System.Windows.Forms.TextBox cookiet;
        private System.Windows.Forms.Button getgoodslb;
        private System.Windows.Forms.TextBox outputt;
        private System.Windows.Forms.ListView goodslv;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label unifritl;
        private System.Windows.Forms.Label unifrit;
        private System.Windows.Forms.Button manualrushb;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label outputl;
        private System.Windows.Forms.Label unifrietl;
        private System.Windows.Forms.TextBox unifriett;
        private System.Windows.Forms.Label unifriftimel;
        private System.Windows.Forms.TextBox unifriftimet;
        private System.Windows.Forms.Button autorushb;
        private System.Windows.Forms.Button stopautob;
        private System.ComponentModel.BackgroundWorker bggetunifritime;
        private System.Windows.Forms.CheckBox serverccb;
        private System.Windows.Forms.TextBox servercsckeyt;
        private System.Windows.Forms.LinkLabel servercweb;
        private System.Windows.Forms.Button getcookieb;
        private UnifriLoginUC unifriLoginUC1;
        private System.ComponentModel.BackgroundWorker bgunifrirushonce;
        private System.ComponentModel.BackgroundWorker bgunifrirushsuc;
    }
}

