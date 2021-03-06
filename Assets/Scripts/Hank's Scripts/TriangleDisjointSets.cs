﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class TriangleDisjointSets
{
    int[] rank, parent;
    int n;
    public int[] meshIndex;
    
    // Constructor 
    public TriangleDisjointSets(int n)
    {
        rank = new int[n];
        parent = new int[n];
        meshIndex = new int[n];
        this.n = n;
        makeSet();           
    }

    // Creates n sets with single item in each 
    public void makeSet()
    {
        for (int i = 0; i < n; i++)
        {
            // Initially, all elements are in 
            // their own set. 
            parent[i] = i;
        }
    }

    public void saveIndex(int i, int x)
    {
        meshIndex[i] = x;
    }

    public int getMeshIndex(int i)
    {
        return meshIndex[i];
    }

    // Returns representative of x's set 
    public int find(int x)
    {
        // Finds the representative of the set 
        // that x is an element of 
        if (parent[x] != x)
        {

            // if x is not the parent of itself 
            // Then x is not the representative of 
            // his set, 
            parent[x] = find(parent[x]);

            // so we recursively call Find on its parent 
            // and move i's node directly under the 
            // representative of this set 
        }
        return parent[x];
    }

    // Unites the set that includes x and 
    // the set that includes x 
    public void union(int x, int y)
    {
        // Find representatives of two sets 
        int xRoot = find(x), yRoot = find(y);

        // Elements are in the same set,  
        // no need to unite anything. 
        if (xRoot == yRoot)
            return;

        // If x's rank is less than y's rank 
        if (rank[xRoot] < rank[yRoot])

            // Then move x under y so that depth 
            // of tree remains less 
            parent[xRoot] = yRoot;

        // Else if y's rank is less than x's rank 
        else if (rank[yRoot] < rank[xRoot])

            // Then move y under x so that depth of 
            // tree remains less 
            parent[yRoot] = xRoot;

        else // if ranks are the same 
        {
            // Then move y under x (doesn't matter 
            // which one goes where) 
            parent[yRoot] = xRoot;

            // And increment the result tree's 
            // rank by 1 
            rank[xRoot] = rank[xRoot] + 1;
        }
    }

    public int totalSets()
    {
        return parent.Distinct().ToArray().Length;
    }

    public void printSets()
    {
        foreach(var p in parent)
        {
            Debug.Log(p);
        }
    }

    public int[] getDisjointSets()
    {
        return parent;
    }
    
}
