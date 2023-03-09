# RobotManipulation
Interface development for controlling an industrial robotic arm using Myo armband and MS Kinect sensors

A Windows application has been created using UNITY 3D for the manipulation of an indstrial robotic arm (STAUBLI RX90L) using Myo Armband and MS Kinect sensors. The project is uploaded in ReaserchGate (https://www.researchgate.net/publication/345310537_Interface_development_for_controlling_an_industrial_robotic_arm_using_Myo_armband_and_MS_Kinect_sensors) with DOI: 10.13140/RG.2.2.24533.65765

A new GUI work space has been created including the robotic arm, a work table, cubes for manipulation and a lathe entrance. The scope of the project is to manipulate cubes and tools with the 6 DOF robotic arm, using a MS Kinect sensor and a Myo armband sensor. 
Noise filters have been designed to isolate movement and rotation of the operator's hand in three dimensional space. 

Both sensors have to be activated. If the application is achieved then the respective indication will turn yellow. Additionally, any activated joint is yellow. The joints in gray color can not be manipulated. To change the activated joints, operator has to achieve certain moves:

Shoulder, Arm and Elbow joints are manipulated via Kinect. Forearm, wrist and tool flange are manipulated via Myo. Fisting of the left arm is for end-effector. 

![image](https://user-images.githubusercontent.com/32259290/223964738-988e80fc-e289-4b60-855d-00e1fb466089.png)

![image](https://user-images.githubusercontent.com/32259290/223964791-0fc7dcf7-69e7-4a65-adb5-2a1bbbdc1e62.png)

![image](https://user-images.githubusercontent.com/32259290/223964876-b16e3225-f117-48ae-898b-c295f36a8954.png)
