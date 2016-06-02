<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_APAX_5017H
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Btn_Quit = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar()
        Me.tcRemote = New System.Windows.Forms.TabControl()
        Me.tabModuleInfo = New System.Windows.Forms.TabPage()
        Me.btnLocate = New System.Windows.Forms.Button()
        Me.lblLocate = New System.Windows.Forms.Label()
        Me.labADVer = New System.Windows.Forms.Label()
        Me.txtAIOFwVer = New System.Windows.Forms.TextBox()
        Me.txtModuleID = New System.Windows.Forms.TextBox()
        Me.labModule = New System.Windows.Forms.Label()
        Me.labID = New System.Windows.Forms.Label()
        Me.labFwVer = New System.Windows.Forms.Label()
        Me.txtSWID = New System.Windows.Forms.TextBox()
        Me.txtFwVer = New System.Windows.Forms.TextBox()
        Me.txtSupportKernelFw = New System.Windows.Forms.TextBox()
        Me.labSupportKernelFw = New System.Windows.Forms.Label()
        Me.tabAI = New System.Windows.Forms.TabPage()
        Me.listViewChInfo = New System.Windows.Forms.ListView()
        Me.clmType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmCh = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmChStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmRange = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panelConfig = New System.Windows.Forms.Panel()
        Me.cbxSampleRate = New System.Windows.Forms.ComboBox()
        Me.labSampleRate = New System.Windows.Forms.Label()
        Me.btnSampleRate = New System.Windows.Forms.Button()
        Me.labBurnout = New System.Windows.Forms.Label()
        Me.btnBurnoutFcn = New System.Windows.Forms.Button()
        Me.chkBurnoutFcn = New System.Windows.Forms.CheckBox()
        Me.cbxBurnoutValue = New System.Windows.Forms.ComboBox()
        Me.labBurnoutValue = New System.Windows.Forms.Label()
        Me.cbxRange = New System.Windows.Forms.ComboBox()
        Me.chkApplyAll = New System.Windows.Forms.CheckBox()
        Me.btnApplySelRange = New System.Windows.Forms.Button()
        Me.labRange = New System.Windows.Forms.Label()
        Me.btnBurnoutValue = New System.Windows.Forms.Button()
        Me.panelSetting = New System.Windows.Forms.Panel()
        Me.cbRawData = New System.Windows.Forms.CheckBox()
        Me.cbSetPanelHide = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListDOInfo = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.chbxHide = New System.Windows.Forms.CheckBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmMode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmSafety = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.btnTrue = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnFalse = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.comport = New System.IO.Ports.SerialPort(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReceieveTxtBox = New System.Windows.Forms.TextBox()
        Me.SendTxtBox = New System.Windows.Forms.TextBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.saveData = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ipText = New System.Windows.Forms.TextBox()
        Me.tcRemote.SuspendLayout()
        Me.tabModuleInfo.SuspendLayout()
        Me.tabAI.SuspendLayout()
        Me.panelConfig.SuspendLayout()
        Me.panelSetting.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.panelMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(402, 403)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 15
        Me.Btn_Quit.Text = "Quit"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(323, 403)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 13
        Me.btnStart.Text = "Start"
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 454)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(482, 24)
        Me.StatusBar_IO.TabIndex = 16
        '
        'tcRemote
        '
        Me.tcRemote.Controls.Add(Me.tabModuleInfo)
        Me.tcRemote.Controls.Add(Me.tabAI)
        Me.tcRemote.Controls.Add(Me.TabPage1)
        Me.tcRemote.Controls.Add(Me.TabPage2)
        Me.tcRemote.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcRemote.Enabled = False
        Me.tcRemote.Location = New System.Drawing.Point(0, 0)
        Me.tcRemote.Name = "tcRemote"
        Me.tcRemote.SelectedIndex = 0
        Me.tcRemote.Size = New System.Drawing.Size(482, 344)
        Me.tcRemote.TabIndex = 14
        Me.tcRemote.Visible = False
        '
        'tabModuleInfo
        '
        Me.tabModuleInfo.Controls.Add(Me.btnLocate)
        Me.tabModuleInfo.Controls.Add(Me.lblLocate)
        Me.tabModuleInfo.Controls.Add(Me.labADVer)
        Me.tabModuleInfo.Controls.Add(Me.txtAIOFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtModuleID)
        Me.tabModuleInfo.Controls.Add(Me.labModule)
        Me.tabModuleInfo.Controls.Add(Me.labID)
        Me.tabModuleInfo.Controls.Add(Me.labFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSWID)
        Me.tabModuleInfo.Controls.Add(Me.txtFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSupportKernelFw)
        Me.tabModuleInfo.Controls.Add(Me.labSupportKernelFw)
        Me.tabModuleInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabModuleInfo.Name = "tabModuleInfo"
        Me.tabModuleInfo.Size = New System.Drawing.Size(474, 318)
        Me.tabModuleInfo.TabIndex = 0
        Me.tabModuleInfo.Text = "Module Information"
        '
        'btnLocate
        '
        Me.btnLocate.Location = New System.Drawing.Point(157, 163)
        Me.btnLocate.Name = "btnLocate"
        Me.btnLocate.Size = New System.Drawing.Size(72, 20)
        Me.btnLocate.TabIndex = 48
        Me.btnLocate.Text = "Enable"
        '
        'lblLocate
        '
        Me.lblLocate.Location = New System.Drawing.Point(4, 163)
        Me.lblLocate.Name = "lblLocate"
        Me.lblLocate.Size = New System.Drawing.Size(56, 20)
        Me.lblLocate.TabIndex = 49
        Me.lblLocate.Text = "Locate:"
        '
        'labADVer
        '
        Me.labADVer.Location = New System.Drawing.Point(4, 135)
        Me.labADVer.Name = "labADVer"
        Me.labADVer.Size = New System.Drawing.Size(149, 20)
        Me.labADVer.TabIndex = 50
        Me.labADVer.Text = "AIO Firmware Version :"
        '
        'txtAIOFwVer
        '
        Me.txtAIOFwVer.Location = New System.Drawing.Point(157, 134)
        Me.txtAIOFwVer.Name = "txtAIOFwVer"
        Me.txtAIOFwVer.ReadOnly = True
        Me.txtAIOFwVer.Size = New System.Drawing.Size(208, 22)
        Me.txtAIOFwVer.TabIndex = 41
        '
        'txtModuleID
        '
        Me.txtModuleID.Location = New System.Drawing.Point(157, 8)
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.ReadOnly = True
        Me.txtModuleID.Size = New System.Drawing.Size(208, 22)
        Me.txtModuleID.TabIndex = 36
        '
        'labModule
        '
        Me.labModule.Location = New System.Drawing.Point(4, 9)
        Me.labModule.Name = "labModule"
        Me.labModule.Size = New System.Drawing.Size(100, 20)
        Me.labModule.TabIndex = 51
        Me.labModule.Text = "Module :"
        '
        'labID
        '
        Me.labID.Location = New System.Drawing.Point(4, 41)
        Me.labID.Name = "labID"
        Me.labID.Size = New System.Drawing.Size(100, 20)
        Me.labID.TabIndex = 52
        Me.labID.Text = "Switch ID :"
        '
        'labFwVer
        '
        Me.labFwVer.Location = New System.Drawing.Point(4, 103)
        Me.labFwVer.Name = "labFwVer"
        Me.labFwVer.Size = New System.Drawing.Size(124, 20)
        Me.labFwVer.TabIndex = 53
        Me.labFwVer.Text = "Firmware Version:"
        '
        'txtSWID
        '
        Me.txtSWID.Location = New System.Drawing.Point(157, 40)
        Me.txtSWID.Name = "txtSWID"
        Me.txtSWID.ReadOnly = True
        Me.txtSWID.Size = New System.Drawing.Size(208, 22)
        Me.txtSWID.TabIndex = 37
        '
        'txtFwVer
        '
        Me.txtFwVer.Location = New System.Drawing.Point(157, 102)
        Me.txtFwVer.Name = "txtFwVer"
        Me.txtFwVer.ReadOnly = True
        Me.txtFwVer.Size = New System.Drawing.Size(208, 22)
        Me.txtFwVer.TabIndex = 39
        '
        'txtSupportKernelFw
        '
        Me.txtSupportKernelFw.Location = New System.Drawing.Point(157, 70)
        Me.txtSupportKernelFw.Name = "txtSupportKernelFw"
        Me.txtSupportKernelFw.ReadOnly = True
        Me.txtSupportKernelFw.Size = New System.Drawing.Size(208, 22)
        Me.txtSupportKernelFw.TabIndex = 40
        '
        'labSupportKernelFw
        '
        Me.labSupportKernelFw.Location = New System.Drawing.Point(4, 71)
        Me.labSupportKernelFw.Name = "labSupportKernelFw"
        Me.labSupportKernelFw.Size = New System.Drawing.Size(124, 20)
        Me.labSupportKernelFw.TabIndex = 54
        Me.labSupportKernelFw.Text = "Support Kernel Fw:"
        '
        'tabAI
        '
        Me.tabAI.Controls.Add(Me.listViewChInfo)
        Me.tabAI.Controls.Add(Me.panelConfig)
        Me.tabAI.Controls.Add(Me.panelSetting)
        Me.tabAI.Location = New System.Drawing.Point(4, 22)
        Me.tabAI.Name = "tabAI"
        Me.tabAI.Size = New System.Drawing.Size(474, 318)
        Me.tabAI.TabIndex = 1
        Me.tabAI.Text = "AI"
        '
        'listViewChInfo
        '
        Me.listViewChInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmType, Me.clmCh, Me.clmValue, Me.clmChStatus, Me.clmRange})
        Me.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo.FullRowSelect = True
        Me.listViewChInfo.Location = New System.Drawing.Point(0, 164)
        Me.listViewChInfo.Name = "listViewChInfo"
        Me.listViewChInfo.Size = New System.Drawing.Size(474, 154)
        Me.listViewChInfo.TabIndex = 2
        Me.listViewChInfo.UseCompatibleStateImageBehavior = False
        Me.listViewChInfo.View = System.Windows.Forms.View.Details
        '
        'clmType
        '
        Me.clmType.Text = "Type"
        '
        'clmCh
        '
        Me.clmCh.Text = "CH"
        '
        'clmValue
        '
        Me.clmValue.Text = "Value"
        '
        'clmChStatus
        '
        Me.clmChStatus.Text = "Ch Status"
        Me.clmChStatus.Width = 80
        '
        'clmRange
        '
        Me.clmRange.Text = "Range"
        Me.clmRange.Width = 200
        '
        'panelConfig
        '
        Me.panelConfig.BackColor = System.Drawing.Color.SkyBlue
        Me.panelConfig.Controls.Add(Me.cbxSampleRate)
        Me.panelConfig.Controls.Add(Me.labSampleRate)
        Me.panelConfig.Controls.Add(Me.btnSampleRate)
        Me.panelConfig.Controls.Add(Me.labBurnout)
        Me.panelConfig.Controls.Add(Me.btnBurnoutFcn)
        Me.panelConfig.Controls.Add(Me.chkBurnoutFcn)
        Me.panelConfig.Controls.Add(Me.cbxBurnoutValue)
        Me.panelConfig.Controls.Add(Me.labBurnoutValue)
        Me.panelConfig.Controls.Add(Me.cbxRange)
        Me.panelConfig.Controls.Add(Me.chkApplyAll)
        Me.panelConfig.Controls.Add(Me.btnApplySelRange)
        Me.panelConfig.Controls.Add(Me.labRange)
        Me.panelConfig.Controls.Add(Me.btnBurnoutValue)
        Me.panelConfig.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelConfig.Location = New System.Drawing.Point(0, 28)
        Me.panelConfig.Name = "panelConfig"
        Me.panelConfig.Size = New System.Drawing.Size(474, 136)
        Me.panelConfig.TabIndex = 3
        '
        'cbxSampleRate
        '
        Me.cbxSampleRate.Location = New System.Drawing.Point(149, 106)
        Me.cbxSampleRate.Name = "cbxSampleRate"
        Me.cbxSampleRate.Size = New System.Drawing.Size(181, 20)
        Me.cbxSampleRate.TabIndex = 35
        '
        'labSampleRate
        '
        Me.labSampleRate.Location = New System.Drawing.Point(8, 107)
        Me.labSampleRate.Name = "labSampleRate"
        Me.labSampleRate.Size = New System.Drawing.Size(153, 20)
        Me.labSampleRate.TabIndex = 36
        Me.labSampleRate.Text = "Sampling Rate (Hz/Ch):"
        '
        'btnSampleRate
        '
        Me.btnSampleRate.Location = New System.Drawing.Point(345, 105)
        Me.btnSampleRate.Name = "btnSampleRate"
        Me.btnSampleRate.Size = New System.Drawing.Size(86, 24)
        Me.btnSampleRate.TabIndex = 36
        Me.btnSampleRate.Text = "Apply"
        '
        'labBurnout
        '
        Me.labBurnout.Location = New System.Drawing.Point(8, 51)
        Me.labBurnout.Name = "labBurnout"
        Me.labBurnout.Size = New System.Drawing.Size(100, 20)
        Me.labBurnout.TabIndex = 37
        Me.labBurnout.Text = "Burnout Detect:"
        '
        'btnBurnoutFcn
        '
        Me.btnBurnoutFcn.Enabled = False
        Me.btnBurnoutFcn.Location = New System.Drawing.Point(345, 49)
        Me.btnBurnoutFcn.Name = "btnBurnoutFcn"
        Me.btnBurnoutFcn.Size = New System.Drawing.Size(86, 24)
        Me.btnBurnoutFcn.TabIndex = 31
        Me.btnBurnoutFcn.Text = "Apply"
        '
        'chkBurnoutFcn
        '
        Me.chkBurnoutFcn.Enabled = False
        Me.chkBurnoutFcn.Location = New System.Drawing.Point(149, 51)
        Me.chkBurnoutFcn.Name = "chkBurnoutFcn"
        Me.chkBurnoutFcn.Size = New System.Drawing.Size(168, 20)
        Me.chkBurnoutFcn.TabIndex = 32
        Me.chkBurnoutFcn.Text = "Enable"
        '
        'cbxBurnoutValue
        '
        Me.cbxBurnoutValue.Location = New System.Drawing.Point(149, 78)
        Me.cbxBurnoutValue.Name = "cbxBurnoutValue"
        Me.cbxBurnoutValue.Size = New System.Drawing.Size(181, 20)
        Me.cbxBurnoutValue.TabIndex = 15
        '
        'labBurnoutValue
        '
        Me.labBurnoutValue.Location = New System.Drawing.Point(8, 79)
        Me.labBurnoutValue.Name = "labBurnoutValue"
        Me.labBurnoutValue.Size = New System.Drawing.Size(153, 20)
        Me.labBurnoutValue.TabIndex = 38
        Me.labBurnoutValue.Text = "Burnout Detect Mode :"
        '
        'cbxRange
        '
        Me.cbxRange.Location = New System.Drawing.Point(149, 22)
        Me.cbxRange.Name = "cbxRange"
        Me.cbxRange.Size = New System.Drawing.Size(181, 20)
        Me.cbxRange.TabIndex = 19
        '
        'chkApplyAll
        '
        Me.chkApplyAll.Location = New System.Drawing.Point(8, 2)
        Me.chkApplyAll.Name = "chkApplyAll"
        Me.chkApplyAll.Size = New System.Drawing.Size(203, 24)
        Me.chkApplyAll.TabIndex = 21
        Me.chkApplyAll.Text = "Apply to All Channels"
        '
        'btnApplySelRange
        '
        Me.btnApplySelRange.Location = New System.Drawing.Point(345, 21)
        Me.btnApplySelRange.Name = "btnApplySelRange"
        Me.btnApplySelRange.Size = New System.Drawing.Size(86, 24)
        Me.btnApplySelRange.TabIndex = 23
        Me.btnApplySelRange.Text = "Apply"
        '
        'labRange
        '
        Me.labRange.Location = New System.Drawing.Point(8, 23)
        Me.labRange.Name = "labRange"
        Me.labRange.Size = New System.Drawing.Size(118, 20)
        Me.labRange.TabIndex = 39
        Me.labRange.Text = "Range :"
        '
        'btnBurnoutValue
        '
        Me.btnBurnoutValue.Location = New System.Drawing.Point(345, 77)
        Me.btnBurnoutValue.Name = "btnBurnoutValue"
        Me.btnBurnoutValue.Size = New System.Drawing.Size(86, 24)
        Me.btnBurnoutValue.TabIndex = 29
        Me.btnBurnoutValue.Text = "Apply"
        '
        'panelSetting
        '
        Me.panelSetting.Controls.Add(Me.cbRawData)
        Me.panelSetting.Controls.Add(Me.cbSetPanelHide)
        Me.panelSetting.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelSetting.Location = New System.Drawing.Point(0, 0)
        Me.panelSetting.Name = "panelSetting"
        Me.panelSetting.Size = New System.Drawing.Size(474, 28)
        Me.panelSetting.TabIndex = 4
        '
        'cbRawData
        '
        Me.cbRawData.Location = New System.Drawing.Point(176, 3)
        Me.cbRawData.Name = "cbRawData"
        Me.cbRawData.Size = New System.Drawing.Size(128, 20)
        Me.cbRawData.TabIndex = 30
        Me.cbRawData.Text = "Show Raw Data"
        '
        'cbSetPanelHide
        '
        Me.cbSetPanelHide.Location = New System.Drawing.Point(8, 5)
        Me.cbSetPanelHide.Name = "cbSetPanelHide"
        Me.cbSetPanelHide.Size = New System.Drawing.Size(168, 20)
        Me.cbSetPanelHide.TabIndex = 1
        Me.cbSetPanelHide.Text = "Hide Setting Panel"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListDOInfo)
        Me.TabPage1.Controls.Add(Me.panelMain)
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(474, 318)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "DO"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListDOInfo
        '
        Me.ListDOInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListDOInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListDOInfo.FullRowSelect = True
        Me.ListDOInfo.Location = New System.Drawing.Point(3, 81)
        Me.ListDOInfo.Name = "ListDOInfo"
        Me.ListDOInfo.Size = New System.Drawing.Size(468, 234)
        Me.ListDOInfo.TabIndex = 8
        Me.ListDOInfo.UseCompatibleStateImageBehavior = False
        Me.ListDOInfo.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Type"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "CH"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Value"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Mode"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Safety Value"
        Me.ColumnHeader8.Width = 150
        '
        'panelMain
        '
        Me.panelMain.Controls.Add(Me.chbxHide)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMain.Location = New System.Drawing.Point(3, 49)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(468, 32)
        Me.panelMain.TabIndex = 7
        '
        'chbxHide
        '
        Me.chbxHide.Location = New System.Drawing.Point(8, 8)
        Me.chbxHide.Name = "chbxHide"
        Me.chbxHide.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide.TabIndex = 1
        Me.chbxHide.Text = "Hide Setting Panel"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.clmMode, Me.clmSafety})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(3, 49)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(468, 266)
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Type"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "CH"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Value"
        '
        'clmMode
        '
        Me.clmMode.Text = "Mode"
        '
        'clmSafety
        '
        Me.clmSafety.Text = "Safety Value"
        Me.clmSafety.Width = 150
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel1.Controls.Add(Me.NumericUpDown1)
        Me.Panel1.Controls.Add(Me.btnTrue)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnFalse)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(468, 46)
        Me.Panel1.TabIndex = 6
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(172, 11)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(72, 22)
        Me.NumericUpDown1.TabIndex = 8
        '
        'btnTrue
        '
        Me.btnTrue.Location = New System.Drawing.Point(291, 11)
        Me.btnTrue.Name = "btnTrue"
        Me.btnTrue.Size = New System.Drawing.Size(72, 24)
        Me.btnTrue.TabIndex = 0
        Me.btnTrue.Text = "Set True"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(166, 46)
        Me.Panel2.TabIndex = 7
        '
        'btnFalse
        '
        Me.btnFalse.Location = New System.Drawing.Point(391, 11)
        Me.btnFalse.Name = "btnFalse"
        Me.btnFalse.Size = New System.Drawing.Size(72, 24)
        Me.btnFalse.TabIndex = 1
        Me.btnFalse.Text = "Set False"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightGray
        Me.TabPage2.Controls.Add(Me.ipText)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.TextBox4)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(474, 318)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "TabPage2"
        '
        'Timer1
        '
        Me.Timer1.Interval = 800
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 351)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "COM receive"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 380)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "COM send"
        '
        'ReceieveTxtBox
        '
        Me.ReceieveTxtBox.Location = New System.Drawing.Point(78, 347)
        Me.ReceieveTxtBox.Name = "ReceieveTxtBox"
        Me.ReceieveTxtBox.Size = New System.Drawing.Size(400, 22)
        Me.ReceieveTxtBox.TabIndex = 19
        '
        'SendTxtBox
        '
        Me.SendTxtBox.Location = New System.Drawing.Point(78, 375)
        Me.SendTxtBox.Name = "SendTxtBox"
        Me.SendTxtBox.Size = New System.Drawing.Size(400, 22)
        Me.SendTxtBox.TabIndex = 20
        '
        'Timer2
        '
        '
        'saveData
        '
        Me.saveData.Interval = 1000
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(0, 426)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(482, 22)
        Me.TextBox1.TabIndex = 21
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(78, 402)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(239, 22)
        Me.TextBox2.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 405)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 12)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "control signal"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(168, 84)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(169, 22)
        Me.TextBox3.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(121, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "port:"
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(168, 14)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(65, 22)
        Me.TextBox4.TabIndex = 61
        Me.TextBox4.Text = "11000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(71, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 16)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "receive data:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(82, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "IP address:"
        '
        'ipText
        '
        Me.ipText.Location = New System.Drawing.Point(168, 54)
        Me.ipText.Name = "ipText"
        Me.ipText.Size = New System.Drawing.Size(169, 22)
        Me.ipText.TabIndex = 64
        '
        'Form_APAX_5017H
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 478)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.SendTxtBox)
        Me.Controls.Add(Me.ReceieveTxtBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.tcRemote)
        Me.Name = "Form_APAX_5017H"
        Me.Text = "APAX-5017H"
        Me.tcRemote.ResumeLayout(False)
        Me.tabModuleInfo.ResumeLayout(False)
        Me.tabModuleInfo.PerformLayout()
        Me.tabAI.ResumeLayout(False)
        Me.panelConfig.ResumeLayout(False)
        Me.panelSetting.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.panelMain.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
    Private WithEvents tcRemote As System.Windows.Forms.TabControl
    Private WithEvents tabModuleInfo As System.Windows.Forms.TabPage
    Private WithEvents btnLocate As System.Windows.Forms.Button
    Private WithEvents lblLocate As System.Windows.Forms.Label
    Private WithEvents labADVer As System.Windows.Forms.Label
    Private WithEvents txtAIOFwVer As System.Windows.Forms.TextBox
    Private WithEvents txtModuleID As System.Windows.Forms.TextBox
    Private WithEvents labModule As System.Windows.Forms.Label
    Private WithEvents labID As System.Windows.Forms.Label
    Private WithEvents labFwVer As System.Windows.Forms.Label
    Private WithEvents txtSWID As System.Windows.Forms.TextBox
    Private WithEvents txtFwVer As System.Windows.Forms.TextBox
    Private WithEvents txtSupportKernelFw As System.Windows.Forms.TextBox
    Private WithEvents labSupportKernelFw As System.Windows.Forms.Label
    Private WithEvents tabAI As System.Windows.Forms.TabPage
    Private WithEvents listViewChInfo As System.Windows.Forms.ListView
    Private WithEvents clmType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmChStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents clmRange As System.Windows.Forms.ColumnHeader
    Private WithEvents panelConfig As System.Windows.Forms.Panel
    Private WithEvents cbxSampleRate As System.Windows.Forms.ComboBox
    Private WithEvents labSampleRate As System.Windows.Forms.Label
    Private WithEvents btnSampleRate As System.Windows.Forms.Button
    Private WithEvents labBurnout As System.Windows.Forms.Label
    Private WithEvents btnBurnoutFcn As System.Windows.Forms.Button
    Private WithEvents chkBurnoutFcn As System.Windows.Forms.CheckBox
    Private WithEvents cbxBurnoutValue As System.Windows.Forms.ComboBox
    Private WithEvents labBurnoutValue As System.Windows.Forms.Label
    Private WithEvents cbxRange As System.Windows.Forms.ComboBox
    Private WithEvents chkApplyAll As System.Windows.Forms.CheckBox
    Private WithEvents btnApplySelRange As System.Windows.Forms.Button
    Private WithEvents labRange As System.Windows.Forms.Label
    Private WithEvents btnBurnoutValue As System.Windows.Forms.Button
    Private WithEvents panelSetting As System.Windows.Forms.Panel
    Private WithEvents cbRawData As System.Windows.Forms.CheckBox
    Private WithEvents cbSetPanelHide As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents comport As System.IO.Ports.SerialPort
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ReceieveTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents SendTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents saveData As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Timer3 As Timer
    Friend WithEvents TabPage1 As TabPage
    Private WithEvents panelMain As Panel
    Private WithEvents chbxHide As CheckBox
    Private WithEvents ListView1 As ListView
    Private WithEvents ColumnHeader1 As ColumnHeader
    Private WithEvents ColumnHeader2 As ColumnHeader
    Private WithEvents ColumnHeader3 As ColumnHeader
    Private WithEvents clmMode As ColumnHeader
    Private WithEvents clmSafety As ColumnHeader
    Private WithEvents Panel1 As Panel
    Private WithEvents Panel2 As Panel
    Private WithEvents btnTrue As Button
    Private WithEvents btnFalse As Button
    Private WithEvents ListDOInfo As ListView
    Private WithEvents ColumnHeader4 As ColumnHeader
    Private WithEvents ColumnHeader5 As ColumnHeader
    Private WithEvents ColumnHeader6 As ColumnHeader
    Private WithEvents ColumnHeader7 As ColumnHeader
    Private WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ipText As TextBox
    Friend WithEvents Label6 As Label
End Class
