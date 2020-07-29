# Velocity Kata

You are researching the motion of particles and have recorded the position of a particle across a period of time. Your measurements are recorded as an array of int.

Your task is to count the periods of time where the movement of the particle is stable; these are periods where the particle does not change its velocity i.e. the difference between two consecutive measurements remains the same. Note that you need at least three measurements to be sure the particle did not change its velocity.

E.G.
1, 3, 5, 7, 9 is stable (velocity = 2)
7, 7, 7, 7 is stable (velocity = 0)
3, -1, -5, -9 is stable (velocity = -4)
0, 1 is not stable (needs three measurements)
1, 1, 2, 5, 7 is not stable (velocity changes between measurements)

Note that some periods of time when the movement is stable may be contained within others.

Write a function that, given an array of int velocities representing the measurements, returns the number of period of time when the movement was stable. Return -1 if the number exceeds 1 000 000 000.

So given an array = [ -1, 1, 3, 3, 3, 2, 3, 2, 1, 0] the function should return 5 because there are five periods where the movement is stable: 0-2, 2-4, 6-9, 6-8, 7-9. Note that 6-8 and 7-9 are contained within 6-9.

Given an array [2, 2, ... 2, 2] of length 10 000 the function should return 49985001.

Write an efficient function with the following assumptions:

The length of the array is between 0 and 60 000.
Each element in the array is within the range -2 000 000 000 to 2 000 000 000.