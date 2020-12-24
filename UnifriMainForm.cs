using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;   //需要先引用System.Web.Extensions
using System.Windows.Forms;

namespace 联通星期五
{

    public partial class UnifriMainForm : Form
    {

        public UnifriMainForm()
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);   //调用程序图标为窗体图标,减少图标存放量,从而减少程序体积
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;   //忽略跨线程错误
            if (File.Exists("联通星期五.set"))
            {
                String[] lines = File.ReadAllLines("联通星期五.set");
                if (lines.Length == 7)
                {
                    cookiet.Text = lines[3];
                    servercsckeyt.Text = lines[6];
                }
                else
                {
                    MessageBox.Show("联通星期五.set的行数不对哦", "提示");
                    cookiet.Text = "Paste the Cookie";
                    servercsckeyt.Text = "Paste the SCKEY";
                }
            }
            else
            {
                cookiet.Text = "Paste the Cookie";
                servercsckeyt.Text = "Paste the SCKEY";
            }
            phonenumt.Text = "Optional";
            unifriett.Text = "0";
            unifriftimet.Text = "5000";
        }

        private static String Httpors()   //判断系统是否为Vista及以下,因为Vista及以下可能会存在https问题
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
                {00,"暂未开始"},
                {10,"立即抢购"},
                {20,"去查看"},
                {30,"无法抢购"},
                {40,"已抢光"},
                {50,"未开始"}
            };

                //访问活动页面
                String httpors = Httpors();
                String unifrigoodsp = httpors + "m.client.10010.com/welfare-mall-front-activity/mobile/activity/get619Activity/v1?whetherFriday=YES";
                String unifricookie = cookiet.Text;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(unifrigoodsp);
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "Mozilla/5.0 (Linux;Android 10;GM1910) AppleWebKit/537.36(KHTML, like Gecko) "
                    + "Chrome / 83.0.4103.106 Mobile Safari/ 537.36; unicom{version: android@8.0002}";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                httpWebRequest.Headers.Add("Cookie", unifricookie);
                httpWebRequest.Timeout = 2000;

                String unifrigoodspr;
                using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)   //using 方法自动close
                {
                    using (StreamReader StreamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        unifrigoodspr = StreamReader.ReadToEnd();
                    }
                }

                //获取到JSON结果,调用内置JavaScriptSerializer解析,使用Newtonsoft.Json方便一些,但是需要Nuget包,不是频繁且复杂的话处理使用内置即可
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                Dictionary<String, Object> unifrigoodsprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(unifrigoodspr);
                String unifrimsg = unifrigoodsprd["msg"].ToString();
                if (unifrimsg == "未登录")
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
                            String price = goodsListD["price"].ToString() + "0";
                            String state = unifristate[Convert.ToInt32(goodsListD["state"])];
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
                    outputt.AppendText("\r\n" + unifrimsg + "   可能Cookie不对或者联通在维护");
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
            if (regex.IsMatch(outputt.Text))
            {
                String begintime = regex.Match(outputt.Text).Groups[1].Value;
                DateTime datetime = Convert.ToDateTime(begintime);
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                goodsinfo[0] = ((Int64)(datetime - startTime).TotalMilliseconds).ToString();
                goodsinfo[1] = regex.Match(outputt.Text).Groups[2].Value;
                goodsinfo[2] = regex.Match(outputt.Text).Groups[3].Value;
                goodsinfo[3] = regex.Match(outputt.Text).Groups[4].Value;
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
                outputt.Text = String.Format("已选择商品为: {0} {1},商品ID为: {2},商品价格为: {3}", goodslv.Items[s[0]].Text,
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
                outputt.Text = String.Format("已选择商品为: {0} {1},商品ID为: {2},商品价格为: {3}", goodslv.Items[c[0]].Text,
                    goodslv.Items[c[0]].SubItems[1].Text, goodslv.Items[c[0]].SubItems[2].Text, goodslv.Items[c[0]].SubItems[3].Text);
                if (!bggetunifritime.IsBusy)
                {
                    bggetunifritime.RunWorkerAsync();
                }
            }
        }

        private void Get_Unifritime(out Int64 currentTime)   //获取联通时间并返回该值
        {
            try
            {
                Get_goodsinfo(out String[] goodsinfo);
                String httpors = Httpors();
                String unifritimep = httpors + "m.client.10010.com/welfare-mall-front-activity/mobile/activity/getCurrentTimeMillis/v2";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(unifritimep);
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "Mozilla/5.0 (Linux;Android 10;GM1910) AppleWebKit/537.36(KHTML, like Gecko) "
                     + "Chrome / 83.0.4103.106 Mobile Safari/ 537.36; unicom{version: android@8.0002}";
                httpWebRequest.Timeout = 2000;

                String unifritimepr;
                using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader StreamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        unifritimepr = StreamReader.ReadToEnd();
                    }
                }

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                Dictionary<String, Object> unifritimeprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(unifritimepr);
                Object resdata = unifritimeprd["resdata"];
                Dictionary<String, Object> resdataD = (Dictionary<String, Object>)(resdata);
                currentTime = Int64.Parse(resdataD["currentTime"].ToString());
                Int64 currentTimets = Int64.Parse(currentTime.ToString() + "0000");
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                TimeSpan timeSpan = new TimeSpan(currentTimets);
                if (String.Compare(startTime.Add(timeSpan).ToString("HH:mm:ss.fff"), startTime.Add(TimeSpan.FromMilliseconds(Double.Parse(goodsinfo[0]))).AddMinutes(-1).ToString("HH:mm:ss.fff")) < 0 ||
                    String.Compare(startTime.Add(timeSpan).ToString("HH:mm:ss.fff"), startTime.Add(TimeSpan.FromMilliseconds(Double.Parse(goodsinfo[0]))).AddSeconds(3).ToString("HH:mm:ss.fff")) > 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    unifrit.Text = startTime.Add(timeSpan).ToString();
                }
                else
                {
                    System.Threading.Thread.Sleep(10);
                    unifrit.Text = startTime.Add(timeSpan).ToString("yyyy-MM-dd HH:mm:ss.fff");
                }
            }
            catch (System.Net.WebException)
            {
                Get_Unifritime(out currentTime);
            }
            catch (System.NullReferenceException)
            {
                Get_Unifritime(out currentTime);
            }
        }

        private void BGGunifritime_DoWork(object sender, DoWorkEventArgs e)   //异步调用 获取联通时间
        {
            while (!bggetunifritime.CancellationPending)
            {
                Get_goodsinfo(out String[] goodsinfo);
                if (Convert.ToBoolean(goodsinfo[4]))
                {
                    Get_Unifritime(out _);
                }
            }
        }

        private void Get_Order(out String ordermsg)   //提交订单并返回下单状态
        {
            ordermsg = null;
            String reChangeNo;   //reChangeNo参数已被联通删除了,一般不用提交,只是提交了也不会出错,所以才保留的
            if (Int64.TryParse(phonenumt.Text, out Int64 phone))
            {
                if (phone.ToString().Length != 11)
                {
                    outputt.AppendText("\r\n请输入正确的11位手机号哦");
                    phonenumt.Text = "Optional";
                    return;   //判断手机号格式是否正确,不正确则停止提交订单
                }
                else
                {
                    reChangeNo = String.Format("%22reChangeNo%22%3a%22{0}%22%2c", phone.ToString());
                    if (!outputt.Text.Contains("已输入手机号"))
                    {
                        outputt.AppendText("\r\n已输入手机号为: " + phone.ToString() + " ,请自行再次确认有没有输错");
                    }
                }
            }
            else
            {
                reChangeNo = null;
            }
            Get_goodsinfo(out String[] goodsinfo);
            if (Convert.ToBoolean(goodsinfo[4]))
            {
                String unifridata = String.Format("reqsn=&reqtime=&cliver=&reqdata=%7b%22goodsId%22%3a%22{0}%22%2c%22payWay%22%3a%2201%22%2c%22amount%22%3a%22{1}%22%2c"
                    + "{2}%22saleTypes%22%3a%22C%22%2c%22points%22%3a%220%22%2c%22beginTime%22%3a%22{3}%22%2c%22imei%22%3a%22undefined%22%2c%22sourceChannel%22%3a%22%22%2c"
                    + "%22proFlag%22%3a%22%22%2c%22scene%22%3a%22%22%2c%22pormoterCode%22%3a%22%22%2c%22oneid%22%3a%22%22%2c%22twoid%22%3a%22%22%2c"
                    + "%22threeid%22%3a%22%22%2c%22maxcash%22%3a%22%22%2c%22floortype%22%3a%22undefined%22%2c%22launchId%22%3a%22%22%7d",
                    goodsinfo[2], goodsinfo[3], reChangeNo, goodsinfo[0]);
                String httpors = Httpors();
                String unifriorderp = httpors + "m.client.10010.com/welfare-mall-front/mobile/api/bj2402/v1";
                String unifricookie = cookiet.Text;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(unifriorderp);
                httpWebRequest.Method = "POST";
                httpWebRequest.UserAgent = "Mozilla/5.0 (Linux;Android 10;GM1910) AppleWebKit/537.36(KHTML, like Gecko) "
                    + "Chrome / 83.0.4103.106 Mobile Safari/ 537.36; unicom{version: android@8.0002}";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                httpWebRequest.Headers.Add("Cookie", unifricookie);
                Byte[] bunifridata = Encoding.UTF8.GetBytes(unifridata);
                httpWebRequest.ContentLength = bunifridata.Length;
                httpWebRequest.Timeout = 2000;

                using (Stream stream = httpWebRequest.GetRequestStream())   //POST方法需要传递data
                {
                    stream.Write(bunifridata, 0, bunifridata.Length);
                }

                try
                {
                    String unifriorderpr;
                    using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {
                        using (StreamReader StreamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            unifriorderpr = StreamReader.ReadToEnd();
                        }
                    }

                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    Dictionary<String, Object> unifriorderprd = (Dictionary<String, Object>)javaScriptSerializer.DeserializeObject(unifriorderpr);
                    ordermsg = unifriorderprd["msg"].ToString();
                    outputt.AppendText("\r\n" + ordermsg);
                    if (ordermsg == "商品信息不存在")
                    {
                        outputt.AppendText("   可能未到活动当天或商品信息有更新");
                    }
                    else if (ordermsg.Contains("无法购买请稍候再试"))
                    {
                        outputt.AppendText("\r\n账号已被限制当天所有活动,请下次再参加");
                    }
                    if (ordermsg == "下单成功" && serverccb.Checked)
                    {
                        String sendserverchan = httpors + String.Format("sc.ftqq.com/{0}.send?text={1} {2} 下单成功,请尽快在30分钟内支付,逾期将失效哦", servercsckeyt.Text, DateTime.Now.ToString("HH时mm分ss秒"), goodsinfo[1]);
                        HttpWebRequest httpWebRequests = (HttpWebRequest)WebRequest.Create(sendserverchan);
                        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequests.GetResponse();
                    }
                }
                catch (System.ArgumentException)
                {
                    outputt.AppendText("可能联通例行升级中");
                }
                catch (System.Net.WebException err)
                {
                    outputt.AppendText("\r\n网络出错了   " + err.Message);
                    Get_Order(out ordermsg);
                }
                catch (Exception err)
                {
                    outputt.AppendText("\r\n未知错误   " + err.Message);
                    Get_Order(out ordermsg);
                }
            }
        }

        private void Manualrush_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Manualrush_Click();
        }

        private void Manualrush_Click()   //点击按钮提交订单
        {
            Get_Order(out _);   //不引用返回值就使用下划线
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
                    Get_Unifritime(out Int64 currentTime);
                    if (currentTime < unifrirt)
                    {
                        outputt.AppendText("\r\n如果想修改参数,请先停止后再修改,然后重新点击定时\r\n未到对应的活动时间,正在定时...");
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
                        outputt.AppendText("\r\n定时失败");
                        unifriett.Text = "0";
                    }
                    else
                    {
                        outputt.AppendText("\r\n定时失败,提前毫秒只能输入数字哦");
                    }
                }
            }
        }

        private void BGunifrirushonce_DoWork(object sender, DoWorkEventArgs e)
        {
            Get_goodsinfo(out String[] goodsinfo);
            Int64 unifrirt = Int64.Parse(goodsinfo[0]) - Int32.Parse(unifriett.Text);
            Int64 unifrilm = Int64.Parse(goodsinfo[0]) - 60000;
            Get_Unifritime(out Int64 currentTime);
            while (currentTime < unifrirt && !bgunifrirushonce.CancellationPending)
            {
                if (currentTime >= unifrilm)
                {
                    System.Threading.Thread.Sleep(10);
                }
                else
                {
                    System.Threading.Thread.Sleep(30000);
                }
                Get_Unifritime(out currentTime);
            }
            if (!outputt.Text.Contains("正在下单"))
            {
                outputt.AppendText("\r\n正在下单...");
            }
            if (!bgunifrirushonce.CancellationPending)
            {
                Get_Order(out _);
            }
        }

        private void BGunifrirushsuc_DoWork(object sender, DoWorkEventArgs e)
        {
            Get_goodsinfo(out String[] goodsinfo);
            Int64 unifrirt = Int64.Parse(goodsinfo[0]) - Int32.Parse(unifriett.Text);
            Int64 unifrilm = Int64.Parse(goodsinfo[0]) - 60000;
            Get_Unifritime(out Int64 currentTime);
            while (currentTime < unifrirt && !bgunifrirushsuc.CancellationPending)
            {
                if (currentTime >= unifrilm)
                {
                    System.Threading.Thread.Sleep(10);
                }
                else
                {
                    System.Threading.Thread.Sleep(30000);
                }
                Get_Unifritime(out currentTime);
            }
            if (bgunifrirushsuc.IsBusy && !bgunifrirushsuc.CancellationPending)
            {
                if (!outputt.Text.Contains("正在下单或捡漏"))
                {
                    outputt.AppendText("\r\n正在下单或捡漏...");
                }
                if (!Int32.TryParse(unifriftimet.Text, out Int32 unifriftime))
                {
                    outputt.AppendText("\r\n间隔毫秒只能填写数字,已恢复默认的5000毫秒");
                    unifriett.Text = "5000";
                    unifriftime = Int32.Parse(unifriett.Text);
                }
                Int32 unifriftimes = 1;
                Get_Order(out String ordermsg);
                while (ordermsg != "下单成功" && !bgunifrirushsuc.CancellationPending)
                {
                    unifriftimes++;
                    outputt.AppendText(String.Format("\r\n没有下单成功,将在{0}毫秒后第{1}次刷新", unifriftime, unifriftimes));
                    System.Threading.Thread.Sleep(unifriftime);
                    if (!bgunifrirushsuc.CancellationPending)
                    {
                        Get_Order(out ordermsg);
                    }
                    if (Regex.IsMatch(ordermsg, ".*(达到上限 | 数量限制 | 次数限制).*"))
                    {
                        bgunifrirushsuc.CancelAsync();
                        break;
                    }
                    else if (ordermsg.Contains("无法购买请稍候再试"))
                    {
                        bgunifrirushsuc.CancelAsync();
                        break;
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
                outputt.AppendText("\r\n定时或捡漏已停止");
            }
        }

        private void Servercweb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            servercweb.LinkVisited = true;
            System.Diagnostics.Process.Start("http://sc.ftqq.com");
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
            unifriLoginUC1.Visible = true;
            unifriLoginUC1.Httpors = Httpors();
            mecount = 0;
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
    }
}
