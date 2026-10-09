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

## 2D Movement
Unity has a Input System Package that replaced a legacy Input Manager system. This system package, although new, has nicely written documentation on the different methods you can use to implement it. There are 3 workflows that the documentation introduced. The one that I chose was the "Using Actions" workflow. This seemed to be the recommended workflow as stated by the documentation. 

The "Using Actions and the PlayerInput Component" also had promise. It consists of using callback functions. I believe that this workflow is suited for more complex games as you are able to decouple code easier. However, I this game is pretty simple and I want to get things working first before I explore more complex methods.

For the 2D movement on a sidescroller, I first set up the playing area with a ground area with collision so that the player character would not fall through. Then I setup the player character with a 2dRigidBody component and a collision component so that it can move and detect collisions. Unity has a neat option in the 2DRigidBody component that just lets you turn on gravity, which is what I did.

### Sideways Movement
After getting the movement inputs, I used the the built-in smooth damp function to calculate the velocity. By using smooth damp, I was able to set some values to emulate acceleration for the Player. This resulted in a smooth transition into the set speed movement.

### Jump
For jumping, I got the jump input and checked if it was pressed. If it was pressed, the player would gain upward velocity and "jump". The gravity would automatically pull them down. I also implemented a ground check that would only let the player to jump if they were on the ground. This ground check was implemented using a box cast.

---

### What I learned
#### Input System Package
There was no setup needed and I only needed to learn how get the controller inputs. Simple and easy to use.
#### Smooth Damping
I have used LERP before so this isn't something super out of left field to learn. I just needed to read the documentation for the parameters. This is great for smooth acceleration.
#### Box Cast
Rather than using the character collider to detect if it's on the ground. I used a box cast. The character collider may have issues in the future on slopes or other non-flat terrains. You can also have multiple box casts at the same time without issue and have each detect for different things.
#### Gizmos
An issue I ran into while using a box cast was that it does not appear in the scene UI so it was really hard to determine where the box cast actually was. I didn't do too much investigation into this, but Gizmos is used for visual debugging in scene view, which is exactly what I wanted. By using the same parameters as the box cast, I can draw the same box in scene view which lets me see the box cast. This made tweaking the box cast size and location much easier.


## 2D Animation
For this project, I will primarily be using 2D pixel sprites for animation and environmental assets.
