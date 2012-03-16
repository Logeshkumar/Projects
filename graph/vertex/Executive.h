/////////////////////////////////////////////////////////////////////
//  Executive.h - helps in excuting the various operations         //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   Dependency Graph Facility                       //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

/*
Module Operation:
=================
The Executive package is the main package in which the basic functionalities implemented
in the projects are called. This is the package which calls the implemented functions of 
various other packages

Public Interface:
=================
GetXmlFiles(std::string,std::string)==> This is function which is used to get the
files in the path inputted through the command line argument

CreateVertices(std::vector<stdStr>)==> this function creates the vertices for the graph i.e
the files in the inputted are represented as nodes in the graph.

AddChildVertices(std::vector<Vertex<std::string,std::string>>) ==> THis function is used 
add the child dependencies for a particular vertex.
Build Process:
=============
This is the main executive package from which every action is performed.
This file depends on Vertex.h,Vertex.cpp,graph.h,graph.cpp,global.h,global.cpp
Container.h,Container.cpp,StringConversion.h,StringConversion.cpp,Wintools.h,Wintools.cpp
Traverse.h,Traverse.cpp,Display.h,Display.cpp

Maintainence History:
=====================
ver 1.0 24 March 2011
- first release
*/

#ifndef EXECUTIVE_H
#define EXECUTIVE_H
#include "Vertex.h"
#include "graph.h"
#include "Global.h"
#include "Container.h"
#include "StringConversion.h"
#include "WinTools.h"
#include "Traverse.h"
#include "Display.h"

class Exec
{
private:
	
public:
	void GetXmlFiles(std::string,std::string);
	void CreateVertices(std::vector<stdStr>);
	static void AddChildVertices(std::vector<Vertex<std::string,std::string>>);
};
# endif