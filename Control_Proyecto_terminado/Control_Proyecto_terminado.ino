#include <Keyboard.h>
char salto = 101;
char curar = 113;
char trepar = 119;
char izquierda = 97;
char derecha = 100;
char pausa = 116;
void setup() {
  // put your setup code here, to run once:
pinMode(2,INPUT);
pinMode(3, INPUT);
pinMode(4,INPUT);
pinMode(5, INPUT);
pinMode(6, INPUT);
pinMode(7, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
if (digitalRead(6)==HIGH) {
  
  Keyboard.press(salto);

  delay(150);
 
}
if(digitalRead(6)==LOW) {
Keyboard.release(salto);
}

if (digitalRead(7)== HIGH) {

  Keyboard.press(curar);

delay(150);
}
if(digitalRead(7)==LOW) {
Keyboard.release(curar);
}

if (digitalRead(4)== HIGH) {

  Keyboard.press(trepar);

delay(150);
}
if(digitalRead(4)==LOW) {
Keyboard.release(trepar);
}

if (digitalRead(5)==HIGH)  {

  Keyboard.press(izquierda);

delay(100);
}


if (digitalRead(3)==HIGH) {

  Keyboard.press(derecha);

delay(100);
}


if (digitalRead(2)==HIGH) {

  Keyboard.press(pausa);

delay(400);
}

if (digitalRead(5)==LOW ){
Keyboard.release(izquierda);
}
if (digitalRead(3)==LOW ){
Keyboard.release(derecha);
}
if(digitalRead(2)==LOW) {
Keyboard.release(pausa);
}
}
