using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace RadVision
{
    /// <summary>
    /// 加载窗
    /// </summary>
    public partial class frm_Welcome : Form
    {
        #region 全局变量
        /// <summary>
        /// 加载动画延时时间（毫秒）
        /// </summary>
        private int Loading_Time;

        /// <summary>
        /// 配置文件读取实例
        /// </summary>
        private StreamReader ConfigReader;

        /// <summary>
        /// 配置文件路径
        /// </summary>
        private string ConfigPath;
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

        /// <summary>
        /// 构造器
        /// </summary>
        public frm_Welcome()
        {
            InitializeComponent();
            InitItems();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Welcome_Load(object sender, EventArgs e)
        {
            timer_Loading.Enabled = true;

            //窗体弹出效果
            AnimateWindow(this.Handle, 300, AW_CENTER);
        }

        /// <summary>
        /// 计时到达时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Loading_Tick(object sender, EventArgs e)
        {
            timer_Loading.Enabled = false;
            frm_Main frm = new frm_Main();

            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitItems()
        {
            ConfigPath = Application.StartupPath + "\\Config\\StartConfig.bin";
            ReadConfig();
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        private void ReadConfig()
        {
            try
            {
                ConfigReader = new StreamReader(ConfigPath);

                Loading_Time = Convert.ToInt32(ConfigReader.ReadLine());

                timer_Loading.Interval = Loading_Time;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "启动配置文件不存在");
                System.Environment.Exit(0);
            }
            catch
            {
                MessageBox.Show("无法转换", "初始化时间设置错误");
                System.Environment.Exit(0);
            }
        }
    }
}
