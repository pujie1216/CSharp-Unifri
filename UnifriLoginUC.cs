using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Unifri
{
    public partial class UnifriLoginUC : UserControl
    {

        public UnifriLoginUC()
        {
            InitializeComponent();
        }

        public String Httpors { get; set; }

        private void UnifriRSAEnc(ref String phoneorcode, out String porcb64str)   //使用联通公钥RSA加密
        {
            //先将PEM格式转换为XML格式
            String xmlpublickey = "<RSAKeyValue>"
               + "<Exponent>AQAB</Exponent>"
               + "<Modulus>3PgmSvWwQPSFPoGVDnOhVBru8jvVqUzQdD85oBQYfejINVq6Lw9aKmfniBeC478SlxjnSO/SUXb3vTT4UKNO/rqhkIBOIpsDZ0cezxbQka8oiBHFKGr7jbbkVaAQJuqnQdEq3LYGqhny4Cr2Rzp8E48jaowVMczHkJRAtnMxDEs=</Modulus>"
               + "</RSAKeyValue>";
            RSACryptoServiceProvider rSACrypto = new RSACryptoServiceProvider();
            rSACrypto.FromXmlString(xmlpublickey);
            Byte[] porcbytes = rSACrypto.Encrypt(Encoding.UTF8.GetBytes(phoneorcode), false);
            porcb64str = Convert.ToBase64String(porcbytes);
        }

        private void Unifrisrcb_MouseDown(object sender, MouseEventArgs e)   //定义仅鼠标左键点击
        {
            if (e.Button == MouseButtons.Left)
            {
                Unifrisrcb_Click();
            }
        }

        private void Unifrisrcb_Click()   //发送验证码
        {
            unifrircodet.Text = null;
            try
            {
                if (unifripnumt.Text.Length == 11)
                {
                    String phonenum = unifripnumt.Text;
                    UnifriRSAEnc(ref phonenum, out String porcb64str);
                    String pnum64strquo = System.Web.HttpUtility.UrlEncode(porcb64str);   //需要先引用System.Web
                    String unisrcodep = Httpors + "m.client.10010.com/mobileService/sendRadomNum.htm";
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(unisrcodep);
                    httpWebRequest.Method = "POST";
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Linux;Android 10;GM1910) AppleWebKit/537.36(KHTML, like Gecko) "
                        + "Chrome / 83.0.4103.106 Mobile Safari/ 537.36; unicom{version: android@8.0002}";
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                    String uniscdata = String.Format("mobile={0}&version=android@8.0002&keyVersion=", pnum64strquo);
                    Byte[] uniscdatab = Encoding.UTF8.GetBytes(uniscdata);
                    httpWebRequest.ContentLength = uniscdatab.Length;
                    httpWebRequest.Timeout = 2000;

                    using (Stream stream = httpWebRequest.GetRequestStream())
                    {
                        stream.Write(uniscdatab, 0, uniscdatab.Length);
                    }

                    String unisrcodepr;
                    using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {
                        using (StreamReader StreamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            unisrcodepr = StreamReader.ReadToEnd();
                        }
                    }

                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    Dictionary<String, Object> unisrcodeprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(unisrcodepr);
                    if (unisrcodeprd.TryGetValue("rsp_desc", out Object rspdesc))
                    {
                        if (rspdesc.ToString() == "验证码已发送")
                        {
                            unifrircodet.Text = null;
                            MessageBox.Show(rspdesc.ToString(), "提示");
                        }
                        else
                        {
                            unifrircodet.Text = rspdesc.ToString();
                        }
                    }
                    else
                    {
                        unifrircodet.Text = unisrcodepr + "   未知错误";
                    }
                }
                else
                {
                    unifrircodet.Text = "请输入正确的11位手机号码";
                }
            }
            catch (System.Net.WebException err)
            {
                MessageBox.Show("返回信息: " + err.Message, "网络出错了,请重新获取");
            }
        }

        private void Logingetckb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Logingetckb_Click();
            }
        }

        private void Logingetckb_Click()   //提交参数登录并获取Cookie
        {
            try
            {
                String phonenum = unifripnumt.Text;
                UnifriRSAEnc(ref phonenum, out String porcb64str);
                String pnum64strquo = System.Web.HttpUtility.UrlEncode(porcb64str);
                String unifrirc = unifrircodet.Text;
                UnifriRSAEnc(ref unifrirc, out porcb64str);
                String rcodeb64strquo = System.Web.HttpUtility.UrlEncode(porcb64str);
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                String ts = ((System.DateTime.Now.Ticks - startTime.Ticks) / 10000).ToString();
                String uuid = System.Guid.NewGuid().ToString("N");
                String uniloginp = Httpors + "m.client.10010.com/mobileService/radomLogin.htm";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uniloginp);
                httpWebRequest.Method = "POST";
                httpWebRequest.UserAgent = "Mozilla/5.0 (Linux;Android 10;GM1910) AppleWebKit/537.36(KHTML, like Gecko) "
                    + "Chrome / 83.0.4103.106 Mobile Safari/ 537.36; unicom{version: android@8.0002}";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                httpWebRequest.CookieContainer = new CookieContainer();
                String unilgdata = String.Format("yw_code=&loginStyle=0&deviceOS=android10&mobile={0}&netWay=4G&deviceCode={1}&"
                    + "isRemberPwd=true&version=android@8.0002&deviceId={1}&password={2}&keyVersion=&pip=127.0.0.1&provinceChanel=general&voice_code=&"
                    + "appId=ChinaunicomMobileBusiness&voiceoff_flag=1&deviceModel=GM1910&deviceBrand=OnePlus&timestamp={3}", pnum64strquo, uuid, rcodeb64strquo, ts);
                Byte[] unilgdatab = Encoding.UTF8.GetBytes(unilgdata);
                httpWebRequest.ContentLength = unilgdatab.Length;
                httpWebRequest.Timeout = 2000;

                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(unilgdatab, 0, unilgdatab.Length);
                }

                String uniloginpr;
                String unilogincookie = "";
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    for (int i = 0; i < httpWebResponse.Cookies.Count; i++)
                    {
                        if (httpWebResponse.Cookies[i].ToString().Contains("cw_mutual")) { }
                        else if (httpWebResponse.Cookies[i].ToString().Contains("u_account")) { }
                        else if (httpWebResponse.Cookies[i].ToString().Contains("c_mobile")) { }
                        else
                        {
                            unilogincookie += String.Format("{0};", httpWebResponse.Cookies[i].ToString());
                        }
                    }
                    using (StreamReader StreamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        uniloginpr = StreamReader.ReadToEnd();
                    }
                }

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                Dictionary<String, Object> uniloginprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(uniloginpr);
                if (uniloginprd.TryGetValue("list", out Object uniinfolist))
                {
                    Dictionary<String, Object> uniinfolistd = (Dictionary<String, Object>)((Object[])uniinfolist)[0];
                    using (StreamWriter streamWriter = new StreamWriter(uniinfolistd["num"] + " uni.cookie"))
                    {
                        streamWriter.Write(unilogincookie);
                    }
                    MessageBox.Show(String.Format("返回登录信息: {0}省 {1}市 {2}\r\nCookie已保存在当前目录的 .cookie 文件里,自行用记事本应用打开即可", uniinfolistd["proName"], uniinfolistd["cityName"], uniinfolistd["num"]));
                }
                else if (uniloginprd.TryGetValue("dsc", out Object unidsc))
                {
                    MessageBox.Show(unidsc.ToString(), "提示");
                }
                else
                {
                    MessageBox.Show(uniloginpr, "未知错误");
                }
            }
            catch (System.Net.WebException err)
            {
                MessageBox.Show("返回信息: " + err.Message, "网络出错了,请重新获取");
            }
        }

        private void Closeb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Closeb_Click();
            }
        }

        private void Closeb_Click()
        {
            unifripnumt.Text = null;
            unifrircodet.Text = null;
            Visible = false;
        }
    }
}
