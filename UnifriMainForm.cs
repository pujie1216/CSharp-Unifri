using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;   //需要先引用System.Web.Extensions
using System.Windows.Forms;

namespace Unifri
{

    public partial class UnifriMainForm : Form
    {

        public UnifriMainForm()
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);   //调用程序图标为窗体图标,减少图标存放量,从而减少程序体积
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;   //忽略跨线程错误
            if (File.Exists("联通星期五.set"))
            {
                String[] lines = File.ReadAllLines("联通星期五.set");
                if (lines.Length == 13)
                {
                    acIdt.Text = lines[3];
                    cookiet.Text = lines[9];
                    unifriaccountt.Text = lines[6];
                    noticpatht.Text = lines[12];
                    bgsetcheck.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("联通星期五.set的行数不对哦", "提示");
                    acIdt.Text = "Paste the acId";
                    cookiet.Text = "Paste the Cookie";
                    unifriaccountt.Text = "Unifri1";
                    noticpatht.Text = ".";
                }
            }
            else
            {
                acIdt.Text = "Paste the acId";
                cookiet.Text = "Paste the Cookie";
                unifriaccountt.Text = "Unifri1";
                noticpatht.Text = ".";
            }
            String noticset = noticpatht.Text + "\\notic.set";
            if (File.Exists(noticset))
            {
                if (File.ReadAllLines(noticset)[4] == "0")
                {
                    workwxr.Checked = false;
                    barkr.Checked = false;
                    dingtalkr.Checked = false;
                    idorkeyt.Text = "没有选择推送通知哦";
                }
                else if (File.ReadAllLines(noticset)[4] == "1")
                {
                    workwxr.Checked = true;
                }
                else if (File.ReadAllLines(noticset)[4] == "2")
                {
                    barkr.Checked = true;
                }
                else if (File.ReadAllLines(noticset)[4] == "3")
                {
                    dingtalkr.Checked = true;
                }
            }
            else
            {
                idorkeyt.Text = "没有 notic.set 文件,自行填写对应选择的所需ID或Key哦";
            }
            unifriaccountt.Text = "Unifri1";
            timeoutt.Text = "2000";
            unifriett.Text = "0";
            unifriftimet.Text = "5000";
            if (Convert.ToDouble(Environment.OSVersion.Version.ToString().Substring(0, 3)) < 6.1)
            {
                MessageBox.Show("Win7以下的系统请自行打开Github查看是否有更新", "提示");
            }
            else
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;   //解决访问Tls1.2协议的网址,否则会出错
                Versioncheck();
            }
        }

        private static String Httpors()   //判断系统是否为Win7以下,因为Win7以下可能会存在https问题
        {
            OperatingSystem os = Environment.OSVersion;
            String httpors;
            if (Convert.ToDouble(os.Version.ToString().Substring(0, 3)) < 6.1)
            {
                httpors = "http://";
            }
            else
            {
                httpors = "https://";
            }
            return httpors;
        }

        private static String Urlresp(String url, String postdata, String cookie, Int32 timeout)
        {
            String urlp = Httpors() + url;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(urlp);
            httpWebRequest.UserAgent = "Mozilla/5.0 (Linux;Android 10;GM1910) AppleWebKit/537.36(KHTML, like Gecko) "
                + "Chrome / 83.0.4103.106 Mobile Safari/ 537.36; unicom{version: android@8.0002}";
            httpWebRequest.Timeout = timeout;
            if (cookie != null)
            {
                httpWebRequest.Headers.Add("Cookie", cookie);
            }
            if (postdata == null)
            {
                httpWebRequest.Method = "GET";
            }
            else
            {
                httpWebRequest.Method = "POST";
                if (postdata.Contains(":"))
                {
                    httpWebRequest.ContentType = "application/json;charset=UTF-8";
                }
                else
                {
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                }
                Byte[] bpostdata = Encoding.UTF8.GetBytes(postdata);
                httpWebRequest.ContentLength = bpostdata.Length;

                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(bpostdata, 0, bpostdata.Length);
                }
            }

            String urlpr;
            using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
            {
                using (StreamReader StreamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    urlpr = StreamReader.ReadToEnd();
                }
            }
            return urlpr;
        }

        private void Versioncheck()
        {
            try
            {
                Version versionnow = new Version(Application.ProductVersion);
                String versionp = "raw.githubusercontent.com/pujie1216/CSharp-Unifri/main/version.json";
                String versionpr = Urlresp(versionp, null, null, 5000);
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                Dictionary<String, Object> versionprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(versionpr);
                Version versionnew = new Version(versionprd["version"].ToString());
                if (versionnew > versionnow)
                {
                    DialogResult dialogResult = MessageBox.Show("更新内容为:\r\n" + versionprd["changelog"].ToString() + "\r\n是否去GitHub查看更新", "检测到新版本", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://github.com/pujie1216/CSharp-Unifri");
                        System.Environment.Exit(0);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("访问GitHub出错,跳过检测更新", err.Message);
            }
        }

        private void BGsetcheck_DoWork(object sender, DoWorkEventArgs e)
        {
            SetCheck();
        }

        private void SetCheck()
        {
            Byte[] setsha1bnow;
            using (Stream stream = new FileStream("联通星期五.set", FileMode.Open))
            {
                setsha1bnow = SHA1.Create().ComputeHash(stream);
            }
            DateTime tenmins = DateTime.Now.AddMinutes(10);
            while (true)
            {
                DateTime dateTime = DateTime.Now;
                if (dateTime < tenmins)
                {
                    Byte[] setsha1bnew;
                    using (Stream stream = new FileStream("联通星期五.set", FileMode.Open))
                    {
                        setsha1bnew = SHA1.Create().ComputeHash(stream);
                    }
                    if (BitConverter.ToString(setsha1bnew) == BitConverter.ToString(setsha1bnow))
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("检测到set文件有更改,是否重新载入set文件数据?", "提示", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            String[] lines = File.ReadAllLines("联通星期五.set");
                            acIdt.Text = lines[3];
                            cookiet.Text = lines[9];
                            unifriaccountt.Text = lines[6];
                            noticpatht.Text = lines[12];
                        }
                        using (Stream stream = new FileStream("联通星期五.set", FileMode.Open))
                        {
                            setsha1bnow = SHA1.Create().ComputeHash(stream);
                        }
                    }
                }
                else
                {
                    bgsetcheck.CancelAsync();
                    break;
                }
            }
        }

        private void Getgoods_MouseDown(object sender, MouseEventArgs e)   //定义仅鼠标左键点击
        {
            if (e.Button == MouseButtons.Left)
            {
                Getgoods_Click();
            }
        }

        private void Getgoods_Click()   //获取商品列表的按钮事件
        {
            try
            {
                Dictionary<Int32, String> unifristate = new Dictionary<Int32, String>()
            {
                {00,"未开始"},
                {10,"抢购"},
                {20,"查看"},
                {30,"无法抢购"},
                {40,"抢光"},
                {50,"待支付"},
                {60,"处理中"}
            };

                //访问活动页面
                String unifrigoodsp = "m.client.10010.com/welfare-mall-front-activity/super/five/get619Activity/v1?acId=" + acIdt.Text;
                String unifricookie = cookiet.Text;
                String unifrigoodspr = Urlresp(unifrigoodsp, null, unifricookie, 5000);
                //获取到JSON结果,调用内置JavaScriptSerializer解析,使用Newtonsoft.Json方便一些,但是需要Nuget包,不是频繁且复杂的话处理使用内置即可
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                Dictionary<String, Object> unifrigoodsprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(unifrigoodspr);
                String unifrimsg = unifrigoodsprd["msg"].ToString();
                if (Regex.IsMatch(unifrimsg, "未登录|获取用户信息异常"))
                {
                    MessageBox.Show("联通登录状态失效了,请重新获取Cookie", unifrimsg);
                }
                else if (unifrimsg == "查询商品信息成功")
                {
                    List<String> goodsListl = new List<string>();
                    Object resdata = unifrigoodsprd["resdata"];
                    Dictionary<String, Object> resdataD = (Dictionary<String, Object>)(resdata);
                    Object[] tabList = (Object[])resdataD["tabList"];

                    foreach (Object tabListO in tabList)
                    {
                        Dictionary<String, Object> tabListD = (Dictionary<String, Object>)(tabListO);
                        String timeNav = tabListD["timeNav"].ToString();
                        Object[] goodsList = (Object[])tabListD["goodsList"];

                        foreach (Object goodsList1L in goodsList)
                        {
                            Dictionary<String, Object> goodsListD = (Dictionary<String, Object>)(goodsList1L);
                            String goodsName = goodsListD["goodsName"].ToString();
                            String goodsId = goodsListD["goodsId"].ToString();
                            String price = goodsListD["price"].ToString();
                            if (price.Contains("."))
                            {
                                price += "0";
                            }
                            else
                            {
                                price += ".00";
                            }
                            if (!unifristate.TryGetValue(Convert.ToInt32(goodsListD["state"]), out String state))
                            {
                                state = "未知状态";
                            }
                            goodsListl.Add(timeNav);
                            goodsListl.Add(state);
                            goodsListl.Add(goodsName);
                            goodsListl.Add(goodsId);
                            goodsListl.Add(price);
                        }
                    }

                    goodslv.Items.Clear();   //每次获取都先清空原有列表,以免重复加入
                    for (Int32 goods = 0; goods < goodsListl.Count; goods += 5)
                    {
                        goodslv.Items.Add(new ListViewItem(new String[] { goodsListl[goods] + goodsListl[goods + 1],goodsListl[goods + 2],
                            goodsListl[goods + 3], goodsListl[goods + 4] }));
                    }
                }
                else
                {
                    returnmsgt.AppendText("\r\n" + unifrimsg + "   可能Cookie不对或者联通在维护");
                }
            }
            catch (System.Net.WebException err)   //异常捕获
            {
                MessageBox.Show("返回信息: " + err.Message, "网络出错了,请重新获取");
            }
            catch (System.ArgumentException err)
            {
                MessageBox.Show("返回信息: " + err.Message, "可能联通在维护升级");
            }
            catch (System.NullReferenceException err)
            {
                MessageBox.Show("返回信息: " + err.Message, "可能网络出错了,多次获取依然出错,可能联通更新代码了");
            }
        }

        private void Get_goodsinfo(out String[] goodsinfo)   //获取已选择的商品信息
        {
            goodsinfo = new String[5];
            Regex regex = new Regex("已选择商品为: (\\d+:\\d+).* (.*),商品ID为: (.*),商品价格为: (\\d+\\.\\d+)", RegexOptions.IgnoreCase);
            if (regex.IsMatch(returnmsgt.Text))
            {
                String begintime = regex.Match(returnmsgt.Text).Groups[1].Value;
                DateTime datetime = Convert.ToDateTime(begintime);
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                goodsinfo[0] = ((Int64)(datetime - startTime).TotalMilliseconds).ToString();
                goodsinfo[1] = regex.Match(returnmsgt.Text).Groups[2].Value;
                goodsinfo[2] = regex.Match(returnmsgt.Text).Groups[3].Value;
                goodsinfo[3] = regex.Match(returnmsgt.Text).Groups[4].Value;
                goodsinfo[4] = "true";
            }
            else
            {
                MessageBox.Show("请先勾选或者单击选中商品哦", "提示");
                goodsinfo[4] = "false";
            }
        }

        private void Goodslv_SelectedIndexChanged(object sender, EventArgs e)   //单击选中商品同时异步显示联通时间
        {
            if (goodslv.SelectedIndices != null && goodslv.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection s = goodslv.SelectedIndices;
                returnmsgt.Text = String.Format("已选择商品为: {0} {1},商品ID为: {2},商品价格为: {3}", goodslv.Items[s[0]].Text,
                    goodslv.Items[s[0]].SubItems[1].Text, goodslv.Items[s[0]].SubItems[2].Text, goodslv.Items[s[0]].SubItems[3].Text);
                if (!bggetunifritime.IsBusy)
                {
                    bggetunifritime.RunWorkerAsync();
                }
            }
        }

        private void Goodslv_ItemChecked(object sender, ItemCheckedEventArgs e)   //勾选商品同时异步显示联通时间
        {
            if (goodslv.CheckedIndices != null && goodslv.CheckedIndices.Count > 0)
            {
                ListView.CheckedIndexCollection c = goodslv.CheckedIndices;
                returnmsgt.Text = String.Format("已选择商品为: {0} {1},商品ID为: {2},商品价格为: {3}", goodslv.Items[c[0]].Text,
                    goodslv.Items[c[0]].SubItems[1].Text, goodslv.Items[c[0]].SubItems[2].Text, goodslv.Items[c[0]].SubItems[3].Text);
                if (!bggetunifritime.IsBusy)
                {
                    bggetunifritime.RunWorkerAsync();
                }
            }
        }

        private void BGGunifritime_DoWork(object sender, DoWorkEventArgs e)   //异步调用 获取时间
        {
            while (!bggetunifritime.CancellationPending)
            {
                Get_goodsinfo(out String[] goodsinfo);
                if (Convert.ToBoolean(goodsinfo[4]))
                {
                    Get_Time(out _);
                }
            }
        }

        private void Unifritl_MouseDown(object sender, MouseEventArgs e)   //点击时间标签切换时间源
        {
            if (e.Button == MouseButtons.Left)
            {
                if (unifritl.Text == "联通时间:")
                {
                    unifritl.Text = "本地时间:";
                }
                else
                {
                    unifritl.Text = "联通时间:";
                }
            }
        }

        private void Get_Time(out Int64 currentTime)   //获取时间并返回该值
        {
            currentTime = 0;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            Get_goodsinfo(out String[] goodsinfo);
            if (unifritl.Text == "联通时间:")
            {
                try
                {
                    String unifritimep = "m.client.10010.com/welfare-mall-front-activity/mobile/activity/getCurrentTimeMillis/v2";
                    String unifritimepr = Urlresp(unifritimep, null, null, 2000);
                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    Dictionary<String, Object> unifritimeprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(unifritimepr);
                    Object resdata = unifritimeprd["resdata"];
                    Dictionary<String, Object> resdataD = (Dictionary<String, Object>)(resdata);
                    currentTime = Int64.Parse(resdataD["currentTime"].ToString());
                }
                catch (System.Net.WebException)
                {
                    Get_Time(out currentTime);
                }
                catch (System.NullReferenceException)
                {
                    Get_Time(out currentTime);
                }
            }
            else if (unifritl.Text == "本地时间:")
            {
                currentTime = (DateTime.Now.Ticks - startTime.Ticks) / 10000;
            }
            if (String.Compare(startTime.AddMilliseconds(currentTime).ToString("HH:mm:ss.fff"), startTime.Add(TimeSpan.FromMilliseconds(Double.Parse(goodsinfo[0]))).AddMinutes(-1).ToString("HH:mm:ss.fff")) < 0 ||
                String.Compare(startTime.AddMilliseconds(currentTime).ToString("HH:mm:ss.fff"), startTime.Add(TimeSpan.FromMilliseconds(Double.Parse(goodsinfo[0]))).AddSeconds(3).ToString("HH:mm:ss.fff")) > 0)
            {
                System.Threading.Thread.Sleep(1000);
                unifrit.Text = startTime.AddMilliseconds(currentTime).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                System.Threading.Thread.Sleep(10);
                unifrit.Text = startTime.AddMilliseconds(currentTime).ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
        }

        private void Get_Order(out String ordermsg)   //提交订单并返回下单状态
        {
            ordermsg = null;
            Get_goodsinfo(out String[] goodsinfo);
            if (Convert.ToBoolean(goodsinfo[4]))
            {
                String unifridata = String.Format("reqsn=&reqtime=&cliver=&reqdata=%7b%22goodsId%22%3a%22{0}%22%2c%22payWay%22%3a%2201%22%2c%22amount%22%3a%22{1}%22%2c"
                    + "%22saleTypes%22%3a%22C%22%2c%22points%22%3a%220%22%2c%22beginTime%22%3a%22{2}%22%2c%22imei%22%3a%22undefined%22%2c%22sourceChannel%22%3a%22%22%2c"
                    + "%22proFlag%22%3a%22%22%2c%22scene%22%3a%22%22%2c%22pormoterCode%22%3a%22%22%2c%22sign%22%3a%22%22%2c%22oneid%22%3a%22%22%2c%22twoid%22%3a%22%22%2c"
                    + "%22threeid%22%3a%22%22%2c%22maxcash%22%3a%22%22%2c%22floortype%22%3a%22undefined%22%2c%22FLSC_PREFECTURE%22%3a%22SUPER_FRIDAY%22%2c%22launchId%22%3a%22%22%2C%22platAcId%22%3A%22{3}%22%7d",
                    goodsinfo[2], goodsinfo[3], goodsinfo[0], acIdt.Text);
                String unifriorderp = "m.client.10010.com/welfare-mall-front/mobile/api/bj2402/v1";
                String unifricookie = cookiet.Text;
                if (!Int32.TryParse(timeoutt.Text, out Int32 timeout))
                {
                    returnmsgt.AppendText("\r\n网络超时只能填写数字,已恢复默认的2000毫秒");
                    timeoutt.Text = "2000";
                    timeout = Int32.Parse(timeoutt.Text);
                }
                try
                {
                    String unifriorderpr = Urlresp(unifriorderp, unifridata, unifricookie, timeout);
                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    Dictionary<String, Object> unifriorderprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(unifriorderpr);
                    ordermsg = unifriorderprd["msg"].ToString();
                    returnmsgt.AppendText("\r\n" + ordermsg);
                    if (ordermsg == "商品信息不存在")
                    {
                        returnmsgt.AppendText("   可能未到活动当天或商品信息有更新");
                    }
                    else if (ordermsg.Contains("无法购买请稍候再试"))
                    {
                        returnmsgt.AppendText("\r\n账号可能被限制当天活动");
                    }
                    else if (Regex.IsMatch(ordermsg, "活动太火爆，请稍后再试|系统开小差了") && captchacb.Checked)
                    {
                        String message = unifriaccountt.Text + "处于半黑状态,需要过一下验证才能继续抢购哦";
                        if (noticcb.Checked)
                        {
                            Notification(message);
                        }
                        MessageBox.Show(message, "提示");
                        unifriCaptcha1.Httpors = Httpors();
                        unifriCaptcha1.UnifriappId = unifriorderprd["resdata"].ToString();
                        unifriCaptcha1.Unifricookie = unifricookie;
                        unifriCaptcha1.Visible = true;
                    }
                    if (ordermsg == "下单成功")
                    {
                        String message = "   请尽快在30分钟内支付,逾期将失效哦";
                        returnmsgt.AppendText(message);
                        if (noticcb.Checked)
                        {
                            Notification(unifriaccountt.Text + goodsinfo[1] + ordermsg + message);
                        }
                    }
                }
                catch (System.ArgumentException)
                {
                    returnmsgt.AppendText("可能联通例行升级中");
                    Get_Order(out ordermsg);
                }
                catch (System.Net.WebException err)
                {
                    returnmsgt.AppendText("\r\n网络出错了   " + err.Message);
                    Get_Order(out ordermsg);
                }
                catch (Exception err)
                {
                    returnmsgt.AppendText("\r\n未知错误   " + err.Message);
                    Get_Order(out ordermsg);
                }
            }
        }

        private void Unifriwaitpay(Int32 unifriwpreminded)
        {
            String unifriwpp = "m.client.10010.com/welfare-mall-front/mobile/api/bj2404/v1";
            String unifricookie = cookiet.Text;
            String unifriwpdata = "reqsn=&reqtime=&cliver=&reqdata=%7B%22orderState%22%3A%2200%22%2C%22start%22%3A%221%22%2C%22limit%22%3A10%7D";
            try
            {
                String unifriwppr = Urlresp(unifriwpp, unifriwpdata, unifricookie, 5000);
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                Dictionary<String, Object> unifriwpprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(unifriwppr);
                Object[] unifriwpresdata = (Object[])unifriwpprd["resdata"];
                if (unifriwpresdata.Length != 0)
                {
                    String message = unifriaccountt.Text + "有未支付订单,请尽快支付,逾期将失效哦";
                    returnmsgt.AppendText("\r\n" + message);
                    if (unifriwpreminded == 0 && noticcb.Checked)
                    {
                        foreach (Object o in unifriwpresdata)
                        {
                            Dictionary<String, Object> goodsd = (Dictionary<String, Object>)o;
                            Object[] goodlist = (Object[])goodsd["goodList"];
                            Dictionary<String, Object> goods0d = (Dictionary<String, Object>)goodlist[0];
                            String goodsname = goods0d["proName"].ToString();
                            Notification(unifriaccountt.Text + goodsname + "待支付,请尽快支付,逾期将失效哦");
                        }
                    }
                }
                else
                {
                    returnmsgt.AppendText("\r\n" + unifriaccountt.Text + "已查询未支付订单,但未发现有未支付订单,如有需要,请手动在APP查看");
                }
            }
            catch (System.Net.WebException err)
            {
                returnmsgt.AppendText("\r\n网络出错了   " + err.Message);
            }
            catch (System.InvalidCastException)
            {
                returnmsgt.AppendText("\r\n" + unifriaccountt.Text + "查询未支付订单出错了,可能刷新间隔过短导致限制访问一段时间,请手动查看是否有未支付订单");
            }
        }

        private void Manualrush_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Manualrush_Click();
            }
        }

        private void Manualrush_Click()   //点击按钮提交订单
        {
            Get_Order(out _);   //不引用返回值就使用下划线
            if (returnmsgt.Lines.Length > 100)
            {
                String returnmsgtline1 = returnmsgt.Lines[0];
                returnmsgt.Clear();
                returnmsgt.AppendText(returnmsgtline1);
            }
        }

        private void Autorush_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Autorush_Click();
            }
        }

        private void Autorush_Click()   //点击按钮定时+捡漏
        {
            Get_goodsinfo(out String[] goodsinfo);
            if (Convert.ToBoolean(goodsinfo[4]))
            {
                if (Int32.TryParse(unifriett.Text, out Int32 unifriet))
                {
                    Int64 unifrirt = Int64.Parse(goodsinfo[0]) - unifriet;
                    Get_Time(out Int64 currentTime);
                    if (currentTime < unifrirt)
                    {
                        returnmsgt.AppendText("\r\n如果想修改参数,请先停止后再修改,然后重新点击定时\r\n未到对应的活动时间,正在定时...");
                    }
                    DialogResult dialogResult = MessageBox.Show("\r\n一次下单不成功后是否需要自动捡漏", "提示", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (!bgunifrirushsuc.IsBusy)
                        {
                            bgunifrirushsuc.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        if (!bgunifrirushonce.IsBusy)
                        {
                            bgunifrirushonce.RunWorkerAsync();
                        }
                    }
                }
                else
                {
                    if (unifriett.Text == "")
                    {
                        returnmsgt.AppendText("\r\n定时失败");
                        unifriett.Text = "0";
                    }
                    else
                    {
                        returnmsgt.AppendText("\r\n定时失败,提前毫秒只能输入数字哦");
                    }
                }
            }
        }

        private void BGunifrirushonce_DoWork(object sender, DoWorkEventArgs e)
        {
            Get_goodsinfo(out String[] goodsinfo);
            Int64 unifrirt = Int64.Parse(goodsinfo[0]) - Int32.Parse(unifriett.Text);
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            Int64 currentTime = (Convert.ToDateTime(unifrit.Text).Ticks - startTime.Ticks) / 10000;
            while (currentTime < unifrirt && !bgunifrirushonce.CancellationPending)
            {
                System.Threading.Thread.Sleep(10);
                currentTime = (Convert.ToDateTime(unifrit.Text).Ticks - startTime.Ticks) / 10000;
            }
            if (bgunifrirushonce.IsBusy && !bgunifrirushonce.CancellationPending)
            {
                if (!returnmsgt.Text.Contains("正在下单"))
                {
                    returnmsgt.AppendText("\r\n正在下单...");
                }
                Get_Order(out _);
            }
        }

        private void BGunifrirushsuc_DoWork(object sender, DoWorkEventArgs e)
        {
            Get_goodsinfo(out String[] goodsinfo);
            Int64 unifrirt = Int64.Parse(goodsinfo[0]) - Int32.Parse(unifriett.Text);
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            Int64 currentTime = (Convert.ToDateTime(unifrit.Text).Ticks - startTime.Ticks) / 10000;
            while (currentTime < unifrirt && !bgunifrirushsuc.CancellationPending)
            {
                System.Threading.Thread.Sleep(10);
                currentTime = (Convert.ToDateTime(unifrit.Text).Ticks - startTime.Ticks) / 10000;
            }
            if (bgunifrirushsuc.IsBusy && !bgunifrirushsuc.CancellationPending)
            {
                if (!returnmsgt.Text.Contains("正在下单或捡漏"))
                {
                    returnmsgt.AppendText("\r\n正在下单或捡漏...");
                }
                if (!Int32.TryParse(unifriftimet.Text, out Int32 unifriftime))
                {
                    returnmsgt.AppendText("\r\n间隔毫秒只能填写数字,已恢复默认的5000毫秒");
                    unifriett.Text = "5000";
                    unifriftime = Int32.Parse(unifriett.Text);
                }
                Int32 unifriftimes = 1;
                Int32 unifriwpreminded = 0;
                Get_Order(out String ordermsg);
                while (ordermsg != "下单成功" && !bgunifrirushsuc.CancellationPending)
                {
                    if (unifriCaptcha1.Visible)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        unifriftimes++;
                        returnmsgt.AppendText(String.Format("\r\n没有下单成功,将在{0}毫秒后第{1}次刷新", unifriftime, unifriftimes));
                        System.Threading.Thread.Sleep(unifriftime);
                        if (!bgunifrirushsuc.CancellationPending)
                        {
                            Get_Order(out ordermsg);
                        }
                        if (returnmsgt.Lines.Length > 100)
                        {
                            String returnmsgtline1 = returnmsgt.Lines[0];
                            returnmsgt.Clear();
                            returnmsgt.AppendText(returnmsgtline1);
                        }
                        if (Regex.IsMatch(ordermsg, ".*(达到上限 | 数量限制 | 次数限制).*"))
                        {
                            bgunifrirushsuc.CancelAsync();
                            break;
                        }
                        else if (ordermsg.Contains("无法购买请稍候再试") && blockrushcb.Checked)
                        {
                            bgunifrirushsuc.CancelAsync();
                            break;
                        }
                        if (!Convert.ToBoolean(goodsinfo[4]))
                        {
                            bgunifrirushsuc.CancelAsync();
                            break;
                        }
                        if (unifriftimes % 20 == 0)
                        {
                            Unifriwaitpay(unifriwpreminded);
                            unifriwpreminded = 1;
                        }
                    }
                }
            }
        }

        private void Stopauto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Stopauto_Click();
            }
        }

        private void Stopauto_Click()   //停止定时或捡漏
        {
            if (!bgunifrirushonce.CancellationPending)
            {
                bgunifrirushonce.CancelAsync();
            }
            if (!bgunifrirushsuc.CancellationPending)
            {
                bgunifrirushsuc.CancelAsync();
            }
            if (bgunifrirushonce.CancellationPending || bgunifrirushsuc.CancellationPending)
            {
                returnmsgt.AppendText("\r\n定时或捡漏已停止");
            }
        }

        private void Getcookie_MouseEnter(object sender, EventArgs e)   //小调皮,随机移动按钮
        {
            Random random = new Random();
            Int32 getcookiebx = random.Next(0, 740);
            Int32 getcookieby = random.Next(0, 260);
            getcookieb.Location = new System.Drawing.Point(getcookiebx, getcookieby);
            mecount++;
            if (mecount > 2)   //移动次数
            {
                getcookieb.Location = new System.Drawing.Point(738, 254);
            }
        }

        private void Getcookie_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Getcookie_Click();
            }
        }

        Int32 mecount = 0;
        private void Getcookie_Click()   //点击显示登录框
        {
            unifriLoginUC1.Httpors = Httpors();
            unifriLoginUC1.Visible = true;
            mecount = 0;
        }

        private void Notification(String message)
        {
            message = String.Format("{0} {1}", DateTime.Now.ToString("HH:mm:ss"), message);
            if (workwxr.Checked)
            {
                returnmsgt.AppendText("\r\n当前使用 企业微信 推送通知");
                Workwxnotic(message);
            }
            else if (barkr.Checked)
            {
                returnmsgt.AppendText("\r\n当前使用 Bark 推送通知");
                Barknotic(message);
            }
            else if (dingtalkr.Checked)
            {
                returnmsgt.AppendText("\r\n当前使用 钉钉 推送通知");
                Dingtalknotic(message);
            }
        }

        private void Workwxnotic(String message)
        {
            String[] workwxidarr = idorkeyt.Text.Split(new char[1] { '.' });
            String corpid = workwxidarr[0];
            String corpsecret = workwxidarr[1];
            String agentid = workwxidarr[2];
            String tokenpath = noticpatht.Text + "\\workwx.token";
            String access_token;
            if (File.Exists(tokenpath))
            {
                DateTime tokencretime = new FileInfo(tokenpath).LastWriteTime;
                DateTime tokenexptime = tokencretime.AddHours(2);
                if (DateTime.Now < tokenexptime)
                {
                    returnmsgt.AppendText("\r\n企业微信的本地token还在有效期内,继续使用");
                    access_token = File.ReadAllText(tokenpath);
                }
                else
                {
                    returnmsgt.AppendText("\r\n企业微信的本地token可能已过期,正在自动重新获取");
                    access_token = GetWorkwxtoken(corpid, corpsecret);
                    if (access_token == "")
                    {
                        return;
                    }
                }
            }
            else
            {
                access_token = GetWorkwxtoken(corpid, corpsecret);
                if (access_token == "")
                {
                    return;
                }
            }
            SendWorkwxmsg(agentid, access_token, message);
        }

        private String GetWorkwxtoken(String corpid, String corpsecret)
        {
            String access_token = "";
            String gettokenp = "qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + corpid + "&corpsecret=" + corpsecret;
            String gettokenpr = Urlresp(gettokenp, null, null, 5000);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Dictionary<String, Object> gettokenprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(gettokenpr);
            if (gettokenprd["errcode"].ToString() == "0")
            {
                access_token = gettokenprd["access_token"].ToString();
                using (StreamWriter streamWriter = new StreamWriter("workwx.token"))
                {
                    streamWriter.Write(access_token);
                }
                returnmsgt.AppendText("\r\n企业微信的token已本地记录");
            }
            else
            {
                returnmsgt.AppendText("\r\n企业微信的token获取失败: " + gettokenprd["errmsg"].ToString());
            }
            return access_token;
        }

        private void SendWorkwxmsg(String agentid, String access_token, String message)
        {
            String workwxdata = String.Format("{{\"touser\":\"@all\",\"msgtype\":\"text\",\"agentid\":\"{0}\",\"text\":{{\"content\":\"{1}\"}}}}", agentid, message);
            String sendmsgp = "qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + access_token;
            String sendmsgpr = Urlresp(sendmsgp, workwxdata, null, 5000);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Dictionary<String, Object> sendmsgprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(sendmsgpr);
            if (sendmsgprd["errcode"].ToString() == "0")
            {
                returnmsgt.AppendText("\r\n企业微信的推送消息发送成功");
            }
            else
            {
                returnmsgt.AppendText("\r\n企业微信的推送消息发送失败: " + sendmsgprd["errmsg"].ToString());
            }
        }

        private void Barknotic(String message)
        {
            String barkey = idorkeyt.Text;
            String sendmsgp = String.Format("api.day.app/{0}/{1}", barkey, message);
            try
            {
                String sendmsgpr = Urlresp(sendmsgp, null, null, 5000);
                returnmsgt.AppendText("\r\nBark的推送消息已发送,如果没有收到,检查Barkey是否填写错误");
            }
            catch (Exception err)
            {
                returnmsgt.AppendText("\r\nBark的推送消息发送失败: " + err.Message);
            }
        }

        private void Dingtalknotic(String message)
        {
            String[] dingtalkkeyarr = idorkeyt.Text.Split(new char[1] { '.' });
            String keyword = dingtalkkeyarr[0];
            String access_token = dingtalkkeyarr[1];
            String dingtalkdata = String.Format("{{\"msgtype\":\"text\",\"text\":{{\"content\": \"{0}\\n{1}\"}}}}", keyword, message);
            String sendmsgp = "oapi.dingtalk.com/robot/send?access_token=" + access_token;
            String sendmsgpr = Urlresp(sendmsgp, dingtalkdata, null, 5000);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Dictionary<String, Object> sendmsgprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(sendmsgpr);
            if (sendmsgprd["errcode"].ToString() == "0")
            {
                returnmsgt.AppendText("\r\n钉钉的推送消息发送成功");
            }
            else
            {
                returnmsgt.AppendText("\r\n钉钉的推送消息发送失败: " + sendmsgprd["errmsg"].ToString());
            }
        }

        private void Workwxr_CheckedChanged(object sender, EventArgs e)
        {
            if (workwxr.Checked)
            {
                if (File.Exists(noticpatht.Text + "\\notic.set"))
                {
                    idorkeyt.Text = File.ReadAllLines(noticpatht.Text + "\\notic.set")[7];
                }
                else
                {
                    idorkeyt.Text = "按照 企业ID(cropid).应用Secret(corpsecret).应用ID(agentid) 的顺序格式覆盖填写,以 . 分隔";
                }
            }
        }

        private void Barkr_CheckedChanged(object sender, EventArgs e)
        {
            if (barkr.Checked)
            {
                if (File.Exists(noticpatht.Text + "\\notic.set"))
                {
                    idorkeyt.Text = File.ReadAllLines(noticpatht.Text + "\\notic.set")[10];
                }
                else
                {
                    idorkeyt.Text = "覆盖填写Bark应用的地址里两撇之间最长的那串字符";
                }
            }
        }

        private void Dingtalkr_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists(noticpatht.Text + "\\notic.set"))
            {
                idorkeyt.Text = File.ReadAllLines(noticpatht.Text + "\\notic.set")[13] + "." + File.ReadAllLines(noticpatht.Text + "\\notic.set")[14];
            }
            else
            {
                idorkeyt.Text = "按照 关键字.token 的顺序格式覆盖填写,因为以 . 分隔,所以关键字里不能带 .";
            }
        }
    }
}
