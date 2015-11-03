# PirSensor Class
This is the code block for using a PIR motion sensor with Windows 10 IoT Core. Check the *Supported Devices* section to see the list of tested sensors.

## Usage 
To use this block in your project, you need to perform the following steps:  

1. Navigate to your git project folder using Command Prompt and run `git submodule add https://github.com/ms-iot/motion-sensor`   
2. Next, run `git submodule update`   
3. Open your project solution in Visual Studio and right-click on the solution and select **Add -> Existing Project**. Select motion-sensor -> PirSensor -> PirSensor.csproj.   
4. Once PirSensor is added to the solution explorer, right-click on **References** in your project and select **Add Reference -> Projects -> Solution**. Check PirSensor and select **OK**.  
You should now be able to use PirSensor objects in your project.   

*Note:* Every time you clone your project after its initial creation, you must run the following commands in the project's root folder:  

-  `git submodule init`   
-  `git submodule update`   

## Constructors
- **MotionSensor(int, SensorType):** Creates a new instance of the motion sensor taking the GPIO pin and type (SensorType.ActiveLow or SensorType.ActiveHigh) as arguments. 

*Note:* See the *Supported Devices* section to see what sensor type to use.

## Events 
- **motionDetected:** Occurs when motion is detected. 

## Methods
- **Dispose:** Performs tasks associated with freeing, releasing, or resetting unmanaged resources.

## Supported Devices
| Manufacturer  |      Sensor                                                      | SensorType |
|---------------|------------------------------------------------------------------|------------|
| Adafruit      |[PIR (motion) sensor](https://www.adafruit.com/products/189)      | ActiveHigh |
| Sparkfun      |[PIR Motion Sensor (JST)](https://www.sparkfun.com/products/13285)| ActiveLow  |


