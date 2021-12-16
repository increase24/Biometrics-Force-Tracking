using NationalInstruments.Analysis;
using NationalInstruments.Analysis.Conversion;
using NationalInstruments.Analysis.Dsp;
using NationalInstruments.Analysis.Dsp.Filters;
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis.Monitoring;
using NationalInstruments.Analysis.SignalGeneration;
using NationalInstruments.Analysis.SpectralMeasurements;
using NationalInstruments;
using NationalInstruments.UI;
using NationalInstruments.NetworkVariable;
using NationalInstruments.NetworkVariable.WindowsForms;
using NationalInstruments.Tdms;
using NationalInstruments.UI.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using OnLineInterfaceLib;
using System.Threading;
using System.Runtime.InteropServices;
using Wavelet_EMGNative;
using MathWorks.MATLAB.NET.Arrays;


namespace ad_angular
{
    public partial class PreSensor : Form
    {
        public string CurrentDictionary;
        private const int ONLINE_GETERROR = (int)StatusOption.ONLINE_GETERROR;
        private const int ONLINE_GETENABLE = (int)StatusOption.ONLINE_GETENABLE;
        private const int ONLINE_GETRATE = (int)StatusOption.ONLINE_GETRATE;
        private const int ONLINE_GETSAMPLES = (int)StatusOption.ONLINE_GETSAMPLES;
        private const int ONLINE_GETVALUE = (int)StatusOption.ONLINE_GETVALUE;
        private const int ONLINE_START = (int)StatusOption.ONLINE_START;
        private const int ONLINE_STOP = (int)StatusOption.ONLINE_STOP;
        private const int ONLINE_OK = (int)ErrorCode.ONLINE_OK;
        private const int ONLINE_COMMSFAIL = (int)ErrorCode.ONLINE_COMMSFAIL;
        private const int ONLINE_OVERRUN = (int)ErrorCode.ONLINE_OVERRUN;
        OnLineClass Biometrics;
        int Channel;
        int stop;
        int SamplesPerSec;
        int[] pStatus = new int[4];
        int startSamplePre1;
        int numberSamplePre1;
        private int pActualSamples;
        System.DateTime startPre;
        double MVC=600.0;//最大主动收缩力
        double targetMVC = 300.0;//最大主动收缩力
        int FI_restTime, FI_holdTime, FT_restTime, FT_holdTime, FT_riseTime, FT_descentTime;
        int num_trial = 12;

        bool EMGReceiveFlag;
        private int counter2 = 0;
        private int counter5 = 0;
        int counter6;
        int FESTrigerCount=0;
        double Threshold=500.00;
        double rms_h,rms_l;
        double bimetrics_t;
        double t_targetForce;//timer for plotting target Force  
        double scale_force;
        MyQueue<double> EMGQueue=new MyQueue<double>(256);
        private List<short> DataBuffer1;
        Int16[] dataBuffer = new Int16[8];
        Int16[] Channelx = new Int16[16];
        private List<Int16> EMGData;

        private List<double> EMGArray { get; set; }
        private List<double> ForceArray { get; set; }

        //#region **waveform show**
        public List<float> DelayTime = new List<float>();
        public List<double> EmgStiffness = new List<double>();

        public List<int> ActualSamples1 = new List<int>();
        public List<int> ActualSamples2 = new List<int>();

        public List<int> PActualSamples2 = new List<int>();
        public List<double> ActPressureXpoint = new List<double>();
        public List<double> ActPressureYpoint = new List<double>();

        public List<int> PActualSamples3 = new List<int>();
        public List<float> MyPressureXpoint = new List<float>();
        public List<float> MyPressureYpoint = new List<float>();

        public List<float> DuringXpoint = new List<float>();
        public List<float> DuringYpoint = new List<float>();

        public List<float> StatusXpoint = new List<float>();
        public List<float> StatusYpoint = new List<float>();     //define: stiffness:1, slipping:2, pressure:3, broken:4, crush:5, Normal:6

        public List<double> ChangeXpoint = new List<double>();
        public List<double> ChangeYpoint = new List<double>();
        public List<double> StiffnessCorrect = new List<double>();     //define: -1: wrong and feeling of stiffness low; 0: correct; 1: wrong and feeling of stiffness high

        //#endregion
 
        public PreSensor()
        {
            InitializeComponent();
            GraphicInitialize();
            Biometrics = new OnLineClass();
            EMGArray = new List<double>();
            ForceArray = new List<double>();
            Biometrics.OnLineStatus(0, (int)OnLineInterfaceLib.StatusOption.ONLINE_STOP, out stop);
            timer1.Interval = 100;

            Int16[] dataBuffer = new Int16[8];
            DataBuffer1 = new List<short>();
            EMGData = new List<Int16>();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 256; i++)
            {
                EMGQueue.Enqueue(0.0);
            }
            EMGReceiveFlag = false;
            Stop_Button.Enabled = false;

            num_trial = int.Parse(textBox_trial.Text);
            FI_restTime = int.Parse(textBox_FI_restTime.Text);
            FI_holdTime = int.Parse(textBox_FI_holdTime.Text);
            FT_riseTime = int.Parse(textBox_FT_riseTime.Text);
            FT_descentTime = int.Parse(textBox_FT_descentTime.Text);
            FT_holdTime = int.Parse(textBox_FT_holdTime.Text);
            FT_restTime = int.Parse(textBox_FT_restTime.Text);
        }

        /// <summary>
        /// //initiate the graph
        /// </summary>
        private void GraphicInitialize()
        {
            DelayTime.Clear();
            EmgStiffness.Clear();
            PActualSamples2.Clear();
            PActualSamples3.Clear();
            ActualSamples1.Clear();
            ActualSamples2.Clear();
            ActPressureXpoint.Clear();
            ActPressureYpoint.Clear();
            MyPressureXpoint.Clear();
            MyPressureYpoint.Clear();
            StatusXpoint.Clear();
            StatusYpoint.Clear();
            ChangeXpoint.Clear();
            ChangeYpoint.Clear();
            DuringXpoint.Clear();
            DuringYpoint.Clear();
            StiffnessCorrect.Clear();
        }


        /*
         * 最大主动收缩力标定
         */
        double force_calibration = 0;
        private void MAV_Calibration_Click(object sender, EventArgs e)
        {
            ForceArray.Clear();
            EMGArray.Clear();
            waveformPlot_targetForce.ClearData();
            waveformPlot_actualForce.ClearData();
            Biometrics.OnLineStatus(0, (int)OnLineInterfaceLib.StatusOption.ONLINE_START, out  pStatus[0]);                    //begin the sample of EMG         
            Biometrics.OnLineStatus(Channel, (int)OnLineInterfaceLib.StatusOption.ONLINE_GETENABLE, out pStatus[1]);       //check the Channel1 enabled

            if (pStatus[1] == 1)                                                                                           //channel is enabled
            {
                Biometrics.OnLineStatus(Channel, (int)OnLineInterfaceLib.StatusOption.ONLINE_GETRATE, out pStatus[2]);     //get the sample rate
                SamplesPerSec = pStatus[2];
            }
            startPre = System.DateTime.Now;
            bimetrics_t = 0;
            timer_mvcCalibration.Start();
            MAV_Calibration.Enabled = false;
        }



        private void ForceInducing_Click(object sender, EventArgs e)
        {
            ForceArray.Clear();
            EMGArray.Clear();
            waveformPlot_actualForce.ClearData();
            waveformPlot_targetForce.ClearData();
            waveformPlot_emg.ClearData();
            Biometrics.OnLineStatus(0, (int)OnLineInterfaceLib.StatusOption.ONLINE_START, out  pStatus[0]);                    //begin the sample of EMG         
            Biometrics.OnLineStatus(Channel, (int)OnLineInterfaceLib.StatusOption.ONLINE_GETENABLE, out pStatus[1]);       //check the Channel1 enabled

            if (pStatus[1] == 1)                                                                                           //channel is enabled
            {
                Biometrics.OnLineStatus(Channel, (int)OnLineInterfaceLib.StatusOption.ONLINE_GETRATE, out pStatus[2]);     //get the sample rate
                SamplesPerSec = pStatus[2];
            }
            startPre = System.DateTime.Now;
            bimetrics_t = 0;
            timer_forceInducing.Start();//plot力数据的定时器
            // timer_EMG.Start();//plot肌电数据的定时器

        }


        private void EMG_Force_Calibration_Click(object sender, EventArgs e)
        {
            ForceArray.Clear();
            EMGArray.Clear();
            waveformPlot_actualForce.ClearData();
            waveformPlot_targetForce.ClearData();
            waveformPlot_emg.ClearData();
            Biometrics.OnLineStatus(0, (int)OnLineInterfaceLib.StatusOption.ONLINE_START, out  pStatus[0]);                    //begin the sample of EMG         
            Biometrics.OnLineStatus(Channel, (int)OnLineInterfaceLib.StatusOption.ONLINE_GETENABLE, out pStatus[1]);       //check the Channel1 enabled

            if (pStatus[1] == 1)                                                                                           //channel is enabled
            {
                Biometrics.OnLineStatus(Channel, (int)OnLineInterfaceLib.StatusOption.ONLINE_GETRATE, out pStatus[2]);     //get the sample rate
                SamplesPerSec = pStatus[2];
            }
            startPre = System.DateTime.Now;
            bimetrics_t=0;
            timer_forceInducing.Start();//plot力数据的定时器
            timer_EMG.Start();//plot肌电数据的定时器
            if (serialPort1.IsOpen)
            {
                byte[] data = new byte[10] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                byte[] data1 = new byte[1] { 0x00 };
                data[0] = 0xA0;
                data[1] = 0x01;
                data[8] = 0x05;

                for (int i = 0; i < 9; i++)
                {
                    data[9] += data[i];
                }

                for (int j = 0; j < 3; j++)        //传输指令
                {
                    for (int i = 0; i < 10; i++)
                    {

                        data1[0] = data[i];
                        serialPort1.Write(data1, 0, 1);
                        System.Threading.Thread.Sleep(2);
                    }

                }
            }
            //Calibration1.Enabled = false;
        }




        private void forceEstimation_Click(object sender, EventArgs e)
        {
            waveformPlot_targetForce.ClearData();
            waveformPlot_actualForce.ClearData();
            //serialPort1.Open();
            Biometrics.OnLineStatus(0, (int)OnLineInterfaceLib.StatusOption.ONLINE_START, out  pStatus[0]);                    //begin the sample of EMG
           //if (pStatus[0] == (int)OnLineInterfaceLib.ErrorCode.ONLINE_OK)                                                   //check for error
            {
                //button_Start.Text = "Stop";

                Biometrics.OnLineStatus(Channel, (int)OnLineInterfaceLib.StatusOption.ONLINE_GETENABLE, out pStatus[1]);       //chack the Channel1 enabled

                if (pStatus[1] == 1)                                                                                           //channel is enabled
                {
                    Biometrics.OnLineStatus(Channel, (int)OnLineInterfaceLib.StatusOption.ONLINE_GETRATE, out pStatus[2]);     //get the sample rate
                    SamplesPerSec = pStatus[2];
                    //datalink_status.Text = "Channel1:" + pStatus[2] + "samples per second";                         //the indication of  status
                }
                //else { datalink_status.Text = "Channe1 disabled"; }                                                          //Channel1 is not enabled
                //GraphicInitialize();
                startPre = System.DateTime.Now;
                t_targetForce = 0;//输出指示力时间间隔的计数器
                if (textBox_trial.Text != "")
                { MVC = double.Parse(textBox_trial.Text); }
                scale_force = MVC / (2.5 * 1000.0 / timer1.Interval);//10s内力从0到MVC线性变化
                timer1.Start();
                //Start_Button.Enabled = false;
            }
        }


        /*
         * timer1用于输出阶梯波
         * waveformPlot1：实际的力曲线
         * waveformPlot2：指示的力曲线
         * 20181203,暂时还未用到
         */
        int counter_waves;
        double targetForce;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Biometrics.OnLineStatus(0, ONLINE_GETVALUE, out pActualSamples);  //与biometric通信读取数据至pActualSamples
            double force = (pActualSamples - 4000);
            waveformPlot_actualForce.PlotYAppend(force);
            double t_targetForce_remainder = t_targetForce % 11;
            if (t_targetForce_remainder >= 0 && t_targetForce_remainder < 3)
            {
                waveformPlot_targetForce.PlotYAppend(0);
                //waveformPlot_unfatigued.PlotYAppend(0.9*MVC);
                //waveformPlot_fatigued.PlotYAppend(0.7*MVC);
            }
            else if (t_targetForce_remainder >= 3 && t_targetForce_remainder < 5.5)
            {
                targetForce += scale_force;
                waveformPlot_targetForce.PlotYAppend(targetForce);
                //waveformPlot_unfatigued.PlotYAppend(0.9 * MVC);
                //waveformPlot_fatigued.PlotYAppend(0.7 * MVC);
            }
            else if (t_targetForce_remainder >= 5.5 && t_targetForce_remainder < 8)
            {
                targetForce -= scale_force;
                waveformPlot_targetForce.PlotYAppend(targetForce);
                //waveformPlot_unfatigued.PlotYAppend(0.9 * MVC);
                //waveformPlot_fatigued.PlotYAppend(0.7 * MVC);
            }
            else if (t_targetForce_remainder >= 8 && t_targetForce_remainder < 11)
            {
                waveformPlot_targetForce.PlotYAppend(0);
                //waveformPlot_unfatigued.PlotYAppend(0.9 * MVC);
                //waveformPlot_fatigued.PlotYAppend(0.7 * MVC);
            }
            if (t_targetForce_remainder >= 10.9 && t_targetForce_remainder < 11)
            {
                counter_waves++;
                if (counter_waves == 55) //定义trial数
                {
                    timer1.Stop();
                    Biometrics.OnLineStatus(0, (int)OnLineInterfaceLib.StatusOption.ONLINE_STOP, out pStatus[0]);
                }
            }
            t_targetForce += 0.1;
        }


        /*
         * timer_mvcCalibration服务于MVC的标定，只测量最大力，不采肌电
         * * interval=100ms
         * waveformPlot_actualForce:实际力信号
         * waveformPlot_targetForce:期望波形
         */

        private void timer_mvcCalibration_Tick(object sender, EventArgs e)
        {
            Biometrics.OnLineStatus(0, ONLINE_GETVALUE, out pActualSamples); //与biometric通信读取数据至pActualSamples
            double force = (pActualSamples - 4000);
            waveformPlot_actualForce.PlotYAppend(force);
            ForceArray.Add(force);
            bimetrics_t += 0.1;
            if (bimetrics_t > 0 && bimetrics_t < 5)
            {
                waveformPlot_targetForce.PlotYAppend(0);
            }
            else if (bimetrics_t >= 5 && bimetrics_t < 10)
            {
                waveformPlot_targetForce.PlotYAppend(800);
            }
            else if (bimetrics_t >= 10 && bimetrics_t < 15)
            {
                waveformPlot_targetForce.PlotYAppend(0);
            }
            if (bimetrics_t >= 14.9 && bimetrics_t < 15)
            {
                timer_mvcCalibration.Stop();
                Biometrics.OnLineStatus(0, (int)OnLineInterfaceLib.StatusOption.ONLINE_STOP, out pStatus[0]);
                MAV_Calibration.Enabled = true;
                for (int i = 71; i <= 100; i++)
                {
                    force_calibration = force_calibration + ForceArray[i];
                }
                force_calibration = force_calibration / 30;
                textBox_mvc.Text = Math.Round(force_calibration, 2).ToString();
            }   
        }

        /*
         * timer_forceInducing用于恒力下的疲劳诱发实验
         * * interval=100ms
         * waveformPlot_actualForce:实际力信号
         * waveformPlot_targetForce:期望波形
         */
        private void timer_forceInducing_Tick(object sender, EventArgs e)
        {
            Biometrics.OnLineStatus(0, ONLINE_GETVALUE, out pActualSamples);  //与biometric通信读取数据至pActualSamples
            double force = (pActualSamples - 4000);
            waveformPlot_actualForce.PlotYAppend(force);
            ForceArray.Add(force);
            bimetrics_t += 0.1;
            if (bimetrics_t > 0 && bimetrics_t < FI_restTime)
            {
                waveformPlot_targetForce.PlotYAppend(0);
            }
            else if (bimetrics_t >= FI_restTime && bimetrics_t < FI_holdTime + FI_restTime)
            {
                waveformPlot_targetForce.PlotYAppend(targetMVC);
            }
            if (bimetrics_t >= FI_holdTime + FI_restTime - 0.1 && bimetrics_t < FI_holdTime + FI_restTime)
            {
                timer_forceInducing.Stop();
                Biometrics.OnLineStatus(0, (int)OnLineInterfaceLib.StatusOption.ONLINE_STOP, out pStatus[0]);
            } 
        }

        /*
         * 串口接受数据（中断）
         */
        private void serialPortDataReceived1(object sender, SerialDataReceivedEventArgs e)
        {
            int DataCount1 = serialPort1.BytesToRead;
            byte[] readBuffer1 = new byte[DataCount1];
            serialPort1.Read(readBuffer1, 0, readBuffer1.Length);//当调用Read方法读取数据之后,缓存就没有了
            if (EMGReceiveFlag == true)
            {
                for (int i = 0; i < DataCount1; i++)
                {

                    DataBuffer1.Add(readBuffer1[i]);
                    counter2++;
                    if (counter2 >= 16&&DataBuffer1[counter2 - 1] == 0x0A && DataBuffer1[counter2 - 2] == 0x0D)
                    {

                        for (int j = 0; j < 8; j++)
                        {
                            //short c = 0;
                            Channelx[j] = (short)(DataBuffer1[counter2 - 16 + j] << 4);//读取通道j的高8位

                            if ((j % 2) != 0)
                            {
                                Channelx[j] += (short)(DataBuffer1[counter2 - 8 + j / 2] & 0x0F);

                            }
                            else
                            {
                                Channelx[j] += (short)((DataBuffer1[counter2 - 8 + j / 2] & 0xF0) >> 4);

                            }
                            if ((Channelx[j] & 0x0800) != 0)//转换为有符号数
                            {
                                Channelx[j] = (short)((Channelx[j] | 0xF000));
                            }
                        }
                        EMGData.Add(Channelx[0]);
                        EMGQueue.Enqueue(Channelx[0]);
                    }       
                }          
            }
        }

        //public static string GetCurrentDirectory()
        //{
        //    string dir = Directory.GetCurrentDirectory();
        //    dir = dir.Substring(0, dir.Length - 10);
        //    return dir;
        //} 

        private void PreGraph_PlotDataChanged(object sender, XYPlotDataChangedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Threshold_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_mvc_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                MVC = double.Parse(textBox_mvc.Text);
                try
                {
                    targetMVC = MVC * double.Parse(comboBox_targetForce.Text);
                }
                catch { }
            }
            catch { }
        }

        private void comboBox_targetForce_TextChanged(object sender, EventArgs e)
        {
            try
            {
                targetMVC = MVC * double.Parse(comboBox_targetForce.Text);
            }
            catch { }
        }

        private void textBox_trial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                num_trial = int.Parse(textBox_trial.Text);
            }
            catch { }
        }

        private void textBox_FI_restTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FI_restTime = int.Parse(textBox_FI_restTime.Text);
            }
            catch { }
        }

        private void textBox_FI_holdTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FI_holdTime = int.Parse(textBox_FI_holdTime.Text);
            }
            catch { }
        }

        private void textBox_FT_riseTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FT_riseTime = int.Parse(textBox_FT_riseTime.Text);
            }
            catch { }
        }

        private void textBox_FT_holdTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FT_holdTime = int.Parse(textBox_FT_holdTime.Text);
            }
            catch { }
        }

        private void textBox_FT_descentTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FT_descentTime = int.Parse(textBox_FT_descentTime.Text);
            }
            catch { }
        }

        private void textBox_FT_restTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FT_restTime = int.Parse(textBox_FT_restTime.Text);
            }
            catch { }
        }



    }
}
