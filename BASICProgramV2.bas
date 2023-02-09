#No_Data
#No_Table
#Slot 0

'PWM Frequencies for 25kg servos: 44-252
'PWM Frequencies for 9g servos: 75-225
'Constants
Symbol Servo1Default = 148
Symbol Servo2Default = 148
Symbol Servo3Default = 150

'Output Pins
Symbol ServoD1 = B.0
Symbol ServoD2 = B.1
Symbol ServoD3 = B.2

'Variables
Symbol TempReceive = b0
Symbol ColourC = b1
Symbol ColourM = b2
Symbol ColourY = b3
Symbol ColourK = b4
Symbol Servo1Pos = b5
Symbol Servo2Pos = b6
Symbol Servo3Pos = b7
Symbol Servo1OldPos = b8
Symbol Servo2OldPos = b9
Symbol Servo3OldPos = b10

'Initialise servo variables
Servo1Pos = Servo1Default
Servo2Pos = Servo2Default
Servo3Pos = Servo3Default
Servo1OldPos = 0
Servo2OldPos = 0
Servo3OldPos = 0

'Initialise servos
Servo ServoD1, Servo1Pos
Servo ServoD2, Servo2Pos
Servo ServoD3, 200

Let Servo1OldPos = Servo1Pos
Let Servo2OldPos = Servo2Pos
Let Servo3OldPos = 200
Servo3Pos = Servo3Default

'Move servos to calibration positions
Pause 2000
Servo1Pos = 145
Servo2Pos = 175
Servo3Pos = 100
GoSub MoveServos
Pause 2000
Servo1Pos = 118
Servo2Pos = 195
Servo3Pos = 104
GoSub MoveServos
Pause 2000
GoSub BrushBottomLeft
Pause 2000
GoSub BrushDefault
Pause 1000

WaitForProgramStart:
Serrxd TempReceive
If TempReceive <> 10 Then
	GoTo ErrorOccured
EndIf
'Received data is the start of a new painting
Pause 100
GoSub SendReady
GoTo WaitForNewData
End

WaitForNewData:
TempReceive = 0
'Data recieved here could be 15, 20, 25, 35.
Serrxd TempReceive
If TempReceive = 15 Then
	'End of painting, return brush to neutral position
	GoSub WashBrush
	GoSub SendReady
	Reset
Else If TempReceive = 20 Then
	'Start of new stroke object, wash brush then recieve colour
	GoTo ReceiveColourObject
Else If TempReceive = 25 Then
	'Start of new stroke coordinate, receive position
	GoTo ReceivePositionObject
Else
	'Data received is either 30 (error code) or null
	GoTo ErrorOccured
EndIf
GoTo WaitForNewData
End

ReceiveColourObject:
GoSub BrushDefault
Pause 100
'Clean old paint off of brush
GoSub WashBrush
Pause 500
GoSub SendReady
Pause 100
'Receive colour values (1-10)
Serrxd ColourC
Pause 100
Serrxd ColourM
Pause 100
Serrxd ColourY
Pause 100
Serrxd ColourK
Pause 500
'Pick paint up with brush
GoSub CollectPaint
Pause 500
GoSub SendReady
Pause 100
GoTo WaitForNewData
End

ReceivePositionObject:
Pause 500
Servo3Pos = 150
GoSub MoveServos
Pause 500
GoSub SendReady
Pause 100
'Receive position values
Serrxd Servo1Pos
Pause 100
Serrxd Servo2Pos
Pause 100
GoSub MoveServos
Pause 500
Servo3Pos = 200
GoSub MoveServos
Pause 500
Servo3Pos = 150
GoSub MoveServos
Pause 100
GoSub SendReady
Pause 100
GoTo WaitForNewData
End

ErrorOccured:
GoSub SendError
Pause 500
GoTo ErrorOccured
End

CollectPaint:
'Black
If ColourK <> 0 Then
	Servo1Pos = 138
	Servo2Pos = 182
	Servo3Pos = 95
	GoSub MoveServos
	Pause 1000
	Servo1Pos = ColourK * 5
	Servo1Pos = Servo1Pos / 10
	Servo1Pos = Servo1Pos + 138
	Servo2Pos = 185
	GoSub MoveServos
	Pause 500
	Servo1Pos = 138
	Servo2Pos = 182
	GoSub MoveServos
	Pause 1000
EndIf
'Yellow
If ColourY <> 0 Then
	Servo1Pos = 138
	Servo2Pos = 182
	Servo3Pos = 104
	GoSub MoveServos
	Pause 1000
	Servo1Pos = ColourY * 5
	Servo1Pos = Servo1Pos / 10
	Servo1Pos = Servo1Pos + 138
	Servo2Pos = 185
	GoSub MoveServos
	Pause 500
	Servo1Pos = 138
	Servo2Pos = 182
	GoSub MoveServos
	Pause 1000
EndIf
'Magenta
If ColourM <> 0 Then
	Servo1Pos = 118
	Servo2Pos = 195
	Servo3Pos = 95
	GoSub MoveServos
	Pause 1000
	Servo1Pos = ColourM * 7
	Servo1Pos = Servo1Pos / 10
	Servo1Pos = Servo1Pos + 118
	Servo2Pos = 198
	GoSub MoveServos
	Pause 500
	Servo1Pos = 118
	Servo2Pos = 195
	GoSub MoveServos
	Pause 1000
EndIf
'Cyan
If ColourC <> 0 Then
	Servo1Pos = 118
	Servo2Pos = 195
	Servo3Pos = 104
	GoSub MoveServos
	Pause 1000
	Servo1Pos = ColourC * 7
	Servo1Pos = Servo1Pos / 10
	Servo1Pos = Servo1Pos + 118
	Servo2Pos = 198
	GoSub MoveServos
	Pause 500
	Servo1Pos = 118
	Servo2Pos = 195
	GoSub MoveServos
	Pause 1000
EndIf
Return

WashBrush:
'Move brush into pot
For b55 = 0 To 4 Step 1
	Servo1Pos = 145
	Servo2Pos = 175
	Servo3Pos = 100
	GoSub MoveServos
	Pause 1000
	Servo1Pos = 157
	Servo2Pos = 172
	Servo3Pos = 100
	GoSub MoveServos
	Pause 1000
Next b55
'Wiggle brush
For b55 = 0 To 4 Step 1
	Servo3Pos = 90
	GoSub MoveServos
	Pause 100
	Servo3Pos = 100
	GoSub MoveServos
	Pause 100
Next b55
Pause 500
'Remove brush
Servo1Pos = 145
Servo2Pos = 175
GoSub MoveServos
Pause 500
'Wiggle brush
For b55 = 0 To 4 Step 1
	Servo3Pos = 90
	GoSub MoveServos
	Pause 100
	Servo3Pos = 100
	GoSub MoveServos
	Pause 100
Next b55
Pause 1000
Return

BrushDefault:
Servo1Pos = Servo1Default
Servo2Pos = Servo2Default
Servo3Pos = Servo3Default
GoSub MoveServos
Return

BrushTopRight:
Servo1Pos = 151
Servo2Pos = 110
Servo3Pos = 200
GoSub MoveServos
Return

BrushTopLeft:
Servo1Pos = 109
Servo2Pos = 148
Servo3Pos = 200
GoSub MoveServos
Return

BrushBottomRight:
Servo1Pos = 167
Servo2Pos = 151
Servo3Pos = 200
GoSub MoveServos
Return

BrushBottomLeft:
Servo1Pos = 81
Servo2Pos = 205
Servo3Pos = 200
GoSub MoveServos
Return

MoveServos:
'Check that servo value is within permitted range of movement
If Servo1Pos > 252 OR Servo1Pos < 44 Then
	Servo1Pos = Servo1Default
EndIf
If Servo2Pos > 252 OR Servo2Pos < 44 Then
	Servo2Pos = Servo2Default
EndIf
If Servo3Pos > 225 OR Servo3Pos < 75 Then
	Servo3Pos = Servo3Default
EndIf
'Only move servo if new position is different to old position
If Servo1OldPos <> Servo1Pos Then
	ServoPos B.0, Servo1Pos
EndIf
If Servo2OldPos <> Servo2Pos Then
	ServoPos B.1, Servo2Pos
EndIf
If Servo3OldPos <> Servo3Pos Then
	ServoPos B.2, Servo3Pos
EndIf

Let Servo1OldPos = Servo1Pos
Let Servo2OldPos = Servo2Pos
Let Servo3OldPos = Servo3Pos
Return

SendReady:
Sertxd (30)
Return

SendError:
Sertxd (35)
Return