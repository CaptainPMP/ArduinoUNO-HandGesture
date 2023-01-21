# ArduinoUNO Hand Gesture
## Concept :
- Use MPU6050 sync with the PC cursor
- ArduinoUNO don't support `Mouse.h`
- But ArduinoUNO can still use `MPU6050.h`
- I send `MPU6050.h` to C# to control cursor (I use C# because I used to it before and it faster than python)
![plan image](https://github.com/CaptainPMP/ArduinoUNO-HandGesture/blob/main/images/plan.jpg)

## What it suppose to be?
- [x] ArduinoUNO can send data to C# Program
- [ ] ArduinoUNO MPU6050 generate right acceleration
- [x] Create C# GUI for setting with difference environment (flexible)
- [x] Can select your own com port
- [x] Kill the program if MPU6050 error with shortcut keys
- [ ] Can tune your own sensitivity
- [ ] MPU6050 sync with cursor with smooth movement

<!-- ## Why am I doing this?
Because I lazy to use normal mouse, actually I want this project make more creative project () -->
