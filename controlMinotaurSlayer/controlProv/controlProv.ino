#include "Keyboard.h"
#include "Mouse.h"

#define joyX1 A0
#define joyY1 A1
#define joySW1 2
#define joyX2 A2
#define joyY2 A3
#define joySW2 3
#define bot1 4
#define bot2 5
#define bot3 6
#define bot4 7

void setup() {
  Serial.begin(115000);
  Keyboard.begin();
  
  pinMode(joySW1, INPUT_PULLUP);
  pinMode(joySW2, INPUT_PULLUP);
  pinMode(bot1, INPUT_PULLUP);
  pinMode(bot2, INPUT_PULLUP);
  pinMode(bot3, INPUT_PULLUP);
  pinMode(bot4, INPUT_PULLUP);
}
 
void loop() {
  // put your main code here, to run repeatedly:
  int x1Value = analogRead(joyX1);
  int y1Value = analogRead(joyY1);
  int sw1Value = !digitalRead(joySW1); 
  int x2Value = analogRead(joyX2);
  int y2Value = analogRead(joyY2);
  int sw2Value = !digitalRead(joySW2);
  int bot1Value = !digitalRead(bot1);
  int bot2Value = !digitalRead(bot2);
  int bot3Value = !digitalRead(bot3);
  int bot4Value = !digitalRead(bot4);
  int x1Map = map(x1Value, 0, 1024, -46, 45);
  int y1Map = map(y1Value, 0, 1024, 45, -46);
  int x2Map = map(x2Value, 0, 1024, -46, 45);
  int y2Map = map(y2Value, 0, 1024, 45, -46);

/*  if (Serial.available() > 0) {
    char inChar = Serial.read();

    switch (inChar) {
      case 'u':
        // move mouse up
        Mouse.move(0, -40);
        break;
      case 'd':
        // move mouse down
        Mouse.move(0, 40);
        break;
      case 'l':
        // move mouse left
        Mouse.move(-40, 0);
        break;
      case 'r':
        // move mouse right
        Mouse.move(40, 0);
        break;
      case 'm':
        // perform mouse left click
        Mouse.click(MOUSE_LEFT);
        break;
    }
  } */

  // use the pushbuttons to control the keyboard:
  if (x1Map > 10) {
    Keyboard.write('w');
    // adelante
  }
  if (x1Map < -10) {
    Keyboard.write('s');
    // atras
  }
  if (y1Map > 10) {
    Keyboard.write('d');
    // derecha
  }
  if (y1Map < -10) {
    Keyboard.write('a');
    // izquierda
  }
  if (sw1Value == HIGH) {
    Keyboard.write('p');
    // pausar
  }
   if (sw2Value == HIGH) {
    Keyboard.write('e');
    // correr
  }
   if (bot1 == HIGH) {
    Keyboard.write('m');
    // atacar / agarrar objetos
  }
   if (bot2 == HIGH) {
    Keyboard.write(32);
    // saltar
  }
   if (bot3 == HIGH) {
    Keyboard.write('q');
    // tirar hilo
  }
   if (bot4 == HIGH) {
    Keyboard.write('f');
    // inventario
  }
  

}
