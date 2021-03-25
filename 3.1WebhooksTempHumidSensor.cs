#include "Adafruit_DHT.h" // the library i am using for this experiment

// Recording for various DHT humidity/temperature sensors


#define DHTPIN 2     // what pin it is connected to


#define DHTTYPE DHT22		// DHT-22 the temperature & humidity sensor

// Instructions
// Connect pin 1 (on the left) of the sensor to +5V
// Connect pin 2 of the sensor to whatever your DHTPIN is (D2)
// Connect pin 4 (on the right) of the sensor to GROUND

// where data is being stored

String sendData; // to send data

DHT dht(DHTPIN, DHTTYPE); // setting the instance

void setup() {
    
	dht.begin(); // starting the instance
}

void loop() {


	float humidity = dht.getHumidity(); // Read humidity

	float temperature = dht.getTempCelcius(); // Read temperature as Celsius

    
    sendData = String::format("{\"humid\": %.1f, \"temp\": %.1f}", humidity, temperature); // reading values, setting up array


    Particle.publish("HumidAndTemp", sendData, PRIVATE); // publishing of data

	delay(30000); // Waiting time between measurements

}

