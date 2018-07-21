# MindControlledCar
This project aims to steer a virtual car in a virtual environment using EEG signals.



# Description
In this work, we have designed and developed a racing car game in a three-dimensional (3D) simulated virtual environment using Unity software. The 3D virtual environment consists of two racing cars, tracks, as well as surrounding terrain that includes trees, grass, buildings, mountains, and the sky. Three cameras have been set up to show a driver’s view, a bird’s-eye view, and a following camera’s view. Kinetic parameters of the cars are chosen to simulate rational movements. The two racing cars are separately controlled by two individual drivers’ brainwaves. Each driver’s EEG brainwave is monitored in real time and a control signal is generated to steer the car using MATLAB.



# Method
We implement a hybrid decoding algorithm that combines steady state visual evoked potential (SSVEP) and sensorimotor rhythm (SMR).  SSVEP can provide relatively high signal-to-noise ratio (SNR) and information transfer rate (ITR) while SMR provides natural imagery body movement. 

A monitor with 60Hz refresh rate is used throught the experiment. So, the flickering frequency of the four squares are chosen to be 7.5, 10, 12, and 15Hz on the left, right, top and bottom square, respectively. By staring at different flashing squares, a user intends to steer the car towards the corresponding direction. 
Canonical correlation analysis (CCA) as a highly efficient method to maximize signal-to-noise ratio (SNR) of EEG is utilized to calculate the canonical correlation of the projected EEG and the target frequencies in real-time.

Two different states of resting and imagery pushing are used to control stopping and moving the car. The so called alertness index has been incorporated to implement and decode those the states.

The overall decoding algorithm is a combination of the SSVEP and the SMR paradigms. We utilize the SMR paradigm as a gating function. If the online model detects the “pushing” state, the subject’s intended direction by the SSVEP paradigm is translated into the virtual car movement. If the SMR model determines the “resting” state, the virtual car remains stationary. 

The control signal is then calculated based on the user intension towards four different flickering squares and sent through the TCP/IP protocol to Unity to steer the car.
