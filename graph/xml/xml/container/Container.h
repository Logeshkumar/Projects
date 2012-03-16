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
Similarly the setters and getters functions for a vector and map data structures is declared and defined

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
#include<map>
#include <iostream>
using namespace std;
class container
{
private:
	 static string key;
	 static std::vector<std::string> ContainerVec;
	 static std::vector<std::string> DirVec;
	 static map<std::string, std::vector<std::string>> ContainerMap;
	 static string hfilename;
	 static string cppfilename;
	 static string Dir;
public:
	void SetDir(std::string);
	std::string GetDir();
	void Sethfile(std::string);
	std::string GetHfile();
	void Setcppfile(std::string);
	std::string Getcppfile();
	void SetKey(std::string);
	std::string GetKey();
	void SetVector(std::vector<std::string>);
	std::vector<std::string> GetVector();
	void SetdirVector(std::vector<std::string>);
	std::vector<std::string> GetdirVector();
	void SetMap (map<std::string, std::vector<std::string>>);
	map<std::string, std::vector<std::string>> GetMap();
	};
# endif