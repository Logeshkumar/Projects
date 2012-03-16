#ifndef TRAVERSEINFO_H
#define TRAVERSEINFO_H
/////////////////////////////////////////////////////////////////////
//  Traverse.h - Helps to traverse XML and determine dependencies  //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   XML Metadata Manager			                   //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

/*Module Operation:
 The depenfunc is a recursive function which initially determines the direct dependencies from the xml file inputted
 and later recursive call is made to the same function and the indirect dependencies are also determined.
 The functionremove function removes the packagename or the inputted file name from the dependency list. Since there can be no cyclic dependency
 The c.GetHfile() gets the package name which is inputted or 
 the file to which direct and indirect dependencies are determined
 The main function gets the input from the command line
  1. The path to be inputted
  2. The package anme for which direct and indirect dependencies are to be determined.

  Public Interface:
  =================

  void depenfunc(somefile); -> The depenfunc is a recursive function which initially determines the direct dependencies from the xml file inputted
                               and later recursive call is made to the same function and the indirect dependencies are also determined.
  void functionremove();    -> The functionremove function removes the packagename or the inputted file name from the dependency list. 
                                Since there can be no cyclic dependency
  void  functionEdge(stdStr); -> to determine the direct and indirect dependencies

  Build Process:
  =============
  Required files:
  Wintools.h, StringConversion.h,Parser.h,Container.h
  Wintools.cpp, StringConversion.cpp,Parser.cpp,Container.cpp

   Maintainence History:
  =====================
  ver 1.0 27 March 2011
- first release
*/

#include "Wintools.h"
#include "StringConversion.h"
#include "Parser.h"
#include "Container.h"
using namespace Win32Tools;

class Traverse
{
private:
	std::vector<stdStr> headervec;
public:
    void depenfunc(stdStr);
	void functionremove();
	void  functionEdge(stdStr);
	
};

# endif