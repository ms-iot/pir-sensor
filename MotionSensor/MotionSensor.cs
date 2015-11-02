using System;
using Windows.Devices.Gpio;

namespace Microsoft.Maker.Devices.Gpio.MotionSensor
{
    public class MotionSensor
    {
        /// <summary>
        /// Sensor type: Active high or active low.
        /// </summary>
        public enum SensorType
        {
            ActiveHigh, // Sensor pin is pulled high when motion is detected 
            ActiveLow   // Sensor pin is pulled low when motion is detected 
        }

        /// <summary>
        /// GpioPin object for the sensor's signal pin
        /// </summary>
        private GpioPin motionSensorPin;

        /// <summary>
        /// The edge to compare the signal with for motion based on the sensor type.
        /// </summary>
        private GpioPinEdge motionSensorEdge;

        /// <summary>
        /// Occurs when motion is detected
        /// </summary>
        public event EventHandler<GpioPinValueChangedEventArgs> motionDetected;

        /// <summary>
        /// Constructs a motion sensor device.
        /// </summary>
        /// <param name="sensorPin">
        /// The GPIO number of the pin used for the motion sensor.
        /// </param>
        /// <param name="sensorType">
        /// The motion sensor type: Active low or active high
        /// </param>
        public MotionSensor(int sensorPin, SensorType sensorType)
        {
            var gpioController = GpioController.GetDefault();
            motionSensorEdge = sensorType == SensorType.ActiveLow ? GpioPinEdge.FallingEdge : GpioPinEdge.RisingEdge;
            motionSensorPin = gpioController.OpenPin(sensorPin);
            motionSensorPin.SetDriveMode(GpioPinDriveMode.Input);
            motionSensorPin.ValueChanged += MotionSensorPin_ValueChanged;
        }

        /// <summary>
        /// Performs tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            motionSensorPin.Dispose();
        }

        /// <summary>
        /// Occurs when motion sensor pin value has changed
        /// </summary>
        private void MotionSensorPin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            if (motionDetected != null && args.Edge == motionSensorEdge)
            {
                motionDetected(this, args);
            }
        }
    }
}
