using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace txt文件分割工具
{
    public partial class MainFrm : Form
    {
        public MainFrm ()
        {
            InitializeComponent ();
        }



        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnOpenFile_Click (object sender , EventArgs e)
        {
            //打开文件并入入textbox中
            OpenFileDialog open = new OpenFileDialog ();
            open.Filter = "文本文件|*.txt";
            DialogResult dr = open.ShowDialog ();
            if ( dr == DialogResult.OK )
            {
                txtFilePath.Text = open.FileName;
                nupChose_ValueChanged (sender , e);
            }

        }

        private string saveFolder = string.Empty;
        private void btnEnter_Click (object sender , EventArgs e)
        {
            //确定文本框中是否有文本
            if ( string.IsNullOrEmpty (txtFilePath.Text) )
            {
                MessageBox.Show ("请输入一个文本文件地址" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            else
            {
                string filePath = txtFilePath.Text;
                if ( System.IO.File.Exists (filePath) )
                {
                    //打开保存对话框选择保存目录
                    FolderBrowserDialog save = new FolderBrowserDialog ();
                    var sa = save.ShowDialog ();
                    if ( sa == DialogResult.OK )
                    {
                        saveFolder = save.SelectedPath;
                        //启动后,禁用按钮
                        btnOpenFile.Enabled = false;
                        btnEnter.Enabled = false;
                        t_Split = new Thread (SplitTxt);
                        //t.IsBackground = true;
                        t_Split.Start ();
                    }


                }
                else
                {
                    MessageBox.Show ("文件不存在,请重新打开或输入" , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                }
            }
        }

        Thread t_Split;

        /// <summary>
        /// 用字符的方式,一次性加载
        /// </summary>
        private void SplitTxt ()
        {
            //得到要分割的等份
            int split = (int)nupChose.Value;
            string filePath = txtFilePath.Text.Trim ();
            Stopwatch st = new Stopwatch ();
            st.Start ();
            char[] css;
            //得到文本文件
            using ( FileStream fs = new FileStream (filePath , FileMode.Open , FileAccess.Read) )
            {

                int length;
                


                //计算等份
                using ( BinaryReader br = new BinaryReader (fs , Encoding.Default) )
                {

                    try
                    {
                        css = br.ReadChars ((int)fs.Length);
                    }
                    catch
                    {

                        MessageBox.Show ("不支持这么大的文件");
                        return;
                    }

                }


                int len = css.Length;

                if ( len % split != 0 )
                {
                    //如果分不成等份
                    length = (int)Math.Ceiling (len / ( split * 1.0 ));
                }
                else
                {
                    length = len / split;
                }

                listInfo.Invoke ((Action)( () =>
                {
                    listInfo.Items.Add ("正在处理中................");

                } ));

                string file = Path.GetFileNameWithoutExtension (txtFilePath.Text.Trim ());

                int skip = 0;
                for ( int i = 0; i < split; i++ )
                {

                    var cs = css.Skip (skip).Take (length);
                    skip = skip + length;
                    StringBuilder sb = new StringBuilder ();

                    foreach ( char c in cs )
                    {
                        sb.Append (c.ToString ());
                    }



                    string savePath = Path.Combine (saveFolder , $"{file}_{i + 1}.txt");
                    File.WriteAllText (savePath , sb.ToString () , Encoding.Default);
                    listInfo.Invoke ((Action)( () =>
                    {
                        //显示信息
                        listInfo.Items.Add ($"{file}_{i + 1}.txt 已经创建成功");
                    } ));

                }

               
            }
            css = null;
            st.Stop ();
            listInfo.Invoke ((Action)( () =>
            {
                listInfo.Items.Add ("处理完成");
                listInfo.Items.Add ("总共花时:" + st.ElapsedMilliseconds + "毫秒");

            } ));
            this.Invoke ((Action)( () =>
            {
                btnEnter.Enabled = true;
                btnOpenFile.Enabled = true;

            } ));
           

            GC.Collect ();

            if ( t_Split.IsAlive )
            {

                
                t_Split.Abort ();
            }

        }

        /// <summary>
        /// 用流的方式
        /// </summary>
        private void SplitTxt2 ()
        {
            //得到要分割的等份
            int split = (int)nupChose.Value;
            string filePath = txtFilePath.Text.Trim ();
            Stopwatch st = new Stopwatch ();
            st.Start ();

            //得到文本文件
            using ( FileStream fs = new FileStream (filePath , FileMode.Open , FileAccess.Read) )
            {
                //每次应该读取的最大长度
                int length;

                //获取总长度
                int len = (int)fs.Length;


                if ( len % split != 0 )
                {
                    //如果分不成等份
                    length = (int)Math.Ceiling (len / ( split * 1.0 ));
                }
                else
                {
                    length = len / split;
                }

                listInfo.Invoke ((Action)( () =>
                {
                    listInfo.Items.Add ("正在处理中................");

                } ));

                string file = Path.GetFileNameWithoutExtension (txtFilePath.Text.Trim ());

                //每次读取的和
                int sum = 0;

                for ( int i = 0; i < split; i++ )
                {
                    string savePath = Path.Combine (saveFolder , $"{file}_{i + 1}.txt");
                    //写入
                    using ( FileStream fsWrite = new FileStream (savePath , FileMode.OpenOrCreate , FileAccess.Write) )
                    {
                        //一次读取3万字节
                        byte[] bys = new byte[5];

                        while ( true )
                        {
                            //分成split等份
                            //读取这么多等份
                            int readLen = fs.Read (bys , 0 , bys.Length);
                            sum += readLen;
                            //写入数据
                            fsWrite.Write (bys , 0 , readLen);
                            //如果本次读取的比实际读取的要大
                            if ( bys.Length > readLen )
                            {
                                //跳出
                                break;
                            }
                            //如果已经读取的比应该读取的要大
                            if ( sum>=length )
                            {
                                //跳出本次读取,应该读取下一次了
                                sum = 0;
                                break;
                            }

                           


                        }

                    }
                }

            }
            st.Stop ();
            listInfo.Invoke ((Action)( () =>
            {
                listInfo.Items.Add ("处理完成");
                listInfo.Items.Add ("总共花时:" + st.ElapsedMilliseconds + "毫秒");

            } ));

            if ( t_Split.IsAlive )
            {

                GC.Collect ();
                t_Split.Abort ();
            }

        }

        private void nupChose_ValueChanged (object sender , EventArgs e)
        {
            //确定文本框中是否有文本
            if ( string.IsNullOrEmpty (txtFilePath.Text) )
            {
                MessageBox.Show ("请输入一个文本文件地址" , "提示" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            else
            {

                string filePath = txtFilePath.Text;
                if ( System.IO.File.Exists (filePath) )
                {
                    //确定文件是否存在
                    //得到要分割的等份
                    int split = (int)nupChose.Value;
                    //分割文本,并且输出信息



                    FileStream file = File.Open (txtFilePath.Text.Trim () , FileMode.Open);
                    long fileSize = file.Length;
                    long length;


                    if ( fileSize % split != 0 )
                    {
                        //如果分不成等份
                        length = (long)Math.Ceiling (fileSize / ( split * 1.0 ));
                    }
                    else
                    {
                        length = fileSize / split;
                    }

                    lbInfo.Text = ( string.Format ("文件将被分成{0}等份,每份大小约为{1:G3}MB" , split , length / ( 1024 * 1.0 * 1024 )) );
                    file.Close ();
                    file.Dispose ();

                }
                else
                {
                    MessageBox.Show ("文件不存在,请重新打开或输入" , "错误" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                    if ( sender is TextBox )
                    {
                        TextBox text = sender as TextBox;
                        text.SelectAll ();

                    }
                }
            }
        }

        private void MainFrm_Load (object sender , EventArgs e)
        {

        }

        private void MainFrm_Paint (object sender , PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine (Pens.Black , new Point (txtFilePath.Location.X , txtFilePath.Location.Y + txtFilePath.Height) , new Point (txtFilePath.Location.X + txtFilePath.Size.Width , txtFilePath.Location.Y + txtFilePath.Height));
        }

        private void btnAdd_Click (object sender , EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog ();
            file.Filter = "文本文件|*.txt";
            file.Multiselect = true;
            if ( file.ShowDialog () == DialogResult.OK )
            {

                FIleList.Items.AddRange (file.FileNames);
            }
        }

        private void btnClearChose_Click (object sender , EventArgs e)
        {
            if ( FIleList.SelectedItem != null )
            {
                FIleList.Items.Remove (FIleList.SelectedItem);
            }
        }

        private void btnClearAll_Click (object sender , EventArgs e)
        {
            FIleList.Items.Clear ();
            listBox1.Items.Clear ();
            GC.Collect ();
        }

        //string saveMergePath;
        private void btnCombine_Click (object sender , EventArgs e)
        {
            //读取各项文件

            SaveFileDialog fbd = new SaveFileDialog ();
            fbd.Filter = "文本文件|*.txt";
            if ( fbd.ShowDialog () == DialogResult.OK )
            {
                string saveMergePath = fbd.FileName;
                using ( FileStream fscreate = new FileStream (saveMergePath , FileMode.Create) )
                {

                }
                //禁用其它按钮
                btnAdd.Enabled = false;
                btnClearAll.Enabled = false;
                btnClearChose.Enabled = false;

                t_merge = new Thread (MergeFiles2);

                t_merge.Start (saveMergePath);

                //System.Threading.ThreadPool.QueueUserWorkItem (MergeFiles,saveMergePath);
                //MergeFiles (saveMergePath);
            }
        }
        Thread t_merge;
      

        /// <summary>
        /// 当前合并读取到的总长度
        /// </summary>
        private int readlenSum = 0;
        private void MergeFiles2 (object obj)
        {

            listBox1.Invoke ((Action)( () =>
            {
                listBox1.Items.Add ("开始合并.....");

            } ));
            Stopwatch watch = new Stopwatch ();
            watch.Start ();
            string saveMergePath = obj.ToString ();


            //存储当前文件列表的总数
            int fileLen = FIleList.Items.Count;



            //循环读取列表中待合并的文件
            for ( int i = 0; i < FIleList.Items.Count; i++ )
            {
                //设置缓冲区大小
                byte[] bys = new byte[1024 * 1024 * 20];
                listBox1.Invoke ((Action)( () =>
                {
                    listBox1.Items.Add ("当前正在合并:" + FIleList.Items[i].ToString ());

                } ));

                //获得当前文件路径
                string fileReaderPath = FIleList.Items[i].ToString ();
                //读取当前文件
                using ( FileStream fsRead = new FileStream (fileReaderPath , FileMode.Open , FileAccess.Read) )
                {

                    //写入当前文件到新文件中
                    using ( FileStream fsWrite = new FileStream (saveMergePath , FileMode.Append , FileAccess.Write) )
                    {



                        //不断写入
                        while ( true )
                        {
                            //读取 返回当前实际读取到的数字
                            int fsReadLen = fsRead.Read (bys , 0 , bys.Length);

                            fsWrite.Write (bys , 0 , fsReadLen);

                            //获取当前的进度
                            //当前读取到的总进度
                            readlenSum += fsReadLen;
                            double sum = readlenSum * 1.0 / fsRead.Length;

                            //显示进度
                            lbProgressInfo.Invoke ((Action)( () =>
                            {
                                lbProgressInfo.Text = (int)( sum * 100 * 100 ) * 1.0 / 100 + "%";
                            } ));

                            //判断是否最后一次写入
                            if ( fsReadLen < bys.Length )
                            {
                                //最后一次读取,退出循环
                                //重置计数
                                readlenSum = 0;
                                //读取完了释放缓冲区
                                bys = new byte[1];
                                fsWrite.Flush ();
                                break;
                            }
                        }

                    }
                }

                listBox1.Invoke ((Action)( () =>
                {
                    listBox1.Items[i + 1] = $"合并:{Path.GetFileName (fileReaderPath)}成功";
                } ));
            }


            watch.Stop ();
            listBox1.Invoke ((Action)( () =>
            {
                listBox1.Items.Add ("共耗时:" + watch.ElapsedMilliseconds + "毫秒");
                listBox1.Items.Add ("合并文件为:" + saveMergePath);

            } ));
            this.Invoke (new Action (() =>
            {
                btnAdd.Enabled = true;
                btnClearAll.Enabled = true;
                btnClearChose.Enabled = true;
            }));
           
            //bys = null;
            GC.Collect ();
            MessageBox.Show ("完成");
            if ( t_merge.IsAlive )
            {
                t_merge.Abort ();
            }
        }

        private void MergeFiles (object obj)
        {
            Stopwatch watch = new Stopwatch ();
            watch.Start ();
            string saveMergePath = obj.ToString ();

            foreach ( var item in FIleList.Items )
            {
                string filePath = item.ToString ();
                //分配1m的空间
                byte[] bys = new byte[1024 * 1024 * 10];
                using ( FileStream fs = new FileStream (filePath , FileMode.Open , FileAccess.Read) )
                {

                    bys = new byte[fs.Length];
                    //读取

                    using ( FileStream fs2 = new FileStream (saveMergePath , FileMode.Append , FileAccess.Write) )
                    {
                        while ( true )
                        {
                            int count = fs.Read (bys , 0 , bys.Length);
                            fs2.Write (bys , 0 , bys.Length);//写入
                        }


                    }

                }

                listBox1.Invoke ((Action)( () =>
                {
                    listBox1.Items.Add ("合并" + Path.GetFileName (item.ToString ()) + "完成");

                } ));
                GC.Collect ();


            }
            MessageBox.Show ("完成");
            watch.Stop ();
            listBox1.Invoke ((Action)( () =>
            {
                listBox1.Items.Add ("共耗时:" + watch.ElapsedMilliseconds + "毫秒");

            } ));
            methodState = true;


        }

        bool methodState = false;
        private void timer1_Tick (object sender , EventArgs e)
        {
            if ( methodState )
            {
                if ( t_merge != null )
                {
                    if ( t_merge.IsAlive )
                    {
                        t_merge.Abort ();
                        GC.Collect ();
                    }
                    t_merge = null;

                }
                GC.Collect ();
            }


        }


       
    }
}
