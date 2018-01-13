using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
//using System.Diagnostics;

namespace SerialPortTools
{
    public partial class Form1 : Form
    {
        SerialPort sp = null; //声明一个串口类
        bool IsOped = false;  //打开串口标志位
        bool IsSetProperty = false; //属性设置标志位
        bool IsHEX = false;  //十六进制显示标志位
       

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
            sp = new SerialPort
            {
                PortName = CbxCOMPort.Text.Trim(),

                BaudRate = Convert.ToInt32(CbxBaudBate.Text.Trim())
            };

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

            sp.RtsEnable = true;

            try
            {               
                sp.DataReceived += new SerialDataReceivedEventHandler(Sp_DataReceived);
            }
            catch (Exception)
            {
                MessageBox.Show("接收进程错误","错误提示");
            }

            if (RbnHex.Checked)
            {
                IsHEX = true;
            }
            else
            {
                IsHEX = false;
            }

        }

        //接收进程
        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (IsHEX == false)
                {
                    try
                    {
                        TbxRecvData.Text += sp.ReadLine();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ASCII接收错误","错误提示");
                    }                   
                }
                else
                {
                    try
                    {
                        Byte[] ReceivedData = new Byte[sp.BytesToRead];//创建接收字节数组
                        sp.Read(ReceivedData, 0, ReceivedData.Length);//读取所接收到的数据
                        string RecvDataText = null;
                        for (int i = 0; i < ReceivedData.Length; i++)
                        {
                            RecvDataText +=( ReceivedData[i].ToString("X2") + "");
                        }
                        TbxRecvData.Text += RecvDataText;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("16进制数接收错误", "错误提示");
                        TbxRecvData.Text = "";
                    }
                }
                sp.DiscardInBuffer(); //丢弃接收缓冲区数据
                System.Diagnostics.Debug.WriteLine("接收数据");
            }
            catch (Exception)
            {
                MessageBox.Show("接收线程错误","错误提示");
            }
        }

        //发送数据按钮
        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (IsOped)//写串口数据
            {
                try
                {
                    if (IsHEX == false)
                    {
                        sp.WriteLine(TbxSendData.Text);
                    }
                    else
                    {
                        Byte[] SendData = new Byte[TbxSendData.Text.Length];
                        string s = TbxSendData.Text;
                        for (int i = 0; i < TbxSendData.Text.Length; i++)
                        {
                            SendData[i] = Convert.ToByte(s[i]);
                        }
                        sp.Write(SendData,0,TbxSendData.Text.Length);
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
                }
                catch (Exception)
                {
                    MessageBox.Show("串口无法关闭", "错误提示");
                }
            }

        }

        private void BtnCleanData_Click(object sender, EventArgs e)
        {
            TbxRecvData.Text = "";
            TbxSendData.Text = "";
        }


    }


}
