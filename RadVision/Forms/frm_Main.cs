using System;
using System.Threading;
using System.Windows.Forms;
using MatrixService;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;

namespace RadVision
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class frm_Main : Form
    {
        #region 全局变量

        #region 实例
        /// <summary>
        /// 数据发送实例
        /// </summary>
        private MatrixHelper Matrix;

        /// <summary>
        /// 全局计时器
        /// </summary>
        private System.Timers.Timer Timer;

        /// <summary>
        /// 时间刷新委托事件
        /// </summary>
        private delegate void TimeLabelsRefreshDelegate();

        /// <summary>
        /// 分钟刷新委托事件
        /// </summary>
        private delegate void MinuteLabelRefreshDelegate();

        /// <summary>
        /// 星期刷新委托事件
        /// </summary>
        private delegate void WeekLabelRefreshDelegate();

        /// <summary>
        /// 日期刷新委托事件
        /// </summary>
        private delegate void DateLabelRefreshDelegate();

        /// <summary>
        /// 升降台距离刷新委托事件
        /// </summary>
        /// <param name="Distance"></param>
        private delegate void DistanceLabelRefreshDelegate(string Distance);

        /// <summary>
        /// DICOM数值刷新委托事件
        /// </summary>
        /// <param name="DICOM"></param>
        private delegate void DICOMLabelRefreshDelegate(string DICOM);

        /// <summary>
        /// 模式按钮刷新委托事件
        /// </summary>
        private delegate void ModeButtonRefreshDelegate();

        /// <summary>
        /// 刷新模式按钮委托实例
        /// </summary>
        private ModeButtonRefreshDelegate Button;

        /// <summary>
        /// 显示休息界面委托
        /// </summary>
        private delegate void ShowHealthyNoticeDelagate();
        #endregion

        #region 标志位
        /// <summary>
        /// 内外网开关标志位
        /// </summary>
        private volatile bool flag_Net = false;

        /// <summary>
        /// 预设坐下模式标志位
        /// </summary>
        private volatile bool is_SitDown = false;

        /// <summary>
        /// 预设站立模式标志位
        /// </summary>
        private volatile bool is_StandUp = false;
        #endregion

        #region 线程
        /// <summary>
        /// 刷新小时线程
        /// </summary>
        private Thread TimeThread;

        /// <summary>
        /// 刷新距离线程
        /// </summary>
        private Thread DistanceThread;

        /// <summary>
        /// 刷新DICOM线程
        /// </summary>
        private Thread DICOMThread;
        #endregion

        #region 系统配置
        /// <summary>
        /// 矩阵连接串口
        /// </summary>
        private SerialPort MatrixPort;

        /// <summary>
        /// 内网直连串口
        /// </summary>
        private SerialPort ServerPort;

        /// <summary>
        /// 读取配置文件实例
        /// </summary>
        private StreamReader ConfigReader;

        /// <summary>
        /// 串口配置文件路径
        /// </summary>
        private string SerialPortConfigPath = Application.StartupPath + "\\Config\\SerialPortConfig.bin";

        /// <summary>
        /// 健康提醒时间配置文件路径
        /// </summary>
        private string HealthyNoticeConfigPath = Application.StartupPath + "\\Config\\HealthyNoticeConfig.bin";
        #endregion

        #region 控制指令
        //升降控制
        private bool upkeyclickdown = false;
        private bool downkeyclickdown = false;
        private byte[] upstr = { 0xAB, 0x01 };      //发送给串口的数据，上升键
        private byte[] downstr = { 0xAB, 0x02 };    //发送给串口的数据，下降键
        private byte[] nostr = { 0xAB, 0x00 };      //发送给串口的数据，无按键

        //模式选择
        private byte[] modeStandUp = { 0xAB, 0x06 };
        private byte[] modeSitDown = { 0xAB, 0x03 };

        //模式设置
        private byte[] modeSetting = { 0xAB, 0x07 };

        //矩阵控制
        private char[] chr = { 'A', '0', '1', '<', '0', '2', '!' }; //发送给矩阵的数据
        private byte[] cha = { 171, 170 };
        private byte[] rcvbuff = new byte[4];
        private int index = 0;

        //内网关机指令
        private char[] CommandShutDown = { 'S', 'h', 'u', 't', 'D', 'o', 'w', 'n' };
        private char[] CommandExitNormal = { 'E', 'x', 'i', 't', 'N', 'o', 'r', 'm', 'l' };
        #endregion

        #endregion

        #region 动画效果
        //窗体弹出或消失效果
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        /// <summary>
        /// AW_HOR_POSITIV
        /// </summary>
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        /// <summary>
        /// AW_HOR_NEGATIVE
        /// </summary>
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        /// <summary>
        /// AW_VER_POSITIVE
        /// </summary>
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        /// <summary>
        /// AW_VER_NEGATIVE
        /// </summary>
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        /// <summary>
        /// AW_CENTER
        /// </summary>
        public const Int32 AW_CENTER = 0x00000010;
        /// <summary>
        /// AW_HIDE
        /// </summary>
        public const Int32 AW_HIDE = 0x00010000;
        /// <summary>
        /// AW_ACTIVATE
        /// </summary>
        public const Int32 AW_ACTIVATE = 0x00020000;
        /// <summary>
        /// AW_SLIDE
        /// </summary>
        public const Int32 AW_SLIDE = 0x00040000;
        /// <summary>
        /// AW_BLEND
        /// </summary>
        public const Int32 AW_BLEND = 0x00080000;
        #endregion

        #region 构造器
        /// <summary>
        /// 默认构造器
        /// </summary>
        public frm_Main()
        {
            InitializeComponent();
            InitItems();
        }
        #endregion

        #region 事件函数
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_Load(object sender, EventArgs e)
        {
            //窗体弹出效果
            AnimateWindow(this.Handle, 300, AW_CENTER);

            //开启计时器
            StartHealthyNotice();
        }

        /// <summary>
        /// 串口接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistancePort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RecvDataFromSerialPort();
        }

        /// <summary>
        /// 上升键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_Up_MouseDown(object sender, MouseEventArgs e)
        {
            upkeyclickdown = true;

            UpdateModeButtons();

            pBx_Up.Image = Properties.Resources.up_2;
        }

        /// <summary>
        /// 鼠标进入上升键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_Up_MouseEnter(object sender, EventArgs e)
        {
            pBx_Up.Image = Properties.Resources.up_2;
        }

        /// <summary>
        /// 鼠标离开上升键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_Up_MouseLeave(object sender, EventArgs e)
        {
            pBx_Up.Image = Properties.Resources.up_1;
        }

        /// <summary>
        /// 松开上升键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_Up_MouseUp(object sender, MouseEventArgs e)
        {
            upkeyclickdown = false;
            pBx_Up.Image = Properties.Resources.up_1;
        }

        /// <summary>
        /// 下降键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_Down_MouseDown(object sender, MouseEventArgs e)
        {
            downkeyclickdown = true;

            UpdateModeButtons();

            pBx_Down.Image = Properties.Resources.down_2;
        }

        /// <summary>
        /// 鼠标进入下降键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_Down_MouseEnter(object sender, EventArgs e)
        {
            pBx_Down.Image = Properties.Resources.down_2;
        }

        /// <summary>
        /// 鼠标离开下降键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_Down_MouseLeave(object sender, EventArgs e)
        {
            pBx_Down.Image = Properties.Resources.down_1;
        }

        /// <summary>
        /// 松开下降键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_Down_MouseUp(object sender, MouseEventArgs e)
        {
            downkeyclickdown = false;
            pBx_Down.Image = Properties.Resources.down_1;
        }

        /// <summary>
        /// 内外网切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_SwitchNet_Click(object sender, EventArgs e)
        {
            SwitchNet();
        }

        /// <summary>
        /// 站立模式按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModeStandUp_MouseDown(object sender, MouseEventArgs e)
        {
            pBx_ModeStandUp.Image = Properties.Resources.stand_up_2;
        }

        /// <summary>
        /// 站立模式松开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModeStandUp_MouseUp(object sender, MouseEventArgs e)
        {
            SwitchModeStandUp();
        }

        /// <summary>
        /// 坐下模式按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModeSitDown_MouseDown(object sender, MouseEventArgs e)
        {
            pBx_ModeSitDown.Image = Properties.Resources.sit_down_2;
        }

        /// <summary>
        /// 坐下模式松开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModeSitDown_MouseUp(object sender, MouseEventArgs e)
        {
            SwitchModeSitDown();
        }

        /// <summary>
        /// 按下键鼠复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_ResetPoint_MouseDown(object sender, MouseEventArgs e)
        {
            pBx_ResetPoint.Image = Properties.Resources.ResetPoint2;
        }

        /// <summary>
        /// 松开键鼠复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_ResetPoint_MouseUp(object sender, MouseEventArgs e)
        {
            pBx_ResetPoint.Image = Properties.Resources.ResetPoint1;
            ResetPointAndKeyBoard();
        }

        /// <summary>
        /// 按下不再提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_ExitTimer_MouseDown(object sender, MouseEventArgs e)
        {
            pBx_ExitTimer.Image = Properties.Resources.exittimer2;
        }

        /// <summary>
        /// 松开不再提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_ExitTimer_MouseUp(object sender, MouseEventArgs e)
        {
            pBx_ExitTimer.Image = Properties.Resources.exittimer1;
            Timer.Enabled = false;
            panel_HealthyNotice.Visible = false;
        }

        /// <summary>
        /// 按下确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_ContinuTimer_MouseDown(object sender, MouseEventArgs e)
        {
            pBx_ContinuTimer.Image = Properties.Resources.continutimer2;
        }

        /// <summary>
        /// 松开确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBx_ContinuTimer_MouseUp(object sender, MouseEventArgs e)
        {
            pBx_ContinuTimer.Image = Properties.Resources.continutimer1;
            Timer.Enabled = true;
            panel_HealthyNotice.Visible = false;
        }
        #endregion

        #region 功能函数

        #region 初始化服务
        /// <summary>
        /// 初始化服务
        /// </summary>
        private void InitItems()
        {
            Matrix = new MatrixHelper();

            MatrixPort = new SerialPort();

            DistancePort = new SerialPort();

            ServerPort = new SerialPort();

            ReadSerialPortConfig();

            StartTime();

            StartDistance();

            //StartDICOM();
        }
        #endregion

        #region 读取配置文件
        /// <summary>
        /// 读取串口配置文件
        /// </summary>
        private void ReadSerialPortConfig()
        {
            string[] PortNames = null;
            string[] BaudRates = null;

            try
            {
                ConfigReader = new StreamReader(SerialPortConfigPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统配置文件缺失");
                System.Environment.Exit(0);
            }

            PortNames = ConfigReader.ReadLine().Split(':');
            BaudRates = ConfigReader.ReadLine().Split(':');

            MatrixPort.PortName = PortNames[0];
            DistancePort.PortName = PortNames[1];
            ServerPort.PortName = PortNames[2];

            try
            {
                MatrixPort.BaudRate = Convert.ToInt32(BaudRates[0]);
                DistancePort.BaudRate = Convert.ToInt32(BaudRates[1]);
                ServerPort.BaudRate = Convert.ToInt32(BaudRates[2]);

                this.DistancePort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.DistancePort_DataReceived);

                ConfigReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "波特率配置错误");
                System.Environment.Exit(0);
            }
        }

        /// <summary>
        /// 获取健康提醒配置
        /// </summary>
        private void ReadTimerConfig()
        {
            int Time = 0;

            try
            {
                ConfigReader = new StreamReader(HealthyNoticeConfigPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统配置文件丢失");
                System.Environment.Exit(0);
            }

            try
            {
                Time = Convert.ToInt32(ConfigReader.ReadLine());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提醒时间配置错误");
                System.Environment.Exit(0);
            }

            ConfigReader.Close();
            Timer = new System.Timers.Timer(Time);
        }

        #endregion

        #region 读取串口数据
        /// <summary>
        /// 读取串口数据
        /// </summary>
        private void RecvDataFromSerialPort()
        {
            int i = 0;
            byte[] readBuffer = new byte[DistancePort.ReadBufferSize];
            int readout = DistancePort.Read(readBuffer, 0, readBuffer.Length);

            if (readout < 0)
            {
                return;
            }

            for (i = 0; i < readout; i++)
            {
                if ((readBuffer[i] == 0xBA))
                {
                    rcvbuff[index++] = readBuffer[i];
                }
                else if ((index > 0) && (index < 4))
                {
                    rcvbuff[index++] = readBuffer[i];
                }
                if (index == 4)
                {
                    float hight = 0;
                    float distance = 19;
                    if (rcvbuff[1] == 0x01)      //行程数据
                    {
                        if ((rcvbuff[2] & 0x80) != 0x00)
                        {
                            rcvbuff[2] &= 0x7F;
                            hight = (float)(rcvbuff[2] * 256 + rcvbuff[3]) / (float)10;
                        }
                        else
                        {
                            hight = rcvbuff[2] * 256 + rcvbuff[3];
                        }

                        hight += distance;

                        string heightstr = Convert.ToString(hight) + " " + "cm";
                        UpdateTextBox(heightstr);
                        rcvbuff = new byte[4];

                    }
                    else if (rcvbuff[i + 1] == 0x10)   //异常数据
                    {
                        string error = "err:" + Convert.ToString(rcvbuff[i + 2]);
                        UpdateTextBox(error);
                        rcvbuff = new byte[4];
                    }
                    index = 0;
                }
                else if (index > 4)
                {
                    index = 0;
                }
            }
        }
        #endregion

        #region 网络切换
        /// <summary>
        /// 切换网络
        /// </summary>
        private void SwitchNet()
        {
            if (flag_Net)
            {
                try
                {
                    chr[5] = '1';
                    chr[2] = '1';
                    Matrix.sendCHAR(MatrixPort, chr); // A01<03!

                    Matrix.sendHEX(DistancePort, cha);
                    Thread.Sleep(200);
                    Matrix.sendHEX(DistancePort, cha);
                    
                    chr[5] = '2';
                    chr[2] = '2';
                    Matrix.sendCHAR(MatrixPort, chr); // A02<04!

                    pBx_SwitchNet.Image = Properties.Resources.outer_net;
                    flag_Net = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
            }
            else
            {
                try
                {
                    chr[5] = '3';
                    chr[2] = '1';
                    Matrix.sendCHAR(MatrixPort, chr); // A01<01!

                    Matrix.sendHEX(DistancePort, cha);
                    Thread.Sleep(200);
                    Matrix.sendHEX(DistancePort, cha);
                    
                    chr[5] = '4';
                    chr[2] = '2';
                    Matrix.sendCHAR(MatrixPort, chr); // A02<02!

                    pBx_SwitchNet.Image = Properties.Resources.inner_net;
                    flag_Net = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
            }
        }

        /// <summary>
        /// 选择站立模式
        /// </summary>
        private void SwitchModeStandUp()
        {
            if (is_StandUp)
            {
                is_StandUp = false;
                pBx_ModeStandUp.Image = Properties.Resources.stand_up_1;
                pBx_ModeStandUp.Enabled = true;
            }
            else if (is_SitDown && !is_StandUp)
            {
                try
                {
                    Matrix.sendHEX(DistancePort, modeStandUp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                    return;
                }

                is_SitDown = false;
                pBx_ModeSitDown.Image = Properties.Resources.sit_down_1;
                pBx_ModeSitDown.Enabled = true;

                is_StandUp = true;
                pBx_ModeStandUp.Image = Properties.Resources.stand_up_3;
                pBx_ModeStandUp.Enabled = false;
            }
            else
            {
                try
                {
                    Matrix.sendHEX(DistancePort, modeStandUp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                    return;
                }

                is_StandUp = true;
                pBx_ModeStandUp.Image = Properties.Resources.stand_up_3;
                pBx_ModeStandUp.Enabled = false;
            }
        }

        /// <summary>
        /// 选择坐下模式
        /// </summary>
        private void SwitchModeSitDown()
        {
            if (is_SitDown)
            {
                is_SitDown = false;
                pBx_ModeSitDown.Image = Properties.Resources.sit_down_1;
                pBx_ModeSitDown.Enabled = true;
            }
            else if (is_StandUp && !is_SitDown)
            {
                try
                {
                    Matrix.sendHEX(DistancePort, modeSitDown);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                    return;
                }

                is_StandUp = false;
                pBx_ModeStandUp.Image = Properties.Resources.stand_up_1;
                pBx_ModeStandUp.Enabled = true;

                is_SitDown = true;
                pBx_ModeSitDown.Image = Properties.Resources.sit_down_3;
                pBx_ModeSitDown.Enabled = false;
            }
            else
            {
                try
                {
                    Matrix.sendHEX(DistancePort, modeSitDown);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                    return;
                }

                is_SitDown = true;
                pBx_ModeSitDown.Image = Properties.Resources.sit_down_3;
                pBx_ModeSitDown.Enabled = false;
            }
        }
        #endregion

        #region 时间动态刷新
        /// <summary>
        /// 时间刷新线程
        /// </summary>
        private void StartTime()
        {
            TimeThread = new Thread(GetTime);
            TimeThread.IsBackground = true;
            TimeThread.Start();
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        private void GetTime()
        {
            while (true)
            {
                TimeLabelsRefresh();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 刷新小时标签
        /// </summary>
        private void TimeLabelsRefresh()
        {
            if (label_Hour.InvokeRequired || label_Minute.InvokeRequired || label_Week.InvokeRequired || label_Date.InvokeRequired)
            {
                TimeLabelsRefreshDelegate Time = new TimeLabelsRefreshDelegate(TimeLabelsRefresh);
                label_Hour.BeginInvoke(Time);
                label_Minute.BeginInvoke(Time);
                label_Week.BeginInvoke(Time);
                label_Date.BeginInvoke(Time);
            }
            else
            {
                label_Hour.Text = HourChange(DateTime.Now.Hour);
                label_Minute.Text = MinuteChange(DateTime.Now.Minute);
                label_Week.Text = WeekChangetoChinese(DateTime.Now.DayOfWeek.ToString());
                label_Date.Text = DateTime.Today.ToString("yyyy/MM/dd");
            }
        }

        /// <summary>
        /// 小时补0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string HourChange(int num)
        {
            string Hour;
            if (num >= 0 && num <= 9)
            {
                Hour = "0" + num.ToString();
            }
            else
            {
                Hour = num.ToString();
            }
            return Hour;
        }

        /// <summary>
        /// 分钟补0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string MinuteChange(int num)
        {
            string Minute;
            if (num >= 0 && num <= 9)
            {
                Minute = "0" + num.ToString();
            }
            else
            {
                Minute = num.ToString();
            }
            return Minute;
        }

        /// <summary>
        /// 转换汉语星期
        /// </summary>
        /// <param name="Week"></param>
        /// <returns></returns>
        private string WeekChangetoChinese(string Week)
        {
            switch (Week)
            {
                case "Monday":
                    Week = "星期一";
                    break;
                case "Tuesday":
                    Week = "星期二";
                    break;
                case "Wednesday":
                    Week = "星期三";
                    break;
                case "Thursday":
                    Week = "星期四";
                    break;
                case "Friday":
                    Week = "星期五";
                    break;
                case "Saturday":
                    Week = "星期六";
                    break;
                case "Sunday":
                    Week = "星期日";
                    break;
                default:
                    break;
            }

            return Week;
        }
        #endregion

        #region Distance动态刷新
        /// <summary>
        /// 开启服务
        /// </summary>
        private void StartDistance()
        {
            DistanceThread = new Thread(sendMessageToRS232);
            DistanceThread.IsBackground = true;
            DistanceThread.Start();
        }

        /// <summary>
        /// 发送指令到控制器
        /// </summary>
        public void sendMessageToRS232()
        {

            while (true)
            {
                if (upkeyclickdown)
                {
                    try
                    {
                        Matrix.sendHEX(DistancePort, upstr);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误");
                    }
                }
                else if (downkeyclickdown)
                {
                    try
                    {
                        Matrix.sendHEX(DistancePort, downstr);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误");
                    }
                }
                else
                {
                    try
                    {
                        Matrix.sendHEX(DistancePort, nostr);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误");
                    }
                }

                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// 刷新label
        /// </summary>
        /// <param name="text"></param>
        public void UpdateTextBox(string text)
        {
            if(label_Distance.InvokeRequired)
            {
                DistanceLabelRefreshDelegate Distance = new DistanceLabelRefreshDelegate(UpdateTextBox);
                label_Distance.BeginInvoke(Distance,text);
            }
            else
            {
                label_Distance.Text = text;
            }
        }
        #endregion

        #region DICOM数值动态刷新
        /// <summary>
        /// 启动DICOM刷新线程
        /// </summary>
        private void StartDICOM()
        {
            DICOMThread = new Thread(GetDICOM);
            DICOMThread.IsBackground = true;
            DICOMThread.Start();
        }

        /// <summary>
        /// 获取DICOM数值
        /// </summary>
        private void GetDICOM()
        {
            string DICOM = "460";

            while(true)
            {
                RefreshDICOM(DICOM);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 刷新DICOM数值
        /// </summary>
        private void RefreshDICOM(string DICOM)
        {
            if(label_Dicom.InvokeRequired)
            {
                DICOMLabelRefreshDelegate Dicom = new DICOMLabelRefreshDelegate(RefreshDICOM);
                label_Dicom.BeginInvoke(Dicom, DICOM);
            }
            else
            {
                label_Dicom.Text = "DICOM:" + DICOM;
            }
        }
        #endregion

        #region 模式按钮动态刷新
        /// <summary>
        /// 刷新模式按钮
        /// </summary>
        private void UpdateModeButtons()
        {
            if (pBx_ModeStandUp.InvokeRequired && pBx_ModeSitDown.InvokeRequired)
            {
                Button = new ModeButtonRefreshDelegate(UpdateModeButtons);
                this.Invoke(Button);
            }
            else
            {
                pBx_ModeStandUp.Enabled = true;
                is_StandUp = false;
                pBx_ModeStandUp.Image = Properties.Resources.stand_up_1;

                pBx_ModeSitDown.Enabled = true;
                is_SitDown = false;
                pBx_ModeSitDown.Image = Properties.Resources.sit_down_1;
            }
        }
        #endregion

        #region 键鼠复位
        /// <summary>
        /// 键鼠复位
        /// </summary>
        private void ResetPointAndKeyBoard()
        {
            if (flag_Net)
            {
                try
                {
                    Matrix.sendHEX(DistancePort, cha);
                    Thread.Sleep(200);
                    Matrix.sendHEX(DistancePort, cha);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
            }
            else
            {
                try
                {
                    Matrix.sendHEX(DistancePort, cha);
                    Thread.Sleep(200);
                    Matrix.sendHEX(DistancePort, cha);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
            }
        }
        #endregion

        #region 健康提醒
        /// <summary>
        /// 开启健康提醒
        /// </summary>
        private void StartHealthyNotice()
        {
            ReadTimerConfig();

            Timer.AutoReset = true;
            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
        }

        /// <summary>
        /// 计时器到达
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Timer.Enabled = false;
            ShowHealthyNotice();
        }

        /// <summary>
        /// 显示健康提醒
        /// </summary>
        private void ShowHealthyNotice()
        {
            if(panel_HealthyNotice.InvokeRequired)
            {
                ShowHealthyNoticeDelagate Healthy = new ShowHealthyNoticeDelagate(ShowHealthyNotice);
                panel_HealthyNotice.Invoke(Healthy);
            }
            else
            {
                panel_HealthyNotice.Visible = true;
            }
        }
        #endregion

        #region 关机提示
        /// <summary>
        /// 拦截用户关机事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.TaskManagerClosing:
                    e.Cancel = true;
                    MessageBox.Show("非法关闭请求！已阻止！");
                    break;
                case CloseReason.UserClosing:
                    e.Cancel = false;
                    try
                    {
                        Matrix.sendCommand(ServerPort, CommandExitNormal);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误");
                    }
                    break;
                case CloseReason.WindowsShutDown:
                    e.Cancel = false;
                    try
                    {
                        Matrix.sendCommand(ServerPort, CommandShutDown);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误");
                    }
                    break;
                default:
                    break;
            }
            base.OnFormClosing(e);
            System.Environment.Exit(0);
        }

        #endregion

        #endregion}
    }
}
