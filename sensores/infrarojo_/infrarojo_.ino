//Definimos los pines del motor
#define IN1  2
#define IN2  3
#define IN3  5
#define IN4  6
//Variables para controlar el motor paso a paso
int Steps = 0; // estado del motor
boolean Direction = true;// true = contra direccion del reloj
int steppsPorLectura = 100;

//Definimos los pines para los leds
int redPin = 9;
int greenPin = 10;
int bluePin = 11;

//Configura el modo de los pin de los leds
void configurarPinLeds() {
  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);
}
//configura el modo de los pines del motor
void configurarMotor(){
  pinMode(IN1, OUTPUT); 
  pinMode(IN2, OUTPUT); 
  pinMode(IN3, OUTPUT); 
  pinMode(IN4, OUTPUT); 
}

/*
 * enciende el led RGB en un color determinado por la codificacion RGB
 * si valorRed = 255 y los demas en cero el led enciende rojo
 * si valorGreen = 255 y los demas en cero el led enciende verde
 * si valorBlue = 255 y los demas en cero el led enciende azul
 * si todos 255 el led enciende blanco
 * otro valor apaga todos los leds
*/
void colorRGB(int valorRed, int valorGreen, int valorBlue)
{
  analogWrite(redPin, valorRed);
  analogWrite(greenPin, valorGreen);
  analogWrite(bluePin, valorBlue);
}

//Controlador para el motor de acuerdo a datasheet
void stepper(int xw){
  for (int x=0;x<xw;x++){
    switch(Steps){
       case 0:
         digitalWrite(IN1, LOW); 
         digitalWrite(IN2, LOW);
         digitalWrite(IN3, LOW);
         digitalWrite(IN4, HIGH);
       break; 
       case 1:
         digitalWrite(IN1, LOW); 
         digitalWrite(IN2, LOW);
         digitalWrite(IN3, HIGH);
         digitalWrite(IN4, HIGH);
       break; 
       case 2:
         digitalWrite(IN1, LOW); 
         digitalWrite(IN2, LOW);
         digitalWrite(IN3, HIGH);
         digitalWrite(IN4, LOW);
       break; 
       case 3:
         digitalWrite(IN1, LOW); 
         digitalWrite(IN2, HIGH);
         digitalWrite(IN3, HIGH);
         digitalWrite(IN4, LOW);
       break; 
       case 4:
         digitalWrite(IN1, LOW); 
         digitalWrite(IN2, HIGH);
         digitalWrite(IN3, LOW);
         digitalWrite(IN4, LOW);
       break; 
       case 5:
         digitalWrite(IN1, HIGH); 
         digitalWrite(IN2, HIGH);
         digitalWrite(IN3, LOW);
         digitalWrite(IN4, LOW);
       break; 
         case 6:
         digitalWrite(IN1, HIGH); 
         digitalWrite(IN2, LOW);
         digitalWrite(IN3, LOW);
         digitalWrite(IN4, LOW);
       break; 
       case 7:
         digitalWrite(IN1, HIGH); 
         digitalWrite(IN2, LOW);
         digitalWrite(IN3, LOW);
         digitalWrite(IN4, HIGH);
       break; 
       default:
         digitalWrite(IN1, LOW); 
         digitalWrite(IN2, LOW);
         digitalWrite(IN3, LOW);
         digitalWrite(IN4, LOW);
       break; 
    }
    //delay(10);
    SetDirection();
  }
} 
//Modifica la configuracion de los pines del motor
//para el siguiente step
void SetDirection(){
  if(Direction==1){ 
    Steps++;
  }
  if(Direction==0){ 
    Steps--; 
  }
  if(Steps>7){
    Steps=0;
  }
  if(Steps<0){
    Steps=7; 
  }
}

//Movimiento en direccion de las agujas del reloj
void conterClockWise() {
  Direction=true;
  stepper(steppsPorLectura);
}
//Movimiento en contra de la direccion de las agujas del reloj
void clockWise() {
  Direction=false;
  stepper(steppsPorLectura);
}
//Motor detenido
void stopMotor() {
  stepper(0);
}
//Metodo para configurar led y motor si todo esta bien
void todoOK() {
  colorRGB(0,255,0); //enciende verde
  stopMotor();
}
//Metodo para configurar led si los valores estan por debajo de lo permitido
//motor en direccion de las agujas del reloj
void peligroAbajo() {
  colorRGB(255,0,0); //enciende rojo
  clockWise();
}
//Metodo para configurar led si los valores estan por encima de lo permitido
//motor en contra de la direccion de las agujas del reloj
void peligroArriba() {
  colorRGB(0,0,255); //enciende azul
  conterClockWise();
}

//valor leido por sensor
int valorLeido = 0;
//pins del sensor
const int sensorPin = 7;
// defines variables
long duration;
int distance;
//#define pin0 12
//#define pin1 A1
//#define pin2 A2
//#define pin3 A3

//Definir limites
int limiteInferior;
int limiteSuperior;
void configurarSensor() {
  pinMode(sensorPin, INPUT); // configuramos sensorPin as output
}

void setup() {
  Serial.begin(9600);
  delay(500);//espera para q encienda
  //inicializar sensor
  configurarSensor();
  //inicializar outputs
  configurarPinLeds();
  configurarMotor();
}

void loop() {
  int obstaculo = digitalRead(sensorPin);
  if (obstaculo == LOW) {
    Serial.print("Existe obstaculo, lectura: ");
    Serial.println(obstaculo);
    peligroAbajo();
  } else {
    Serial.print("Todo Bien, lectura: ");
    Serial.println(obstaculo);
    todoOK();
  }
  delay(1000);
}
