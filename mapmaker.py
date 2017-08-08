# Outputs a map file in the folder where the script
# is run. File format:
# x|y|terrain type|passable terrain boolean|item

from random import random

width = 200
height = 200

def clean():
    global terrain
    
    hasCleaned = False
    for x in range(width):
        for y in range(height):
            if terrain[x][y] == "water" and getAdjacent(x, y, "water") <= 1:
                terrain[x][y] = "grass"
                hasCleaned = True
            elif terrain[x][y] == "grass" and getAdjacent(x, y, "grass") + getAdjacent(x, y, "sand") <= 1:
                terrain[x][y] = "water"
                hasCleaned = True
            elif terrain[x][y] == "sand" and getAdjacent(x, y, "sand") == 0:
                terrain[x][y] = "grass"
                hasCleaned = True
                
    return hasCleaned

def getAdjacent(x, y, terrainType):
    global terrain
    
    total = 0
    offs = [[-1, 0], [0, -1], [0, 1], [1, 0]]
    for o in offs:
        if x + o[0] < 0 or x + o[0] >= width or y + o[1] < 0 or y + o[1] >= height:
            continue
        if terrain[x + o[0]][y + o[1]] == terrainType:
            total += 1
    
    return total
    
terrain = []
for x in range(width):
    terrain.append([])
    for y in range(height):
        terrain[x].append(None)

for x in range(width):
    for y in range(height):
        if random() < min(0.2 + getAdjacent(x, y, "grass")*0.35, 0.95):
            terrain[x][y] = "grass"
        else:
            terrain[x][y] = "water"
            

runs = 0
while (clean() and runs < 10000):
    runs += 1

for x in range(width):
    for y in range(height):
        if terrain[x][y] == "grass" and getAdjacent(x, y, "water") > 0 and getAdjacent(x, y, "grass") > 0 and random() < 0.3 + getAdjacent(x, y, "sand"):
            terrain[x][y] = "sand"
            
runs = 0
while (clean() and runs < 10000):
    runs += 1

f = open("maptest.txt", 'w')
for x in range(width):
    for y in range(height):
        f.write(str(x) + "|" + str(y) + "|" + str(terrain[x][y]) + "\n")
        