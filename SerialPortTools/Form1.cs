using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

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
           
        }

        private void BtnCheckCOM_Click(object sender, EventArgs e)
        {
            bool COMExistence = false; //有可用的串口标志
            CbxCOMPort.Items.Clear();  //清除当前串口号中的说有串口名称
            for (int i = 0; i < 40; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    sp.Close();
                    CbxCOMPort.Items.Add("COM" + (i + 1).ToString());
                    COMExistence = true;
                }
                catch (Exception)
                {
                    continue;
                }
                if (COMExistence)
                {
                    CbxCOMPort.SelectedIndex = 0;//使显示LISTBOX显示第1个添加的索引
                }
                else
                {
                    MessageBox.Show("我没有找到可使用串口！","错误提示");
                }
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
            sp = new SerialPort();

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

            sp.DataBits = Convert.ToInt16(CbxBaudBate.Text.Trim());

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


        }
    }


}
