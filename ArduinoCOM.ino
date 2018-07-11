//Very simple sketch for the arduino that can communicate with ArduinoCOM

String inputString = "";
boolean stringComplete = false;

void setup() {
  Serial.begin(9600);
}

void loop() {
if (stringComplete) {
    if (inputString == "CONNECT-") {
      //Acknoledge a connection
      Serial.println("ACK");
    } else {
      //Send back input string when command is unknown
      Serial.println(inputString);
    }
    // clear the string:
    inputString = "";
    stringComplete = false;
  }
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
      // add it to the inputString:
      inputString += inChar;
    // if the incoming character is a newline, set a flag so the main loop can
    // do something about it:
    if (inChar == '-') {
      stringComplete = true;
    }
  }
}

