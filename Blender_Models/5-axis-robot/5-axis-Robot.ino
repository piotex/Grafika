#include <Servo.h>

Servo myservo1;
Servo myservo2;
Servo myservo3;
Servo myservo4;
Servo myservo5;

int pos1 = 90;
int pos2 = 90;
int pos3 = 90;
int pos4 = 90;
int pos5 = 90;

String inString = ""; 

void setup() {
  myservo1.attach(12);  
  myservo2.attach(11);  
  myservo3.attach(10);  
  myservo4.attach(9);  
  myservo5.attach(8);  
  
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }
}

//ramka:    q1:123;q2:33;q3:5;q4:55;q5:66;

void loop() {

  while (Serial.available() > 0) {
    int inChar = Serial.read();
    inString += (char)inChar;
    
    if (inChar == '\n') {
      //Serial.println(inString);
      int q_index=0;
      for(int i=0;i<inString.length();i++){
        if(inString[i] == 'q'){
          i++;
          String strPos = ""; 
          
          if(inString[i] == '1'){
            i+=2;  //pominiecie '1:'
            while(inString[i] != ';'){
              strPos += inString[i];
              i++;
            }
            pos1 = strPos.toInt();
            strPos = "";
          }
          if(inString[i] == '1'){
            i+=2;  //pominiecie '1:'
            while(inString[i] != ';'){
              strPos += inString[i];
              i++;
            }
            pos1 = strPos.toInt();
            strPos = "";
          }
          if(inString[i] == '2'){
            i+=2;  //pominiecie '2:'
            while(inString[i] != ';'){
              strPos += inString[i];
              i++;
            }
            pos2 = strPos.toInt();
            strPos = "";
          }
          if(inString[i] == '3'){
            i+=2;  //pominiecie '3:'
            while(inString[i] != ';'){
              strPos += inString[i];
              i++;
            }
            pos3 = strPos.toInt();
            strPos = "";
          }
          if(inString[i] == '4'){
            i+=2;  //pominiecie '4:'
            while(inString[i] != ';'){
              strPos += inString[i];
              i++;
            }
            pos4 = strPos.toInt();
            strPos = "";
          }
          if(inString[i] == '5'){
            i+=2;  //pominiecie '5:'
            while(inString[i] != ';'){
              strPos += inString[i];
              i++;
            }
            pos5 = strPos.toInt();
            strPos = "";
          }
        }
      }


      
      Serial.print("pos1: ");
      Serial.println(pos1);
      Serial.print("pos2: ");
      Serial.println(pos2);
      Serial.print("pos3: ");
      Serial.println(pos3);
      Serial.print("pos4: ");
      Serial.println(pos4);
      Serial.print("pos5: ");
      Serial.println(pos5);      
      Serial.println("-------------");

      myservo1.write(pos1);
      myservo2.write(pos2);
      myservo3.write(pos3);
      myservo4.write(pos4);
      myservo5.write(pos5); 
  
      inString = "";
      pos1=0;
      pos2=0;
      pos3=0;
      pos4=0;
      pos5=0;

    }
  }

  /*
  for (pos = 0; pos <= 180; pos += 1) { // goes from 0 degrees to 180 degrees
    // in steps of 1 degree
    myservo.write(pos);              // tell servo to go to position in variable 'pos'
    delay(15);                       // waits 15 ms for the servo to reach the position
  }
  for (pos = 180; pos >= 0; pos -= 1) { // goes from 180 degrees to 0 degrees
    myservo.write(pos);              // tell servo to go to position in variable 'pos'
    delay(15);                       // waits 15 ms for the servo to reach the position
  }
  */
}
