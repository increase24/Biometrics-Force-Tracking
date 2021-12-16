namespace ad_angular
{
    partial class PreSensor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.forceEstimation = new System.Windows.Forms.Button();
            this.Stop_Button = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.textBox_trial = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PreGraph = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot_actualForce = new NationalInstruments.UI.WaveformPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.waveformPlot_targetForce = new NationalInstruments.UI.WaveformPlot();
            this.EMG_Force_Calibration = new System.Windows.Forms.Button();
            this.timer_mvcCalibration = new System.Windows.Forms.Timer(this.components);
            this.MAV_Calibration = new System.Windows.Forms.Button();
            this.EMGwaveform = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot_emg = new NationalInstruments.UI.WaveformPlot();
            this.xAxis2 = new NationalInstruments.UI.XAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer_forceInducing = new System.Windows.Forms.Timer(this.components);
            this.timer_EMG = new System.Windows.Forms.Timer(this.components);
            this.timer_compare = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_mvc = new System.Windows.Forms.TextBox();
            this.textBox_FT_riseTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_FT_descentTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_FT_holdTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_FT_restTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_FI_restTime = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_FI_holdTime = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox_targetForce = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PreGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EMGwaveform)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM4";
            // 
            // forceEstimation
            // 
            this.forceEstimation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.forceEstimation.Location = new System.Drawing.Point(497, 263);
            this.forceEstimation.Name = "forceEstimation";
            this.forceEstimation.Size = new System.Drawing.Size(75, 37);
            this.forceEstimation.TabIndex = 0;
            this.forceEstimation.Text = "Force Tracking";
            this.forceEstimation.UseVisualStyleBackColor = true;
            this.forceEstimation.Click += new System.EventHandler(this.forceEstimation_Click);
            // 
            // Stop_Button
            // 
            this.Stop_Button.Location = new System.Drawing.Point(497, 302);
            this.Stop_Button.Name = "Stop_Button";
            this.Stop_Button.Size = new System.Drawing.Size(75, 35);
            this.Stop_Button.TabIndex = 1;
            this.Stop_Button.Text = "Stop";
            this.Stop_Button.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label.Location = new System.Drawing.Point(138, 267);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(28, 14);
            this.label.TabIndex = 2;
            this.label.Text = "MVC";
            // 
            // textBox_trial
            // 
            this.textBox_trial.Location = new System.Drawing.Point(578, 297);
            this.textBox_trial.Name = "textBox_trial";
            this.textBox_trial.Size = new System.Drawing.Size(56, 21);
            this.textBox_trial.TabIndex = 3;
            this.textBox_trial.Text = "12";
            this.textBox_trial.TextChanged += new System.EventHandler(this.textBox_trial_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PreGraph
            // 
            this.PreGraph.Location = new System.Drawing.Point(14, 22);
            this.PreGraph.Name = "PreGraph";
            this.PreGraph.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot_actualForce,
            this.waveformPlot_targetForce});
            this.PreGraph.Size = new System.Drawing.Size(846, 227);
            this.PreGraph.TabIndex = 4;
            this.PreGraph.UseColorGenerator = true;
            this.PreGraph.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.PreGraph.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            this.PreGraph.PlotDataChanged += new NationalInstruments.UI.XYPlotDataChangedEventHandler(this.PreGraph_PlotDataChanged);
            // 
            // waveformPlot_actualForce
            // 
            this.waveformPlot_actualForce.HistoryCapacity = 10000;
            this.waveformPlot_actualForce.LineColor = System.Drawing.Color.Red;
            this.waveformPlot_actualForce.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.waveformPlot_actualForce.LineWidth = 2F;
            this.waveformPlot_actualForce.XAxis = this.xAxis1;
            this.waveformPlot_actualForce.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.Mode = NationalInstruments.UI.AxisMode.ScopeChart;
            this.xAxis1.Range = new NationalInstruments.UI.Range(0D, 600D);
            // 
            // yAxis1
            // 
            this.yAxis1.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.yAxis1.Range = new NationalInstruments.UI.Range(0D, 1500D);
            // 
            // waveformPlot_targetForce
            // 
            this.waveformPlot_targetForce.HistoryCapacity = 10000;
            this.waveformPlot_targetForce.LineColor = System.Drawing.Color.Lime;
            this.waveformPlot_targetForce.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.waveformPlot_targetForce.LineWidth = 2F;
            this.waveformPlot_targetForce.PointColor = System.Drawing.Color.Lime;
            this.waveformPlot_targetForce.XAxis = this.xAxis1;
            this.waveformPlot_targetForce.YAxis = this.yAxis1;
            // 
            // EMG_Force_Calibration
            // 
            this.EMG_Force_Calibration.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EMG_Force_Calibration.Location = new System.Drawing.Point(228, 282);
            this.EMG_Force_Calibration.Name = "EMG_Force_Calibration";
            this.EMG_Force_Calibration.Size = new System.Drawing.Size(105, 37);
            this.EMG_Force_Calibration.TabIndex = 7;
            this.EMG_Force_Calibration.Text = "Force Inducing";
            this.EMG_Force_Calibration.UseVisualStyleBackColor = true;
            this.EMG_Force_Calibration.Click += new System.EventHandler(this.ForceInducing_Click);
            // 
            // timer_mvcCalibration
            // 
            this.timer_mvcCalibration.Tick += new System.EventHandler(this.timer_mvcCalibration_Tick);
            // 
            // MAV_Calibration
            // 
            this.MAV_Calibration.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MAV_Calibration.Location = new System.Drawing.Point(22, 264);
            this.MAV_Calibration.Name = "MAV_Calibration";
            this.MAV_Calibration.Size = new System.Drawing.Size(96, 39);
            this.MAV_Calibration.TabIndex = 8;
            this.MAV_Calibration.Text = "MVC Calibration";
            this.MAV_Calibration.UseVisualStyleBackColor = true;
            this.MAV_Calibration.Click += new System.EventHandler(this.MAV_Calibration_Click);
            // 
            // EMGwaveform
            // 
            this.EMGwaveform.Location = new System.Drawing.Point(14, 366);
            this.EMGwaveform.Name = "EMGwaveform";
            this.EMGwaveform.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot_emg});
            this.EMGwaveform.Size = new System.Drawing.Size(846, 227);
            this.EMGwaveform.TabIndex = 9;
            this.EMGwaveform.UseColorGenerator = true;
            this.EMGwaveform.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis2});
            this.EMGwaveform.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis2});
            // 
            // waveformPlot_emg
            // 
            this.waveformPlot_emg.HistoryCapacity = 120000;
            this.waveformPlot_emg.XAxis = this.xAxis2;
            this.waveformPlot_emg.YAxis = this.yAxis2;
            // 
            // xAxis2
            // 
            this.xAxis2.Mode = NationalInstruments.UI.AxisMode.ScopeChart;
            this.xAxis2.Range = new NationalInstruments.UI.Range(0D, 60000D);
            // 
            // yAxis2
            // 
            this.yAxis2.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.yAxis2.Range = new NationalInstruments.UI.Range(-2000D, 2000D);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Hand Grip Force";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "sEMG";
            // 
            // timer_forceInducing
            // 
            this.timer_forceInducing.Tick += new System.EventHandler(this.timer_forceInducing_Tick);
            // 
            // timer_EMG
            // 
            this.timer_EMG.Interval = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(587, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "trial";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox_mvc
            // 
            this.textBox_mvc.Location = new System.Drawing.Point(124, 282);
            this.textBox_mvc.Name = "textBox_mvc";
            this.textBox_mvc.Size = new System.Drawing.Size(57, 21);
            this.textBox_mvc.TabIndex = 0;
            this.textBox_mvc.TextChanged += new System.EventHandler(this.textBox_mvc_TextChanged_1);
            // 
            // textBox_FT_riseTime
            // 
            this.textBox_FT_riseTime.Location = new System.Drawing.Point(653, 273);
            this.textBox_FT_riseTime.Name = "textBox_FT_riseTime";
            this.textBox_FT_riseTime.Size = new System.Drawing.Size(75, 21);
            this.textBox_FT_riseTime.TabIndex = 19;
            this.textBox_FT_riseTime.Text = "5";
            this.textBox_FT_riseTime.TextChanged += new System.EventHandler(this.textBox_FT_riseTime_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(653, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "rise time";
            // 
            // textBox_FT_descentTime
            // 
            this.textBox_FT_descentTime.Location = new System.Drawing.Point(752, 273);
            this.textBox_FT_descentTime.Name = "textBox_FT_descentTime";
            this.textBox_FT_descentTime.Size = new System.Drawing.Size(75, 21);
            this.textBox_FT_descentTime.TabIndex = 21;
            this.textBox_FT_descentTime.Text = "5";
            this.textBox_FT_descentTime.TextChanged += new System.EventHandler(this.textBox_FT_descentTime_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(752, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "descent time";
            // 
            // textBox_FT_holdTime
            // 
            this.textBox_FT_holdTime.Location = new System.Drawing.Point(653, 315);
            this.textBox_FT_holdTime.Name = "textBox_FT_holdTime";
            this.textBox_FT_holdTime.Size = new System.Drawing.Size(75, 21);
            this.textBox_FT_holdTime.TabIndex = 23;
            this.textBox_FT_holdTime.Text = "5";
            this.textBox_FT_holdTime.TextChanged += new System.EventHandler(this.textBox_FT_holdTime_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(653, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 24;
            this.label6.Text = "hold time";
            // 
            // textBox_FT_restTime
            // 
            this.textBox_FT_restTime.Location = new System.Drawing.Point(752, 315);
            this.textBox_FT_restTime.Name = "textBox_FT_restTime";
            this.textBox_FT_restTime.Size = new System.Drawing.Size(75, 21);
            this.textBox_FT_restTime.TabIndex = 25;
            this.textBox_FT_restTime.Text = "10";
            this.textBox_FT_restTime.TextChanged += new System.EventHandler(this.textBox_FT_restTime_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(752, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "rest time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(730, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 27;
            this.label8.Text = "s";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(829, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 28;
            this.label9.Text = "s";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(730, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 14);
            this.label10.TabIndex = 29;
            this.label10.Text = "s";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(829, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 14);
            this.label11.TabIndex = 30;
            this.label11.Text = "s";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(425, 278);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 14);
            this.label12.TabIndex = 36;
            this.label12.Text = "s";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(425, 320);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 14);
            this.label13.TabIndex = 35;
            this.label13.Text = "s";
            // 
            // textBox_FI_restTime
            // 
            this.textBox_FI_restTime.Location = new System.Drawing.Point(348, 273);
            this.textBox_FI_restTime.Name = "textBox_FI_restTime";
            this.textBox_FI_restTime.Size = new System.Drawing.Size(75, 21);
            this.textBox_FI_restTime.TabIndex = 33;
            this.textBox_FI_restTime.Text = "10";
            this.textBox_FI_restTime.TextChanged += new System.EventHandler(this.textBox_FI_restTime_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(348, 258);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 34;
            this.label14.Text = "rest time";
            // 
            // textBox_FI_holdTime
            // 
            this.textBox_FI_holdTime.Location = new System.Drawing.Point(348, 315);
            this.textBox_FI_holdTime.Name = "textBox_FI_holdTime";
            this.textBox_FI_holdTime.Size = new System.Drawing.Size(75, 21);
            this.textBox_FI_holdTime.TabIndex = 31;
            this.textBox_FI_holdTime.Text = "90";
            this.textBox_FI_holdTime.TextChanged += new System.EventHandler(this.textBox_FI_holdTime_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(348, 300);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 32;
            this.label15.Text = "hold time";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(20, 316);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 28);
            this.label16.TabIndex = 37;
            this.label16.Text = "target force:\r\n   (%MVC)";
            // 
            // comboBox_targetForce
            // 
            this.comboBox_targetForce.FormattingEnabled = true;
            this.comboBox_targetForce.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1.0"});
            this.comboBox_targetForce.Location = new System.Drawing.Point(124, 320);
            this.comboBox_targetForce.Name = "comboBox_targetForce";
            this.comboBox_targetForce.Size = new System.Drawing.Size(57, 20);
            this.comboBox_targetForce.TabIndex = 38;
            this.comboBox_targetForce.TextChanged += new System.EventHandler(this.comboBox_targetForce_TextChanged);
            // 
            // PreSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 616);
            this.Controls.Add(this.comboBox_targetForce);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox_FI_restTime);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox_FI_holdTime);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.MAV_Calibration);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_trial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_FT_restTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_FT_holdTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_FT_descentTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_FT_riseTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_mvc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EMGwaveform);
            this.Controls.Add(this.EMG_Force_Calibration);
            this.Controls.Add(this.PreGraph);
            this.Controls.Add(this.Stop_Button);
            this.Controls.Add(this.forceEstimation);
            this.Name = "PreSensor";
            this.Text = "Muscle assessment ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EMGwaveform)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button forceEstimation;
        private System.Windows.Forms.Button Stop_Button;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox_trial;
        private System.Windows.Forms.Timer timer1;
        private NationalInstruments.UI.WindowsForms.WaveformGraph PreGraph;
        private NationalInstruments.UI.WaveformPlot waveformPlot_actualForce;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private NationalInstruments.UI.WaveformPlot waveformPlot_targetForce;
        private System.Windows.Forms.Button EMG_Force_Calibration;
        private System.Windows.Forms.Timer timer_mvcCalibration;
        private System.Windows.Forms.Button MAV_Calibration;
        private NationalInstruments.UI.WindowsForms.WaveformGraph EMGwaveform;
        private NationalInstruments.UI.WaveformPlot waveformPlot_emg;
        private NationalInstruments.UI.XAxis xAxis2;
        private NationalInstruments.UI.YAxis yAxis2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_forceInducing;
        private System.Windows.Forms.Timer timer_EMG;
        private System.Windows.Forms.Timer timer_compare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_mvc;
        private System.Windows.Forms.TextBox textBox_FT_riseTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_FT_descentTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_FT_holdTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_FT_restTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_FI_restTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_FI_holdTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox_targetForce;
    }
}

