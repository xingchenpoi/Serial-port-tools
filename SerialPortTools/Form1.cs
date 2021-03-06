﻿using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SerialPortTools
{
    public partial class Form1 : Form
    {
        SerialPort sp = new SerialPort(); //声明一个串口类
        bool IsOped = false;  //打开串口标志位
        bool IsSetProperty = false; //属性设置标志位
        private StringBuilder builder = new StringBuilder(); //避免在事件处理方法中反复的创建，定义到外面。
        private long received_count = 0;  //接收计数
        //private long send_count = 0;//发送计数


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;

            CbxCOMPort.SelectedIndex = 0;
            CbxBaudBate.SelectedIndex = 5;
            CbxStopBits.SelectedIndex = 1;
            CbxDataBits.SelectedIndex = 0;
            CbxParity.SelectedIndex = 0;

            sp.NewLine = "\r\n";

            bool COMExistence = false; //有可用的串口标志
            CbxCOMPort.Items.Clear();  //清除当前串口号中的说有串口名称
            //优化串口检测按钮，使其不输出错误的调试信息
            try
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    CbxCOMPort.Items.Add(s);
                }
                COMExistence = true;

            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("串口打开失败");
            }

            if (COMExistence)
            {
                CbxCOMPort.SelectedIndex = 0;//使显示LISTBOX显示第1个添加的索引
            }
            else
            {
                MessageBox.Show("我没有找到可使用串口！", "错误提示");
            }

           
        }


        private bool CheckPortSetting()//检查串口是否设置
        {
            if (CbxCOMPort.Text.Trim() == "")
                return false;
            if(CbxBaudBate.Text.Trim() == "")
                return false;
            if (CbxDataBits.Text.Trim() == "")
                return false;
            if (CbxParity.Text.Trim() == "")
                return false;
            if (CbxStopBits.Text.Trim() == "")
                return false;
            return true;
        }

        private bool CheckSendData()
        {
            if (TbxSendData.Text.Trim() == "")
                return false;
            return true;
        }



        private void SetPortProperty() //设置串口属性
        {
            sp.PortName = CbxCOMPort.Text.Trim();
            sp.BaudRate = Convert.ToInt32(CbxBaudBate.Text.Trim());

            float f = Convert.ToSingle(CbxStopBits.Text.Trim());

            if (f == 0)
            {
                sp.StopBits = StopBits.None;
            }
            else if (f == 1)
            {
                sp.StopBits = StopBits.One;
            }
            else if (f == 1.5)
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (f == 2)
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }
           
            try
            {
                int temp = Convert.ToInt16(CbxDataBits.Text.Trim());
                sp.DataBits = temp;
                System.Diagnostics.Debug.WriteLine("数据位设置正确");
            }
            catch
            {
                MessageBox.Show("数据位设置错误","错误信息");
            }
           
           
            string s = CbxParity.Text.Trim();//设置奇偶校验

            if (s.CompareTo("无") == 0)
            {
                sp.Parity = Parity.None;
            }
            else if (s.CompareTo("奇校验") == 0)
            {
                sp.Parity = Parity.Odd;
            }
            else if (s.CompareTo("偶校验") == 0)
            {
                sp.Parity = Parity.Even;
            }
            else
            {
                sp.Parity = Parity.None;
            }

            sp.ReadTimeout = -1;  //设置超时读取时间

            //sp.RtsEnable = true;

            try
            {
                sp.DataReceived += new SerialDataReceivedEventHandler(Sp_DataReceived);
            }
            catch (Exception)
            {
                MessageBox.Show("创建接收进程错误","错误提示");
            }

        }

        //接收进程
        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int TextNum = sp.BytesToRead;  //获取接收的字节数
            byte[] buff = new byte[TextNum];   //声明一个临时数组来存储当前的串口数据
            received_count += TextNum;         //记录接收的字节数
            sp.Read(buff, 0, TextNum);       //获取串口数据
            builder.Clear();         //清除字符串构造器的内容


            //一定要加上INVOKE,不然会出现莫名奇妙的问题   因为要访问ui资源，所以需要invoke同步UI  
            this.Invoke((EventHandler)(delegate {
                try
                {
                    if (RbnHex.Checked)                   
                    {
                        try
                        {
                            foreach (byte b in buff)
                            {
                                builder.Append(b.ToString("X2")+ " ");
                            }
                            System.Diagnostics.Debug.WriteLine("接收16进制数据");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("16进制数接收错误", "错误提示");
                            TbxRecvData.Text = "";
                        }
                    }
                    else
                    {
                        try
                        {
                            builder.Append(Encoding.ASCII.GetString(buff));  //直接按ASCII规则转换成字符串  
                            System.Diagnostics.Debug.WriteLine("接收ASCII数据");

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("ASCII接收错误", "错误提示");
                        }
                    }
                    //追加的形式添加到文本框末端，并滚动到最后。
                    this.TbxRecvData.AppendText(builder.ToString());

                    sp.DiscardInBuffer(); //丢弃接收缓冲区数据
                    System.Diagnostics.Debug.WriteLine("接收数据");
                }
                catch (Exception)
                {
                    MessageBox.Show("接收线程错误", "错误提示");
                }
            }));

        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] StrToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        //发送数据按钮
        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (IsOped)//写串口数据
            {
                try
                {
                    //如果定时发送数据按钮已选上
                    if (CB_TimeSend.Checked)
                    {
                        if (Timer.Enabled == false)
                        {
                            Timer.Start();
                        }
                            
                    }
                    else
                    {
                        if (Timer.Enabled == true)
                        {
                            Timer.Stop();  //停止定时器
                        }
                    }
                    if (RbnHex.Checked)
                    {
                        byte[] buff = new byte[TbxSendData.Text.Length/2];
                        buff = StrToToHexByte(TbxSendData.Text);
                        sp.Write(buff,0,buff.Length);
                        System.Diagnostics.Debug.WriteLine("发送16进制数据");
                    }
                    else
                    {
                        sp.WriteLine(TbxSendData.Text);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("发送数据时发生错误！", "错误提示");
                }
            }
            else
            {
                MessageBox.Show("串口未打开","错误提示");
            }
        }


        


        //打开串口按钮
        private void BtnOpenCOM_Click(object sender, EventArgs e)
        {
            if (IsOped == false)
            {
                if (!CheckPortSetting())//检测串口设置
                {
                    MessageBox.Show("串口未设置！", "错误提示");
                    return;
                }
                if (!IsSetProperty)//串口为设置则设置串口
                {
                    SetPortProperty();
                    IsSetProperty = true;
                }

                try//打开串口
                {
                    sp.Open();
                    IsOped = true;
                    BtnOpenCOM.Text = "关闭串口";
                    //串口打开后则相关的串口设置按钮便不可再用
                    CbxCOMPort.Enabled = false;
                    CbxBaudBate.Enabled = false;
                    CbxDataBits.Enabled = false;
                    CbxParity.Enabled = false;
                    CbxStopBits.Enabled = false;
                    RbnChar.Enabled = false;
                    RbnHex.Enabled = false;
                }
                catch (Exception)
                {
                    //打开串口失败后，响应标志为取消
                    IsSetProperty = false;
                    IsOped = false;
                    Timer.Enabled = false;       //关闭定时器
                    MessageBox.Show("串口无效或已被占用", "错误提示");
                }
            }
            else
            {
                try//关闭串口
                {
                    sp.Close();
                    IsOped = false;
                    BtnOpenCOM.Text = "打开串口";
                    //串口打开后则相关的串口设置按钮便不可再用
                    CbxCOMPort.Enabled = true;
                    CbxBaudBate.Enabled = true;
                    CbxDataBits.Enabled = true;
                    CbxParity.Enabled = true;
                    CbxStopBits.Enabled = true;
                    RbnChar.Enabled = true;
                    RbnHex.Enabled = true;
                    Timer.Stop();  //停止定时器
                }
                catch (Exception)
                {
                    Timer.Stop();  //停止定时器
                    MessageBox.Show("串口无法关闭", "错误提示");
                }
            }

        }

        //清空按钮
        private void BtnCleanData_Click(object sender, EventArgs e)
        {
            TbxRecvData.Clear();
            TbxSendData.Clear();
        }

        //定时器事件
        private void Timer_Tick(object sender, EventArgs e)
        {
            string strsecond = TB_SentTime.Text;
            try
            {
                int isecond = int.Parse(strsecond);
                Timer.Interval = isecond;
                if (Timer.Enabled == true)
                {
                    BtnSend.PerformClick();
                }
            }
            catch (Exception)
            {
                Timer.Stop();  //停止定时器
                MessageBox.Show("打开定时器失败", "错误提示");
            }

        }

    }


}
