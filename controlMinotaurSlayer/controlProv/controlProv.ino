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
#define vib 8

int range = 12;             // output range of X or Y movement
int responseDelay = 5;      // response delay of the mouse, in ms
int threshold = range / 4;  // resting 0
int center = range / 2;     // resting position value
bool mouseIsMoving = true;

void setup() {
  Serial.begin(115200);
  Keyboard.begin();
  Mouse.begin();

  pinMode(joySW1, INPUT_PULLUP);
  pinMode(joySW2, INPUT_PULLUP);
  pinMode(bot1, INPUT_PULLUP);
  pinMode(bot2, INPUT_PULLUP);
  pinMode(bot3, INPUT_PULLUP);
  pinMode(bot4, INPUT_PULLUP);
  pinMode(vib, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  int sw1Value = !digitalRead(joySW1);
  int sw2Value = !digitalRead(joySW2);
  int bot1Value = !digitalRead(bot1);
  int bot2Value = !digitalRead(bot2);
  int bot3Value = !digitalRead(bot3);
  int bot4Value = !digitalRead(bot4);
  int vibra = Serial.read();
  
  digitalWrite(vib, LOW);

  int x1Map = readAxis(joyX1);
  int y1Map = readAxis(joyY1);
  int x2Map = readAxis(joyX2);
  int y2Map = readAxis(joyY2);


  // use the pushbuttons to control the keyboard:
  if (x1Map < 0) {
    Keyboard.write('a');   // izquierda
  }
  
  if (x1Map > 0) {
    Keyboard.write('d'); // derecha
  }

  if (y1Map > 0) {
    Keyboard.write('s'); // abajo
  }

  if (y1Map < 0) {
    Keyboard.write('w'); // arriba
  }


  if (sw1Value == HIGH) {
    Keyboard.write('p');    // pausar
  }

  if (sw2Value == HIGH) {
    Keyboard.write('e');    // correr
  }

   
  if (bot1Value == HIGH) {
    Keyboard.write('m');  // atacar / agarrar objetos
  }


  if (bot2Value == HIGH) {
    Keyboard.write(32); // saltar
  }

 
  if (bot3Value == HIGH) {
    Keyboard.write('q');
    // tirar hilo
  }

  if (bot4Value == HIGH) {
    Keyboard.write('f');
  }


  if(mouseIsMoving){
    Mouse.move(x2Map, y2Map, 0);
  }

  if(vibra == 1){
    digitalWrite(vib, HIGH);
    digitalWrite(LED_BUILTIN, HIGH);
  }
  else{
    digitalWrite(vib, LOW);
    digitalWrite(LED_BUILTIN, LOW);
  }

  delay(responseDelay);
} 

int readAxis(int thisAxis) {
  
  int reading = analogRead(thisAxis);

  reading = map(reading, 0, 1023, 0, range);

  int distance = reading - center;

  if (abs(distance) < threshold) {
    distance = 0;
  }

  // return the distance for this axis:
  return distance;
}
