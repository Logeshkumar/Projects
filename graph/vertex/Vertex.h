/////////////////////////////////////////////////////////////////////
//  vertex.h - helps the graph class for constructing graph        //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   Dependency Graph Facility                       //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

/*
Module Operation:
=================
This module is basically used for displaying the ouput to the console 
window. The display function are called by the executive package in 
order to execute the display functions. This is basically done to separate
execution logic from the displaying.
Public Interface:
=================
void storeVertex(Vertex<V,E> &)     ==> used to store the vertex inputted in the vertex class
void AddChild(Vertex<V,E> &,E)      ==> Adds the chils vertices to the corresponding vertex
std::vector<std::pair<Vertex<V,E>*,int>> GetVector()  ==> returns a vector
std::vector<std::pair<int,E>> GetObjectVector()       ==>returns a vector of objects
std::vector<std::pair<int,E>> GetGlobalVector();      ==> returns a vector of objects for global algorithm
int Getid() ==>returns Id for a particular object
V GetUserId(); ==> returns user id for a particualr object
static std::vector<Vertex<V,E>> getstoredVector() ==> returns the stored vector in the vertex clas
Vertex<V,E>& getObject(int) ===> returns particular object for Vertex id inputted
int Getnum(); ==> Getnum is used for getting num value for an vertex object
int Getlowlink(); ==> getlowlink is used for getting lowlink for an vertex object

Build Process:
=============
this is an independent module but very necessary for the graph

Maintainence History:
=====================
ver 1.0 24 March 2011
- first release
*/


#ifndef VERTEX_H
#define VERTEX_H
#include<vector>
#include<string>
#include <iostream>
#include<algorithm>

class Getid
{
private:
	static int in;
public:
	static int  GetVal();
};

template<class V,class E>
class Vertex
{
	Getid identity;
	V userid;
	int Vertexid;	
	static std::vector<Vertex<V,E>> vect;
    std::vector<std::pair<int,E>> myVector;
	static std::vector<std::pair<int,E>> GlobalVector;
	

public:
	int num;
    int lowlink;
	Vertex(V _userid){userid =_userid;Vertexid =identity.GetVal(); };
	void storeVertex(Vertex<V,E> &);
	void AddChild(Vertex<V,E> &,E);
	std::vector<std::pair<int,E>> GetObjectVector();
	std::vector<std::pair<int,E>> GetGlobalVector();
	int Getid();
	V GetUserId();
	static std::vector<Vertex<V,E>> getstoredVector();
	Vertex<V,E>& getObject(int);
	};


// adding child vertex and edge to the Parent vertex object

template<class V,class E>
void Vertex<V,E>::AddChild(Vertex<V,E> &object, E Edge)
{
	std::pair<int,E> myPair;
	myPair.first = object.Getid();
	myPair.second = Edge;
	myVector.push_back(myPair);
	GlobalVector.push_back(myPair);
	
}


template<class V,class E>
std::vector<Vertex<V,E>> Vertex<V,E>::vect;

template<class V,class E>
std::vector<std::pair<int,E>> Vertex<V,E>::GlobalVector;


// returns the vertexid for an object(vertex)
template<class V,class E>
int Vertex<V,E>::Getid()
{
	return this->Vertexid;
}



//returns te use id for particular object vertex
template<class V,class E>
V Vertex<V,E>::GetUserId()
{
	return this->userid;
}

// storing vertex object in a vector
template<class V,class E>
void Vertex<V,E>::storeVertex(Vertex<V,E> &Var)
{   
	
	vect.push_back(Var);
}


// returns object vector
template<class V,class E>
std::vector<std::pair<int,E>> Vertex<V,E>::GetObjectVector()
{
	return myVector;
}

// returns object vector for global algorithm determination
template<class V,class E>
std::vector<std::pair<int,E>> Vertex<V,E>::GetGlobalVector()
{
	return this->GlobalVector;
}

// returns the stroed vector of vertex objects
template<class V,class E>
std::vector<Vertex<V,E>> Vertex<V,E>::getstoredVector()
{
	return vect;
}

# endif