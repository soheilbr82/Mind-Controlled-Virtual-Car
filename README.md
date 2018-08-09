# MindControlledCar
This project aims to steer a virtual car in a virtual environment using EEG signals.



# Description
In this work, we have designed and developed a racing car game in a three-dimensional (3D) simulated virtual environment using Unity software. The 3D virtual environment consists of two racing cars, tracks, as well as surrounding terrain that includes trees, grass, buildings, mountains, and the sky. Three cameras have been set up to show a driver’s view, a bird’s-eye view, and a following camera’s view. Kinetic parameters of the cars are chosen to simulate rational movements. The two racing cars are separately controlled by two individual drivers’ brainwaves. Each driver’s EEG brainwave is monitored in real time and a control signal is generated to steer the car using MATLAB.

# Unity Environment
A rich 3D terrain is designed to reflect the kinetics of the car. The 3D model designed in Unity can receive control commands through the asynchronous UDP protocol to steer the virtual car. The commands are control signals to determine whether move the virtual car towards left, right, forward and backward or make the car stand still. We have designed a MATLAB/Simulink platform in concert with the Unity model to train users with the paradigms of interests, collect EEG data, develop an individualized model, and to generate control signals to manipulate the virtual car in the Unity 3D model. A 3D virtual race car model along with a racing track layout are designed in Unity. The behaviors and kinematics of the virtual car are defined to pronounce a rational movement of a car. C# is used for parsing UDP messages, and handling the physics of the virtual car. Three viewing angles are specified to give the users the flexibility of control, and to evaluate different visual feedback of the same movement.


# Method
We implement a hybrid decoding algorithm that combines steady state visual evoked potential (SSVEP) and sensorimotor rhythm (SMR).  SSVEP can provide relatively high signal-to-noise ratio (SNR) and information transfer rate (ITR) while SMR provides natural imagery body movement. 

A monitor with 60Hz refresh rate is used throught the experiment. So, the flickering frequency of the four squares are chosen to be 7.5, 10, 12, and 15Hz on the left, right, top and bottom square, respectively. By staring at different flashing squares, a user intends to steer the car towards the corresponding direction. 
Canonical correlation analysis (CCA) as a highly efficient method to maximize signal-to-noise ratio (SNR) of EEG is utilized to calculate the canonical correlation of the projected EEG and the target frequencies in real-time.

Two different states of resting and imagery pushing are used to control stopping and moving the car. The so called alertness index has been incorporated to implement and decode those the states.

The overall decoding algorithm is a combination of the SSVEP and the SMR paradigms. We utilize the SMR paradigm as a gating function. If the online model detects the “pushing” state, the subject’s intended direction by the SSVEP paradigm is translated into the virtual car movement. If the SMR model determines the “resting” state, the virtual car remains stationary. 

The control signal is then calculated based on the user intension towards four different flickering squares and sent through the TCP/IP protocol to Unity to steer the car.

# Status of the work
The platform including GUI interface, Unity 3D environment, training protocol, data acquisition processes, communication protocols, as well as online and offline decoding algorithms, has been fully implemented.


[![Mind-controlled Virtual Car](https://github.com/soheilbr82/Mind-Controlled-Virtual-Car/blob/master/image.jpg)](https://www.youtube.com/watch?v=mtFRiu9rQD8&feature=youtu.be "Mind-controlled Virtual Car")






# Potential applications and future work
Conventional BCI-based biofeedback systems lack the users’ engagement and motivation, which makes it hard for users to attain a satisfactory level of control. The platform is designed to improve users’ experience of motor imagery with a visual feedback of the users’ intention on to a virtual car. It serves as a pilot for online BCI-based gaming while suggests an educational tool to promote interests in BCI for the public. The setup has potential to use as a research tool for investigators in developmental psychology and behavioral science. Moreover, Unity opens the opportunity for us to evaluate users’ immersion in virtual reality (VR) using the proposed platform in future study. The platform may suggest an effective visual feedback of vision, which can lay a foundation for BCI application.

