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
  
  
  Serial.flush();  
  
  Serial.print(x1Value);
  Serial.print(",");
  Serial.print(y1Value);
  Serial.print(",");
  Serial.print(sw1Value);
  Serial.print(x2Value);
  Serial.print(",");
  Serial.print(y2Value);
  Serial.print(",");
  Serial.println(sw2Value);

  delay(50);
}
