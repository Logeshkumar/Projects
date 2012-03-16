/////////////////////////////////////////////////////////////////////
//  Container.h - Helps in storing data                            //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   XML Metadata Manager			                   //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

/*
Module Operation:
=================
This Module is basically a container class which helps in storing data.
This is an independent module which can be edited and compiled separately.
This helps in code reuse and data integrity.
Public Interface:
=================
container c;     -> creates an instance of container class
Sethfile(string) -> sets the value inputted to a string variable
GetHfile()       -> gets the value stored in it
Similarly SetKey and GetKey does the same operation as Sethfile and GetHfile functions
Similarly the setters and getters function for a vector data structure is declared and defined

Build Process:
=============
This is an independent module. Only library functions are required
Maintainence History:
=====================
ver 1.0 24 March 2011
- first release
*/

#ifndef CONTAINERINFO_H
#define CONTAINERINFO_H
#include<string>
#include<vector>
#include <iostream>
using namespace std;

class Container
{
private:
	 static string key;
	 static std::vector<std::string> ContainerVec;
	 static std::vector<std::string> RemoverVec;
	 static string hfilename;
	
public:
	void Sethfile(std::string);
	std::string GetHfile();
	void SetKey(std::string);
	std::string GetKey();
	void SetVector(std::vector<std::string>);
	std::vector<std::string> GetVector();
	void SetRVector(std::vector<std::string>);
	std::vector<std::string> GetRVector();
};
# endif