using UnityEngine;
using System.Collections;

public class PermutateBinaryTree : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int i = 1; i < 17; i++) {
			int possibilities = permutateBinaryTrees(i);
			Debug.Log("PermutateBinaryTree(" + i + ") = " + possibilities);
		}
	}
	/**
	** Used to permutate every possible balanced binary tree with n nodes.
	** A balanced binary tree in this algorithm is that for each parent node, the difference between the max depth of its left sub-tree and right sub-tree is 1 or 0.
	** The permutation works by x+y = n-1 (n-1 because -1 to represent parent node) for every height k, and we permutate every possible value of x and y, if there
	** is a possible balanced binary tree for x and y combinations that both reach height k, we add this permutation to the total permutations.
	** If there is a possible permutation of x node and y node for height k, we increase the height k by 1  to find further permutations, if there
	** is no permutations for height k, we assume there is no permutation for height k+1 so we stop increasing the height.
	** Next, there is a allowed difference of depth between left sub-tree and right sub-tree of 1. These differences increase the further the depth
	** of the tree goes, hence at each parent node, we permutate if there is a possible balanced binary tree by putting a height difference between 
	** the left sub-tree and right sub-tree by 1.
	** @params n = how many nodes.
	*/
	int permutateBinaryTrees(int n) {
		if (n == 0 || n == 1 || n == 3)
			return 1;
		else if (n == 2)
			return 2;
		int height = 3; // n < 4 represents all trees of height 2, quick check to reduce computation time
		if (n > 7) { // There are no trees of height 3 if n > 7 (Physically impossible to fit the 8th element).
			int nCalculator = 1;
			int newHeight = 1;
			while (nCalculator < n) {
				nCalculator = nCalculator*2 + 1;
				newHeight++;
			}
			height = newHeight;
		}
		// Used to exhaustively search for all permutations of binary trees with N nodes. We assume if there is no permutations
		// of a tree with n nodes and k height, there is no permutation of a tree with N nodes and k+1 height.
		bool canIncrHeight = true;
		int total = 0; // Total permutations of balanced binary trees.
		// The height rule is given only at root of tree, allowed depth differences occur at each parent node
		while (canIncrHeight) {
			int totalAdd = 0; // Total balanced binary trees to add
			int start = 1; // Assign one node to left subtree
			int finish = n-2; // Assign rest of nodes to right subtree and subtract one node that represents parent of sub-trees
			while (start <= finish) {
				int left = permutateBinaryTrees(start, height-1);
				int right = permutateBinaryTrees(finish, height-1);
				// We must swap nodes between left sides and right sides to get all possible permutations, since
				// start does not reach n-1 and finish does not reach 1 (Quicker computation).
				// E.g 2 nodes left, 3 nodes right = 3 nodes left, 2 nodes right = *2 results.
				// But 2 nodes left, 2 nodes right does not need to be multiplied twice.
				// If there is no result for 2 nodes left, but for 3 nodes right, 0 * ? = 0 anyways.
				if (start != finish) 
					totalAdd += (left*right)*2;
				else {
					totalAdd += left*right;
				}
				//Debug.Log("Result = " + totalAdd + ". Left nodes = " + start + "=" + left + " right nodes = " + finish + "=" + right);
				left = permutateBinaryTrees(start, height-1);
				right = permutateBinaryTrees(finish, height-2); // At each parent node, the height difference can be increased further
				if (start != finish) 
					totalAdd += left*right*2;
				else {
					totalAdd += left*right;
				}
				//Debug.Log("Result = " + totalAdd + ". Left nodes = " + start + "=" + left + " right nodes = " + finish + "=" + right);
				left = permutateBinaryTrees(start, height-2); // At each parent node, the height difference can be increased further
				right = permutateBinaryTrees(finish, height-1); 
				if (start != finish) {
					totalAdd += left*right*2;
				}
				else {
					totalAdd += left*right;
				}
				//Debug.Log("Result = " + totalAdd + ". Left nodes = " + start + "=" + left + " right nodes = " + finish + "=" + right);
				start++;
				finish--;
			}
			total += totalAdd;
			if (totalAdd == 0) // Found no permutations of this height
				canIncrHeight = false;
			height++;
		}
		return total;
	}
	// Lots of stack frames holding data for these recursive calls, should implement a lookup table for (node & height) -> permutations for future performance
	int permutateBinaryTrees(int n, int height) {
		if (n < 4) {
			if (n == 0 && height == 0)
				return 1;
			else if (n == 1 && height == 1)
				return 1;	
			else if (n == 2 && height == 2) 
				return 2;
			else if (n == 3 && height == 2)
				return 1;
			else
				return 0; 	// Cannot make tree of height > 3 with < 3 nodes without breaking rules 
		}	
		int start = 1;
		int finish = n-2;
		int total = 0;
		while (start <= finish) {
			int left = permutateBinaryTrees(start, height-1);
			int right = permutateBinaryTrees(finish, height-1);
			if (start != finish) 
				total += (left*right)*2;
			else {
				total += (left*right);
			}
			// At each subtree, the height difference can be increased further
			left = permutateBinaryTrees(start, height-1);
			right = permutateBinaryTrees(finish, height-2); 
			if (start != finish) 
				total += (left*right)*2;
			else {
				total += (left*right);
			}
			// At each subtree, the height difference can be increased further
			left = permutateBinaryTrees(start, height-2);
			right = permutateBinaryTrees(finish, height-1);
			if (start != finish) 
				total += (left*right)*2;
			else {
				total += (left*right);
			}
			start++;
			finish--;
		}
		return total;
	}
}
