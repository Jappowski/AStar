using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour {
    const int MAP_SIZE = 6;

    List<string> map = new();
    Node[,] nodeMap;

    void Start() {
        map.Add("G-X---");
        map.Add("--X-X-");
        map.Add("-XX-X-");
        map.Add("------");
        map.Add("XXXXX-");
        map.Add("S-----");

        nodeMap = new Node[MAP_SIZE, MAP_SIZE];
        Node start = null;
        Node goal = null;

        for (var y = 0; y < map.Count; y++) {
            for (var x = 0; x < map.Count; x++) {
                var node = new Node(x, y);
                var currentChar = map[y][x];
                if (currentChar == 'X') {
                    node.nodeState = Node.NodeState.blocked;
                } else if (currentChar == 'G') {
                    goal = node;
                } else if (currentChar == 'S') {
                    start = node;
                }
                nodeMap[x, y] = node;
            }
        }
    }
}

public class Node {
    public int posX;
    public int posY;
    public int basicCost;
    public int estimatedCost;
    public Node parent;
    public NodeState nodeState;

    public Node(int posX, int posY) {
        this.posX = posX;
        this.posY = posY;
        nodeState = NodeState.free;
    }
    
    public enum NodeState {
        free,
        blocked,
    }
}
