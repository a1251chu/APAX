﻿Imports Advantech.Adam
Imports Advantech.Common
Imports Apax_IO_Module_Library
Imports System.Threading
Imports System.Data.SqlClient '引入命名空間
Imports System.Net.Sockets
Imports System.Net
Imports System
Imports System.Text


Public Class Form_APAX_5017H
    Public strsql As String '定義一個資料庫連接字串
    Public conn As New SqlConnection '聲明一個資料連線物件的變數
    Public cmd As New SqlCommand '聲明一個sqlcommand物件
    Public ds As New DataSet '聲明一個資料集DATASET物件
    Public adp As New SqlDataAdapter '定義一個資料配接器物件，用於充當DataSet物件與實際資料之間橋樑的物件

    Private ReadOnly MAX_CHANNEL = "24"

    Public APAX_INFO_NAME As String = "APAX"
    Public Const DVICE_TYPE_5017H = "5017H"
    Public Const DVICE_TYPE_5060 = "5060"

    Dim m_adamCtl As AdamControl 'Control Handle
    Dim m_aConf As Apax5000Config 'Configuration information
    Dim m_iSlot_ID_5017 As Integer 'Device switch ID
    Dim m_iSlot_ID_5060 As Integer
    Dim m_ScanTime_LocalSys() As Integer
    Dim m_szSlots() As String 'Container of all solt device type
    Dim m_usOutVal(), m_usInVal() As System.UInt16 'Container of AIO raw data
    Dim m_usInVal2() As System.UInt16

    Dim m_bStartFlag As Boolean = False
    Dim m_aStatus() As Advantech.Adam.Apax5000_ChannelStatus

    Dim m_adamCtl2 As AdamControl 'Control Handle
    Dim m_iSlot_ID2 As Integer 'Device switch ID


    Dim m_iPollingCount As Integer 'Polling device status count
    Dim m_iFailCount As Integer 'Device Polling fail count
    Dim m_iAIChannelNum As Integer 'Device AI Channel number
    Dim m_iAOChannelNum As Integer 'Device AO Channel number
    Dim m_iDIChannelNum As Integer 'Device DI Channel number
    Dim m_iDOChannelNum As Integer 'Device DO Channel number

    Dim m_iPollingCount_5060 As Integer
    Dim m_iFailCount_5060 As Integer
    Dim m_bChMask() As Boolean = New Boolean((AdamControl.APAX_MaxAIOCh) - 1) {}
    Dim m_uiChMask As UInteger = 0
    Dim m_uiBurnoutVal As UInteger = 0
    Dim m_uiBurnoutMask As UInteger = 0
    Dim m_usRanges() As System.UInt16
    Dim analogValue(14) As String
    Dim analogValue2(0 To 10) As String
    ' Incoming data from the client.
    Public Shared socketData As String = Nothing
    Dim TH As Threading.ThreadStart
    Dim CT As Threading.Thread
    'win Socket code
    Public Sub SynchronousSocketListener()
        ' Data buffer for incoming data.
        Dim bytes() As Byte = New [Byte](1024) {}
        Dim controlNum As Integer
        ' Establish the local endpoint for the socket.
        ' Dns.GetHostName returns the name of the 
        ' host running the application.
        Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
        Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)
        Dim localEndPoint As New IPEndPoint(ipAddress, 11000)
        Dim control As Boolean
        ' Create a TCP/IP socket.
        Dim listener As New Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp)

        ' Bind the socket to the local endpoint and 
        ' listen for incoming connections.
        listener.Bind(localEndPoint)
        listener.Listen(10)
        UpdateUI(ipAddress.ToString, ipText)
        ' Start listening for connections.
        While True
            control = False
            ' Console.WriteLine("Waiting for a connection...")
            ' Program is suspended while waiting for an incoming connection.
            Dim handler As Socket = listener.Accept()
            socketData = Nothing
            ' An incoming connection needs to be processed.
            While True
                bytes = New Byte(1024) {}
                Dim bytesRec As Integer = handler.Receive(bytes)
                Try
                    socketData += Encoding.ASCII.GetString(bytes, 0, bytesRec)
                    If socketData.IndexOf("E") > -1 Then
                        Exit While
                    End If
                Catch ex As Exception

                End Try

            End While
            If Mid(socketData, 1, 1) = "*" And Len(socketData) = 15 Then
                socketData = Mid(socketData, 2, Len(socketData) - 2)
                controlNum = Val(Mid(socketData, 1, 1))
                socketData = Mid(socketData, 2, Len(socketData) - 1)
                If Len(socketData) = 12 Then
                    control = True
                    Call control5060(controlNum, socketData)
                End If
            End If
            ' Show the data on the console.
            'Console.WriteLine("Text received : {0}", socketData)
            ' Echo the data back to the client.
            Dim msg As Byte()
            If control Then
                msg = Encoding.ASCII.GetBytes(socketData)
            Else
                msg = Encoding.ASCII.GetBytes("0")
            End If
            handler.Send(msg)
            UpdateUI(socketData, TextBox3)
            socketData = ""
            'handler.Shutdown(SocketShutdown.Both)
            'handler.Close()
        End While
    End Sub 'SynchronousSocketListener

    Private Sub socketStart()
        TH = New ThreadStart(AddressOf SynchronousSocketListener)
        CT = New Threading.Thread(TH)
        TextBox3.Text = "socket start"
        CT.Start()
    End Sub

    Private Sub socketEnd()
        CT.Abort()
    End Sub
    Private Delegate Sub UpdateUICallBack(ByVal newText As String, ByVal c As Control)

    Private Sub UpdateUI(ByVal newText As String, ByVal c As Control)
        If Me.InvokeRequired() Then
            Dim cb As New UpdateUICallBack(AddressOf UpdateUI)
            Me.Invoke(cb, newText, c)
        Else
            c.Text = newText
        End If
    End Sub

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        m_szSlots = Nothing
        m_iPollingCount = 0
        m_iFailCount = 0
        m_ScanTime_LocalSys = New Integer((1) - 1) {}
        m_iSlot_ID_5017 = -1 'Set in invalid num 
        m_iSlot_ID_5060 = -1
        m_ScanTime_LocalSys(0) = 500 'Scan time default 500 ms
        Timer1.Interval = m_ScanTime_LocalSys(0)
        socketStart()
        ' Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."
        'm_szSlots = Nothing
    End Sub
    Public Sub New(ByVal SlotNum As Integer, ByVal ScanTime As Integer)
        MyBase.New()
        InitializeComponent()
        m_szSlots = Nothing
        m_iSlot_ID_5017 = SlotNum
        m_iSlot_ID_5060 = SlotNum
        m_iPollingCount = 0
        m_iFailCount = 0
        m_ScanTime_LocalSys = New Integer((1) - 1) {}
        m_ScanTime_LocalSys(0) = ScanTime 'Scan time default 500 ms
        Timer1.Interval = m_ScanTime_LocalSys(0)
        socketStart()
        '  Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."

    End Sub

    Private Sub Btn_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quit.Click
        Close()
    End Sub

    Private Sub ShowWaitMsg()

        Dim FormWait = New Wait_Form
        FormWait.Start_Wait(2500)
        FormWait.ShowDialog()

    End Sub

    Private Sub tcRemote_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcRemote.SelectedIndexChanged

        Dim strSelPageName As String = tcRemote.TabPages(tcRemote.SelectedIndex).Text

        Me.StatusBar_IO.Text = ""
        If (strSelPageName = "Module Information") Then

            Timer1.Enabled = False
            m_iFailCount = 0
            Me.m_iPollingCount = 0

        ElseIf (strSelPageName = "AI") Then


        End If

    End Sub

    Public Function FreeResource() As Boolean

        If m_bStartFlag Then
            m_bStartFlag = False
            Me.tcRemote.Enabled = False
            Me.tcRemote.Visible = False

            'disable timer
            Timer1.Enabled = False
            'disable locate module
            m_adamCtl.Configuration.SYS_SetLocateModule(m_iSlot_ID_5017, 0)
            m_adamCtl = Nothing

        End If

        Return True

    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

    End Sub
    Public Function StartRemote()
        Dim a As String
        Dim waitThread As Thread = New Thread(AddressOf ShowWaitMsg)
        waitThread.IsBackground = False
        waitThread.Start()
        a = "no"
        '==============try to open 5017=====================
        Try
            If Not OpenDevice() Then
                a = "1"
                Throw New System.Exception("Open Local Device Fail.")
            End If
            If Not DeviceFind() Then
                a = "2"
                Throw New System.Exception("Find " + DVICE_TYPE_5017H + "Device Fail.")
            End If
            If Not DeviceFind_5060() Then
                a = "3"
                Throw New System.Exception("Find " + DVICE_TYPE_5060 + "Device Fail.")
            End If
            If Not RefreshConfiguration() Then
                a = "4"
                Throw New System.Exception("Get" + DVICE_TYPE_5017H + " Device Configuration Fail.")
            End If
            If Not GetChannelInfo() Then
                a = "5"
                Throw New System.Exception("Get" + DVICE_TYPE_5017H + " Device ChannelInfo Fail.")
            End If

        Catch ex As Exception
            MessageBox.Show(a, "error")
            MessageBox.Show("Demo failed! Please check define 'DVICE_TYPE' of type or device set up status.", "Error")
            Return False

        End Try

        Me.StatusBar_IO.Text = "Starting to remote..."
        Me.Timer1.Interval = m_ScanTime_LocalSys(0)
        Me.tcRemote.Enabled = True
        Me.tcRemote.Visible = True
        InitialRemotePanelComponents()
        Me.Text = APAX_INFO_NAME + DVICE_TYPE_5017H
        m_iPollingCount = 0

        Me.tcRemote.SelectedIndex = 0
        Return True

    End Function
    Public Function OpenDevice() As Boolean

        m_adamCtl = New AdamControl(AdamType.Apax5000)

        If m_adamCtl.OpenDevice Then
            If Not m_adamCtl.Configuration.SYS_SetDspChannelFlag(False) Then
                Me.StatusBar_IO.Text = "SYS_SetDspChannelFlag(false) Failed! "
                Return False
            End If
            If (Not m_adamCtl.Configuration.GetSlotInfo(m_szSlots)) Then
                Me.StatusBar_IO.Text = "GetSlotInfo() Failed! "
                Return False
            End If
        End If

        Return True

    End Function

    Public Function DeviceFind() As Boolean

        Dim iLoop As Integer = 0
        Dim iDeviceNum As Integer = 0

        If m_iSlot_ID_5017 = -1 Then

            For iLoop = 0 To m_szSlots.Length - 1
                If (String.Compare(m_szSlots(iLoop), 0, DVICE_TYPE_5017H, 0, DVICE_TYPE_5017H.Length) = 0) Then
                    iDeviceNum = iDeviceNum + 1
                    If iDeviceNum = 1 Then 'Record first find device
                        m_iSlot_ID_5017 = iLoop 'Get DVICE_TYPE Solt
                    End If
                End If
            Next

        Else

            If (String.Compare(m_szSlots(m_iSlot_ID_5017), 0, DVICE_TYPE_5017H, 0, DVICE_TYPE_5017H.Length) = 0) Then
                iDeviceNum = iDeviceNum + 1
            End If

        End If

        If iDeviceNum = 1 Then
            DeviceFind = True
        ElseIf iDeviceNum > 1 Then
            'MessageBox.Show("Found " + iDeviceNum.ToString + DVICE_TYPE + " devices." + vbCrLf + " It's will demo Solt " + m_iSlot_ID.ToString + ".", "Warning")
            DeviceFind = True
        Else
            'MessageBox.Show("Can't find any " + DVICE_TYPE + " device!", "Error")
            DeviceFind = False
        End If

    End Function

    Public Function RefreshConfiguration() As Boolean

        Dim i As Integer = 0

        If m_adamCtl.Configuration.GetModuleConfig(m_iSlot_ID_5017, m_aConf) Then
            'Information-> Module
            Me.txtModuleID.Text = (APAX_INFO_NAME + ("-" + m_aConf.GetModuleName))
            'Information -> Switch ID
            Me.txtSWID.Text = m_iSlot_ID_5017.ToString
            'Information -> Support kernel Fw
            Me.txtSupportKernelFw.Text = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".")
            'Firmware version
            Me.txtFwVer.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".")
            'AI Firmware version
            Me.txtAIOFwVer.Text = m_aConf.wHwVer.ToString("X04").Insert(2, ".")
        Else
            Me.StatusBar_IO.Text = (" GetModuleConfig(Error:" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! "))
            Return False
        End If

        m_usRanges = m_aConf.wChRange
        m_uiChMask = m_aConf.dwChMask

        For i = 0 To Me.m_bChMask.Length - 1
            m_bChMask(i) = ((m_uiChMask And (&H1 << i)) > 0)
        Next

        Return True

    End Function
    Public Sub SetRangeComboBox(ByVal strRanges() As String)

        cbxRange.BeginUpdate()
        cbxRange.Items.Clear()
        Dim i As Integer = 0
        Do While (i < strRanges.Length)
            cbxRange.Items.Add(strRanges(i))
            i = (i + 1)
        Loop
        If (cbxRange.Items.Count > 0) Then
            cbxRange.SelectedIndex = 0
        End If
        cbxRange.EndUpdate()

    End Sub


    ''' Get Burnout detect mode value combobox string
    Public Sub SetBurnoutFcnValueComboBox(ByVal strRanges() As String)

        cbxBurnoutValue.BeginUpdate()
        cbxBurnoutValue.Items.Clear()

        Dim i As Integer = 0

        Do While (i < strRanges.Length)
            cbxBurnoutValue.Items.Add(strRanges(i))
            i = (i + 1)
        Loop

        If (cbxBurnoutValue.Items.Count > 0) Then
            cbxBurnoutValue.SelectedIndex = 0
        End If

        cbxBurnoutValue.EndUpdate()

    End Sub


    Public Sub SetSampleRateComboBox(ByVal strSampleRate() As String)

        cbxSampleRate.BeginUpdate()
        cbxSampleRate.Items.Clear()
        Dim i As Integer = 0
        Do While (i < strSampleRate.Length)
            cbxSampleRate.Items.Add(strSampleRate(i))
            i = (i + 1)
        Loop
        If (cbxSampleRate.Items.Count > 0) Then
            cbxSampleRate.SelectedIndex = 0
        End If
        cbxSampleRate.EndUpdate()

    End Sub

    Public Sub InitialRemotePanelComponents()

        Dim iLoop, iSiezOfRange, iIndex As Integer
        Dim lvItem As ListViewItem
        Dim lvItemDO As ListViewItem
        Dim strRanges() As String
        Dim m_usRanges_supAI() As System.UInt16

        For iLoop = 0 To m_aConf.HwIoType.Length - 1
            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.AI) Then
                iIndex = iLoop
            End If
        Next

        'init range combobox
        If (iIndex = 0) Then
            m_usRanges_supAI = m_aConf.wHwIoType_0_Range
        ElseIf (iIndex = 1) Then
            m_usRanges_supAI = m_aConf.wHwIoType_1_Range
        ElseIf (iIndex = 2) Then
            m_usRanges_supAI = m_aConf.wHwIoType_2_Range
        ElseIf (iIndex = 3) Then
            m_usRanges_supAI = m_aConf.wHwIoType_3_Range
        Else
            m_usRanges_supAI = m_aConf.wHwIoType_4_Range
        End If

        iSiezOfRange = (m_aConf.HwIoType_TotalRange(iIndex)) 'Get AI Total type range number
        strRanges = New String(iSiezOfRange - 1) {}

        For iLoop = 0 To iSiezOfRange - 1
            strRanges(iLoop) = AnalogInput.GetRangeName(m_usRanges_supAI(iLoop))
        Next

        SetRangeComboBox(strRanges)
        SetBurnoutFcnValueComboBox(New String() {"Down Scale", "Up Scale"})

        If (m_aConf.GetModuleName = "5017H") Then
            SetSampleRateComboBox(New String() {"100", "1000"})
        ElseIf (m_aConf.GetModuleName = "5017") Then
            SetSampleRateComboBox(New String() {"1", "10"})
        End If

        listViewChInfo.Items.Clear()
        listViewChInfo.BeginUpdate()

        For iLoop = 0 To m_iAIChannelNum - 1
            lvItem = New ListViewItem(_HardwareIOType.AI.ToString)
            'type
            lvItem.SubItems.Add(iLoop.ToString)
            'Ch
            lvItem.SubItems.Add("*****")
            'Value
            lvItem.SubItems.Add("*****")
            'Ch Status 
            lvItem.SubItems.Add("*****")
            'Range
            listViewChInfo().Items.Add(lvItem)
        Next

        listViewChInfo.EndUpdate()

        '==========for DO list
        ListDOInfo.Items.Clear()
        ListDOInfo.BeginUpdate()
        For iLoop = 0 To Me.m_iDOChannelNum - 1
            lvItemDO = New ListViewItem(_HardwareIOType.DO.ToString)
            'Type
            lvItemDO.SubItems.Add(iLoop.ToString)
            'Ch
            lvItemDO.SubItems.Add("*****")
            'Value
            lvItemDO.SubItems.Add("BOOL")
            'Mode
            lvItemDO.SubItems.Add("*****")
            'Safety Value
            ListDOInfo.Items.Add(lvItemDO)
        Next

        ListDOInfo.EndUpdate()
    End Sub

    Public Function GetChannelInfo() As Boolean

        Dim iLoop As Integer

        For iLoop = 0 To m_aConf.HwIoType.Length - 1
            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.AI) Then
                m_iAIChannelNum = m_aConf.HwIoTotal(iLoop)
            ElseIf (m_aConf.HwIoType(iLoop) = _HardwareIOType.DO) Then
                m_iDOChannelNum = m_aConf.HwIoTotal(iLoop)
            ElseIf (m_aConf.HwIoType(iLoop) = _HardwareIOType.DI) Then
                m_iDIChannelNum = m_aConf.HwIoTotal(iLoop)
            ElseIf (m_aConf.HwIoType(iLoop) = _HardwareIOType.AO) Then
                m_iDIChannelNum = m_aConf.HwIoTotal(iLoop)
            End If
            '==================尋找DO==========================================================
            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.DO) Then
                m_iDOChannelNum = m_aConf.HwIoTotal(iLoop)
            ElseIf (m_aConf.HwIoType(iLoop) = _HardwareIOType.DI) Then
                m_iDIChannelNum = m_aConf.HwIoTotal(iLoop)
            End If
        Next

        Return True

    End Function

    Private Sub cbSetPanelHide_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSetPanelHide.CheckStateChanged

        Me.panelConfig.Visible = (Not Me.cbSetPanelHide.Checked)

    End Sub

    Private Sub btnLocate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocate.Click

        If (Me.btnLocate.Text = "Enable") Then
            If m_adamCtl.Configuration.SYS_SetLocateModule(m_iSlot_ID_5017, 255) Then
                Me.btnLocate.Text = "Disable"
            Else
                MessageBox.Show("Locate module failed!", "Error")
            End If
        ElseIf m_adamCtl.Configuration.SYS_SetLocateModule(m_iSlot_ID_5017, 0) Then
            btnLocate.Text = "Enable"
        Else
            MessageBox.Show("Locate module failed!", "Error")
        End If

    End Sub

    Private Sub Form_APAX_5017H_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        FreeResource()
    End Sub

    Public Function ReadChannelStatus() As Boolean

        m_usInVal = Nothing
        m_aStatus = Nothing

        If (Me.m_uiChMask <> 0) Then

            If Not Me.m_adamCtl.AnalogInput.GetChannelStatus(Me.m_iSlot_ID_5017, Me.m_iAIChannelNum, m_aStatus) Then
                Me.StatusBar_IO.Text = (StatusBar_IO.Text + ("[GetChannelStatus] ApiErr:" _
                            + (m_adamCtl.AnalogInput.ApiLastError.ToString + " ")))
                Return False
            End If

            If Not m_adamCtl.AnalogInput.GetValues(Me.m_iSlot_ID_5017, Me.m_iAIChannelNum, m_usInVal) Then
                StatusBar_IO.Text = (StatusBar_IO.Text + ("[GetValues] ApiErr:" _
                            + (m_adamCtl.AnalogInput.ApiLastError.ToString + " ")))
                Return False
            End If
            m_adamCtl.AnalogInput.GetValues(1, Me.m_iAIChannelNum, m_usInVal2)
            'MsgBox("m_iSlot_ID=" & m_iSlot_ID & "m_iAIChannelNum=" & m_iAIChannelNum)
            Return True

        End If

        Return False

    End Function

    Public Function RefreshData() As Boolean

        If Not ReadChannelStatus() Then
            Return False
        End If
        Update_AI_UIStatus()

        Return True
    End Function


    Public Function Update_AI_UIStatus() As Boolean

        Dim strVal() As String = New String((Me.m_iAIChannelNum) - 1) {}
        Dim strVal2() As String = New String((Me.m_iAIChannelNum) - 1) {}
        Dim strStatus() As String = New String((Me.m_iAIChannelNum) - 1) {}
        Dim dVals() As Double = New Double((Me.m_iAIChannelNum) - 1) {}
        Dim dVals2() As Double = New Double((Me.m_iAIChannelNum) - 1) {}
        Dim i As Integer
        ReDim analogValue(0 To Me.m_iAIChannelNum - 1)
        ReDim analogValue2(0 To Me.m_iAIChannelNum - 1)
        listViewChInfo.BeginUpdate()

        If m_usInVal.Length > 0 Then

            For i = 0 To Me.m_iAIChannelNum - 1
                If (m_aConf.wPktVer >= 2) Then
                    dVals(i) = AnalogInput.GetScaledValueWithResolution(Me.m_usRanges(i), m_usInVal(i), m_aConf.wHwIoType_0_Resolution)
                ElseIf (m_aConf.GetModuleName = "5017H") Then
                    dVals(i) = AnalogInput.GetScaledValueWithResolution(Me.m_usRanges(i), m_usInVal(i), 12)
                Else
                    dVals(i) = AnalogInput.GetScaledValue(Me.m_usRanges(i), m_usInVal(i))
                End If

                If m_bChMask(i) Then
                    If cbRawData.Checked Then
                        strVal(i) = m_usInVal(i).ToString("X04")
                    Else
                        strVal(i) = dVals(i).ToString(AnalogInput.GetFloatFormat(Me.m_usRanges(i)))
                    End If
                    strStatus(i) = m_aStatus(i).ToString
                Else
                    strVal(i) = "*****"
                    strStatus(i) = "Disable"
                End If

                If listViewChInfo.Items(i).SubItems(2).Text <> strVal(i).ToString Then
                    listViewChInfo.Items(i).SubItems(2).Text = strVal(i).ToString 'moduify "Value" column
                End If

                If listViewChInfo.Items(i).SubItems(3).Text <> strStatus(i).ToString Then
                    listViewChInfo.Items(i).SubItems(3).Text = strStatus(i).ToString 'modify "Ch Status" column
                End If
                If strVal(i) > 0 Then
                    analogValue(i) = "+0" & strVal(i)
                Else
                    analogValue(i) = "-0" & Mid(strVal(i), 2, strVal(i).Length)
                End If
            Next
        Else
            For i = 0 To Me.m_iAIChannelNum - 1
                listViewChInfo.Items(i).SubItems(2).Text = "******"
                'moduify "Value" column
                listViewChInfo.Items(i).SubItems(3).Text = "******"
                'modify "Ch Status" column
            Next
        End If

        If m_usInVal2.Length > 0 Then

            For i = 0 To Me.m_iAIChannelNum - 1
                If (m_aConf.wPktVer >= 2) Then
                    dVals2(i) = AnalogInput.GetScaledValueWithResolution(Me.m_usRanges(i), m_usInVal2(i), m_aConf.wHwIoType_0_Resolution)
                ElseIf (m_aConf.GetModuleName = "5017H") Then
                    dVals2(i) = AnalogInput.GetScaledValueWithResolution(Me.m_usRanges(i), m_usInVal2(i), 12)
                Else
                    dVals2(i) = AnalogInput.GetScaledValue(Me.m_usRanges(i), m_usInVal(i))
                End If

                If m_bChMask(i) Then
                    If cbRawData.Checked Then
                        strVal2(i) = m_usInVal2(i).ToString("X04")
                    Else
                        strVal2(i) = dVals2(i).ToString(AnalogInput.GetFloatFormat(Me.m_usRanges(i)))
                    End If
                Else
                    strVal2(i) = "*****"
                End If
                If strVal2(i) > 0 Then
                    analogValue2(i) = "+0" & strVal2(i)
                Else
                    analogValue2(i) = "-0" & Mid(strVal2(i), 2, strVal2(i).Length)
                End If
            Next
        End If

        listViewChInfo.EndUpdate()

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim bRet As Boolean

        Timer1.Enabled = False

        Me.StatusBar_IO.Text = ("Polling (Interval=" _
            + (Timer1.Interval.ToString + "ms): "))

        bRet = RefreshData() 'Upadate UI Status

        If bRet Then
            Me.m_iPollingCount = (Me.m_iPollingCount + 1)
            m_iFailCount = 0
            Me.StatusBar_IO.Text = (Me.StatusBar_IO.Text _
                        + (Me.m_iPollingCount.ToString + " times..."))
        Else
            m_iFailCount = (m_iFailCount + 1)
            Me.StatusBar_IO.Text = (Me.StatusBar_IO.Text + (m_iFailCount.ToString + " failures..."))
        End If

        If (m_iFailCount > 5) Then
            Me.StatusBar_IO.Text = (Me.StatusBar_IO.Text + " polling suspended!!")
            MessageBox.Show("Failed more than 5 times! Please check the physical connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Return
        End If

        If ((Me.m_iPollingCount Mod 50) = 0) Then
            GC.Collect()
        End If

        Timer1.Enabled = True
    End Sub

    ''' When user select specific item of channel information, you should update channel range
    Private Sub LvChInfo_SelectedIndexChanged(ByVal idxSel As Integer)

        Me.cbxRange.SelectedIndex = GetChannelRangeIdx(AnalogInput.GetRangeName(m_usRanges(idxSel)))

        If (((m_usRanges(idxSel) <= CType(ApaxUnknown_InputRange.Btype_200To1820C, System.UInt16)) _
                    AndAlso (m_usRanges(idxSel) >= CType(ApaxUnknown_InputRange.Jtype_Neg210To1200C, System.UInt16))) _
                    OrElse ((m_usRanges(idxSel) <= CType(ApaxUnknown_InputRange.Ni518_0To100, System.UInt16)) _
                    AndAlso (m_usRanges(idxSel) >= CType(ApaxUnknown_InputRange.Pt100_3851_Neg200To850, System.UInt16)))) Then

            Me.chkBurnoutFcn.Enabled = True
            Me.btnBurnoutFcn.Enabled = True

        Else

            Me.chkBurnoutFcn.Enabled = False
            Me.btnBurnoutFcn.Enabled = False

        End If

        'refresh burnout mask
        If (((m_uiBurnoutMask >> idxSel) And 1) > 0) Then
            chkBurnoutFcn.Checked = True
        Else
            chkBurnoutFcn.Checked = False
        End If

    End Sub

    Public Function GetChannelRangeIdx(ByVal o_szRangeName As String) As Integer

        Dim i As Integer = 0

        Do While (i < cbxRange.Items.Count)
            If (cbxRange.Items(i).ToString = o_szRangeName) Then
                Return i
            End If
            i = (i + 1)
        Loop

        Return -1

    End Function


    Private Function RefreshRanges() As Boolean

        Dim i As Integer = 0

        Try
            listViewChInfo.BeginUpdate()

            If Me.m_adamCtl.Configuration.GetModuleConfig(m_iSlot_ID_5017, m_aConf) Then
                m_usRanges = m_aConf.wChRange
                m_uiChMask = m_aConf.dwChMask

                For i = 0 To Me.m_bChMask.Length - 1
                    m_bChMask(i) = ((m_uiChMask And (&H1 << i)) > 0)
                Next

                For i = 0 To Me.m_iAIChannelNum - 1
                    listViewChInfo.Items(i).SubItems(4).Text = AnalogInput.GetRangeName(m_usRanges(i)).ToString
                Next
            Else
                Me.StatusBar_IO.Text = (StatusBar_IO.Text + ("GetModuleConfig(Error:" _
                            + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! ")))
            End If

            listViewChInfo.EndUpdate()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' Refresh Integration time 
    Private Sub RefreshAiSetting()
        If m_adamCtl.Configuration.GetModuleConfig(Me.m_iSlot_ID_5017, m_aConf) Then

            Dim uiFcnParam As UInteger
            'Check if support SampleRate
            If (Me.m_aConf.byFunType_0 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_0
            ElseIf (Me.m_aConf.byFunType_1 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_1
            ElseIf (Me.m_aConf.byFunType_2 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_2
            ElseIf (Me.m_aConf.byFunType_3 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_3
            ElseIf (Me.m_aConf.byFunType_4 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_4
            Else
                Return
            End If

        Else
            Me.StatusBar_IO.Text = (Me.StatusBar_IO.Text + ("GetModuleConfig(Error:" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! ")))
        End If

    End Sub

    ''' Refresh AI Burnout detect mode settings
    Private Function RefreshBurnoutSetting(ByVal bUpdateBurnFun As Boolean, ByVal bUpdateBurnVal As Boolean) As Boolean

        Try
            Dim bRet As Boolean = False
            Dim o_dwEnableMask As UInteger
            Dim o_dwValue As UInteger

            If bUpdateBurnFun Then
                If Not m_adamCtl.AnalogInput.GetBurnoutFunEnable(m_iSlot_ID_5017, o_dwEnableMask) Then
                    bRet = False
                Else
                    bRet = True
                    m_uiBurnoutMask = o_dwEnableMask
                End If
            End If

            If bUpdateBurnVal Then
                If Not m_adamCtl.AnalogInput.GetBurnoutValue(m_iSlot_ID_5017, o_dwValue) Then
                    bRet = False
                Else
                    bRet = True
                    m_uiBurnoutVal = o_dwValue
                    If (m_uiBurnoutVal = 0) Then
                        cbxBurnoutValue.SelectedIndex = 0
                    Else
                        cbxBurnoutValue.SelectedIndex = 1
                    End If
                End If
            End If

            Return bRet
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub RefreshAiSampleRate()
        Dim idx As Integer = -1
        Dim uiRate As UInteger

        If m_adamCtl.AnalogInput.GetSampleRate(m_iSlot_ID_5017, uiRate) Then
            If (m_aConf.GetModuleName = "5017") Then
                If (uiRate = 1) Then
                    idx = 0
                ElseIf (uiRate = 10) Then
                    idx = 1
                End If
            ElseIf (m_aConf.GetModuleName = "5017H") Then
                If (uiRate = 100) Then
                    idx = 0
                ElseIf (uiRate = 1000) Then
                    idx = 1
                End If
            Else
                idx = -2
            End If
            If (idx >= 0) Then
                If (idx > (cbxSampleRate.Items.Count - 1)) Then
                    cbxSampleRate.SelectedIndex = -1
                Else
                    cbxSampleRate.SelectedIndex = idx
                End If
            Else
                StatusBar_IO.Text = (StatusBar_IO.Text + ("GetSampleRate Index (Err : " + (idx.ToString + ") Failed! ")))
            End If
        Else
            StatusBar_IO.Text = (StatusBar_IO.Text + ("GetSampleRate (Err : " _
                        + (m_adamCtl.AnalogInput.ApiLastError.ToString + ") Failed! ")))
        End If

    End Sub

    ''' Check module controllable
    Private Function CheckControllable() As Boolean
        Dim active As System.UInt16
        If m_adamCtl.Configuration.SYS_GetGlobalActive(active) Then
            If (active = 1) Then
                Return True
            Else
                MessageBox.Show("There is another controller taking control, so you only can monitor IO data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return False
            End If
        End If
        MessageBox.Show(("Checking controllable failed, utility only could monitor io data now. (" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ")")), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Return False
    End Function

    Private Sub btnApplySelRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplySelRange.Click
        Dim i As Integer = 0
        Dim bRet As Boolean = True

        If Not CheckControllable() Then
            Return
        End If

        Timer1.Enabled = False

        If ((listViewChInfo.SelectedIndices.Count = 0) AndAlso Not chkApplyAll.Checked) Then

            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            bRet = False
        End If

        listViewChInfo.BeginUpdate()
        If bRet Then
            Dim usRanges() As System.UInt16 = New System.UInt16((m_usRanges.Length) - 1) {}
            Array.Copy(m_usRanges, 0, usRanges, 0, m_usRanges.Length)
            If chkApplyAll.Checked Then
                For i = 0 To usRanges.Length - 1
                    usRanges(i) = AnalogInput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                Next
            Else
                For i = 0 To listViewChInfo.SelectedIndices.Count - 1
                    usRanges(listViewChInfo.SelectedIndices(i)) = AnalogInput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                Next
            End If
            If m_adamCtl.AnalogInput.SetRanges(Me.m_iSlot_ID_5017, Me.m_iAIChannelNum, usRanges) Then
                RefreshRanges()
            Else
                MessageBox.Show("Set ranges failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If
        End If

        listViewChInfo.EndUpdate()
        Timer1.Enabled = True
    End Sub

    Private Sub btnBurnoutFcn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBurnoutFcn.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        If chkApplyAll.Checked Then
            If chkBurnoutFcn.Checked Then
                m_uiBurnoutMask = (CType((1 + m_iAIChannelNum), UInteger) - 1)
            Else
                m_uiBurnoutMask = 0
            End If
        Else
            Dim idx As Integer = 0
            Dim i As Integer = 0
            For i = 0 To listViewChInfo.Items.Count - 1
                If listViewChInfo.Items(i).Selected Then
                    idx = i
                    Exit For
                End If
            Next
            Dim uiMask As UInteger = CType((&H1 << idx), UInteger)
            If chkBurnoutFcn.Checked Then
                m_uiBurnoutMask = (m_uiBurnoutMask Or uiMask)
            End If
            m_uiBurnoutMask = (m_uiBurnoutMask And (Not uiMask))
        End If
        If m_adamCtl.AnalogInput.SetBurnoutFunEnable(Me.m_iSlot_ID_5017, m_uiBurnoutMask) Then
            MessageBox.Show("Set burnout enable function done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            RefreshBurnoutSetting(True, False)
            'refresh burnout mask value
        Else
            MessageBox.Show("Set burnout enable function failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub btnBurnoutValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBurnoutValue.Click
        Dim uiVal As UInteger

        If (cbxBurnoutValue.SelectedIndex = 0) Then
            uiVal = 0
        Else
            uiVal = 65535
        End If

        If Not CheckControllable() Then
            Return
        End If

        Timer1.Enabled = False

        If m_adamCtl.AnalogInput.SetBurnoutValue(Me.m_iSlot_ID_5017, uiVal) Then
            MessageBox.Show("Set burnout value done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            RefreshBurnoutSetting(False, True)
            'refresh burnout detect mode
        Else
            MessageBox.Show("Set burnout value failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End If

        Timer1.Enabled = True
    End Sub

    Private Sub btnSampleRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSampleRate.Click
        Dim iIdx As Integer = cbxSampleRate.SelectedIndex

        If Not CheckControllable() Then
            Return
        End If

        Timer1.Enabled = False

        Dim uiRate As UInteger

        If (m_aConf.GetModuleName = "5017") Then
            If (iIdx = 0) Then
                uiRate = 1
            Else
                uiRate = 10
            End If
        ElseIf (iIdx = 0) Then
            uiRate = 100
        Else
            uiRate = 1000
        End If

        If m_adamCtl.AnalogInput.SetSampleRate(Me.m_iSlot_ID_5017, uiRate) Then
            MessageBox.Show("Set sampling rate done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            RefreshAiSampleRate()
        Else
            MessageBox.Show("Set sampling rate failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End If

        Timer1.Enabled = True
    End Sub

    Private Sub listViewChInfo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listViewChInfo.SelectedIndexChanged
        Dim i As Integer

        For i = 0 To listViewChInfo.Items.Count - 1

            If listViewChInfo.Items(i).Selected Then
                LvChInfo_SelectedIndexChanged(i)
                Exit For
            End If

        Next
    End Sub

    Private Sub Form_APAX_5017H_Closing_1(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        FreeResource()
    End Sub

    Private Sub Form_APAX_5017H_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connDB()
        Try
            comport.Open()
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            If comport.IsOpen = False Then
                MsgBox("Can't open COM1", MsgBoxStyle.Exclamation)
            End If

        End Try
        Timer2.Enabled = True
        saveData.Enabled = True
        Dim strbtnStatus As String = Me.btnStart.Text

        If String.Compare(strbtnStatus, "Start", True) = 0 Then 'Was Stop, Then Start

            If Not StartRemote() Then
                Return
            End If

            m_bStartFlag = True
            Me.btnStart.Text = "Stop"

        Else  'Was Start, Then Stop
            ' Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start'button."
            Me.FreeResource()
            Me.btnStart.Text = "Start"

        End If

        Dim waitThread As Thread = New Thread(AddressOf ShowWaitMsg)
        waitThread.IsBackground = False
        waitThread.Start()

        Timer1.Enabled = True
        RefreshRanges()
        RefreshAiSetting()
        If (m_aConf.GetModuleName = "5017H") Then
            RefreshBurnoutSetting(True, True)
        End If
        If (m_aConf.GetModuleName = "5017") Then
            RefreshBurnoutSetting(False, True)
        End If
        RefreshAiSampleRate()
    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim Incoming As String
        Dim outPut As String
        Incoming = ""
        outPut = ""
        Incoming = comport.ReadExisting()
        Dim SendString = ">" & analogValue(0) & analogValue(1) & analogValue(2) & analogValue(3) & analogValue(4) & analogValue(5) & analogValue(6) & analogValue(7)
        Dim SendString2 = ">" & analogValue(8) & analogValue(9) & analogValue(10) & analogValue(11) & analogValue2(0) & analogValue2(1) & analogValue2(2) & analogValue2(3)
        Dim i As Integer
        Dim controlNum As Integer
        ReceieveTxtBox.Text = Incoming
        If Incoming = ("#01" & Chr(13)) Or Incoming = ("#01") Then
            comport.Write(SendString + Chr(13))
            outPut = SendString
        End If
        If Incoming = ("#02" & Chr(13)) Or Incoming = ("#02") Then
            comport.Write(SendString2 + Chr(13))
            outPut = SendString2
        End If
        If Incoming = ("#01" & Chr(13) & "#02" & Chr(13)) Or Incoming = ("#01" + "#02") Then
            comport.Write(SendString + Chr(13))
            comport.Write(SendString2 + Chr(13))
            outPut = SendString + Chr(13) + SendString2 + Chr(13)
        End If
        If Mid(Incoming, 1, 1) = "*" Then
            Incoming = Mid(Incoming, 2, Len(Incoming) - 1)
            controlNum = Val(Mid(Incoming, 1, 1))
            Incoming = Mid(Incoming, 2, Len(Incoming) - 1)
            If Len(Incoming) = 12 Then
                Call control5060(controlNum, Incoming)
            End If
        End If
        SendTxtBox.Text = outPut

    End Sub

    Private Sub StatusBar_IO_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles StatusBar_IO.PanelClick

    End Sub

    Private Sub connDB()
        '======定義一個過程連接資料========================
        strsql = "user id=wecc;password=27548312;initial catalog=RAW;data source=APAX-5580\SQLEXPRESS;Connect Timeout=30"
        conn = New SqlConnection(strsql) '創建連線物件
        Try
            conn.Open() '打開連接
            TextBox1.Text = "已經正確建立連接!"
        Catch ex As Exception
            TextBox1.Text = ex.Message & "連接錯誤"
            Exit Sub
        End Try
    End Sub

    Private Sub saveData_Tick(sender As Object, e As EventArgs) Handles saveData.Tick
        Dim hourStamp As Integer
        Dim minuteStamp As Integer
        Dim secondNow As Integer
        Dim minuteNow As Integer

        minuteNow = Minute(Now())
        secondNow = Second(Now())
        If secondNow = 0 And minuteNow <> minuteStamp Then
            Call saveValue()
            minuteStamp = minuteNow
        End If
    End Sub

    Private Sub saveValue()     'save data to database
        Dim timeNow As String
        Dim query As String = String.Empty
        query &= "INSERT INTO data (time, ch101, ch102, ch103, ch104, ch105, ch106, ch107, ch108, ch109, ch110, ch111, "
        query &= "                     ch201, ch202, ch203, ch204, ch205, ch206, ch207, ch208, ch209, ch210, ch211)  "
        query &= "VALUES (@colTime,@colCh101, @colCh102, @colCh103,@colCh104, @colCh105, @colCh106,@colCh107, @colCh108, @colCh109,@colCh110, @colCh111, @colCh201,@colCh202, @colCh203, @colCh204,@colCh205,@colCh206, @colCh207, @colCh208, @colCh209,@colCh210, @colCh211)"
        timeNow = Format(Now, "yyyy/MM/dd hh:mm:ss")
        Using comm As New SqlCommand()
            With comm
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@colTime", timeNow)
                .Parameters.AddWithValue("@colch101", analogValue(0))
                .Parameters.AddWithValue("@colch102", analogValue(1))
                .Parameters.AddWithValue("@colch103", analogValue(2))
                .Parameters.AddWithValue("@colch104", analogValue(3))
                .Parameters.AddWithValue("@colch105", analogValue(4))
                .Parameters.AddWithValue("@colch106", analogValue(5))
                .Parameters.AddWithValue("@colch107", analogValue(6))
                .Parameters.AddWithValue("@colch108", analogValue(7))
                .Parameters.AddWithValue("@colch109", analogValue(8))
                .Parameters.AddWithValue("@colch110", analogValue(9))
                .Parameters.AddWithValue("@colch111", analogValue(10))
                .Parameters.AddWithValue("@colch201", analogValue2(0))
                .Parameters.AddWithValue("@colch202", analogValue2(1))
                .Parameters.AddWithValue("@colch203", analogValue2(2))
                .Parameters.AddWithValue("@colch204", analogValue2(3))
                .Parameters.AddWithValue("@colch205", analogValue2(4))
                .Parameters.AddWithValue("@colch206", analogValue2(5))
                .Parameters.AddWithValue("@colch207", analogValue2(6))
                .Parameters.AddWithValue("@colch208", analogValue2(7))
                .Parameters.AddWithValue("@colch209", analogValue2(8))
                .Parameters.AddWithValue("@colch210", analogValue2(9))
                .Parameters.AddWithValue("@colch211", analogValue2(10))
            End With
            Try
                'conn.Open()
                comm.ExecuteNonQuery()
                TextBox1.Text = timeNow & "data writing success!!"
            Catch
                TextBox1.Text = timeNow & "write to database error!!!"
            End Try
        End Using

    End Sub

    Private Sub btnTrue_Click(sender As Object, e As EventArgs) Handles btnTrue.Click
        If NumericUpDown1.Value >= 0 And NumericUpDown1.Value < 12 Then
            m_adamCtl.DigitalOutput.SetValue(m_iSlot_ID_5060, NumericUpDown1.Value, True)
        End If

    End Sub

    Private Sub btnFalse_Click(sender As Object, e As EventArgs) Handles btnFalse.Click
        If NumericUpDown1.Value >= 0 And NumericUpDown1.Value < 12 Then
            m_adamCtl.DigitalOutput.SetValue(m_iSlot_ID_5060, NumericUpDown1.Value, False)
        End If
    End Sub
    '======================== code for 5060===================================
    Public Function DeviceFind_5060() As Boolean

        Dim iLoop As Integer = 0
        Dim iDeviceNum As Integer = 0
        If m_iSlot_ID_5060 = -1 Then
            For iLoop = 0 To m_szSlots.Length - 1
                If (String.Compare(m_szSlots(iLoop), 0, DVICE_TYPE_5060, 0, DVICE_TYPE_5060.Length) = 0 And m_szSlots(iLoop).Length = 4) Then

                    iDeviceNum = iDeviceNum + 1
                    If iDeviceNum = 1 Then 'Record first find device
                        m_iSlot_ID_5060 = iLoop 'Get DVICE_TYPE Solt

                    End If
                End If
            Next

        Else

            If (String.Compare(m_szSlots(m_iSlot_ID_5060), 0, DVICE_TYPE_5060, 0, DVICE_TYPE_5060.Length) = 0 And m_szSlots(m_iSlot_ID_5060).Length = 4) Then
                iDeviceNum = iDeviceNum + 1
            End If

        End If
        If iDeviceNum = 1 Then
            DeviceFind_5060 = True
        ElseIf iDeviceNum > 1 Then
            MessageBox.Show("Found " + iDeviceNum.ToString + DVICE_TYPE_5060 + " devices." + vbCrLf + " It's will demo Solt " + m_iSlot_ID_5060.ToString + ".", "Warning")
            DeviceFind_5060 = True
        Else
            MessageBox.Show("Can't find any " + DVICE_TYPE_5060 + " device!  iDevicenum = " + iDeviceNum, "Error")
            DeviceFind_5060 = False
        End If


    End Function

    Private Sub control5060(iSlotID_5060 As Integer, str As String)
        Dim i As Integer
        Dim channelNum As Integer
        Dim switch As String
        channelNum = Len(str) - 1
        TextBox2.Text = str
        For i = 0 To channelNum
            switch = Mid(str, 1, 1)
            If switch = "0" Then
                m_adamCtl.DigitalOutput.SetValue(iSlotID_5060, i, False)
            Else
                m_adamCtl.DigitalOutput.SetValue(iSlotID_5060, i, True)
            End If
            str = Mid(str, 2, Len(str) - 1)
        Next
    End Sub

    Private Sub Form_APAX_5017H_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        socketEnd()
    End Sub
End Class