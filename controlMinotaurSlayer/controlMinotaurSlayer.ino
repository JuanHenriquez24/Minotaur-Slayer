#include <Joystick.h>

#define joyX1 A0
#define joyY1 A1
#define joySW1 2
#define joyX2 A2
#define joyY2 A3
#define joySW2 3

void setup() {
  Serial.begin(9600);
  
  pinMode(joySW1, INPUT_PULLUP);
  pinMode(joySW2, INPUT_PULLUP);
}
 
void loop() {
  // put your main code here, to run repeatedly:
  int x1Value = analogRead(joyX1);
  int y1Value = analogRead(joyY1);
  int sw1Value = digitalRead(joySW1); 
  int x2Value = analogRead(joyX2);
  int y2Value = analogRead(joyY2);
  int sw2Value = digitalRead(joySW2);
  int x1Map = map(x1Value, 0, 1024, -46, 45);
  int y1Map = map(y1Value, 0, 1024, 45, -46);
  int x2Map = map(x2Value, 0, 1024, -46, 45);
  int y2Map = map(y2Value, 0, 1024, 45, -46); 
 
  Serial.flush(); 
  Serial.print(x1Map);
  Serial.print(",");
  Serial.print(y1Map);
  Serial.print(",");
  Serial.print(!sw1Value);
  Serial.print(",");
  Serial.print(x2Map);
  Serial.print(",");
  Serial.print(y2Map);
  Serial.print(",");
  Serial.print(!sw2Value);
  Serial.println();

  delay(10);
}
