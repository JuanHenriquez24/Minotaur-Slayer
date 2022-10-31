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
  Mouse.begin();

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

  int threshold = 10;
  int x1Map = map(x1Value, 0, 1024, -46, 45);
  int y1Map = map(y1Value, 0, 1024, 45, -46);
  int x2Map = map(x2Value, 0, 1024, -46, 45);
  int y2Map = map(y2Value, 0, 1024, 45, -46);

  // use the pushbuttons to control the keyboard:
  if (x1Map > threshold) {
    // adelante
    Keyboard.press('w');
    delay(50);

  } else {
    Keyboard.release('w');
  }

  if (x1Map < !threshold) {
    // atras
    Keyboard.press('s');
    delay(50);

  } else {
    Keyboard.release('s');
  }

  if (y1Map > threshold) {
    // derecha
    Keyboard.press('d');
    delay(50);

  } else {
    Keyboard.release('d');
  }

  if (y1Map < !threshold) {
    // izquierda
    Keyboard.press('a');
    delay(50);

  } else {
    Keyboard.release('a');
  }

  if (sw1Value == HIGH) {
    // pausar
    Keyboard.press('p');
    delay(50);

  } else {
    Keyboard.release('p');
  }

  if (sw2Value == HIGH) {
    // correr
    Keyboard.press('e');
    delay(50);

  } else {
    Keyboard.release('e');
  }

  if (bot1Value == HIGH) {
    // atacar / agarrar objetos
    Keyboard.press('m');
    delay(50);

  } else {
    Keyboard.release('m');
  }
  if (bot2Value == HIGH) {
    // saltar
    Keyboard.press(32);
    delay(50);

  } else {
    Keyboard.release(32);
  }
  if (bot3Value == HIGH) {
    // tirar hilo
    Keyboard.press('q');
    delay(50);

  } else {
    Keyboard.release('q');
  }
  if (bot4Value == HIGH) {
    // inventario
    Keyboard.press('f');
    delay(50);

  } else {
    Keyboard.release('f');
  }

  if (x2Map > threshold) {
    // arriba
    Mouse.move(10, 0);
  }
  if (x2Map < !threshold) {
    // abajo
    Mouse.move(-10, 0);
  }
  if (y2Map > !threshold) {
    // derecha
    Mouse.move(0, -10);
  }
  if (y2Map < threshold) {
    // izquierda
    Mouse.move(0, 10);
  }
  if (bot4Value == HIGH && bot3Value == HIGH) {
    Keyboard.end();
    Mouse.end();
  }
}
