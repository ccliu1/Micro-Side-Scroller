# Devlog: Making my First Game in Unity
This is my first devlog! I have always been interested in making video games and I've heard that keeping a devlog would only benefit me in the future, so I'm started this devlog. This devlog won't be as professional and it'll be more like a devjournal than anything else. I want to write down what I have been doing, what I have been struggling with, and what I have been trying to learn over the course of this project.

I have a background in computer science, but so far from my experience, the coding portion is the least of my problems. One of my obstacles will definitely be learning proper game design architecture.

## Goals
The MAIN goal of this project is to learn how to use Unity by completing a small 2D side scroller game. Some initial objectives are:
1. 2D Movement
2. 2D Animation
3. Basic combat against enemies
4. Simple enemy AI
5. Simple level design and progression
6. Game ending

### 2D Movement
Unity has a Input System Package that replaced a legacy Input Manager system. This system package, although new, has nicely written documentation on the different methods you can use to implement it. There are 3 workflows that the documentation introduced. The one that I chose was the "Using Actions" workflow. This seemed to be the recommended workflow as stated by the documentation. 

The "Using Actions and the PlayerInput Component" also had promise. It consists of using callback functions. I believe that this workflow is suited for more complex games as you are able to decouple code easier. However, I this game is pretty simple and I want to get things working first before I explore more complex methods.

For the 2D movement on a sidescroller, I first set up the playing area with a ground area with collision so that the player character would not fall through. Then I setup the player character with a 2dRigidBody component and a collision component so that it can move and detect collisions. Unity has a neat option in the 2DRigidBody component that just lets you turn on gravity, which is what I did.

#### Sideways Movement
This was the easiest part. All I had to do was get the input data from the controller and used the value to determine if the player moved left or right.

#### Jump
For jumping, I got the jump input and checked if it was pressed. If it was pressed, the player would gain upward velocity and "jump". The gravity would automatically pull them down.

#### 
