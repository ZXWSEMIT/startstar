using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;


namespace sendform
{
    public partial class dbname1 : Form
    {
        static Socket sock;
        static List<string> path = new List<string>();
        //定时器
        System.Timers.Timer t;//实例化Timer类，设置间隔时间为1800000毫秒(半小时)；
        Thread threadStart;
        public dbname1()
        {
            InitializeComponent();
        }

        public void mystartSend()
        {
            string text = iptext.Text.Trim();
            int port = Convert.ToInt32(txtport.Text.Trim());
            string address = txtpath.Text.Trim();
            start(text, port, address);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            if (button1.Text == "开启发送")
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                threadStart = new Thread(mystartSend);
                threadStart.IsBackground = true;
                threadStart.Start();

                if (comboBox1.SelectedIndex == 0) {

                    int dstm = Convert.ToInt32(txtds.Text.Trim()) * 60 * 1000;
                    t = new System.Timers.Timer(dstm);
                    t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；

                    t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；

                    t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；

                    t.Start();
                }
                
                button1.Text = "关闭";
            }
            else
            {

                System.Environment.Exit(0);

            }
            
        }


        public void theout(object source, System.Timers.ElapsedEventArgs e)

        {

            String user = dbuser.Text.Trim(); // 数据库帐号
            String password = dbpassword.Text.Trim(); // 登陆密码
            String database = dbname.Text.Trim(); // 需要备份的bai数据库名
            String filepath = txtpath.Text.Trim(); // 备份的路径地址
            string saveName = database + DateTime.Now.ToString("yyyyMMddHHmmss") + ".sql";
            String stmt1 = "mysqldump -u" + user + " -p" + password + " " + database + " --single-transaction  --result-file=" + filepath + "\\" + saveName;
            /*
             * String mysql="mysqldump test -u root -proot
             * --result-file=d:\\test.sql";
             */
           
           Process p = new Process();
           //设置要启动的应用程序
           p.StartInfo.FileName = "cmd.exe";
           //是否使用操作系统shell启动
           p.StartInfo.UseShellExecute = false;
           // 接受来自调用程序的输入信息
           p.StartInfo.RedirectStandardInput = true;
           //输出信息
           p.StartInfo.RedirectStandardOutput = true;
           // 输出错误
           p.StartInfo.RedirectStandardError = true;
           //不显示程序窗口
           p.StartInfo.CreateNoWindow = true;
           //启动程序
           p.Start();

           //向cmd窗口发送输入信息
           p.StandardInput.WriteLine(stmt1 + "&exit");

           p.StandardInput.AutoFlush = true;

            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();

            Console.WriteLine(strOuput);
        }

        private void start(string text,int port,string address)
        {
            WatcherStrat(address, "*.*", true, true);
            try
            {
                sock.Connect(new IPEndPoint(IPAddress.Parse(text), port));
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
            
            Console.WriteLine("Connect successfully");
            
            while (true)
            {
                if (path.Count > 0)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        string str = "";
                        if (Directory.Exists(path[i]))
                        {
                            str = "folder," + path[i];
                            sock.Send(Encoding.Default.GetBytes(str));
                        }
                        else
                        {
                            try
                            {
                                using (FileStream reader = new FileStream(path[i], FileMode.Open, FileAccess.Read, FileShare.None))
                                {
                                    long send = 0L, length = reader.Length;

                                    string sendStr = "";

                                    sendStr = "file," + path[i] + "," + length.ToString();

                                    string fileName = Path.GetFileName(path[i]);
                                    sock.Send(Encoding.Default.GetBytes(sendStr));

                                    int BufferSize = 1024;
                                    byte[] buffer = new byte[32];
                                    sock.Receive(buffer);
                                    string mes = Encoding.Default.GetString(buffer);

                                    if (mes.Contains("OK"))
                                    {
                                        Console.WriteLine("Sending file:" + fileName + ".Plz wait...");
                                        byte[] fileBuffer = new byte[BufferSize];
                                        int read, sent;
                                        while ((read = reader.Read(fileBuffer, 0, BufferSize)) != 0)
                                        {
                                            sent = 0;
                                            while ((sent += sock.Send(fileBuffer, sent, read, SocketFlags.None)) < read)
                                            {
                                                send += (long)sent;
                                            }
                                        }
                                        Console.WriteLine("Send finish.\n");

                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    path = new List<string>();
                }

            }
        }


        static FileSystemWatcher watcher = new FileSystemWatcher();

        private static void WatcherStrat(string StrWarcherPath, string FilterType, bool IsEnableRaising, bool IsInclude)
        {
            //初始化监听           
            watcher.BeginInit();
            //设置监听文件类型           
            watcher.Filter = FilterType;
            //设置是否监听子目录           
            watcher.IncludeSubdirectories = IsInclude;
            //设置是否启用监听?           
            watcher.EnableRaisingEvents = IsEnableRaising;
            //设置需要监听的更改类型(如:文件或者文件夹的属性,文件或者文件夹的创建时间;NotifyFilters枚举的内容)          
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            //设置监听的路径           
            watcher.Path = StrWarcherPath;
            //注册创建文件或目录时的监听事件           
            watcher.Created += new FileSystemEventHandler(watch_created);
            //注册当指定目录的文件或者目录发生改变的时候的监听事件  
            watcher.Changed += new FileSystemEventHandler(watch_changed);
            //注册当删除目录的文件或者目录的时候的监听事件           
            watcher.Deleted += new FileSystemEventHandler(watch_deleted);
            //当指定目录的文件或者目录发生重命名的时候的监听事件           
            watcher.Renamed += new RenamedEventHandler(watch_renamed);
            //结束初始化           
            watcher.EndInit();
        }
        /// <summary>       
        /// 创建文件或者目录时的监听事件      
        /// </summary>      
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private static void watch_created(object sender, FileSystemEventArgs e)
        {
            //事件内容
            string fileName = e.FullPath;
            path.Add(fileName);
            //MessageBox.Show("创建文件");
        }
        /// <summary>       
        /// 当指定目录的文件或者目录发生改变的时候的监听事件      
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private static void watch_changed(object sender, FileSystemEventArgs e)
        {
            //事件内容    
            //MessageBox.Show("发生改变");
            string fileName = e.FullPath;
            if (!Directory.Exists(fileName))
            {
                path.Add(fileName);
            }

            //MessageBox.Show("文件改变");
        }
        /// <summary>       
        /// 当删除目录的文件或者目录的时候的监听事件       
        /// </summary>       
        /// <param name="sender"></param>             
        /// <param name="e"></param>      
        private static void watch_deleted(object sender, FileSystemEventArgs e)
        {
            //事件内容
        }
        /// <summary>       
        /// 当指定目录的文件或者目录发生重命名的时候的事件      
        /// </summary>      
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private static void watch_renamed(object sender, RenamedEventArgs e)
        {
            //事件内容      
        }
        public Boolean getFileOrFold(String fileName)
        {
            if (Directory.Exists(fileName))
            {
                return false;
            }

            if (File.Exists(fileName))
            {
                return true;
            }

            return false;
        }

        private void Send(Socket c_socket, byte[] by)
        {
            //发送
            c_socket.BeginSend(by, 0, by.Length, SocketFlags.None, asyncResult =>
            {
                try
                {
                    //完成消息发送
                    int len = c_socket.EndSend(asyncResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error ex=" + ex.Message + " " + ex.StackTrace);
                }
            }, null);
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            
            //dialog.RootFolder = Environment.SpecialFolder.Programs;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                txtpath.Text = foldPath;
            }
        }

        private void Dbname1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void Dbname1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //try
            //{

            //    sock.Close();
            //    sock = null;
            //    if (threadStart.IsAlive) threadStart.Abort();
            //}
            //catch
            //{
            //}

            //Application.Exit();
            System.Environment.Exit(0);
        }
    }
}
