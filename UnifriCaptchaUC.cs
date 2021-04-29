using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Unifri
{
    public partial class UnifriCaptcha : UserControl
    {
        public UnifriCaptcha()
        {
            InitializeComponent();
        }
        public String Httpors { get; set; }
        public String UnifriappId { get; set; }
        public String Unifricookie { get; set; }

        private Stream HttpWebGet(String url)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "Mozilla/5.0 (Linux;Android 10;GM1910) AppleWebKit/537.36(KHTML, like Gecko) "
                        + "Chrome / 83.0.4103.106 Mobile Safari/ 537.36; unicom{version: android@8.0002}";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                httpWebRequest.Headers.Add("Cookie", Unifricookie);
                httpWebRequest.Timeout = 5000;

                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream urls = httpWebResponse.GetResponseStream();
                return urls;
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("网址有概率访问不了,按确定后重新尝试...", "提示");
                return HttpWebGet(url);
            }
        }

        private void UnifriCaptcha_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Unifricaptcha();
            }
        }

        private void Unifricaptcha()
        {
            String imagep = Httpors + "act.10010.com/riskService?appId=" + UnifriappId + "&method=send&riskCode=image";
            Stream imageps = HttpWebGet(imagep);

            String imagepr;
            using (StreamReader StreamReader = new StreamReader(imageps))
            {
                imagepr = StreamReader.ReadToEnd();
            }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Dictionary<String, Object> imageprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(imagepr);
            String imageUrl = imageprd["imageUrl"].ToString().Replace("\\", "");
            Stream images = HttpWebGet(imageUrl);

            captchap.Image = new Bitmap(images);
        }

        private void Captchab_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Captchab_Click();
            }
        }

        private void Captchab_Click()
        {
            String riskp = Httpors + "act.10010.com/riskService?appId=" + UnifriappId + "&method=check&riskCode=image&checkCode=" + captchat.Text + "&systemCode=19991";
            Stream riskps = HttpWebGet(riskp);

            String riskpr;
            using (StreamReader StreamReader = new StreamReader(riskps))
            {
                riskpr = StreamReader.ReadToEnd();
            }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Dictionary<String, Object> riskprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(riskpr);
            if (riskprd.TryGetValue("token", out _))
            {
                MessageBox.Show("号码已正常,可以继续抢购了", "提示");
                captchat.Text = null;
                captchap.Image = null;
                Visible = false;
            }
            else
            {
                MessageBox.Show("验证码出错,按确定后重新获取再输入", "提示");
                captchap.Image = null;
                Unifricaptcha();
            }
        }
    }
}
